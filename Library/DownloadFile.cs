using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LinuxPackageInstaller.Library
{
    public class DownloadFile
    {
        public static void Download(string url, string filename)
        {
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, filename);
            }
#pragma warning restore SYSLIB0014 // Type or member is obsolete
        }
    }
}
