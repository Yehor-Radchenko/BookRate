﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRate.DAL.DTO.Serie
{
    public abstract class BaseSerieDTO
    {
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
