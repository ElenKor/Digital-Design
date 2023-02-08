using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using TicketsSearch.Models;
using DocsVision.Platform.StorageServer.Extensibility;

namespace TicketsSearch
{
    //класс серверного расширения
    public class Search //:  StorageServerExtension
    {
        //метод, доступный на клиенте
        //[ExtensionMethod]
        public decimal MinimalTicketPrice(string destination, string dateFrom, string dateTo)
        {
            string departure_at = DateTime.Parse(dateFrom).ToString("yyyy-MM-dd"); //дата вылета из пункта отправления
            string return_at = DateTime.Parse(dateTo).ToString("yyyy-MM-dd");//дата возвращения
            string url = $"https://api.travelpayouts.com/aviasales/v3/prices_for_dates?origin=LED&destination={destination}&currency=rub&departure_at={departure_at}&return_at={return_at}&sorting=price&direct=true&limit=10&token=83f61e3efffda65096f35d90b7a24df7";
            string result = getContent(url);
            var tickets = JsonConvert.DeserializeObject<Ticket>(result);
            var minimalTicketPrice = tickets.data
                .Select(t => t.price)
                .Min(); 
            return minimalTicketPrice;
        }

        private static string getContent(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.Accept = "application/json";
            request.UserAgent = "Mozilla/5.0 ....";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            StringBuilder output = new StringBuilder();
            output.Append(reader.ReadToEnd());
            response.Close();
            return output.ToString();
        }
    }
}