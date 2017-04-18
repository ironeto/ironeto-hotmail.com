using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.DeliveryFile
{
    public enum Cnab240Codes : int
    {
        ProcessingFile = 1,
        InvalidFileFormat = 2,
        ErrorProcessingFile = 3,
        CompanyNotFound = 4,
        UserNotFound = 5,
        ErroProcessingLine = 6,
        CreditInsertedSuccessfully = 7,
        InsufficientFunds = 8,
        FileSuccessfullyProcessed = 9,
        FileProcessedWithErrors = 10,
    }
}
