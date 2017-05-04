using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.ReturnFile
{
    public class CNAB240ReturnFileHeaderLote
    {
        //Dados de Controle
        public string Banco { get; set; } //Código do Banco na Compensação 1 3 3 - '001'
        public string Lote { get; set; } //Lote de Serviço 4 7 5 - '0000'
        public string Registro { get; set; } //Registro Header de Arquivo 8 8 1 - '0'
        public string TipoOpercao { get; set; }
        public string TipoServico { get; set; }
        public string FormaLancamento { get; set; }
        public string VersaoArquivoLote { get; set; }
        public string FebrabanCnab { get; set; }

        //Dados da Empresa
        public string TipoInscricao { get; set; }
        public string Inscricao { get; set; }
        public string Convenio { get; set; }
        public string NrConvenioPagamento { get; set; }
        public string BB2 { get; set; }
        public string BB3 { get; set; }
        public string BB4 { get; set; }
        public string CodAgencia { get; set; } //Agência mantenedora da conta 53 57 5 - Numérico
        public string DVAgencia { get; set; } //Dígito verificador da Agência 58 58 1 - Alfanumérico
        public string NumeroConta { get; set; }//Número da Conta Corrente 59 70 12 - Numérico
        public string DVConta { get; set; } //Dígito verificador Conta Corrente 71 71 1 - Alfanumérico
        public string DV { get; set; } //Dígito verificador da Ag/Conta 72 72 1 - '0'
        public string Nome { get; set; } //Nome da Empresa 73 102 30 - Alfanumérico
        public string Mensagem1 { get; set; }
        public string Logradouro { get; set; } // Nome da Rua, Av., etc 143 172 40 - Alfanumérico
        public string NumeroLogradouro { get; set; } // Nº do local 173 177 5 - Numérico
        public string CasaAptoSala { get; set; } //Caso, Apto, Sala, etc 178 192 18 - Alfanumérico
        public string Cidade { get; set; } //Nome da cidade 193 212 20 - Alfanumérico
        public string CEP { get; set; } //CEP 213 217 5 - Numérico
        public string ComplemCEP { get; set; } // Complemento do CEP 218 220 3 - Alfanumérico
        public string Estado { get; set; } //Sigla do Estado 221 222 2 - Alfanumérico
        public string FebrabanCnab2 { get; set; } //Uso exclusivo da FEBRABAN 223 230 8 - Brancos
        public string Ocorrencias { get; set; } //Cód. das ocorrências RETORNOS 231 240 10 - Ver Tabela
    }
}
