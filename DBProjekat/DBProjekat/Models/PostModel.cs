using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBProjekat.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string DestinationFrom { get; set; }
        public string DestinationTo { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string LandDate { get; set; }
        public string PassportNumber { get; set; }
        public Flight Fl { get; set; }
        public string Username { get; set; }
        public string NumberOfTickets { get; set; }
        public string DailyRate { get; set; }
        public string TotalPrice { get; set; }
        public string DateStart { get; set; }
        public string DateReturn { get; set; }
        public int RCId { get; set; }
        public int CarId { get; set; }
    }
}
