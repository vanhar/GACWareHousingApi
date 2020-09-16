using GACWareHousingScheduler.Helpers;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GACWareHousingScheduler
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            await PushSalesOrderMessages();

        }

        private static async Task PushSalesOrderMessages()
        {
            Console.WriteLine("Push SalesOrder messages!");
            try
            {
                var files = Directory.GetFiles(AppConstantsHelper.basePath + AppConstantsHelper.XmlMessagesFolder, AppConstantsHelper.xmlExt);
                if (files != null)
                {
                    foreach (var filepath in files)
                    {
                        var xml = File.ReadAllText(filepath);
                        if (!string.IsNullOrEmpty(xml))
                        {
                            Console.WriteLine("Invoke SalesOrder Api!");

                            var data = new StringContent(xml, Encoding.UTF8, "application/json");
                            var response = await HttpClientHelper.Object().PostAsync(HttpClientHelper.salesOrderApi, data);
                        }


                        Console.WriteLine("Archive SalesOrder messages!");
                        File.Move(filepath, Path.Combine(AppConstantsHelper.basePath + AppConstantsHelper.archiveFolder, DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(filepath)));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Push SalesOrder messages!");
            }
        }


    }
}
