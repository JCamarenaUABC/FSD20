using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoctorProject.Startup))]
namespace DoctorProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
