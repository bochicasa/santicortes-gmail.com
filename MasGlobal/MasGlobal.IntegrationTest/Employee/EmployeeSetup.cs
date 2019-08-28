using MasGlobal.API;
using Microsoft.Extensions.Configuration;

namespace MasGlobal.IntegrationTest.Employee
{
    public class ReservaSetup : Startup
    {
        public ReservaSetup(IConfiguration env) : base(env)
        {
        }
    }
}
