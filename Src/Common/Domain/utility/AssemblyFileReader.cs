using System.IO;
using System.Reflection;

namespace Ttu.Domain
{
    public class AssemblyFileReader
    {

        #region Constructors

        public AssemblyFileReader(Assembly assembly)
        {
            Assembly = assembly;
        }

        #endregion

        #region Properties

        private Assembly Assembly { get; set; }

        #endregion

        #region Public Methods

        public byte[] ReadBinaryFile(string filePath)
        {
            try
            {
                // guard clause - resource is not embedded
                Stream resourceStream = GetResourceAsStream(filePath);
                if (resourceStream == null)
                {
                    GetLogger().Warn(string.Format("Could not read file [\"{0}\"].", filePath));
                    return new byte[0];
                }

                byte[] fileBytes = new byte[resourceStream.Length];
                resourceStream.Read(fileBytes, 0, fileBytes.Length);
                return fileBytes;
            }
            catch (BusinessException ex)
            {
                GetLogger().Error(ex);
                return new byte[0];
            }
        }

        #endregion

        #region Helper Methods

        private IApplicationLogger GetLogger()
        {
            return ApplicationLogger.GetLogger(GetType());
        }

        private Stream GetResourceAsStream(string name)
        {
            return Assembly.GetManifestResourceStream(name);
        }

        #endregion

    }
}
