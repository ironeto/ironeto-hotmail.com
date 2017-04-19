using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.ReturnFile
{
    public class CNAB240ReturnFileHeader
    {

    //Dados de Controle
    public string Banco { get; set; } //Código do Banco na Compensação 1 3 3 - '001'
    public string Lote { get; set; } //Lote de Serviço 4 7 5 - '0000'
    public string Registro { get; set; } //Registro Header de Arquivo 8 8 1 - '0'
    public string CNABDadosControle { get; set; } //Uso exclusivo FEBRABAN/CNAB 9 17 9 - Brancos

    //Dados da Empresa
    public string TipoInscricao { get; set; } //Tipo de inscrição da empresa 18 18 1 - '1' = CPF, '2' = CGC
    public string Inscricao { get; set; } //Numero da inscrição da emrpesa 19 32 14 - Numérico
    public string Convenio { get; set; } //Código do convênio do Banco 33 52 20 - Alfanumérico
    public string CodAgencia { get; set; } //Agência mantenedora da conta 53 57 5 - Numérico
    public string DVAgencia { get; set; } //Dígito verificador da Agência 58 58 1 - Alfanumérico
    public string NumeroConta { get; set; }//Número da Conta Corrente 59 70 12 - Numérico
    public string DVConta { get; set; } //Dígito verificador Conta Corrente 71 71 1 - Alfanumérico
    public string DV { get; set; } //Dígito verificador da Ag/Conta 72 72 1 - '0'
    public string Nome { get; set; } //Nome da Empresa 73 102 30 - Alfanumérico
    public string NomeBanco { get; set; } //Nome do Banco 103 132 30 - 'BANCO DO BRASIL'
    public string CNABDadosEmpresa { get; set; }//Uso exclusivo da FEBRABAN 133 142 10 - Brancos

    //Dados do arquivo
    public string Codigo { get; set; }//Código Remessa/Retorno 143 143 1 - '2' = Retorno    
    public DateTime? DataGeracao { get; set; }//Data de geração do arquivo 144 151 8 - Numérico(DDMMAAAA)
    public string HoraGeracao { get { return DataGeracao.HasValue ? DataGeracao.Value.ToString("HHmmss") : null; } }//Hora de geração do arquivo 152 157 6 - Numérico(HHMMSS)
    public string Sequencia { get; set; }//Nº sequencial do arquivo 158 163 6 - Sequencial numérico
    public string Layout { get; set; }//Nº da versão do layout do arquivo 164 166 3 - '040'
    public string Densidade { get; set; }//Densidade de gravação do arquivo 167 171 5 - '00000'
    public string Reservado1 { get; set; }//Uso reservado do Banco 172 191 20 - Alfanumérico
    public string Reservado2 { get; set; }//Uso reservado da Empresa 192 211 20 - Alfanumérico
    public string CNABDadosArquivo { get; set; }//Uso exclusivo da FEBRABAN 212 222 11 - Brancos
    public string Identificacao { get; set; } //Identificação cobrança sem papel 223 225 3 - Brancos
    public string ControleVANS { get; set; }//Uso exclusivo das VANS 226 228 3 - '000'
    public string Servico { get; set; } //Tipo de Serviço 229 230 2 - '00'
    public string Ocorrencias { get; set; }//Códigos de ocorrências 231 240 10 - '0000000000'
    }
}
