using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Yarp.Plugins.Api;

namespace ChromeYarpPlugin
{
    public class ChromePasswordRetriever : IYarpPlugin
    {
        private const string PathToPasswordsFile = "Google\\Chrome\\User Data\\Default\\Login Data";

        public void Activate()
        {
            throw new System.NotImplementedException();
        }

        public void Deactivate()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PasswordRetrievalResult> RetrievePasswords()
        {
            var localAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var pathToPasswordsFile = Path.Combine(localAppDataFolder, PathToPasswordsFile);

            //Decrypt password file here


            return Enumerable.Empty<PasswordRetrievalResult>();
        }
    }
}