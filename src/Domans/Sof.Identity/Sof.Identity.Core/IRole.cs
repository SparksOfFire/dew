﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Identity.Core
{
    public interface IRole
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
