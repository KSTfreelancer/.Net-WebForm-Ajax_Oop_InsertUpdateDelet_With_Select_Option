using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_OOP.Model
{
    public class Students
    {
        public int AutoId { get; set; }
        public int Roll { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Subject { get; set; }
        public string Semister { get; set; }
        public string Shift { get; set; }
        public string Admission { get; set; }
        public string Farewell { get; set; }

        
    }
    public class AllSemister
    {
        public int AutoId { get; set; }
        public string Semister { get; set; }

    }
}