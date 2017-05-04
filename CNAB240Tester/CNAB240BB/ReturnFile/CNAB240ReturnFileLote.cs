using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.ReturnFile
{
    public class CNAB240ReturnFileLote
    {
        public CNAB240ReturnFileHeaderLote HeaderLote { get; set; }
        public List<CNAB240ReturnFileSegmentoA> SegmentoA { get; set; }
        public CNAB240ReturnFileTrailerLote TrailerLote { get; set; }


    }
}
