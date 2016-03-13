using CacheCow.Server;
using FHL.Data.DB.NHL;
using System.Data.Entity;
using System.Web;
using System.Web.Http;

namespace FHL.API.Data
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.MessageHandlers.Add(new CachingHandler(GlobalConfiguration.Configuration));
        }
    }
}
