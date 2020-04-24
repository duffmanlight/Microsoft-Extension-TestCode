using System;
using System.IO;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;

namespace db_test_console_app
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables("TEST_")
                .AddCommandLine(args)
                .Build();

            string temp = ConfigurationManager.AppSettings["MyFirstKey"];
            var temp1 = configuration.GetSection("author");
            var temp2 = configuration.GetSection("author:name");
            var temp3 = configuration.GetSection("name");
            var temp4 = configuration.GetSection("author").GetChildren();
            var temp5 = configuration.GetSection("author:name").GetChildren();
            var temp6 = configuration.GetSection("input");
            var temp7 = configuration.GetSection("output");
            var temp8 = configuration.Get<AppConfig>();
            var temp9 = configuration.GetSection("author").Get<Author>();
        }

        [JsonObject("author")]
        public class Author
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            // public string LastName { get; set; }
        }

        public class AppConfig
        {
            public ConnectionStringsConfig ConnectionStrings { get; set; }
            public ApiSettingsConfig ApiSettings { get; set; }

            public class ConnectionStringsConfig
            {
                public string MyDb { get; set; }
            }

            public class ApiSettingsConfig
            {
                public string Url { get; set; }
                public string ApiKey { get; set; }
                public bool UseCache { get; set; }
            }
        }
    }
}
