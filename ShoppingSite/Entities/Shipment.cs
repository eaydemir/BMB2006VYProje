using System;

namespace ShoppingSite.Entities;


public class Shipment
{
    public long ShipmentID { get; set; }
    public string ZipCode { get; set; }
    public string AddressLine1 { get; set; }
    public string City { get; set; }
    public DateTime? DeliveryDate { get; set; }

    public override string ToString()
    {
        return $"izleme ID: {ShipmentID}, " + DeliveryDate == null ? "ulaştırılmadı" : $"{DeliveryDate} tarihinde teslim edildi";
    }
}

