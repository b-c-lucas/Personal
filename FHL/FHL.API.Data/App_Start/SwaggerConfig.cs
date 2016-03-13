using System.Web.Http;
using WebActivatorEx;
using FHL.API.Data;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace FHL.API.Data
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c => c.SingleApiVersion("v1", "FHLLLLLLLLL"))
                .EnableSwaggerUi();
        }
    }
}
