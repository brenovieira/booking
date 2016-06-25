using System;
using System.IO;
using System.Web.Http;
using Swashbuckle.Application;

namespace Booking.API
{
    public class DocsConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger("docs/{apiVersion}", c =>
            {
                c.DescribeAllEnumsAsStrings();
                c.IncludeXmlComments(GetXmlCommentsPath());
                c.RootUrl(req => req.RequestUri.GetLeftPart(UriPartial.Authority) +
                    config.VirtualPathRoot.TrimEnd('/'));

                c.SingleApiVersion("v1", "Booking API")
                    .Description("Booking API description");
            });
        }

        private static string GetXmlCommentsPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "Booking.API.XML");
        }
    }
}