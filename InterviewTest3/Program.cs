using System;
using System.Collections;
using System.Linq;

namespace InterviewTest3
{
    public static class InvoiceTotals
    {
        public static decimal invoiceSubTotal = 0;
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var data = new Repo().All();
            var dataCount = data.Count();
            var i = 0;
            var x = 0;
            var itemCount = 0;
            decimal invoiceTotal = 0;
            decimal commissionTotal = 0;

            string[] invoiceNumbers = data.Select(invoice => invoice.InvoiceNo).ToArray();
            string[] companyNames = data.Select(invoice => invoice.CompanyName).ToArray();
            decimal[] shippingCosts = data.Select(invoice => invoice.Shipping).ToArray();

            IList lineItems = data.SelectMany(invoice => invoice.LineItems).ToList();

            while (i < dataCount)
            {
                itemCount = x + data.Where(invoice => invoice.InvoiceNo == invoiceNumbers[i]).SelectMany(invoice => invoice.LineItems).Count();

                Console.WriteLine("Invoice Number: " + invoiceNumbers[i] + "\nCompany Name: " + companyNames[i] + "\n\n-----\n");
                while (x < itemCount)
                {
                    Console.WriteLine(lineItems[x]);
                    x++;
                }
                
                invoiceTotal = InvoiceTotals.invoiceSubTotal + shippingCosts[i];
                commissionTotal = (InvoiceTotals.invoiceSubTotal * 3/100);
                commissionTotal = Math.Round(commissionTotal * 2, MidpointRounding.ToEven) / 2;

                Console.WriteLine("----------\nInvoice Sub Total: $" + InvoiceTotals.invoiceSubTotal.ToString("#,0.00"));
                Console.WriteLine("Sub Total w/ Shipping: " + invoiceTotal.ToString("#,0.00"));
                Console.WriteLine("\nCommission Amount: $" + commissionTotal.ToString("#,0.00") + "\n----------\n");

                i++;
            }

            Console.ReadLine();
        }
    }
}
