using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FaultAlert
{
    public class ACCServiceProvider : ServiceProvider
    {
        public Uri BaseSerivceUri { get; set; }
        public string Url { get; set; }

        public ACCServiceProvider()
        {
            this.Name = "ACC";
            this.BaseSerivceUri = new Uri("https://acc.md/disconnections");
            this.Url = "https://acc.md/disconnections";

        }

        public override bool Update()
        {
            string page = GetPageContents();
            
            throw new NotImplementedException();
        }

        public string GetPageContents()
        {
            var client = new WebClient();
            var page = client.DownloadString(this.Url);

            var doc = new HtmlDocument();
            doc.LoadHtml(page);

            var table = doc.DocumentNode.SelectNodes("//*[@id='descriptionDisconnection' and @data-id=2]/div/div/div/div/table[@class='avarieri']");

            var rows = table.First().Descendants("tr");

            foreach (var row in rows)
            {
                var cells = row.Descendants("td").ToList();

                if (cells.Count > 1)
                {
                    if (cells[5].InnerText.Contains("Renasterii"))
                    {
                        Console.WriteLine("Alert!");
                    }
                }
            }

            return string.Empty;
        }

      


    }
}
