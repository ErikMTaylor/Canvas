﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Canvas.Utilities
{
    public class QueryMessage
    {
        private string? query;
        public string Query { get => query ?? string.Empty;
            set
            {
                query = value;
            }
        } 
    }
}
