using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsSearchRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = "MOW";
            string dateFrom = "01.12.2022";
            string dateTo = "31.12.2022";

            TicketsSearch.Search search = new TicketsSearch.Search();
            decimal minPrice = search.MinimalTicketPrice(destination, dateFrom, dateTo);
           
            Console.WriteLine("Minimal ticket price from SPB to "+ destination+" = " + +minPrice + " rubles.");
            //Console.ReadKey();
        }
    }
}
