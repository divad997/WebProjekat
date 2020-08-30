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
        public string Date { get; set; }
    }
}
