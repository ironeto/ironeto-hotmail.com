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


                #region HEADER
                StringBuilder _header = new StringBuilder();

                //Dados de Controle
                _header.Append(FormatField(false, Header.Banco, 3, "001"));
                _header.Append(FormatField(false, Header.Lote, 4, "0000"));
                _header.Append(FormatField(false, Header.Registro, 1, "0"));
                _header.Append(FormatField(true, Header.CNABDadosControle, 9));

                //Dados da Empresa
                _header.Append(FormatField(false, Header.TipoInscricao, 1, "2"));
                _header.Append(FormatField(false, Header.Inscricao, 14));
                _header.Append(FormatField(true, Header.Convenio, 20));

                _header.Append(FormatField(false, Header.CodAgencia, 5));
                _header.Append(FormatField(true, Header.DVAgencia, 1));
                _header.Append(FormatField(false, Header.NumeroConta, 12));
                _header.Append(FormatField(true, Header.DVConta, 1));
                _header.Append(FormatField(false, Header.DV, 1 , "0"));
                _header.Append(FormatField(true, Header.Nome, 30));
                _header.Append(FormatField(true, Header.NomeBanco, 30, "OPA!"));
                _header.Append(FormatField(true, Header.CNABDadosEmpresa, 10));

                //Dados do arquivo
                _header.Append(FormatField(false, Header.Codigo, 1, "2"));
                _header.Append(FormatField(true, Header.DataGeracao.HasValue ? DateTime.Now.ToString("ddMMyyyy") : Header.DataGeracao.Value.ToString("ddMMyyyy"), 20));
                _header.Append(FormatField(true, Header.DataGeracao.HasValue ? Header.HoraGeracao : DateTime.Now.ToString("HHmmss"), 20));
                _header.Append(FormatField(false, Header.Sequencia, 6));
                _header.Append(FormatField(true, Header.Densidade, 5, "00000"));
                _header.Append(FormatField(true, Header.Reservado1, 20));
                _header.Append(FormatField(true, Header.Reservado2, 20));
                _header.Append(FormatField(true, Header.CNABDadosArquivo, 11));
                _header.Append(FormatField(true, Header.Identificacao, 3));
                _header.Append(FormatField(false, Header.ControleVANS, 3, "000"));
                _header.Append(FormatField(false, Header.Servico, 2, "00"));
                _header.Append(FormatField(false, Header.Ocorrencias, 10));


                gravaLinha.WriteLine(_header);

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
