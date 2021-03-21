/// <summary>
/// Integration test using XUnit and FluentAssertions
/// </summary>
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
    using System;

    /// <summary>Integration test on the web api</summary>
    public class IntegrationTestModelClassAPI
    {
        /// <summary>Testing for response type</summary>
        /// <param name="httpStatusCode"></param>
        [Theory]
        [InlineData(HttpStatusCode.OK)]
        public async Task TestForResponseTypeGET(HttpStatusCode httpStatusCode)
        {
            //Arrange
            using (var client = new TestClientProvider().Client)
            {
                //Act
                var response = await client.GetAsync("/api/calc");
                response.EnsureSuccessStatusCode();
                //Assert
                response.StatusCode.Should().Be(httpStatusCode);
            }
        }

        [Theory]
        [InlineData(1, 1, 2)]
        public async Task TestForResponseTypeAdd(int n1, int n2, int result)
        {

            using (var client = new TestClientProvider().Client) //Initializes the client
            {
                //Arrange
                var Initial = DateTime.UtcNow;
                var request = await client.PostAsync($"/api/calc/add/{n1}/{n2}", new StringContent(
                    JsonConvert.SerializeObject(new Calculator().Add(n1, n2)),
                    Encoding.UTF8, "application/json"));
                request.EnsureSuccessStatusCode();

                //Act
                var response = request.Content.ReadAsStringAsync().Result;
                var dif = DateTime.Now - Initial;

                //Assert
                if (dif.TotalSeconds < 2)
                {
                    request.StatusCode.Should().Be(HttpStatusCode.OK); //Asserting that the request returns a 200 OK 
                    Assert.Equal(result.ToString(), response); //Asserting that the calculation of the Calculator.Add() method is as expected
                }
            }
        }

        [Theory]
        [InlineData(1, 1, 0)]
        public async Task TestForResponseTypeSubtract(int n1, int n2, int result)
        {

            using (var client = new TestClientProvider().Client) //Initializes the client
            {
                //Arrange
                var Initial = DateTime.UtcNow;
                var request = await client.PostAsync($"/api/calc/sub/{n1}/{n2}", new StringContent(
                    JsonConvert.SerializeObject(new Calculator().Subtract(n1, n2)),
                    Encoding.UTF8, "application/json"));
                request.EnsureSuccessStatusCode();

                //Act
                var response = request.Content.ReadAsStringAsync().Result;
                var dif = DateTime.Now - Initial;

                //Assert
                if (dif.TotalSeconds < 2)
                {
                    request.StatusCode.Should().Be(HttpStatusCode.OK); //Asserting that the request returns a 200 OK 
                    Assert.Equal(result.ToString(), response); //Asserting that the calculation of the Calculator.Add() method is as expected
                }
            }
        }

        [Theory]
        [InlineData(1, 1, 1)]
        public async Task TestForResponseTypeMultiply(int n1, int n2, int result)
        {

            using (var client = new TestClientProvider().Client) //Initializes the client
            {
                //Arrange
                var Initial = DateTime.UtcNow;
                var request = await client.PostAsync($"/api/calc/mul/{n1}/{n2}", new StringContent(
                    JsonConvert.SerializeObject(new Calculator().Multiply(n1, n2)),
                    Encoding.UTF8, "application/json"));
                request.EnsureSuccessStatusCode();

                //Act
                var response = request.Content.ReadAsStringAsync().Result;
                var dif = DateTime.Now - Initial;

                //Assert
                if (dif.TotalSeconds < 2)
                {
                    request.StatusCode.Should().Be(HttpStatusCode.OK); //Asserting that the request returns a 200 OK 
                    Assert.Equal(result.ToString(), response); //Asserting that the calculation of the Calculator.Add() method is as expected
                }
            }
        }

        [Theory]
        [InlineData(4, 2, 2)]
        public async Task TestForResponseTypeDivide(int n1, int n2, int result)
        {

            using (var client = new TestClientProvider().Client) //Initializes the client
            {
                //Arrange
                var Initial = DateTime.UtcNow;
                var request = await client.PostAsync($"/api/calc/div/{n1}/{n2}", new StringContent(
                    JsonConvert.SerializeObject(new Calculator().Divide(n1, n2)),
                    Encoding.UTF8, "application/json"));
                request.EnsureSuccessStatusCode();

                //Act
                var response = request.Content.ReadAsStringAsync().Result;
                var dif = DateTime.Now - Initial;

                //Assert
                if (dif.TotalSeconds < 2)
                {
                    request.StatusCode.Should().Be(HttpStatusCode.OK); //Asserting that the request returns a 200 OK 
                    Assert.Equal(result.ToString(), response); //Asserting that the calculation of the Calculator.Add() method is as expected
                }
            }
        }
    }
}
