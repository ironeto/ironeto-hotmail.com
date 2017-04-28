using CNAB240BB.DeliveryFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240Tester.DeliveryFile
{
    public class FileDto
    {
        public Cnab240Code Status { get; set; }
        public string StatusDescription { get; set; }
        public List<DepositDto> DepositDetails { get; set; }

        public MemoryStream ReturnFile { get; set; }

        public FileDto(Cnab240Code Status)
        {
            this.Status = Status;
            DepositDetails = new List<DepositDto>();
        }
    }
}
