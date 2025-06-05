using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoogleCalTracker
{
    public static class ConfigLoader
    {
        public static Config config;
        private static string path = "config.json";
        public static Config GetConfig()
        {
            if (config != null) return config;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path, optional:true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            config = configuration.GetSection("Config").Get<Config>() ?? new Config();
            return config;
        }

        public static void SaveConfig()
        {
            var json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(path, json);
        }
    }
}
