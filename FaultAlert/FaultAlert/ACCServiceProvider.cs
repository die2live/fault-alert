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

        public override List<string> Update()
        {
            var alerts = new List<string>();
            var client = new WebClient();
            var page = client.DownloadString(this.Url);

            var doc = new HtmlDocument();
            doc.LoadHtml(page);

            var table = doc.DocumentNode.SelectNodes("//*[@id='descriptionDisconnection' and @data-id=3]/div/div/div/div/table[@class='avarieri']");

            var rows = table.First().Descendants("tr");

            foreach (var row in rows)
            {
                var cells = row.Descendants("td").ToList();

                if (cells.Count > 1)
                {
                    foreach (var searchTerm in Settings.SearchTerms)
                    {
                        if (cells[5].InnerText.ToLower().Contains(searchTerm.ToLower()))
                        {
                            string msg = "Disconnected on street {0}<br/>Affected streets: {1} <br/>Disconnected on {2} <br>Reconnect on {3} <br/> Cistern on street {4}";
                            alerts.Add(string.Format(msg, cells[2].InnerText, cells[5].InnerText, cells[6].InnerText, cells[7].InnerText, cells[8].InnerText));
                        }
                    }
                }
            }

            return alerts;
        }

      


    }
}
