﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.Default.Modules
{
    public class DefaultModule : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        [Action(Methods.GET)]
        public string Default()
        {
            return "Blazor sample service up and running!";
        }
    }
}
