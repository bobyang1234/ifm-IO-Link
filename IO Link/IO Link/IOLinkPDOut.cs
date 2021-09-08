using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_Link
{
    public class IOLinkPDOut
    {
        public string code { get; set; }
        public int cid { get; set; }
        public string adr { get; set; }
        public IOLinkPDOutData data { get; set; }
    }
}
