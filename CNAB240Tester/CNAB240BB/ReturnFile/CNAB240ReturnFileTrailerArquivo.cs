using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.ReturnFile
{
    public class CNAB240ReturnFileTrailerArquivo
    {
        //Dados de Controle
        public string Banco { get; set; } //Código do Banco na Compensação 1 3 3 - '001'
        public string Lote { get; set; } //Lote de Serviço 4 7 5 - '9999'
        public string Registro { get; set; } //Registro Header de Arquivo 8 8 1 - '9'
        public string CNABDadosControle { get; set; } //Uso exclusivo FEBRABAN 9 17 9 - Brancos

        //Dados de Arquivo
        public int QtdeLotes { get; set; } //Quantidade de lotes do arquivo 18 23 6 - Numérico(Reg.Tipos 1)
        public int QtdeRegistros { get; set; } //Quantidade de registros arquivo 24 29 6 - Numérico(R.0+1+3+5+9)
        public int QtdeConcil { get; set; } //Quant.contas para conciliação 30 35 6 - '000000'
        public string CNABDadosArquivo { get; set; } // Uso exclusivo FEBRABAN 36 240 205 - Brancos
    }
}
