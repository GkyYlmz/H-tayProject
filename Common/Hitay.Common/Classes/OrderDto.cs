namespace Hitay.Common.Classes
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
        public string CustomerName { get; set; }
        public int CoffeeTypeId { get; set; }
        public string CoffeeType { get; set; }
        public string Cream { get; set; }
        public string Milk { get; set; }
        public string SugarType { get; set; }
        public int SugarTypeId { get; set; }
    }
}
