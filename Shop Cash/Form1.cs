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
        //variables set
        double rainmakerAmount;
        double dd3Amount;
        double md3Amount;
        double rainmakerRate = 26.99;
        double dd3Rate = 26.99;
        double md3Rate = 39.99;
        double subtotal;
        double tax;
        double taxrate = 0.13;
        double total;
        double payment;
        double change;
        double orderNumber = 0;



        public trueNorthDG()
        {
            InitializeComponent();
        }

        private void titleColour_Click(object sender, EventArgs e)
        {
            //link? sure
            Process.Start("https://truenorthdiscgolf.com/");
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //take user intputs 
                rainmakerAmount = Convert.ToDouble(rainmakerAMount.Text);
                dd3Amount = Convert.ToDouble(dd3LabelAmount.Text);
                md3Amount = Convert.ToDouble(md3LabelAmount.Text);
                Refresh();

                //ensure something is bought
                if (rainmakerAmount == 0 && dd3Amount == 0 && md3Amount == 0)
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

                    //actually work
                    if (rainmakerAmount >= 0 && dd3Amount >= 0 && md3Amount >= 0)
                    {
                        //charges calculations
                        calculateButton.Enabled = false;
                        SoundPlayer calculating = new SoundPlayer(Properties.Resources.calculating);
                        calculating.Play();
                        Thread.Sleep(11000);
                        subtotal = (rainmakerAmount * rainmakerRate) + (dd3Amount * dd3Rate) + (md3Amount * md3Rate);
                        subtotalOutput.Text = $" Subtotal Amount:   {subtotal.ToString("C")}";

                        tax = (subtotal * taxrate);
                        taxOutput.Text = $" Tax Amount:          {tax.ToString("C")}";

                        total = tax + subtotal;
                        totalOutput.Text = $" Total Cost:             {total.ToString("C")}";

                        //button states
                        paymentInput.Enabled = true;
                        paymentButton.Enabled = true;
                        rainmakerAMount.Enabled = false;
                        dd3LabelAmount.Enabled = false;
                        md3LabelAmount.Enabled = false;
                    }
                    else
                    {
                        //invalid numbers
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
            //make sure numbers are used
            catch
            {
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

        //Reset all values
        private void newOrderButton_Click(object sender, EventArgs e)
        {
            //reset user varibles 
            rainmakerAmount = 0;
            md3Amount = 0;
            dd3Amount = 0;

            //reset button states
            rainmakerAMount.Enabled = true;
            dd3LabelAmount.Enabled = true;
            md3LabelAmount.Enabled = true;
            recepitButton.Enabled = false;
            calculateButton.Enabled = true;

            //clear out text
            rainmakerAMount.Text = "";
            dd3LabelAmount.Text = "";
            md3LabelAmount.Text = "";
            subtotalOutput.Text = "";
            taxOutput.Text = "";
            totalOutput.Text = "";
            paymentInput.Text = "";
            changeOutput.Text = "";
            recieptOutput.Text = "";

            //display settings
            recieptOutput.BackColor = Color.DimGray;
            SoundPlayer Reset = new SoundPlayer(Properties.Resources.reset);
            Reset.Play();
        }

        //payment button
        private void paymentButton_Click(object sender, EventArgs e)
        {
            //valid input check
            try
            {
                //get total
                payment = Convert.ToDouble(paymentInput.Text);
                change = payment - total;

                //valid payment check
                if (payment >= total)
                {
                    SoundPlayer cash = new SoundPlayer(Properties.Resources.cashnosie);
                    cash.Play();
                    changeOutput.Text = $" {change.ToString("C")}";

                    recepitButton.Enabled = true;
                    paymentButton.Enabled = false;
                    calculateButton.Enabled = false;
                }
                else
                {
                    //too little payment 
                    titleColour.Text = " Not Enough Money";
                    Refresh();
                    Thread.Sleep(1000);
                    titleColour.Text = "";
                    Refresh();
                    Thread.Sleep(1000);
                    Refresh();
                    titleColour.Text = " Not Enough Money";
                    Refresh();
                    Thread.Sleep(1000);
                    titleColour.Text = " True North Disc Golf";
                    Refresh();
                }
            }
            catch
            {
                titleColour.Text = " Enter Valid Payment Amount";
                Refresh();
                Thread.Sleep(1000);
                titleColour.Text = " ";
                Refresh();
                Thread.Sleep(1000);
                Refresh();
                titleColour.Text = " Enter Valid Payment Amount";
                Refresh();
                Thread.Sleep(1000);
                titleColour.Text = " True North Disc Golf";
                Refresh();
            }
        }


        //recepit button
        private void recepitButton_Click(object sender, EventArgs e)
        {
            //recepit display setup
            recepitButton.Enabled = false;
            paymentInput.Enabled = false;
            recieptOutput.BackColor = Color.White;
            int n = 10;
            recieptOutput.Size = new Size(0, 0);

            //recepit output
            orderNumber = orderNumber + 1;
            recieptOutput.Text = "True North Disc Golf";
            Refresh();
            recieptOutput.Text += $" \n\n New Order #{orderNumber}";
            Refresh();

            //only display if somethings actullay been purchased
            if (rainmakerAmount > 0)
            {
                recieptOutput.Text += $" \n\n Rainmakers x{rainmakerAmount}        @ ${rainmakerRate}";

                Refresh();
            }
            if (dd3Amount > 0)
            {
                recieptOutput.Text += $" \n\n DD3s x{dd3Amount}              @ ${dd3Rate}";

                Refresh();
            }
            if (md3Amount > 0)
            {
                recieptOutput.Text += $" \n\n MD3s x{md3Amount}              @ ${md3Rate}";

                Refresh();
            }

            
            recieptOutput.Text += $" \n\n Subtotal               {subtotal.ToString("C")}";

            recieptOutput.Text += $" \n\n Tax                    {tax.ToString("C")}";

            recieptOutput.Text += $" \n\n Total                  {total.ToString("C")}";

            recieptOutput.Text += $" \n\n Tendered               {payment.ToString("C")}";

            recieptOutput.Text += $" \n\n Change                 {change.ToString("C")}";

            recieptOutput.Text += $" \n\n Have A Nice Day! See You Again Soon";

            Refresh();

            //sounds
            SoundPlayer print = new SoundPlayer(Properties.Resources.printnoise);
            print.Play();

            //print animaiton
            for (int i = 0; i < 75; i++)
            {
                n = n + 5;
                recieptOutput.Size = new Size(310, (n + 5));
                Thread.Sleep(5);
                Refresh();
            }
        }
    }
}