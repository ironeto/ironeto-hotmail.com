using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.DeliveryFile
{
    public class CNAB240SegmentoA
    {
        public string TipoMoeda { get; set; } //Index: 102 , Quantity: 3
        public double QuantidadeMoeda { get; set; } //Index: 105 , Quantity: 10, Decimal: 5
        public decimal ValorPagamento { get; set; } //Index: 120 , Quantity: 13, Decimal: 2
        public string NomeFavorecido { get; set; }  //Index: 44 , Quantity: 30
        public DateTime DataPagamento { get; set; }//Index: 94 , Quantity: 8

    }
}
