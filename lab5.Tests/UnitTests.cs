using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using lab5.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace lab5.Tests
{
    public class UnitTests
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
        public async Task GetMethodTestTask()
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log("getTest", w);
            }
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            var result = controller.Get();

            // Assert           
            Assert.IsType<RedirectResult>(result);
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: 3)]
        public async Task AddTestTask(string val1, string val2)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log("addTest" + "Values:" + val1 + ";" + val2, w);
            }
            // Arrange

            ValuesController controller = new ValuesController();
            Values values = new Values() { Val1 = val1, Val2 = val2 };

            // Act
            var result = controller.AddTask(values);

            // Assert               
            Assert.NotNull(values);
            Assert.NotNull(result);
            Assert.IsType<Values>(values);
            Assert.IsType<ValuesController>(controller);

        }

        [Theory]
        [MemberData(nameof(GetData), parameters: 3)]
        public void SubtractionTestTask(string val1, string val2)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log("subtraction Test " + "Values:" + val1 + ";" + val2, w);
            }
            // Arrange
            ValuesController controller = new ValuesController();
            Values values = new Values() { Val1 = val1, Val2 = val2 };

            // Act
            var result = controller.SubtractionTask(values);

            // Assert           
            Assert.NotNull(controller);
            Assert.NotNull(values);
            Assert.NotNull(result);
            Assert.IsType<Values>(values);
            Assert.IsType<ValuesController>(controller);
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: 4)]
        public void DivisionTaskTest(string val1, string val2)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log("division Test " + "Values:" + val1 + ";" + val2, w);
            }
            // Arrange
            ValuesController controller = new ValuesController();
            Values values = new Values() { Val1 = val1, Val2 = val2 };

            // Act
            var result = controller.DivisionTask(values);

            // Assert           
            Assert.NotNull(controller);
            Assert.NotNull(values);
            Assert.NotNull(result);
            Assert.IsType<Values>(values);
            Assert.IsType<ValuesController>(controller);
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: 4)]
        public void MultiplicationTaskTest(string val1, string val2)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log("multiplication Test " + "Values:" + val1 + ";" + val2, w);
            }
            // Arrange
            ValuesController controller = new ValuesController();
            Values values = new Values() { Val1 = val1, Val2 = val2 };

            // Act
            var result = controller.MultiplicationTask(values);

            // Assert           
            Assert.NotNull(controller);
            Assert.NotNull(values);
            Assert.NotNull(result);
            Assert.IsType<Values>(values);
            Assert.IsType<ValuesController>(controller);
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: 3)]
        public void PercentTaskTest(string val1, string val2)
        {
            // Arrange
            ValuesController controller = new ValuesController();
            Values values = new Values() { Val1 = val1, Val2 = val2 };

            // Act
            var result = controller.PercentTask(values);
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log("percent Test " + "Values:" + val1 + ";" + val2, w);
            }
            // Assert           
            Assert.NotNull(controller);
            Assert.NotNull(values);
            Assert.NotNull(result);
            Assert.IsType<Values>(values);
            Assert.IsType<ValuesController>(controller);
        }

    }

}