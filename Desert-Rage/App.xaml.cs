using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Processors;
using System.Text.Json;
using Processors.Converters.Json;
using System.Globalization;
using DesertRage.ViewModel;
using DesertRage.Model.Helpers;

namespace DesertRage
{
    /// <summary>
    /// App configuration
    /// </summary>
    public partial class App : Application
    {
        internal static readonly Serializer Processor;

        static App()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            Processor = new Json(options);
        }

        public App()
        {
            Dictionary<string, string> config = Bank.LoadConfig()
            if (config is null)
                return;
                
            if (config.TryGetValue("Culture", string name) && !name.IsNA())
            {
                CultureInfo culture = new CultureInfo(name);
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            }
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("Logs/log.txt",
                rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application started");
            Log.Debug("Collecting configuration info...");
        }
    }
}
