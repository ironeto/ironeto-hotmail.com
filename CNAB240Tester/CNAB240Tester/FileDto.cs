using CNAB240BB.DeliveryFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240Tester.DeliveryFile
{
    public class FileDto
    {
        public Cnab240Codes Status { get; set; }
        public string StatusDescription { get; set; }
        public List<DepositDto> DepositDetails { get; set; }

        public FileDto(Cnab240Codes Status)
        {
            this.Status = Status;
            DepositDetails = new List<DepositDto>();
        }
    }
}
