using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;


namespace Foompany.Services.SampleService1
{
    [ServiceName("SampleService1")]
    public class ServiceMain : FireflyService
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            //add a sample service
            services.AddSingleton<IMultiplyNumbersService, SampleService1.Services.MultiplyNumbersImplementation>();
        }

        protected override void Configure(IGlowApplicationBuilder app)
        {
            //TODO: Configure middleware..
        }
    }
}
