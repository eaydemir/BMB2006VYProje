using System;

namespace ShoppingSite.Entities;


public class Payment
{
    public long PaymentID { get; set; }
    public long SalesID { get; set; }
    public string PaymentType { get; set; }
    public string IsPaymentDone { get; set; }

    public override string ToString()
    {
        return PaymentID.ToString();
    }
}

