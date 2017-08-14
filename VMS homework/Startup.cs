using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VMS_homework.Startup))]
namespace VMS_homework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
