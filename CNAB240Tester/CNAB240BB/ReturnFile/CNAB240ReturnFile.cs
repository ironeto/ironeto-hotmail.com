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

                int qtdeRegistros_0_1_3_5_9 = 0;
                StringBuilder lineBuilder = new StringBuilder();

                #region HEADER
                qtdeRegistros_0_1_3_5_9++;

                //Dados de Controle
                lineBuilder.Append(FormatField(false, Header.Banco, 3, "001"));
                lineBuilder.Append(FormatField(false, Header.Lote, 4, "0000"));
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
                lineBuilder.Append(FormatField(true, !Header.DataGeracao.HasValue ? DateTime.Now.ToString("ddMMyyyy") : Header.DataGeracao.Value.ToString("ddMMyyyy"), 8));
                lineBuilder.Append(FormatField(true, !Header.DataGeracao.HasValue ? DateTime.Now.ToString("HHmmss") : Header.HoraGeracao, 6));
                lineBuilder.Append(FormatField(false, Header.Sequencia, 6));
                lineBuilder.Append(FormatField(false, Header.Layout, 3, "040"));
                lineBuilder.Append(FormatField(true, Header.Densidade, 5, "00000"));
                lineBuilder.Append(FormatField(true, Header.Reservado1, 20));
                lineBuilder.Append(FormatField(true, Header.Reservado2, 20));
                lineBuilder.Append(FormatField(true, Header.CNABDadosArquivo, 11));
                lineBuilder.Append(FormatField(true, Header.Identificacao, 3));
                lineBuilder.Append(FormatField(false, Header.ControleVANS, 3, "000"));
                lineBuilder.Append(FormatField(false, Header.Servico, 2, "00"));
                lineBuilder.Append(FormatField(false, Header.Ocorrencias, 10));
                lineBuilder.AppendLine();
                //gravaLinha.WriteLine(lineBuilder.ToString());

                #endregion

                #region LOTES
                foreach (var hLote in this.Lotes)
                {
                    #region Header Lote - 1
                    qtdeRegistros_0_1_3_5_9++;

                    //lineBuilder.Clear();

                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.Banco, 3, "001"));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.Lote, 4, "0000"));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.Registro, 1, "1"));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.TipoOpercao, 1, "C"));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.TipoServico, 1, "30"));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.VersaoArquivoLote, 3, "042"));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.FebrabanCnab, 1));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.TipoInscricao, 1, "2"));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.Inscricao, 14));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Convenio, 20, "9999999990126"));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.NrConvenioPagamento, 9));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.BB2, 4, "0126"));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.BB3, 5));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.BB4, 2));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.CodAgencia, 5));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.DVAgencia, 1));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.NumeroConta, 12));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.DVConta, 1));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.DV, 1, "0"));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Nome, 30));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Mensagem1, 40));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Logradouro, 30));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.NumeroLogradouro, 5));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.CasaAptoSala, 15));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Cidade, 20));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.CEP, 5));
                    lineBuilder.Append(FormatField(false, hLote.HeaderLote.ComplemCEP, 3));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Estado, 2));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.FebrabanCnab2, 8));
                    lineBuilder.Append(FormatField(true, hLote.HeaderLote.Ocorrencias, 10));

                    lineBuilder.AppendLine();
                    //gravaLinha.WriteLine(lineBuilder);
                    #endregion

                    #region Segmento J - 3
                    int NrRegistro = 0;
                    hLote.TrailerLote.Valor = 0;
                    hLote.TrailerLote.QtdeMoedas = 0;

                    foreach (var segJ in hLote.SegmentoJ)
                    {
                        qtdeRegistros_0_1_3_5_9++;
                        //lineBuilder.Clear();
                        NrRegistro++;
                        segJ.NrRegistro = NrRegistro;
                        hLote.TrailerLote.Valor += segJ.ValorPagto;
                        hLote.TrailerLote.QtdeMoedas += segJ.QtdadeMoeda;

                        //Dados de Controle
                        lineBuilder.Append(FormatField(false, segJ.Banco, 3, "001"));
                        lineBuilder.Append(FormatField(false, segJ.Lote, 4, "0000"));
                        lineBuilder.Append(FormatField(false, segJ.Registro, 1, "3"));
                        lineBuilder.Append(FormatField(false, segJ.NrRegistro.ToString(), 5));
                        lineBuilder.Append(FormatField(true, segJ.Segmento, 1,"J"));
                        lineBuilder.Append(FormatField(true, segJ.TipoMovto, 1, "0"));
                        lineBuilder.Append(FormatField(true, segJ.CodMovimento, 2, "00"));

                        //Dados de Titulo
                        lineBuilder.Append(FormatField(true, segJ.Banco, 3));
                        lineBuilder.Append(FormatField(true, segJ.CodigoMoedaDadosTitulo, 1));
                        lineBuilder.Append(FormatField(true, segJ.DV, 1));
                        lineBuilder.Append(FormatField(true, segJ.Valor.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(".", string.Empty), 14));
                        lineBuilder.Append(FormatField(false, segJ.CampoLivre, 25));
                        lineBuilder.Append(FormatField(true, segJ.NomeCedente, 30));
                        lineBuilder.Append(FormatField(false, segJ.DataVencto.ToString("ddMMyyyy"), 8));
                        lineBuilder.Append(FormatField(false, segJ.ValorTitulo.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(".", string.Empty), 15));
                        lineBuilder.Append(FormatField(false, segJ.Desconto.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(".", string.Empty), 15));
                        lineBuilder.Append(FormatField(false, segJ.Acrescimos.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(".", string.Empty), 15));
                        lineBuilder.Append(FormatField(false, segJ.DataPagto.ToString("ddMMyyyy"), 8));
                        lineBuilder.Append(FormatField(false, segJ.ValorPagto.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(".", string.Empty), 15));
                        lineBuilder.Append(FormatField(false, segJ.QtdadeMoeda.ToString("0.00000", System.Globalization.CultureInfo.InvariantCulture).Replace(".", string.Empty), 15));
                        lineBuilder.Append(FormatField(true, segJ.Referencia, 20));
                        lineBuilder.Append(FormatField(true, segJ.NossoNumero, 20));
                        lineBuilder.Append(FormatField(false, segJ.CodigoMoedaDadosTitulo2, 2, "09"));
                        lineBuilder.Append(FormatField(true, segJ.CNABDadosTitulo, 6));
                        lineBuilder.Append(FormatField(true, segJ.Ocorrencias, 10));
                        lineBuilder.AppendLine();
                        //gravaLinha.WriteLine(lineBuilder);
                    }
                    #endregion

                    #region Trailer Lote - 5
                    //lineBuilder.Clear();
                    hLote.TrailerLote.QtdeRegistros = NrRegistro + 2;
                    qtdeRegistros_0_1_3_5_9++;

                    //Dados de Controle
                    lineBuilder.Append(FormatField(false, hLote.TrailerLote.Banco, 3, "001"));
                    lineBuilder.Append(FormatField(false, hLote.TrailerLote.Lote, 4, "0000"));
                    lineBuilder.Append(FormatField(false, hLote.TrailerLote.Registro, 1, "5"));
                    lineBuilder.Append(FormatField(true, hLote.TrailerLote.CNABDadosControle, 9));

                    //Dados de Arquivo
                    lineBuilder.Append(FormatField(false, hLote.TrailerLote.QtdeRegistros.ToString(), 6));
                    lineBuilder.Append(FormatField(false, hLote.TrailerLote.Valor.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture).Replace(".", string.Empty), 18));
                    lineBuilder.Append(FormatField(false, hLote.TrailerLote.QtdeMoedas.ToString("0.00000", System.Globalization.CultureInfo.InvariantCulture).Replace(".", string.Empty), 18));
                    lineBuilder.Append(FormatField(false, hLote.TrailerLote.NrAviso, 6));
                    lineBuilder.Append(FormatField(true, hLote.TrailerLote.CNABDadosArquivo, 165));
                    lineBuilder.Append(FormatField(true, hLote.TrailerLote.Ocorrencias, 10));
                    lineBuilder.AppendLine();
                    //gravaLinha.WriteLine(lineBuilder);
                    #endregion
                }
                #endregion

                #region Trailer de Arquivo
                qtdeRegistros_0_1_3_5_9++;
                //lineBuilder.Clear();
                Trailer.QtdeLotes = Lotes.Count;
                Trailer.QtdeRegistros = qtdeRegistros_0_1_3_5_9;
                Trailer.QtdeConcil = 0;

                //Dados de Controle
                lineBuilder.Append(FormatField(false, Trailer.Banco, 3, "001"));
                lineBuilder.Append(FormatField(false, Trailer.Lote, 4, "0000"));
                lineBuilder.Append(FormatField(false, Trailer.Registro, 1, "9"));
                lineBuilder.Append(FormatField(true, Trailer.CNABDadosControle, 9));

                //Dados de Arquivo
                lineBuilder.Append(FormatField(false, Trailer.QtdeLotes.ToString(), 6));
                lineBuilder.Append(FormatField(false, Trailer.QtdeRegistros.ToString(), 6));
                lineBuilder.Append(FormatField(false, Trailer.QtdeConcil.ToString(), 6));
                lineBuilder.Append(FormatField(true, Trailer.CNABDadosArquivo, 205));
                //gravaLinha.WriteLine(lineBuilder.ToString());

                #endregion
                gravaLinha.WriteLine(lineBuilder.ToString());
                gravaLinha.Flush();
                
                return ms;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar arquivo.", ex);
            }
        }

    }
}
