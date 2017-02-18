using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Ttu.Domain
{
    // http://en.wikipedia.org/wiki/FIPS_140

    public class Cipher
    {

        #region Constants

        private const string HASH_ALGORITHM = "SHA1";
        private const string INIT_VECTOR = "&&tuREGf($@#ScFE";
        private const int KEY_SIZE = 256;
        private const int PASSWORD_ITERATIONS = 2;
        private const string PASS_PHRASE = "013170";
        private const string SALT_VALUE = "103103";

        #endregion

        #region Constructors

        public Cipher()
        {
            Initialize(new AesCryptoServiceProvider());
        }

        #endregion

        #region Properties

        private CryptoStream CryptoStream { get; set; }
        private byte[] InitVectorBytes { get; set; }
        private byte[] KeyBytes { get; set; }
        private MemoryStream MemoryStream { get; set; }
        private SymmetricAlgorithm SymmetricKey { get; set; }

        #endregion

        #region Public Methods

        public string Decrypt(string dataToDecrypt)
        {
            // guard clause
            if (string.IsNullOrEmpty(dataToDecrypt))
            {
                return string.Empty;
            }

            try
            {
                string decryptedText = DecryptUsingFIPS(dataToDecrypt);
                if (!string.IsNullOrEmpty(decryptedText))
                {
                    return decryptedText;
                }
                return DecryptUsingManagedKey(dataToDecrypt);
            }
            catch (ArgumentException ex)
            {
                LogException(ex);
            }
            catch (FormatException ex)
            {
                LogException(ex);
            }
            finally
            {
                ReleaseStreams();
            }

            return string.Empty;
        }

        public string Encrypt(string dataToEncrypt)
        {
            try
            {
                string encryptedText = EncryptUsingFIPS(dataToEncrypt);
                if (!string.IsNullOrEmpty(encryptedText))
                {
                    return encryptedText;
                }
                return EncryptUsingManagedKey(dataToEncrypt);
            }
            catch (ArgumentException ex)
            {
                LogException(ex);
            }
            catch (CryptographicException ex)
            {
                LogException(ex);
            }
            finally
            {
                ReleaseStreams();
            }

            return string.Empty;
        }

        #endregion

        #region Helper Methods

        private string DecryptData(string dataToDecrypt)
        {
            ICryptoTransform decryptor = SymmetricKey.CreateDecryptor(KeyBytes, InitVectorBytes);

            byte[] cipherTextBytes = Convert.FromBase64String(dataToDecrypt);
            MemoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream = new CryptoStream(MemoryStream, decryptor, CryptoStreamMode.Read);

            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = CryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        private string DecryptUsingFIPS(string dataToDecrypt)
        {
            Initialize(new AesCryptoServiceProvider());
            return DecryptData(dataToDecrypt);
        }

        private string DecryptUsingManagedKey(string dataToDecrypt)
        {
            Initialize(new RijndaelManaged());
            return DecryptData(dataToDecrypt);
        }

        private string EncryptData(string dataToEncrypt)
        {
            ICryptoTransform encryptor = SymmetricKey.CreateEncryptor(KeyBytes, InitVectorBytes);

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(dataToEncrypt);
            MemoryStream = new MemoryStream();
            CryptoStream = new CryptoStream(MemoryStream, encryptor, CryptoStreamMode.Write);
            CryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            CryptoStream.FlushFinalBlock();

            byte[] cipherTextBytes = MemoryStream.ToArray();
            return Convert.ToBase64String(cipherTextBytes);
        }

        private string EncryptUsingFIPS(string dataToEncrypt)
        {
            Initialize(new AesCryptoServiceProvider());
            return EncryptData(dataToEncrypt);
        }

        private string EncryptUsingManagedKey(string dataToEncrypt)
        {
            Initialize(new RijndaelManaged());
            return EncryptData(dataToEncrypt);
        }

        private IApplicationLogger GetLogger()
        {
            return ApplicationLogger.GetLogger(GetType());
        }

        private void Initialize(SymmetricAlgorithm symmetricAlgorithm)
        {
            ReleaseStreams();
            CryptoStream = null;
            MemoryStream = null;

            byte[] saltValueBytes = Encoding.ASCII.GetBytes(SALT_VALUE);
            PasswordDeriveBytes password = new PasswordDeriveBytes(PASS_PHRASE, saltValueBytes, HASH_ALGORITHM, PASSWORD_ITERATIONS);
            KeyBytes = password.GetBytes(KEY_SIZE / 8);
            InitVectorBytes = Encoding.ASCII.GetBytes(INIT_VECTOR);

            SymmetricKey = symmetricAlgorithm;
            SymmetricKey.Mode = CipherMode.CBC;
        }

        private void LogException(Exception e)
        {
            GetLogger().Error(e);
        }

        private void ReleaseStreams()
        {
            if (MemoryStream != null)
            {
                MemoryStream.Close();
            }

            if (CryptoStream != null)
            {
                CryptoStream.Close();
            }
        }

        #endregion

    }
}
