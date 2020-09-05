using System.Web;
using System.Web.Http;
using EmailComponent.Utils;

namespace EmailComponent
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var dbUpgrade = new DbUpgrade();
            dbUpgrade.Upgrade();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}