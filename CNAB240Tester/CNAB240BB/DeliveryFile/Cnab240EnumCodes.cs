﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.DeliveryFile
{
    public enum Cnab240EnumCodes : int
    {
        ProcessingFile = 1,
        InvalidFileFormat = 2,
        InvalidFormatPaymentValue = 3,
        CompanyNotFound = 4,
        UserNotFound = 5,
        ErroProcessingLine = 6,
        CreditInsertedSuccessfully = 7,
        InsufficientFunds = 8,
        FileSuccessfullyProcessed = 9,
    }
}
