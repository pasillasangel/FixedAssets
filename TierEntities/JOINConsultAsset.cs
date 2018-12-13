using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TierEntities
{
    public class JOINConsultAsset
    {
        public int id { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string responsible { get; set; }
        public decimal cost { get; set; }
        public decimal CostMx { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string serial { get; set; }
        public string invoice { get; set; }
        public DateTime? invoiceDate { get; set; }
        public string pedimento { get; set; }
        public string codePedimento { get; set; }
        public string provider { get; set; }
        public DateTime? dateCreate { get; set; }
        public string PO { get; set; }
        public string Owner { get; set; }
        public string notes { get; set; }

    }
}
