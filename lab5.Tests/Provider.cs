using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace lab5.Tests
{
    class Provider : IDisposable
    {
        private TestServer server;

        public HttpClient Client { get; private set; }
        public Provider()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}

