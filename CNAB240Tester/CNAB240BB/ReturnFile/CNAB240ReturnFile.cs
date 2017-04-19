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

        string FormatField(bool isAlphanumeric, string field, int length)
        {
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
                _header.Append(FormatField(false,Header.Banco,3));
                _header.Append(FormatField(false, Header.Lote, 4));
                _header.Append(FormatField(true, Header.CNAB, 9));

                //Dados da Empresa
                _header.Append(FormatField(false, Header.TipoInscricao, 1));
                _header.Append(FormatField(false, Header.Inscricao, 14));
                _header.Append(FormatField(true, Header.Convenio, 20));


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
