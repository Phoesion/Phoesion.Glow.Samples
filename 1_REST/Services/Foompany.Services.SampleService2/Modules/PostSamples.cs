using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using models = Foompany.Services.API.SampleService2.Modules.PostSamples.Models;

namespace Foompany.Services.SampleService2.Modules
{
    [API<API.SampleService2.Modules.PostSamples.Actions>]
    public class PostSamples : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.POST)]
        public string Action1()
        {
            return "Called Action1 using POST in PostSamples module";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary> Sample action that exposes both GET and POST methods </summary>
        [ActionBody(Methods.GET | Methods.POST)]
        public string Action2()
        {
            return $"Called Action2 using {Request.Method} in PostSamples module.";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /* Example of a data model request/response action.
         * 
         * The Phoesion Glow system will automatically handle the deserialization of the request and the serialization of the response
         * based on the context of the request.
         * 
         * For example in a REST Request :
         * - For the deserialization of the body, the 'Content-Type' will be examined to determine the deserialization method.
         *      If the Content-Type is 'application/json' the body will deserialized using a json deserializer.
         *      An other Content-Type can be 'application/xml' and in this case a Xml deserializer will be used.
         *      
         * - For the serialization of the response, the 'Accept' header will be examined the serialization method based on the client expectations.
         *      If the Accept type is 'application/json' the response will serialized using a json deserializer.
         *      An other Accept type can be 'application/xml' and in this case a Xml serializer will be used.
         *      ( 'application/msgpack' is also handled automatically )
         */
        [ActionBody(Methods.POST)]
        public models.MyDataModel.Response DoTheThing(models.MyDataModel.Request Model)
        {
            return new models.MyDataModel.Response()
            {
                IsSuccess = true,
                Message = $"Hello {Model.InputName}",
            };
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------

        /// <summary> Sample action that reads body as string </summary>
        [ActionBody(Methods.POST)]
        public string Action3([FromBody] string body)
        {
            return $"Called Action3 using body : " + Environment.NewLine + body;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
