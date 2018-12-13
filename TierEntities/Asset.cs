using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TierEntities
{
    public class Asset
    {
        public int IdAssets { get; set; }
        public string partNumber { get; set; }
        public string descrip { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string serial { get; set; }
        public string invoice { get; set; }
        public DateTime? invoiceDate { get; set; }
        public string pedimento { get; set; }
        public string codePedimento { get; set; }
        public string provider { get; set; }
        public decimal cost { get; set; }
        public DateTime dateCreate { get; set; }
        public DateTime? dateLow { get; set; }
        public string picture { get; set; }
        public bool visible { get; set; }
        public int idLocationfk { get; set; }
        public int idResponsiblefk { get; set; }
        public string notes { get; set; }
        public string PO { get; set; }
        public string owner { get; set; }
        public decimal costmx { get; set; }
    }
}
