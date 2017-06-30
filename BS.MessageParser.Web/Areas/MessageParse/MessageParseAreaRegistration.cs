using System.Web.Mvc;

namespace BS.Microservice.Web.Areas.MessageParse
{
    public class MessageParseAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MessageParse";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MessageParse_default",
                "MessageParse/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
