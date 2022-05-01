namespace PaymentService.API.Models
{
    public class PaymentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CardNumber { get; set; }
        public double Fee { get; set; }
        public int PaymentObjectId { get; set; }
    }
}
