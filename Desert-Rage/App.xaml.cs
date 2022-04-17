using Serilog;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using DesertRage.Helpers.ResourceManagement;
using DesertRage.Helpers.ResourceManagement.OST;

namespace DesertRage
{
    /// <summary>
    /// App loading and resolving assembly
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            GameThemes = new Music();
            GameSounds = new Sounds();
            GameNoises = new Noises();
            VideoScene = new CutScenes();
        }

        public App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.File("Logs/log.txt",
                rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application started");
            Log.Debug("Collecting configuration info...");
        }

        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = new AssemblyName(args.Name);
            string path = assemblyName.Name + ".dll";
            var resource = executingAssembly.GetManifestResourceNames().Where(s => s.EndsWith(path)).FirstOrDefault();

            if (resource == null)
                return null;

            using (Stream stream = executingAssembly.GetManifestResourceStream(resource))
            {
                if (stream == null)
                    return null;
                byte[] assemblyRawBytes = new byte[stream.Length];
                stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
                return Assembly.Load(assemblyRawBytes);
            }
        }

        #region OST
        public static readonly Music GameThemes;
        public static readonly Sounds GameSounds;
        public static readonly Noises GameNoises;
        #endregion

        public static readonly CutScenes VideoScene;
    }
}