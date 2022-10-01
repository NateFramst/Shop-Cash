using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace Shop_Cash
{
    public partial class trueNorthDG : Form
    {
        double rainmakeramout;
        double DD3amount;
        double MD3amount;
        double rainmakerrate = 26.99;
        double DD3rate = 26.99;
        double MD3rate = 39.99;
        double subtotal;
        double tax;
        double taxrate = 0.13;
        double total;
        double payment;
        double change;
         
        public trueNorthDG()
        {
            InitializeComponent();
        }

        private void titleColour_Click(object sender, EventArgs e)
        {
            //Process.Start("https://truenorthdiscgolf.com/");
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                rainmakeramout = Convert.ToDouble(rainmakerAMount.Text);
                DD3amount = Convert.ToDouble(dd3LabelAmount.Text);
                MD3amount = Convert.ToDouble(md3LabelAmount.Text);

                subtotal = (rainmakeramout * rainmakerrate) + (DD3amount * DD3rate) + (MD3amount * MD3rate);
                subtotalOutput.Text = $" Subtotal Amount:   {subtotal.ToString("C")}";

                tax = (subtotal * taxrate);
                taxOutput.Text = $" Tax Amount:          {tax.ToString("C")}";

                total = tax + subtotal;
                totalOutput.Text = $" Total Cost:             {total.ToString("C")}";

                paymentInput.Enabled = true;
                paymentButton.Enabled = true;


                rainmakerAMount.Enabled = false;
                dd3LabelAmount.Enabled = false;
                md3LabelAmount.Enabled = false;
            }
            catch {

                titleColour.Text = $" TRY USING NUMBERS STUPID";
                Refresh();
                Thread.Sleep(1000);
                titleColour.Text = $" ";
                Refresh();
                Thread.Sleep(1000);
                Refresh();
                titleColour.Text = $" TRY USING NUMBERS STUPID";
                Refresh();
                Thread.Sleep(1000);
                titleColour.Text = $" True North Disc Golf";
                Refresh();
            }

        }

  
        private void newOrderButton_Click(object sender, EventArgs e)
        {
            rainmakerAMount.Enabled = true;
            dd3LabelAmount.Enabled = true;
            md3LabelAmount.Enabled = true;
            rainmakerAMount.Text = $" ";
           dd3LabelAmount.Text = $" ";
            md3LabelAmount.Text = $" ";
            subtotalOutput.Text = $" ";
            taxOutput.Text = $" ";
            totalOutput.Text = $" ";
            paymentInput.Text = $" ";
            changeOutput.Text = $" ";
            recieptOutput.BackColor = Color.DimGray;
            recepitButton.Enabled = false;

        }

        private void paymentButton_Click(object sender, EventArgs e)
        {
            try
            {
                payment = Convert.ToDouble(paymentInput.Text);
                change = payment - total;
                if (payment >= total)
                {
                    changeOutput.Text = $" {change.ToString ("C")}";

                    recepitButton.Enabled = true;
                    paymentButton.Enabled = false;
                    calculateButton.Enabled = false;
                }
                else
                {
                    titleColour.Text = $" Not Enough Money";
                    Refresh();
                    Thread.Sleep(1000);
                    titleColour.Text = $" ";
                    Refresh();
                    Thread.Sleep(1000);
                    Refresh();
                    titleColour.Text = $" Not Enough Money";
                    Refresh();
                    Thread.Sleep(1000);
                    titleColour.Text = $" True North Disc Golf";
                    Refresh();
                }
            }
            catch
            {
                titleColour.Text = $" Enter Valid Payment Amount";
                Refresh();
                Thread.Sleep(1000);
                titleColour.Text = $" ";
                Refresh();
                Thread.Sleep(1000);
                Refresh();
                titleColour.Text = $" Enter Valid Payment Amount";
                Refresh();
                Thread.Sleep(1000);
                titleColour.Text = $" True North Disc Golf";
                Refresh();
            }
        }

        private void recepitButton_Click(object sender, EventArgs e)
        {
            recieptOutput.BackColor = Color.White;

            recieptOutput.Text = $"
        }
    }
}
