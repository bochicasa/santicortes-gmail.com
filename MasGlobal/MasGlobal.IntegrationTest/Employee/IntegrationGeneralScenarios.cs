using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace MasGlobal.IntegrationTest.Employee
{
    public class IntegrationGeneralScenarios
    {

        [Fact]
        public async Task RetunGetEmployees()
        {
            using (var reservaServer = new ReservaTestBase().CreateServer())
            {
                var reservaClient = reservaServer.CreateClient();
                var url = $"https://localhost:44301/api/Employee";
                var response = await reservaClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
