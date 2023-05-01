using System;
using ShoppingSite.Entities;

namespace ShoppingSite.DataStructures;


public class QueueNode
{
    public Payment Veri;
    public QueueNode Ileri;

    public QueueNode(Payment veri)
    {
        this.Veri = veri;
        Ileri = null;
    }
}

public class PaymentQueueList
{
    public QueueNode bas;
    public QueueNode son;

    public PaymentQueueList()
    {
        bas = null;
        son = null;
    }

    public void Enqueue(QueueNode yeni)
    {
        if (bas == null)
            bas = yeni;
        else
            son.Ileri = yeni;

        son = yeni;
    }


    public QueueNode Dequeue()
    {
        var tmp = bas;

        bas = bas.Ileri;

        if (bas == null)
            son = null;


        return tmp;
    }

    public int Say()
    {
        QueueNode temp = bas;
        int sayac = 0;
        while (temp != null)
        {
            sayac++;
            temp = temp.Ileri;
        }
        return sayac;
    }

    public void Yaz()
    {
        QueueNode temp = bas;
        while (temp != null)
        {
            Console.Write(temp.Veri + " -> ");
            temp = temp.Ileri;
        }
        Console.WriteLine("");
    }
}
