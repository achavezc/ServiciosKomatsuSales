using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using System.IO;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography.Configuration;
using System.Text;
using System.Security.Cryptography;

namespace RANSA.MCIP.Framework
{
    public class ManejadorEncriptacion
    {
        public static string GetSymmProvider()
        {
            return System.Configuration.ConfigurationManager.AppSettings["EntLibSymmProvider"];
        }

        public static string Encriptar(string texto, out Object keysimetric)
        {
            string result = "";
            try
            {
                ProtectedKey key = KeyManager.GenerateSymmetricKey("System.Security.Cryptography.TripleDESCryptoServiceProvider", DataProtectionScope.LocalMachine);

                SymmetricAlgorithmProvider provider = new SymmetricAlgorithmProvider(typeof(TripleDESCryptoServiceProvider), key);
                result = Convert.ToBase64String(provider.Encrypt(UnicodeEncoding.Unicode.GetBytes(texto.ToCharArray(), 0, texto.Length)));
                keysimetric = key;
                
                //string decryptedData = UnicodeEncoding.Unicode.GetString(provider.Decrypt(Convert.FromBase64String(result)));
                //var crypto = EnterpriseLibraryContainer.Current.GetInstance<CryptographyManager>();
                //result = crypto.EncryptSymmetric(GetSymmProvider(), texto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static void ModifProtectedKeyFilename()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.HasFile)
            {
                ConfigurationSection configurationSection = config.Sections["securityCryptographyConfiguration"];
                CryptographySettings cryptographySettings = configurationSection as CryptographySettings;
                NameTypeConfigurationElementCollection<SymmetricProviderData, CustomSymmetricCryptoProviderData> elementCollection = cryptographySettings.SymmetricCryptoProviders;
                SymmetricProviderData symmetricProviderData = elementCollection.Get("AesCryptoServiceProvider");
                string keyFilePath = symmetricProviderData.ElementInformation.Properties["protectedKeyFilename"].Value.ToString();
                if (keyFilePath.Split('\\').Length == 1)
                {
                    symmetricProviderData.ElementInformation.Properties["protectedKeyFilename"].Value = AppDomain.CurrentDomain.BaseDirectory + "\\" + keyFilePath;
                    config.Save(ConfigurationSaveMode.Minimal);
                }
            }
        }

        public static string Desencriptar(string textoEncriptado)
        {
            string result = "";
            try
            {
                string ruta = AppDomain.CurrentDomain.BaseDirectory + "\\" + ConfigurationManager.AppSettings["EntLibSymmProvider"];
                ProtectedKey key = (ProtectedKey)new ManejadorArchivos().LeerKey(ruta);
                SymmetricAlgorithmProvider provider = new SymmetricAlgorithmProvider(typeof(TripleDESCryptoServiceProvider), key);

                result = UnicodeEncoding.Unicode.GetString(provider.Decrypt(Convert.FromBase64String(textoEncriptado)));

                //ModifProtectedKeyFilename();
                //var crypto = EnterpriseLibraryContainer.Current.GetInstance<CryptographyManager>();
                //string clavesimetrica = GetSymmProvider();
                //result = crypto.DecryptSymmetric(clavesimetrica, textoEncriptado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}