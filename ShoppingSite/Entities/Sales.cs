using System;

namespace ShoppingSite.Entities;


public class Sales
{
    public long SalesID { get; set; }
    public int ProductID { get; set; }
    public int UserID { get; set; }
    public DateTime SalesDate { get; set; }
    public double SalesPrice { get; set; }

    public override string ToString()
    {
        return SalesID.ToString();
    }
}

