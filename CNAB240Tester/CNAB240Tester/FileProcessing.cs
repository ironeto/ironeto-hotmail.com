using CNAB240BB.DeliveryFile;
using CNAB240BB.ReturnFile;
using CNAB240Tester.DeliveryFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240Tester
{
    public class FileProcessing
    {
        void FillReturnFile(FileDto CNAB240File)
        {
            //Fill Header
            var header = new CNAB240ReturnFileHeader()
            {
                Inscricao = "123123123",
                Convenio = "222222222",
                CodAgencia = "1234",
                DVAgencia = "1",
                NumeroConta = "123123123",
                DVConta = "2",
                Nome = "Alvaro Augusto de Marco Neto ME",
                Sequencia = "1",
                Ocorrencias = CNAB240File.Status.Occurrence,
            };

            //Fill Lote
            int Lote = 1;
            var lstLotes = new List<CNAB240ReturnFileLote>();
            var retFileLote = new CNAB240ReturnFileLote()
            {
                //Fill Header Lote
                HeaderLote = new CNAB240ReturnFileHeaderLote()
                {
                    Lote = Lote.ToString(),
                    Inscricao = "123123",
                    Convenio = "123123",
                    CodAgencia = "123",
                    DVAgencia = "3",
                    NumeroConta = "123123",
                    DVConta = "4",
                    Nome = "Alvaro Augusto de Marco Neto ME",
                    Logradouro = "Rua Rudi Schaly",
                    NumeroLogradouro = "146",
                    ComplementoLogradouro = "",
                    Cidade = "São Paulo",
                    CEP = "05101",
                    ComplemCEP = "060",
                    Estado = "SP",
                    Ocorrencias = CNAB240File.Status.Occurrence,
                },
                SegmentoJ = new List<CNAB240ReturnFileSegmentoJ>(),

                //Fill Trailer Lote
                TrailerLote = new CNAB240ReturnFileTrailerLote()
                {
                    Lote = Lote.ToString(),
                }
            };

            //Iteração dos depósitos
            foreach (var depositDetail in CNAB240File.DepositDetails)
            {
                //Fill Segmento J
                retFileLote.SegmentoJ.Add(new CNAB240ReturnFileSegmentoJ()
                {
                    Lote = Lote.ToString(),
                    Banco = "123",
                    CodigoMoedaDadosTitulo = "1",
                    DV = "1",
                    Valor = depositDetail.Value,
                    CampoLivre = depositDetail.ChaveBuscaUsuario,
                    NomeCedente = depositDetail.Nome,
                    DataVencto = depositDetail.Date,                    
                    ValorTitulo = depositDetail.Value,                    
                    Desconto = 0,
                    Acrescimos = 0,
                    DataPagto = depositDetail.Date,
                    ValorPagto = depositDetail.Value,
                    Referencia = "123123",
                    NossoNumero = "1234567890",
                    Ocorrencias = depositDetail.Status.Occurrence,
                });
            }
            lstLotes.Add(retFileLote);

            //Fill Trailer
            var Trailer = new CNAB240ReturnFileTrailerArquivo()
            {
                Lote = Lote.ToString(),
                Banco = "123",
            };

            CNAB240File.ReturnFile = CreateCNAB240ReturnFile(header,lstLotes, Trailer);
            
            SaveMemoryStream(CNAB240File.ReturnFile, @"C:\Teste\ArquivoRetorno.txt");

        }

        public static void SaveMemoryStream(MemoryStream ms, string FileName)
        {
            FileStream outStream = File.OpenWrite(FileName);
            ms.WriteTo(outStream);
            outStream.Flush();
            outStream.Close();

            System.Diagnostics.Process.Start(FileName);
        }

        public FileDto ImportFile(Stream File)
        {
            var CNAB240File = new FileDto(Cnab240Codes.ProcessingFile);
            try
            {
                var fileCNABRet = ReadCNAB240(File);


                bool InsufficientFunds = false;
                bool FileProcessedWithErrors = false;
                decimal saldo = 10000;

                //Caso o header seja nulo, o arquivo importado é inválido
                if (fileCNABRet.Header == null || fileCNABRet.Details == null || fileCNABRet.Details.Count <= 0)
                {
                    CNAB240File.Status = Cnab240Codes.InvalidFileFormat;
                    CNAB240File.StatusDescription = "Não foi possível identificar o Header ou os Segmentos";
                    return CNAB240File;
                }

                if (fileCNABRet.Header.TipoInscricaoEmpresa != "2")
                {
                    CNAB240File.Status = Cnab240Codes.InvalidFileFormat;
                    CNAB240File.StatusDescription = "O tipo de inscrição da empresa não é CNPJ";
                    return CNAB240File;
                }

                string CNPJ = fileCNABRet.Header.NumeroInscricaoEmpresa;
                //Consultar CNPJ na base de dados
                if (!true)
                {
                    CNAB240File.Status = Cnab240Codes.CompanyNotFound;
                    CNAB240File.StatusDescription = "Esse CNPJ não está cadastrado na base de dados";
                    return CNAB240File;
                }

                foreach (var detalhe in fileCNABRet.Details)
                {
                    decimal valorASerCreditado = detalhe.SegmentoA.ValorPagamento;
                    string CPF = detalhe.SegmentoB.NumeroInscricaoFavorecido.Substring(3, 11);

                    //Consultar CPF na base de dados
                    if (!true)
                    {
                        CNAB240File.DepositDetails.Add(createDepositDTO(CPF, detalhe.SegmentoA.NomeFavorecido, detalhe.SegmentoA.DataPagamento, 0, Cnab240Codes.UserNotFound));
                    }
                    else
                    {
                        if (saldo - valorASerCreditado >= 0)
                        {
                            saldo -= valorASerCreditado;
                            CNAB240File.DepositDetails.Add(createDepositDTO(CPF, detalhe.SegmentoA.NomeFavorecido, detalhe.SegmentoA.DataPagamento, valorASerCreditado, Cnab240Codes.CreditInsertedSuccessfully));
                        }
                        else
                        {
                            InsufficientFunds = true;
                            CNAB240File.DepositDetails.Add(createDepositDTO(CPF, detalhe.SegmentoA.NomeFavorecido, detalhe.SegmentoA.DataPagamento, 0, Cnab240Codes.InsufficientFunds));
                        }
                    }
                }

                if (InsufficientFunds)
                {
                    CNAB240File.Status = Cnab240Codes.InsufficientFunds;
                }
                else
                {
                    CNAB240File.Status = Cnab240Codes.FileSuccessfullyProcessed;
                }

                //Gera arquivo de retorno
                FillReturnFile(CNAB240File);

                return CNAB240File;
            }
            catch (Exception ex)
            {
                switch (ex.Message.ToUpper())
                {
                    case "ARQUIVO INVALIDO":
                        CNAB240File.Status = Cnab240Codes.InvalidFileFormat;
                        CNAB240File.StatusDescription = (ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                        break;
                    default:
                        CNAB240File.Status = Cnab240Codes.InvalidFileFormat;
                        CNAB240File.StatusDescription = (ex.InnerException != null ? string.Format("{0} {1}", ex.Message, ex.InnerException.Message) : ex.Message);
                        break;
                }
                return CNAB240File;
            }
        }

        DepositDto createDepositDTO(string CPF, string Nome, DateTime Date, decimal Value, Cnab240Code Status)
        {
            return new DepositDto()
            {
                ChaveBuscaUsuario = CPF,
                Nome = Nome,
                Date = Date,
                Value = Value,
                Status = Status,
                Id = 1,
                CompanyId = 1,
                Tax = 1,
                Type = "PAYROLL = 4",
                UserId = 1,
            };
        }


        //Ler
        CNAB240 ReadCNAB240(Stream file) => new CNAB240(file);

        //Criar
        MemoryStream CreateCNAB240ReturnFile(CNAB240ReturnFileHeader Header, List<CNAB240ReturnFileLote> Lotes, CNAB240ReturnFileTrailerArquivo Trailer) => new CNAB240ReturnFile(Header,Lotes,Trailer).GeraArquivoCNAB240BB();
    }
}
