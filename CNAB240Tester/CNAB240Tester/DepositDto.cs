using CNAB240BB.DeliveryFile;
using CNAB240Tester.DeliveryFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240Tester
{
    public class DepositDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public decimal Tax { get; set; }
        public string Type { get; set; }
        public Cnab240Code Status { get; set; }
        public int CompanyId { get; set; }
        public string Nome { get; set; }
        public string ChaveBuscaUsuario { get; set; }
    }
}
