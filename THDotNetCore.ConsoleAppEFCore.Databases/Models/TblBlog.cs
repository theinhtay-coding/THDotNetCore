﻿using System;
using System.Collections.Generic;

namespace THDotNetCore.ConsoleAppEFCore.Databases.Models;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public string? BlogTitle { get; set; }

    public string? BlogAuthor { get; set; }

    public string? BlogContent { get; set; }
}
