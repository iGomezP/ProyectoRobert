using ChimalliStore.Api.Context;

namespace ChimalliStore.Api.DTO
{
    public class UserMapper
    {
        public static UserDTO UserResponseDTO(User user)
        {
            return new UserDTO { Password = user.Password, Email = user.Email };
        }

        public static User MapToDTO(UserDTO userDTO)
        {
            return new User { Email = userDTO.Email , Password = userDTO.Password};
        }
    }
}
