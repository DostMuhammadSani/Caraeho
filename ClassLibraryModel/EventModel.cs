using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class EventModel
    {
        public string EventID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string BID { get; set; }  // Branch ID
    }
}

