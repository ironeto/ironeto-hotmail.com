using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CNAB240Tester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(tbxSaldo.Text))
                {
                    MessageBox.Show("Por favor, informe o saldo.");
                    return;
                }

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.DefaultExt = "*.txt";
                if (openFileDialog.ShowDialog() == true)
                {
                    var ret = new FileProcessing().ImportFile(new StreamReader(openFileDialog.FileName).BaseStream, Convert.ToDecimal(tbxSaldo.Text));

                    switch (ret.Status.Code)
                    {
                        case CNAB240BB.DeliveryFile.Cnab240EnumCodes.ProcessingFile:
                            MessageBox.Show("Erro em: Processando arquivo...");
                            break;
                        case CNAB240BB.DeliveryFile.Cnab240EnumCodes.InvalidFileFormat:
                            MessageBox.Show("Arquivo com formato inválido");
                            break;
                        case CNAB240BB.DeliveryFile.Cnab240EnumCodes.InvalidFormatPaymentValue:
                            MessageBox.Show("Formato de valor inválido");
                            break;
                        case CNAB240BB.DeliveryFile.Cnab240EnumCodes.CompanyNotFound:
                            MessageBox.Show("Cliente não encontrado");
                            break;
                        case CNAB240BB.DeliveryFile.Cnab240EnumCodes.UserNotFound:
                            MessageBox.Show("Funcionário não encontrado");
                            break;
                        case CNAB240BB.DeliveryFile.Cnab240EnumCodes.ErroProcessingLine:
                            MessageBox.Show("Erro ao processar arquivo");
                            break;
                        case CNAB240BB.DeliveryFile.Cnab240EnumCodes.CreditInsertedSuccessfully:
                            MessageBox.Show("Crédito realizado com sucesso!");
                            break;
                        case CNAB240BB.DeliveryFile.Cnab240EnumCodes.InsufficientFunds:
                            MessageBox.Show("Fundos insuficientes");
                            break;
                        case CNAB240BB.DeliveryFile.Cnab240EnumCodes.FileSuccessfullyProcessed:
                            MessageBox.Show("Arquivo processado com sucesso");
                            break;
                        default:
                            MessageBox.Show("Retorno não tratado!!!");
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
