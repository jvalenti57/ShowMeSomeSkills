using System;
using System.Linq;

namespace InterviewTest1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var data = new Repo().All();
            var dataCount = data.Count();
            var i = 0;

            string [] invoiceNumbers = data.Select(invoice => invoice.InvoiceNo).ToArray();
            string[] companyNames = data.Select(invoice => invoice.CompanyName).ToArray();

            while (i < dataCount)
            {
                Console.WriteLine("Invoice Number: " + invoiceNumbers[i] + "\nCompany Name: " + companyNames[i] + "\n");
                i++;
            }

                Console.ReadLine();
        }
    }
}
