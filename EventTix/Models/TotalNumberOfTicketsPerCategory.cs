using System;
using System.Collections.Generic;

namespace EventTix.Models;

public partial class TotalNumberOfTicketsPerCategory
{
    public int TicketCategoryId { get; set; }

    public int TotalTicketsSold { get; set; } 

    public decimal TotalSales { get; set; }
}
