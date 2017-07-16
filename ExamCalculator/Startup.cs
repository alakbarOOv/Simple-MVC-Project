using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamCalculator.Startup))]
namespace ExamCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
