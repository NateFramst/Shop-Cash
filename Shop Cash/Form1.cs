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
using System.Media;
using System.Linq.Expressions;
using System.Web;

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
        double ordernumber = 0;
        double sizee = 50;
        
         
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
                Refresh();
                if (rainmakeramout == 0 && DD3amount == 0 && MD3amount == 0)
                {
                    titleColour.Text = $" Please Buy Something";
                    Refresh();
                    Thread.Sleep(1000);
                    titleColour.Text = $" ";
                    Refresh();
                    Thread.Sleep(1000);
                    Refresh();
                    titleColour.Text = $" Please Buy Something";
                    Refresh();
                    Thread.Sleep(1000);
                    titleColour.Text = $" True North Disc Golf";
                    Refresh();
                }
                else
                {
                    if (rainmakeramout >= 0 && DD3amount >= 0 && MD3amount >= 0)
                    {
                        calculateButton.Enabled = false;
                        SoundPlayer calculating = new SoundPlayer(Properties.Resources.calculating);
                        calculating.Play();
                        Thread.Sleep(11000);
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
                    else
                    {
                        titleColour.Text = $" Invalid Number";
                        Refresh();
                        Thread.Sleep(1000);
                        titleColour.Text = $" ";
                        Refresh();
                        Thread.Sleep(1000);
                        Refresh();
                        titleColour.Text = $" Invalid Number";
                        Refresh();
                        Thread.Sleep(1000);
                        titleColour.Text = $" True North Disc Golf";
                        Refresh();
                    }
                }
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
            recieptOutput.Text = $" ";
            calculateButton.Enabled = true;

        }

        private void paymentButton_Click(object sender, EventArgs e)
        {
            try
            {
                payment = Convert.ToDouble(paymentInput.Text);
                change = payment - total;
                if (payment >= total)
                {
                    SoundPlayer cash = new SoundPlayer(Properties.Resources.cashnosie);
                    cash.Play();
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
            /*
            int n = 50;
            size = recieptOutput.Size;
            for (int i = 0; i < 10; i++)
            {
                n = n++;
                recieptOutput.Size = new Size(310, (n + 50));
            }
            */
            recieptOutput.BackColor = Color.White;
            SoundPlayer print = new SoundPlayer(Properties.Resources.printnoise);
            print.Play();
            ordernumber = ordernumber + 1;
            recepitButton.Enabled = false;
            recieptOutput.Text = $"True North Disc Golf";
            Thread.Sleep(750);
            Refresh();
            recieptOutput.Text += $" \n\n New Order #{ordernumber}";
            Thread.Sleep(750);
            Refresh();
            if (rainmakeramout > 0)
            {
                recieptOutput.Text += $" \n\n Rainmakers x{rainmakeramout}        @ ${rainmakerrate}";
                Thread.Sleep(750);
                Refresh();
            }
            if (DD3amount > 0)
            {
                recieptOutput.Text += $" \n\n DD3s x{DD3amount}              @ ${DD3rate}";
                Thread.Sleep(750);
                Refresh();
            }
            if (MD3amount > 0)
            {
                recieptOutput.Text += $" \n\n MD3s x{MD3amount}              @ ${MD3rate}";
                Thread.Sleep(750);
                Refresh();
            }
            recieptOutput.Text += $" \n\n Subtotal               {subtotal.ToString ("C")}";
            Thread.Sleep(750);
            Refresh();
            recieptOutput.Text += $" \n\n Tax                    {tax.ToString("C")}";
            Thread.Sleep(750);
            Refresh();
            recieptOutput.Text += $" \n\n Total                  {total.ToString("C")}";
            Thread.Sleep(750);
            Refresh();
            recieptOutput.Text += $" \n\n Tendered               {payment.ToString("C")}";
            Thread.Sleep(750);
            Refresh();
            recieptOutput.Text += $" \n\n Change                 {change.ToString("C")}";
            Thread.Sleep(750);
            Refresh();
            recieptOutput.Text += $" \n\n Have A Nice Day! See You Again Soon";
            Thread.Sleep(750);
            Refresh();
        }
    }
}
