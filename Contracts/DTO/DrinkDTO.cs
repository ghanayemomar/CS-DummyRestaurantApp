namespace Contracts.DTO
{
    public class DrinkDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class DrinkWithTotalPriceDTO
    {
        public decimal TotalPrice { get; set; }
        public List<DrinkDTO> Drinks { get; set; }
    }

}

