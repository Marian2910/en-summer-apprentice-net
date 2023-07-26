namespace EventTix.Models.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string CustomerName{ get; set; } = string.Empty;
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string TicketCategory { get; set; } = string.Empty;
        public DateTime OrderedAt { get; set; }
        public int numberOfTickets { get; set; }
        public decimal totalPrice { get; set; }
    }
}
