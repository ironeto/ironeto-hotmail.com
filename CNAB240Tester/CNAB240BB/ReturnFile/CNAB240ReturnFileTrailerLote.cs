using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.ReturnFile
{
    public class CNAB240ReturnFileTrailerLote
    {
        //Dados de Controle
        public string Banco { get; set; } //Código do Banco na Compensação 1 3 3 - '001'
        public string Lote { get; set; } //Lote de Serviço 4 7 5 - Sequencial numérico
        public string Registro { get; set; } //Registro Header de Arquivo 8 8 1 - '5'
        public string CNAB { get; set; } //Uso exclusivo FEBRABAN 9 17 9 - Brancos

        //Dados de Arquivo
        public string QtdeRegistros { get; set; } //Quantidade de registros do lote 18 23 6 - Numérico(Reg. 1+3+5)
        public string Valor { get; set; } //Somatória dos valores 24 41 16 2 Numérico(Reg.Tipos 3)
        public string QtdeMoedas { get; set; } //Somatória de quantidade moedas 42 59 13 5 '000000000000000000'
        public string NrAviso { get; set; } //Número aviso débito 60 65 6 - '000000'
        public string CNAB2 { get; set; } //Uso exclusivo FEBRABAN 66 230 165 - Brancos
        public string Ocorrencias { get; set; } //Cód.das ocorrências para retorno 231 240 10 - Ver Tabela
    }
}
