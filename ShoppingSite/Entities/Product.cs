using System;

namespace ShoppingSite.Entities;


public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string ProductType { get; set; }
    public double ProductPrice { get; set; }

    public override string ToString()
    {
        return ProductID.ToString();
    }
}


