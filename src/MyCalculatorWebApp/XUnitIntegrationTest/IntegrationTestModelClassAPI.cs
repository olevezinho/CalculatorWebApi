namespace XUnitIntegrationTest
{
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;
    using FluentAssertions;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Text;
    using ModelClasses;

    public class IntegrationTestModelClassAPI
    {
        [Fact]
        public async Task TestForOk()
        {
            //Arrange
            using (var client = new TestClientProvider().Client)
            {
                //Act
                var response = await client.GetAsync("/api/calc");
                response.EnsureSuccessStatusCode();
                //Assert
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }      
        }

        [Fact]
        public async Task TestForNotFound()
        {
            //Arrange
            using (var client = new TestClientProvider().Client)
            {
                //Act
                var response = await client.GetAsync("/api/calc");
                response.EnsureSuccessStatusCode();

                //Assert
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
        }

        [Fact]
        public async Task Test_Post()
        {
            //Arrange
            using (var client = new TestClientProvider().Client)
            {
                //Act
                var response = await client.PostAsync("/api/calc/add", new StringContent(
                    JsonConvert.SerializeObject(new Calculator() { n1=2, n2=1 }), 
                    Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                //Assert
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

    }
}
