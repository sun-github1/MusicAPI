﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Core.Models.Auth
{
    public class Role:IdentityRole<Guid>
    {
    }
}
