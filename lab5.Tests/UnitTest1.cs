using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using lab5.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lab5.Tests
{
    public class UnitTestLab5
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
        [InlineData("77", "33")]
        [InlineData("256,128","128,64")]
        [InlineData("-77","-33")]
        public void AddTestTask(string val1, string val2)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log("addTest"+"Values:"+val1+";"+val2, w);
            }
            // Arrange
            ValuesController controller = new ValuesController();
            Values values = new Values() { Val1 = val1, Val2 = val2 };

            // Act
            var result = controller.AddTask(values);

            // Assert           
            Assert.NotNull(controller);
            Assert.NotNull(values);
            Assert.NotNull(result);       
            Assert.IsType<Values>(values);
            Assert.IsType<ValuesController>(controller);
          
        }

        [Theory]
        [InlineData("77", "33")]
        [InlineData("256,128", "128,64")]
        [InlineData("-77", "-33")]
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
        [InlineData("77", "33")]
        [InlineData("256,128", "128,64")]
        [InlineData("-77", "-33")]
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
        [InlineData("77", "33")]
        [InlineData("256,128", "128,64")]
        [InlineData("-77", "-33")]
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
        [InlineData("77", "33")]
        [InlineData("256", "128")]
        [InlineData("222277", "33")]
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
