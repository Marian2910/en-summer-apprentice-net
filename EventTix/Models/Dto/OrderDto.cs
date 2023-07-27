namespace EventTix.Models.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public string CustomerName{ get; set; } = string.Empty;

        public string EventName { get; set; } = string.Empty;

        public string TicketCategory { get; set; } = string.Empty;

        public DateTime OrderedAt { get; set; }

        public int NumberOfTickets { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
