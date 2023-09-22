using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChimalliStore.Api.Context;
using Microsoft.CodeAnalysis.Scripting;
using ChimalliStore.Api.DTO;
using AutoMapper;

namespace ChimalliStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ChimallidbContext _context;

        public UsersController(ChimallidbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        /*
         Mis metodos*/

        [HttpPut("update-alias/{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UserAliasUpdateModel aliasUpdateModel)
        {//int peopleId1,int addressId1,

            //Para Usuario
            // Obtén el usuario existente desde la base de datos
            var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                // Aplica la actualización solo al campo "Alias"
                user.Alias = aliasUpdateModel.Alias;
                user.Email = aliasUpdateModel.Email;
            //await _context.SaveChangesAsync();
            int peopleId = user.PersonId;
            int addressId = user.UserId;
                //Para Person
                var persona = await _context.People.FindAsync(peopleId);
                if (persona == null)
                {
                    return NotFound();
                }
                // Aplica la actualización solo al campo "Alias"
                persona.Name = aliasUpdateModel.Name;
                persona.LastName = aliasUpdateModel.LastName;
                persona.MaternalLastName = aliasUpdateModel.MaternalLastName;   
                persona.Birthdate = aliasUpdateModel.Birthdate;
                persona.Genre = aliasUpdateModel.Genre;

            //await _context.SaveChangesAsync();

            //Para Addresses 
            var direccion = await _context.Addresses.SingleOrDefaultAsync(p => p.UserId == addressId);
            //var direccion = await _context.Addresses.FindAsync(addressId);
            if (direccion == null)
                {
                    return NotFound();
                }
                direccion.Street = aliasUpdateModel.Street;
                direccion.Suburb = aliasUpdateModel.Suburb;
                direccion.City = aliasUpdateModel.City;
                direccion.State = aliasUpdateModel.State;
                direccion.Cp = aliasUpdateModel.Cp;
                direccion.Country = aliasUpdateModel.Country;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        //POST: api/Users
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost("login")]
        public async Task<ActionResult<User>> PostLoginUser(UserDTO user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ChimallidbContext.Users'  is null.");
            }
            //_context.Users.Add(user);
            //await _context.SaveChangesAsync();
            var userDB = await _context.Users
            .FirstOrDefaultAsync(_ => _.Email == user.Email
               && _.ObjectStatusId == 1)
            .ConfigureAwait(false);
            //_context.Users.ToListAsync()
            var userAddress = await _context.Addresses
                .Where(a => a.UserId == userDB.UserId)
                .ToListAsync()
                .ConfigureAwait(false);

            var userPerson = await _context.People
                .FirstOrDefaultAsync(a => a.PersonId == userDB.PersonId)
                .ConfigureAwait(false);

            if (userDB == null)
                return BadRequest("Email o pass es incorrecto");    
            
            if (VerifyPassword(user.Password, userDB.Password))
            {
                var variable = ToDto<User, UserResponses>(userDB);
                variable.Addresses = userAddress;
                variable.Person = userPerson;

                return Ok(variable);
            }
            else
            {
                return Unauthorized("Email o pass es incorrecto");
            }

        }

        // GET: api/Users/5
        [HttpGet("datosOriginales/{id}")]
        public async Task<ActionResult<User>> GetnuevoDatosOriginales(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var userDB = await _context.Users
            .FirstOrDefaultAsync(_ => _.UserId == id
               && _.ObjectStatusId == 1)
            .ConfigureAwait(false);
            //_context.Users.ToListAsync()
            var userAddress = await _context.Addresses
                .Where(a => a.UserId == userDB.UserId)
                .ToListAsync()
                .ConfigureAwait(false);

            var userPerson = await _context.People
                .FirstOrDefaultAsync(a => a.PersonId == userDB.PersonId)
                .ConfigureAwait(false);
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        public static TDestination ToDto<TSource, TDestination>(TSource entity)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>()));
            var entityDto = mapper.Map<TDestination>(entity);





            return entityDto;
        }
        private bool VerifyPassword(string password, string hashPassword)
        {
            bool simonAlPassword = BCrypt.Net.BCrypt.Verify(password, hashPassword);
            return simonAlPassword;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ChimallidbContext.Users'  is null.");
            }
            var newPassword = HashPassword(user.Password);
            user.Password = newPassword;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();//CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
        private string HashPassword(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }
    }
}
