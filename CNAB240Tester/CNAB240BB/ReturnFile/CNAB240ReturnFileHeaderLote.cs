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
        public string Banco { get; set; } // Código do Banco na Compensação 1 3 3 - '001'
        public string Lote { get; set; } // Lote de Serviço 4 7 5 - Sequencial numérico
        public string Registro { get; set; } //Registro Header de Lote 8 8 1 - '1'

        //Dados de Serviço
        public string Operacao { get; set; } // Tipo de Operação 9 9 1 - 'T'
        public string Servico { get; set; } // Tipo de Serviço 41 44 2 - '98'
        public string FormaLancam { get; set; } //Forma de lançamento 12 13 2 - '30'-Tít.BB '31'-Tít.Outros bancos
        public string LayoutDoLote { get; set; } // Nº da versão do layout do lote 14 16 3 - '030'
        public string CNAB { get; set; } // Uso exclusivo da FEBRABAN 17 17 1 - Brancos

        //Dados da Empresa
        public string TipoInscricao { get; set; } // Tipo de inscrição da empresa 18 18 1 - '1' = CPF, '2' = CGC
        public string Inscricao { get; set; } // Número da inscrição da emrpesa 19 32 14 - Numérico
        public string Convenio { get; set; } // Código do convênio do Banco 33 52 20 - Alfanumérico
        public string CodAgencia { get; set; } // Agência mantenedora da conta 53 57 5 - Numérico
        public string DVAgencia { get; set; } // Dígito verificador da Agência 58 58 1 - Alfanumérico
        public string NumeroConta { get; set; } // Número da Conta Corrente 59 70 12 - Numérico
        public string DVConta { get; set; } // Dígito verificador Conta Corrente 71 71 1 - Alfanumérico
        public string DV { get; set; } //Dígito verificador da Ag/Conta 72 72 1 - '0'
        public string Nome { get; set; } // Nome da Empresa 73 102 30 - Alfanumérico
        public string Informacao { get; set; } // 1 Mensagem 103 142 40 - Brancos
        public string Logradouro { get; set; } // Nome da Rua, Av., etc 143 172 40 - Alfanumérico
        public string Numero { get; set; } // Nº do local 173 177 5 - Numérico
        public string Complemento { get; set; } //Caso, Apto, Sala, etc 178 192 18 - Alfanumérico
        public string Cidade { get; set; } //Nome da cidade 193 212 20 - Alfanumérico
        public string CEP { get; set; } //CEP 213 217 5 - Numérico
        public string ComplemCEP { get; set; } // Complemento do CEP 218 220 3 - Alfanumérico
        public string Estado { get; set; } //Sigla do Estado 221 222 2 - Alfanumérico
        public string CNAB2 { get; set; } //Uso exclusivo da FEBRABAN 223 230 8 - Brancos
        public string Ocorrencias { get; set; } //Cód. das ocorrências RETORNOS 231 240 10 - Ver Tabela
    }
}
