﻿using System;
using System.Collections.Generic;

namespace THDotNetCore.ConsoleAppEFCore.Databases.Models;

public partial class TblPizzaOrder
{
    public int PizzaOrderId { get; set; }

    public string PizzaOrderInvoiceNo { get; set; } = null!;

    public int PizzaId { get; set; }

    public decimal TotalAmount { get; set; }
}
