using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Yarp.Plugins.Api;

namespace PidginYarpPlugin
{
    public class PidginPasswordsRetriever : IYarpPlugin
    {
        private const string PidginAccountFile = ".purple\\accounts.xml";

        public void Activate() { }

        public void Deactivate() { }

        public IEnumerable<PasswordRetrievalResult> RetrievePasswords()
        {
            var localFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var pathToPasswordFile = Path.Combine(localFolder, PidginAccountFile);

            if (!File.Exists(pathToPasswordFile))
            {
                yield break;
            }

            var xml = XDocument.Load(pathToPasswordFile);
            var accounts = xml.Root?.Descendants("account") ?? Enumerable.Empty<XElement>();

            foreach (var account in accounts)
            {
                var name = account.Element("name");
                var password = account.Element("password");
                var source = account.Element("protocol");

                yield return new PasswordRetrievalResult(name?.Value ?? "", password?.Value ?? "", source?.Value ?? "");
            }
        }
    }
}