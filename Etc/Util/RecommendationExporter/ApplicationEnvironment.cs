using System;
using System.IO;
using System.Reflection;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.RecommendationExporter
{
    public class ApplicationEnvironment
    {

        public static ApplicationEnvironment Singleton = new ApplicationEnvironment();

        #region Constructors

        private ApplicationEnvironment()
        {
        }

        #endregion

        #region Properties

        public IServiceFactory ServiceFactory { get; private set; }
        public string FullyQualifiedOutputFilePath { get; private set; }

        #endregion

        #region Public Methods

        public void InitializeApplication(string[] args)
        {
            if (args.Length == 0)
            {
                AssemblyName name = Assembly.GetExecutingAssembly().GetName();
                string exceptionMessage = string.Format("Invalid number of arguments.{0}Usage: {1} <output-file-path>", Environment.NewLine, name.Name);
                throw new Exception(exceptionMessage);
            }

            FullyQualifiedOutputFilePath = GetRootedPath(args[0]);
        }

        public IServiceFactory InitializeService()
        {
            ServiceFactory = new ServiceFactory();
            return ServiceFactory;
        }

        #endregion

        #region Helper Methods

        private static string GetRootedPath(string path)
        {
            if (Path.IsPathRooted(path))
            {
                return path;
            }

            return Path.Combine(Environment.CurrentDirectory, path);
        }

        #endregion

    }
}
