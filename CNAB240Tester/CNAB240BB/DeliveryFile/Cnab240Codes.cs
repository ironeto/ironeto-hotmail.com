using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNAB240BB.DeliveryFile
{
    public static class Cnab240Codes
    {
        public static Cnab240Code ProcessingFile = new Cnab240Code() { Code = Cnab240EnumCodes.ProcessingFile, Occurrence = "" };
        public static Cnab240Code InvalidFileFormat = new Cnab240Code() { Code = Cnab240EnumCodes.InvalidFileFormat, Occurrence = "" };
        public static Cnab240Code CompanyNotFound = new Cnab240Code() { Code = Cnab240EnumCodes.CompanyNotFound, Occurrence = "AE" };
        public static Cnab240Code UserNotFound = new Cnab240Code() { Code = Cnab240EnumCodes.UserNotFound, Occurrence = "AT" };
        public static Cnab240Code CreditInsertedSuccessfully = new Cnab240Code() { Code = Cnab240EnumCodes.CreditInsertedSuccessfully, Occurrence = "00" };
        public static Cnab240Code InsufficientFunds = new Cnab240Code() { Code = Cnab240EnumCodes.InsufficientFunds, Occurrence = "01" };
        public static Cnab240Code FileSuccessfullyProcessed = new Cnab240Code() { Code = Cnab240EnumCodes.FileSuccessfullyProcessed, Occurrence = "" };
        public static Cnab240Code InvalidFormatPaymentValue = new Cnab240Code() { Code = Cnab240EnumCodes.InvalidFormatPaymentValue, Occurrence = "AR" };
    }
}
