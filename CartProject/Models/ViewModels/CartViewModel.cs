namespace CartProject.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal GranTotal { get; set; }
    }
}
