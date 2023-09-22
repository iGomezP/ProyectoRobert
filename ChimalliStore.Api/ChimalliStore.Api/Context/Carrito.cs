namespace ChimalliStore.Api.Context
{
    /*
  Aqui es cuando se guarda el articulo
    -productXuserId
    -productId
    -userId
    -quantity
    -subtotal
  
  Aqui se relaciona Carrito y usuario
    productXuserXshoppingCarts
    shoppingCartId
    productXuserId
    objectStatus
  
  Aqui se genera un carrito
    ShoppingCartId
    shoppingCart_GUID
    creationDate
    total
    objectStatus

  Aqui se relaciona Carrito y usuario
    shoppingCartXuser
    userId
    objectStatus
     */
    public class Carrito
    {
        //ProductXuserId
        public int ProductXuserId { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public int Quantity { get; set; }

        public decimal Subtotal { get; set; }
        
        //productXuserXshoppingCarts
        public int ProductXuserXshoppingCartId { get; set; }

        public int ShoppingCartId { get; set; }

    }
}
