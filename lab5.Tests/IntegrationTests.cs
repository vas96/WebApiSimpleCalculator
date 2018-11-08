using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using lab5.Controllers;
using Newtonsoft.Json;
using Xunit;

namespace lab5.Tests
{
   public class IntegrationTests
    {
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

        public static IEnumerable<object[]> GetData(int numTests)
        {
            var allData = new List<object[]>
            {
                new object[] {"100", "20"},
                new object[] {"10", "0,5"},
                new object[] {"-2", "-200"},
                new object[] {(int.MaxValue).ToString(), (int.MinValue).ToString()},
            };
            return allData.Take(numTests);
        }

        [Fact]
        public async Task GetTaskTest()
        {
            // Act
            var client = new Provider().Client;
            var response = await client.GetAsync("/api/values");
         
            response.StatusCode.Should().Be(HttpStatusCode.Redirect);
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: 3)]
        public async Task Add(string val1, string val2)
        {
            // Act
            Values values = new Values() { Val1 = val1, Val2 = val2 };
            var client = new Provider().Client;
            var response = await client.PostAsync("/add",
            new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json"));
               
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            using (StreamWriter w = File.AppendText("logResponse.txt"))
            {
                Log("add test; " + "Values:" + val1 + ";" + val2 +"; Status code: "+response.StatusCode + Environment.NewLine + response.Content + Environment.NewLine + response.RequestMessage + Environment.NewLine + response.Headers , w);
            }
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: 3)]
        public async Task Division(string val1, string val2)
        {
            // Act
            Values values = new Values() { Val1 = val1, Val2 = val2 };
            var client = new Provider().Client;
            var response = await client.PostAsync("/division",
                new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            using (StreamWriter w = File.AppendText("logResponse.txt"))
            {
                Log("division test; " + "Values:" + val1 + ";" + val2 + "; Status code: " + response.StatusCode + Environment.NewLine + response.Content + Environment.NewLine + response.RequestMessage + Environment.NewLine + response.Headers, w);
            }
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: 3)]
        public async Task Multiplication(string val1, string val2)
        {
            // Act
            Values values = new Values() { Val1 = val1, Val2 = val2 };
            var client = new Provider().Client;
            var response = await client.PostAsync("/multiplication",
                new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            using (StreamWriter w = File.AppendText("logResponse.txt"))
            {
                Log("multiplication test; " + "Values:" + val1 + ";" + val2 + "; Status code: " + response.StatusCode + Environment.NewLine + response.Content + Environment.NewLine + response.RequestMessage + Environment.NewLine + response.Headers, w);
            }
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: 2)]
        public async Task Percent(string val1, string val2)
        {
            // Act
            Values values = new Values() { Val1 = val1, Val2 = val2 };
            var client = new Provider().Client;
            var response = await client.PostAsync("/percent",
                new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            using (StreamWriter w = File.AppendText("logResponse.txt"))
            {
                Log("percent test; " + "Values:" + val1 + ";" + val2 + "; Status code: " + response.StatusCode + Environment.NewLine + response.Content + Environment.NewLine + response.RequestMessage + Environment.NewLine + response.Headers, w);
            }
        }
        
    }
}
