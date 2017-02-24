using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using RedCell.Diagnostics.Update;

namespace Ferret
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintDisclaimer();

            // Update Application
            /*Log.Console = true;
            var updater = new Updater();
            updater.StartMonitoring();*/

            // Create web client
            using (WebClient client = new WebClient())
            {
                // Set user agent.
                client.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 6.3; Trident/7.2; rv:11.1) like Gecko";
                // Accept-encoding headers.
                client.Headers["Accept-Encoding"] = "html";
                client.Headers["Accept-Encoding"] = "text";

                // Download urlList
                //Uri urlList = client.DownloadFile("http://www.mosinu.com/files/files.txt", @"C:\users\will\files.txt");
                Uri urList = new Uri("http://www.mosinu.com/files/files.txt");
                string contents;
                contents = client.DownloadString(urList);
                //string filePath;
                string urlFile = (@"C:\users\will\files.txt");
                client.DownloadFile(urList, urlFile);

                // Download data.
                //byte[] arr = client.DownloadData("http://blog.mosinu.com/");
                //string sTr = client.DownloadString("http://blog.mosinu.com/");
                int counter = 0;
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(urlFile);

                // Get response header.
                string contentEncoding = client.ResponseHeaders["Content-Encoding"];

                // Write values.
                //Console.WriteLine("--- WebClient result ---");
                PrintRedAttentionText(" *** Ferret result *** ");

                while ((line = file.ReadLine()) != null)
                //while (contents != null)
                {
                    //Console.WriteLine(line);
                    byte[] myDataBuffer = client.DownloadData(line);
                    string download = Encoding.ASCII.GetString(myDataBuffer);
                    Console.WriteLine(download);
                    counter++;
                }

                //Clean up the files
                file.Close();
                File.Delete(urlFile);
                file.Dispose();
               

                // for loop
                /*
                foreach (LinkItem i in LinkFinder.Find(sTr))
                {
                    //var remoteUri = i;
                    string remoteUri = Console.ReadLine();
                    //byte[] myDataBuffer = client.DownloadData(remoteUri);                    
                    //Console.WriteLine(arr.Length);
                    //client.DownloadData(i);
                    //Debug.WriteLine(i);
                    Console.WriteLine(i);                    
                }
                */

                // Display the downloaded data.  
                PrintRedAttentionText("***Done***");
                Console.ReadLine();
            }
        }

        // Add a disclaimer
        private static void PrintDisclaimer()
        {
            PrintAttentionText("Ferret");
        }

        // Set console color to yellow
        private static void PrintAttentionText(string text)
        {
            ConsoleColor originalColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(text);
            System.Console.ForegroundColor = originalColor;
        }

        // Set console color to red
        private static void PrintRedAttentionText(string text)
        {
            ConsoleColor originalColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(text);
            System.Console.ForegroundColor = originalColor;
        }
    }
}
