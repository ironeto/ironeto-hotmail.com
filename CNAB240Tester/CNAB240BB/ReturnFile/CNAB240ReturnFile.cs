using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.ReturnFile
{
    public class CNAB240ReturnFile
    {

        public CNAB240ReturnFileHeader Header { get; set; }
        public List<CNAB240ReturnFileLote> Lotes { get; set; }
        public CNAB240ReturnFileTrailerArquivo Trailer { get; set; }

        public CNAB240ReturnFile(CNAB240ReturnFileHeader Header, List<CNAB240ReturnFileLote> Lotes, CNAB240ReturnFileTrailerArquivo Trailer)
        {
            this.Header = Header;
            this.Lotes = Lotes;
            this.Trailer = Trailer;
        }

        string IfNull(string str)
        {
            return (string.IsNullOrEmpty(str) ? string.Empty : str);
        }

        string FormatField(bool isAlphanumeric, string field, int length, string defaultValue = null)
        {
            if(string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(defaultValue))
            {
                field = defaultValue;
            }

            if(isAlphanumeric)
            {
                return IfNull(field).PadRight(length, ' ').Substring(0, length);
            }
            else
            {
                return IfNull(field).PadLeft(length, '0').Substring(0, length);
            }
        }

        public MemoryStream GeraArquivoCNAB240BB()
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                StreamWriter gravaLinha = new StreamWriter(ms);


                StringBuilder lineBuilder = new StringBuilder();
                #region HEADER

                //Dados de Controle
                lineBuilder.Append(FormatField(false, Header.Banco, 3, "001"));
                lineBuilder.Append(FormatField(false, Header.Lote, 5, "00000"));
                lineBuilder.Append(FormatField(false, Header.Registro, 1, "0"));
                lineBuilder.Append(FormatField(true, Header.CNABDadosControle, 9));

                //Dados da Empresa
                lineBuilder.Append(FormatField(false, Header.TipoInscricao, 1, "2"));
                lineBuilder.Append(FormatField(false, Header.Inscricao, 14));
                lineBuilder.Append(FormatField(true, Header.Convenio, 20));

                lineBuilder.Append(FormatField(false, Header.CodAgencia, 5));
                lineBuilder.Append(FormatField(true, Header.DVAgencia, 1));
                lineBuilder.Append(FormatField(false, Header.NumeroConta, 12));
                lineBuilder.Append(FormatField(true, Header.DVConta, 1));
                lineBuilder.Append(FormatField(false, Header.DV, 1 , "0"));
                lineBuilder.Append(FormatField(true, Header.Nome, 30));
                lineBuilder.Append(FormatField(true, Header.NomeBanco, 30, "OPA!"));
                lineBuilder.Append(FormatField(true, Header.CNABDadosEmpresa, 10));

                //Dados do arquivo
                lineBuilder.Append(FormatField(false, Header.Codigo, 1, "2"));
                lineBuilder.Append(FormatField(true, Header.DataGeracao.HasValue ? DateTime.Now.ToString("ddMMyyyy") : Header.DataGeracao.Value.ToString("ddMMyyyy"), 20));
                lineBuilder.Append(FormatField(true, Header.DataGeracao.HasValue ? Header.HoraGeracao : DateTime.Now.ToString("HHmmss"), 20));
                lineBuilder.Append(FormatField(false, Header.Sequencia, 6));
                lineBuilder.Append(FormatField(true, Header.Densidade, 5, "00000"));
                lineBuilder.Append(FormatField(true, Header.Reservado1, 20));
                lineBuilder.Append(FormatField(true, Header.Reservado2, 20));
                lineBuilder.Append(FormatField(true, Header.CNABDadosArquivo, 11));
                lineBuilder.Append(FormatField(true, Header.Identificacao, 3));
                lineBuilder.Append(FormatField(false, Header.ControleVANS, 3, "000"));
                lineBuilder.Append(FormatField(false, Header.Servico, 2, "00"));
                lineBuilder.Append(FormatField(false, Header.Ocorrencias, 10));


                gravaLinha.WriteLine(lineBuilder.ToString());

                #endregion

                #region LOTES
                foreach (var hLote in this.Lotes)
                {

                    lineBuilder = new StringBuilder();

                    //Dados de Controle
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.Banco, 3, "001"));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.Lote, 5, "00000"));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.Registro, 1, "0"));

                    //Dados de Serviço
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Operacao, 1,"T"));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.TipoInscricao, 2, "98"));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.FormaLancam, 2, "30"));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.LayoutDoLote, 3, "030"));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.CNABDadosServico, 1));

                    //Dados da Empresa
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.TipoInscricao, 1, "2"));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.Inscricao, 14));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Convenio, 20));

                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.CodAgencia, 5));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.DVAgencia, 1));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.NumeroConta, 12));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.DVConta, 1));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.DV, 1, "0"));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Nome, 30));


                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Informacao, 40));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Logradouro, 40));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.NumeroLogradouro, 5));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.ComplementoLogradouro, 18));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Cidade, 20));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.CEP, 5));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.ComplemCEP, 3));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Estado, 2));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.CNABDadosEmpresa, 8));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Ocorrencias, 10));

                    gravaLinha.WriteLine(lineBuilder);

                    #region Segmento J
                    foreach (var segJ in hLote.SegmentoJ)
                    {

                    }
                    #endregion
                }

                #endregion


                gravaLinha.Close();

                return ms;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar arquivo.", ex);
            }
        }

    }
}
