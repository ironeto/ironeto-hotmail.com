using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.DeliveryFile
{
    public class CNAB240Header
    {
        public string LoteServico { get; set; } //Index: 4 , Quantity: 4
        public string DataGeracaoArquivo { get; set; } //Index: 144 , Quantity: 8
        public string HoraGeracaoArquivo { get; set; } //Index: 152 , Quantity: 6
        public string NumeroSequencialArquivo { get; set; } //Index: 158 , Quantity: 6
        public string TipoInscricaoEmpresa { get; set; } //Index: 18 , Quantity: 1
        public string NumeroInscricaoEmpresa { get; set; } //Index: 19 , Quantity: 14
        public string NomeEmpresa { get; set; } //Index: 73 , Quantity: 30
    }
}
