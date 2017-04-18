using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.DeliveryFile
{
    public class CNAB240
    {
        public CNAB240Header Header { get; set; }
        public List<CNAB240Detail> Details { get; set; }
        public Stream File { get; set; }

        public CNAB240(Stream File)
        {
            this.File = File;
            Details = new List<CNAB240Detail>();
            ExplodeFile();
        }

        void ExplodeFile()
        {
            string strLine = null;
            var srFile = new StreamReader(File);

            var SegA = new CNAB240SegmentoA();
            var SegB = new CNAB240SegmentoB();
            while ((strLine = srFile.ReadLine()) != null)
            {
                object ret = LineProcessing(strLine);

                if(ret is CNAB240Header)
                {
                    this.Header = ret as CNAB240Header;
                }
                else if (ret is CNAB240SegmentoA)
                {
                    SegA = ret as CNAB240SegmentoA;
                }
                else if (ret is CNAB240SegmentoB)
                {
                    SegB = ret as CNAB240SegmentoB;
                    Details.Add(new CNAB240Detail()
                    {
                        SegmentoA = SegA,
                        SegmentoB = SegB,
                    });
                    SegA = null;
                    SegB = null;
                }

            }

            srFile.Close();
        }

        object LineProcessing(string strLine)
        {
            int RegistryType = 0;
            try
            {
                RegistryType = Convert.ToInt32(strLine.Substring(8 - 1, 1));
            }
            catch
            {
                throw new Exception("ARQUIVO INVALIDO", new Exception("REGISTRYTYPE"));
            }

            switch (RegistryType)
            {
                case 0: //Header
                    CNAB240Header header = null;
                    try
                    {
                        header = new CNAB240Header()
                        {
                            LoteServico = strLine.Substring(4 - 1, 4),
                            DataGeracaoArquivo = strLine.Substring(144 - 1, 8),
                            HoraGeracaoArquivo = strLine.Substring(152 - 1, 6),
                            NumeroSequencialArquivo = strLine.Substring(158 - 1, 6),
                            TipoInscricaoEmpresa = strLine.Substring(18 - 1, 1),
                            NumeroInscricaoEmpresa = strLine.Substring(19 - 1, 14),
                            NomeEmpresa = strLine.Substring(73 - 1, 30),
                        };
                    }
                    catch
                    {
                        throw new Exception("ARQUIVO INVALIDO", new Exception("HEADER"));
                    }
                    return header;
                case 1: //Header de Lote ABC
                    break;
                case 3: //Segmento ABC
                    string codSegmento = strLine.Substring(14 - 1, 1);
                    switch (codSegmento.ToUpper())
                    {
                        case "A":
                            var segA = new CNAB240SegmentoA()
                            {
                                TipoMoeda = strLine.Substring(102 - 1, 3),
                                QuantidadeMoeda = Convert.ToDouble(string.Format("{0}.{1}", strLine.Substring(105 - 1, 10), strLine.Substring(115 - 1, 5))),
                                ValorPagamento = Convert.ToDecimal(string.Format("{0}.{1}", strLine.Substring(120 - 1, 13), strLine.Substring(133 - 1, 2))),
                                NomeFavorecido = strLine.Substring(44 - 1, 30),
                                DataPagamento = DateTime.ParseExact(strLine.Substring(94 - 1, 8), "ddMMyyyy", null),
                            };
                            return segA;
                        case "B":
                            var segB = new CNAB240SegmentoB()
                            {
                                TipoInscricaoFavorecido = strLine.Substring(18 - 1, 1),
                                NumeroInscricaoFavorecido = strLine.Substring(19 - 1, 14),
                            };
                            return segB;
                        case "C":

                            break;
                        default:
                            throw new Exception("ARQUIVO INVALIDO", new Exception("SEGMENTO ABC"));
                    }
                    break;
                case 5: //Trailer de Lote ABC
                    break;
                default: //Ignora linha
                    break;
            }
            return null;
        }

    }
}
