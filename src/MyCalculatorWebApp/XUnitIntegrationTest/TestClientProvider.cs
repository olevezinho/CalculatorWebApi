namespace XUnitIntegrationTest
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using MyCalculatorWebApp;
    using System;
    using System.Net.Http;

    public class TestClientProvider : IDisposable
    {
        private readonly TestServer Server;

        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            Server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = Server.CreateClient();
        }

        public void Dispose()
        {
            Server?.Dispose();
            Client?.Dispose();
        }
    }
}
