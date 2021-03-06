﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moot.Model
{
    interface IItem
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string ImageSource { get; set; }
    }
}
