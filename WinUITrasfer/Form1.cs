using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinUITrasfer.Exseption;
using WinUITrasfer.Op;

namespace WinUITrasfer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Sends_Click(object sender, EventArgs e)
        {
            
            Transfer transfer = new Transfer();
           
                decimal amount = Convert.ToDecimal(txtAmmount.Text);
           
              bool isOperationSuccesFull=  transfer.TranserfMoney(txtFrom.Text, txtTo.Text, amount);
            if (isOperationSuccesFull)
            {
                MessageBox.Show("Moeny SuccessFull Send");
            }
            else
            {
                MessageBox.Show("Money Not Send ");
            }
           
        }
    }
}
