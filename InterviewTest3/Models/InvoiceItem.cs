namespace InterviewTest3.Models
{
    public class InvoiceItem
    {
        /// <summary>
        /// Short Description of purchased item
        /// </summary>
        public string LineText { get; set; }

        /// <summary>
        /// Item is subject to tax
        /// </summary>
        public bool Taxable { get; set; }

        /// <summary>
        /// Number of units purchased
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Random price per unit
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Discount in whole percent, ie: 55 %
        /// </summary>
        public byte Discount { get; set; }

        /// <summary>
        /// Tax rate in decimal format, ie: 0.07 for 7%
        /// </summary>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// Total for line item not including tax or discount
        /// </summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Total for line item including tax
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Example ToString implementation, update/replace as desired
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Calculating Subtotal
            SubTotal = UnitPrice * Quantity;

            // Used in calculating Total
            decimal calculateDiscount = (decimal)Discount / 100;

            SubTotal = (SubTotal - (SubTotal * calculateDiscount));

            // Calculating Total depending on if item is Taxable or not
            if (Taxable.Equals(true))
            {
                Total = SubTotal;
                Total = (Total + (Total * TaxRate));
            } else {
                Total = SubTotal;
            }

            InvoiceTotals.invoiceSubTotal = InvoiceTotals.invoiceSubTotal + SubTotal;

            return string.Format("{0}Quantity: {1:00}\tPer Unit: ${2:#,0.00}{5}\tTax Rate: {7:00}%\tDiscount: {3:00}%\nSubTotal: ${4:#,0.00}\nTotal: ${6:#,0.00}\n",
                                 LineText.PadRight(20),
                                 Quantity,
                                 UnitPrice,
                                 Discount,
                                 SubTotal,
                                 Taxable ? "T" : null,
                                 Total,
                                 TaxRate * 100);
        }
    }
}
