using System;
using System.IO;
using System.Text;

namespace Ttu.Domain
{
    public class FileWriter
    {

        #region Utility

        public static FileWriter CreateFile(string filePath)
        {
            // guard clause
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            bool directoryCreated = false;
            try
            {
                directoryCreated = EnsureDirectoryExists(filePath);
                FileStream fileStream = File.Create(filePath);
                return new FileWriter(fileStream, filePath);
            }
            catch (Exception)
            {
                RemoveDirectory(directoryCreated, filePath);
                return null;
            }
        }

        private static bool EnsureDirectoryExists(string filePath)
        {
            // guard clause - directory already exists
            string fileDirectory = Path.GetDirectoryName(filePath);
            fileDirectory = !string.IsNullOrEmpty(fileDirectory) ? fileDirectory : Environment.CurrentDirectory;
            if (Directory.Exists(fileDirectory))
            {
                return false;
            }

            Directory.CreateDirectory(fileDirectory);
            return true;
        }

        private static void RemoveDirectory(bool directoryCreated, string filePath)
        {
            // guard clause - didn't create directory so don't worry about cleaning it up
            if (!directoryCreated)
            {
                return;
            }

            // guard clause - no directory to remove
            string fileDirectory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(fileDirectory))
            {
                return;
            }

            Directory.Delete(fileDirectory, true);
        }

        #endregion

        #region Constructors

        private FileWriter(FileStream fileStream, string filePath)
        {
            FilePath = filePath;
            Stream = fileStream;

            EndLineBytes = Encoding.Default.GetBytes(Environment.NewLine);
        }

        #endregion

        #region Properties

        private byte[] EndLineBytes { get; set; }
        private string FilePath { get; set; }
        private FileStream Stream { get; set; }

        #endregion

        #region Public Methods

        public bool Close()
        {
            // guard clause - stream is already closed
            if (Stream == null)
            {
                return true;
            }

            try
            {
                Stream.Close();
                Stream = null;
                return true;
            }
            catch (IOException)
            {
                // do nothing
            }

            Stream = null;
            return false;
        }

        public void PrintLine(string inputText, params object[] replacements)
        {
            string value = replacements == null || replacements.Length == 0 ? inputText : string.Format(inputText, replacements);
            byte[] valueBytes = Encoding.Default.GetBytes(value);
            WriteBytes(valueBytes);

            WriteBytes(EndLineBytes);
        }

        #endregion

        #region Helper Methods

        private void WriteBytes(byte[] stringBytes)
        {
            Stream.Write(stringBytes, 0, stringBytes.Length);
        }

        #endregion

    }
}
