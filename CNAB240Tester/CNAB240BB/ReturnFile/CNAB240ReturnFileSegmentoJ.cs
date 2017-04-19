using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.ReturnFile
{
    public class CNAB240ReturnFileSegmentoJ
    {
        //Dados de Controle
        public string Banco { get; set; } //Código do Banco na Compensação 1 3 3 - '001'
        public string Lote { get; set; } //Lote de Serviço 4 7 5 - Sequencial numérico
        public string Registro { get; set; } //Registro de Detalhe 8 8 1 - '3'
        public int NrRegistro { get; set; } //Nº sequencial do registro detalhe 9 13 5 - Numérico
        public string Segmento { get; set; } //Cód.segmento do registro detalhe 14 14 1 - 'J'
        public string TipoMovto { get; set; } //Tipo de movimento 15 15 1 - '0'-Inclusão '9'-Exclusão
        public string CodMovimento { get; set; } //Código de instrução para alteração 16 17 2 - '00' - Inclusão '99' - Exclusão

        //Dados de Título
        public string BancoTitulo { get; set; } //Código do Banco destino 18 20 3 - Numérico
        public string CodigoMoedaDadosTitulo { get; set; } // Código da moeda 21 21 1 - Numérico - 4º Registro no Código de Barras
        public string DV { get; set; } //Dígito verificador código de barras 22 22 1 - Numérico
        public decimal Valor { get; set; } //Valor impresso no cód.De barras 23 36 12 2 Numérico
        public string CampoLivre { get; set; } // Campo livre do código de barras 37 61 25 - Numérico
        public string NomeCedente { get; set; } // Nome do cedente 62 91 30 - Alfanumérico
        public DateTime DataVencto { get; set; } // Data do vencimento 92 99 8 - Numérico(DDMMAAAA)
        public decimal ValorTitulo { get; set; } // Valor do título 100 114 13 2 Numérico
        public decimal Desconto { get; set; } //Valor de Desconto + Abatimento 115 129 13 2 Numérico
        public decimal Acrescimos { get; set; } //Valor da Mora + Multa 130 144 13 2 Numérico
        public DateTime DataPagto { get; set; } //Data do pagamento 145 152 8 - Numérico(DDMMAAAA)
        public decimal ValorPagto { get; set; } //Valor do pagamento 153 167 13 2 Numérico
        public decimal QtdadeMoeda { get; set; } //Quantidade da moeda 168 182 10 5 '000000000000000'
        public string Referencia { get; set; } //Descrição do título 183 202 20 - Alfanumérico
        public string NossoNumero { get; set; } //Nº do doc.atribuído pelo banco 203 222 20 - Alfanumérico
        public string CodigoMoedaDadosTitulo2 { get; set; } //Código de moeda 223 224 2 - '09'
        public string CNABDadosTitulo { get; set; } //Uso exclusivo FEBRABA 225 230 6 - Brancos
        public string Ocorrencias { get; set; } // Cód.das ocorrências para retorno 231 240 10 - Ver Tabela
    }
}
