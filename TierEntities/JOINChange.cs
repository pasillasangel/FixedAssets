using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TierEntities
{
    public class JOINChange
    {
        public int idAsset { get; set; }
        public string Location { get; set; }
        public string Responsible { get; set; }
        public string Pedimento { get; set; }
        public string codePedimento { get; set; }
        public string invoice { get; set; }
        public DateTime? invoiceDate { get; set; }
        public string PO { get; set; }
        public string provider { get; set; }
        public string owner { get; set; }
        public DateTime dateChange { get; set; }
        public string notes { get; set; }
    }
}