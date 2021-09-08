using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_Link
{
    public class IOLinkResponse
    {
        public int cid { get; set; }
        public IOLinkResponseData data { get; set; }
        public int code { get; set; }
    }
}
