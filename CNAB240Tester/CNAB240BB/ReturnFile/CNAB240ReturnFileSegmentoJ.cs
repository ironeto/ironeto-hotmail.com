using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.ReturnFile
{
    public class CNAB240ReturnFileSegmentoA
    {
        //Dados de Controle
        public string Banco { get; set; } //Código do Banco na Compensação 1 3 3 - '001'
        public string Lote { get; set; } //Lote de Serviço 4 7 5 - Sequencial numérico
        public string Registro { get; set; } //Registro de Detalhe 8 8 1 - '3'
        public int NrRegistro { get; set; } //Nº sequencial do registro detalhe 9 13 5 - Numérico
        public string Segmento { get; set; } //Cód.segmento do registro detalhe 14 14 1 - 'J'
        public string TipoMovto { get; set; } //Tipo de movimento 15 15 1 - '0'-Inclusão '9'-Exclusão
        public string CodMovimento { get; set; } //Código de instrução para alteração 16 17 2 - '00' - Inclusão '99' - Exclusão
        public string CodCamaraCentralizadora { get; set; } //Código de instrução para alteração 16 17 2 - '00' - Inclusão '99' - Exclusão

        //Dados de Título
        public string BancoFavorecido { get; set; } 
        public string AgenciaMantenedoraFavorecido { get; set; }
        public string DVAgenciaMantenedoraFavorecido { get; set; }
        public string ContaCorrente { get; set; }
        public string DVContaCorrente { get; set; }
        public string DVAgenciaConta { get; set; }
        public string NomeFavorecido { get; set; }
        public string NrDocumentoAtribuidoEmpresa { get; set; }
        public DateTime DataPagto { get; set; }
        public string TipoMoeda { get; set; }
        public decimal QtdadeMoeda { get; set; }
        public decimal ValorPagto { get; set; }
        public string NumeroAtribuidoBanco { get; set; }
        public DateTime DataRealEfetivacaoPagto { get; set; }
        public decimal ValorRealEfetivacaoPagto { get; set; }
        public string OutrasInformacoes { get; set; }
        public string ComplementoTipoServico { get; set; }
        public string CodFinalidadeTED { get; set; }
        public string ComplementoFinalidadePagto { get; set; }
        public string FebrabanCnab { get; set; }
        public string AvisoAoFavorecido { get; set; }
        public string Ocorrencias { get; set; }
    }
}
