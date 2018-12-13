using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TierEntities
{
    public class ChangeAssets
    {
        public int idChange { get; set; }
        public int idAssetsfk { get; set; }
        public int idLocationfkch { get; set; }
        public int idResponsiblefkch { get; set; }
        public string pedimento { get; set; }
        public string codePedimento { get; set; }
        public bool visible { get; set; }
        public DateTime dateChange { get; set; }
        public string notes { get; set; }
        public string invoice { get; set; }
        public DateTime? invoiceDate { get; set; }
        public string PO { get; set; }
        public string provider { get; set; }
        public string owner { get; set; }
    }
}
