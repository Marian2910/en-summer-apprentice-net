using System;
namespace EventTix.Models.Dto
{
	public class OrderPatchDto
	{
        public int OrderId { get; set; }

        public string TicketCategory { get; set; } = string.Empty;

        public int NumberOfTickets { get; set; }
    }
}

