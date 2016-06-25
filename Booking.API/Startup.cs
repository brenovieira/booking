using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

[assembly: OwinStartup(typeof(Booking.API.Startup))]
namespace Booking.API
{
    public partial class Startup
    {
        public static readonly TimeSpan AccessTokenExpireTimeSpan = TimeSpan.FromHours(24);
        public const string TokenEndpointPath = "/api/account/token";

        public void Configuration(IAppBuilder app)
        {
            ConfigureStaticFiles(app);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var httpConfig = new HttpConfiguration();

            IoCConfig.Register(httpConfig);
            WebApiConfig.Register(httpConfig);
            MapperConfig.Register();
            DocsConfig.Register(httpConfig);
        }

        //see more: http://aspnet.codeplex.com/SourceControl/latest#Samples/Katana/StaticFilesSample/Startup.cs
        private static void ConfigureStaticFiles(IAppBuilder app)
        {
            // Remap '/' to '.\app\dist'.
            app.UseFileServer(new FileServerOptions
            {
                EnableDefaultFiles = true,
                EnableDirectoryBrowsing = false,
                FileSystem = new PhysicalFileSystem(@".\app\dist"),
                RequestPath = PathString.Empty
            });

            // Only serve files requested by name.
            app.UseStaticFiles("/app");
        }
    }
}