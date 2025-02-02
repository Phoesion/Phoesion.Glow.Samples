using Microsoft.Extensions.Options;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using Foompany.Services.HelloWorld.Options;

namespace Foompany.Services.HelloWorld.Modules
{
    public class ViewConfigs : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        [Autowire]
        public new ServiceMain Service;

        //Get using Dependency Inject and the IOptions<> mechanism
        [Autowire(Required = true)]
        IOptions<ContactInfoOptions> ContactInfoOptions { get; set; }

        // Auto-bind configuration in module.
        [Configuration]
        string ValueFromAppSettings;

        // Auto-bind simple string configuration in module. (using a specific section name)
        [Configuration("Other:AdminInfo:Name")]
        string AdministratorName;

        // Auto-bind configuration in module.
        [Configuration]
        ContactInfoOptions ContactInfo { get; set; }

        // Auto-bind configuration in module. (using a specific section name)
        [Configuration("Other:AdminInfo")]
        ContactInfoOptions ContactInfoInSubKey { get; set; }


        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => $"{nameof(ViewConfigs)} module up and running";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string FromIConfiguration()
        {
            return $"ValueFromAppSettings = {Configuration["ValueFromAppSettings"]} \r\n\r\n" +
                   $"Configs_MyKey2 = {Configuration["MyKey2"]} \r\n\r\n" +
                   $"ContactInfo.Name = {Configuration["ContactInfo:Name"]} \r\n\r\n" +
                   $"ContactInfo.Email = {Configuration["ContactInfo:Email"]} \r\n\r\n" +
                   $"Other:AdminInfo.Name = {Configuration["Other:AdminInfo:Name"]} \r\n\r\n" +
                   $"Other:AdminInfo.Email = {Configuration["Other:AdminInfo:Email"]} \r\n\r\n";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string FromIOptions()
        {
            return $"ContactInfo from IOptions = {ToJson(ContactInfoOptions)} \r\n\r\n";
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string FromAutoBind()
        {
            return $"ValueFromAppSettings = {ValueFromAppSettings} \r\n\r\n" +
                   $"ContactInfo auto-bind = {ToJson(ContactInfo)} \r\n\r\n" +
                   $"Other:AdminInfo auto-bind = {ToJson(ContactInfoInSubKey)} \r\n\r\n" +
                   $"AdministratorName  = {AdministratorName} \r\n\r\n";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string FromService()
        {
            return $"SampleData1 = {Service.SampleData1} \r\n\r\n" +
                   $"DataWithDefaultValue = {Service.DataWithDefaultValue} \r\n\r\n" +
                   $"SampleNumberConfig = {Service.SampleNumberConfig} \r\n\r\n" +
                   $"Configs_ContactInfo = {ToJson(Service.Configs_ContactInfo)} \r\n\r\n" +
                   $"ValueFromAppSettings = {Service.ValueFromAppSettings} \r\n\r\n" +
                   $"Configs_MyKey2 = {Service.Configs_MyKey2} \r\n\r\n";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
