using System;
using System.Xml.Linq;
using ShoppingSite.Entities;

namespace ShoppingSite.DataStructures;



public class ShipmentNode
{
    public Shipment Veri;

    public ShipmentNode Ileri;
    public ShipmentNode Geri;

    public ShipmentNode(Shipment Veri)
    {
        this.Veri = Veri;
        Ileri = null;
        Geri = null;
    }
}

public class ShipmentLinkedList
{
    public ShipmentNode Bas;
    public ShipmentNode Son;

    public ShipmentLinkedList()
    {
        Bas = null;
        Son = null;
    }

    public void BasaEkle(ShipmentNode yeni)
    {
        if (Son == null)
            Son = yeni;
        else
            Bas.Geri = yeni;

        yeni.Ileri = Bas;

        Bas = yeni;
    }
    public void SonaEkle(ShipmentNode yeni)
    {
        if (Bas == null)
            Bas = yeni;
        else
            Son.Ileri = yeni;

        yeni.Geri = Son;

        Son = yeni;
    }

    public void OrtayaEkle(ShipmentNode yeni)
    {
        int sayac = Say() / 2;
        ShipmentNode temp = Bas;

        for (int i = 0; i < sayac; i++)
            temp = temp.Ileri;

        yeni.Ileri = temp.Ileri;
        temp.Ileri.Geri = yeni;
        yeni.Geri = temp;
        temp.Ileri = yeni;
    }

    public void OrtayaEkle2(ShipmentNode yeni, ShipmentNode once)
    {
        yeni.Ileri = once.Ileri;
        once.Ileri.Geri = yeni;
        yeni.Geri = once;
        once.Ileri = yeni;
    }

    public void BastanSil()
    {
        Bas = Bas.Ileri;
        if (Bas == null)
            Son = null;
        else
            Bas.Geri = null;
    }

    public void SondanSil()
    {
        Son = Son.Geri;
        if (Son == null)
            Bas = null;
        else
            Son.Ileri = null;
    }

    public void OrtayaSil()
    {
        int sayac = Say() / 2;
        ShipmentNode temp = Bas;

        for (int i = 0; i < sayac; i++)
            temp = temp.Ileri;

        temp.Ileri.Geri = temp.Geri;
        temp.Geri.Ileri = temp.Ileri;
    }

    public void OrtadanSil2(ShipmentNode d)
    {
        d.Ileri.Geri = d.Geri;
        d.Geri.Ileri = d.Ileri;
    }

    public int Say()
    {
        ShipmentNode temp = Bas;
        int sayac = 0;
        while (temp != null)
        {
            sayac++;
            temp = temp.Ileri;
        }
        return sayac;
    }

    public void yaz()
    {
        ShipmentNode temp = Bas;

        while (temp != null)
        {
            Console.Write(temp.Veri + " - ");
            temp = temp.Ileri;
        }
    }
}