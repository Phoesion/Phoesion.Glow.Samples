﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Phoesion.Glow.SDK.Firefly;
using Foompany.Middleware.Profiler;

namespace Foompany.Services.SampleService1
{
    public class ServiceMain : Phoesion.Glow.SDK.Firefly.FireflyService
    {
        public override async Task Configure(IGlowApplicationBuilder app)
        {
            await base.Configure(app);

            //enable the middleware profiler
            app.UseProfiler();
        }
    }
}
