﻿using System;
using System.Collections.Generic;

namespace THDotNetCore.RealtimeChartApp.Models;

public partial class TblPizzaExtra
{
    public int PizzaExtraId { get; set; }

    public string PizzaExtraName { get; set; } = null!;

    public decimal Price { get; set; }
}
