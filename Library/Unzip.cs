using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxPackageInstaller.Library
{
    public class Unzip
    {

        public static void UnzipFile(String File, String OutputPath)
        {
            try
            {
                FileStream fileStream = new FileStream(File, FileMode.Open, FileAccess.Read);
                GZipStream gZipStream = new GZipStream(fileStream, CompressionMode.Decompress);
                FileStream fileStream1 = new FileStream(OutputPath, FileMode.Create, FileAccess.Write);
                byte[] buffer = new byte[4096];
                int bytesRead;

                while ((bytesRead = gZipStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream1.Write(buffer, 0, bytesRead);
                }
                fileStream1.Close();
                gZipStream.Close();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}