using System;
using System.Xml;
using ShoppingSite.Entities;

namespace ShoppingSite.DataStructures;


public class SalesNode
{
    public Sales Veri;
    public int Height;
    public SalesNode Left;
    public SalesNode Right;

    public SalesNode(Sales Veri)
    {
        this.Veri = Veri;
        Left = null;
        Right = null;
        this.Height = 1;
    }
}


public class SalesAVLTree
{
    private SalesNode root;

    private int Yukseklik(SalesNode node)
    {
        if (node == null)
            return 0;

        return node.Height;
    }

    private int Denge(SalesNode node)
    {
        if (node == null)
            return 0;

        return Yukseklik(node.Left) - Yukseklik(node.Right);
    }

    private SalesNode SagaDondur(SalesNode y)
    {
        SalesNode x = y.Left;
        SalesNode T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.Height = Math.Max(Yukseklik(y.Left), Yukseklik(y.Right)) + 1;
        x.Height = Math.Max(Yukseklik(x.Left), Yukseklik(x.Right)) + 1;
        return x;
    }

    private SalesNode SolaDondur(SalesNode x)
    {
        SalesNode y = x.Right;
        SalesNode T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.Height = Math.Max(Yukseklik(x.Left), Yukseklik(x.Right)) + 1;
        y.Height = Math.Max(Yukseklik(y.Left), Yukseklik(y.Right)) + 1;

        return y;
    }

    private SalesNode KucukNode(SalesNode node)
    {
        SalesNode current = node;

        while (current.Left != null)
            current = current.Left;

        return current;
    }

    public void Ekle(Sales veri)
    {
        this.root = Ekle(this.root, veri);
    }

    private SalesNode Ekle(SalesNode node, Sales veri)
    {
        if (node == null)
            return new SalesNode(veri);

        if (veri.SalesID < node.Veri.SalesID)
            node.Left = Ekle(node.Left, veri);
        else if (veri.SalesID > node.Veri.SalesID)
            node.Right = Ekle(node.Right, veri);
        else
            return node;

        node.Height = 1 + Math.Max(Yukseklik(node.Left), Yukseklik(node.Right));

        int deng = Denge(node);

        if (deng > 1 && veri.SalesID < node.Left.Veri.SalesID)
            return SagaDondur(node);

        if (deng < -1 && veri.SalesID > node.Right.Veri.SalesID)
            return SolaDondur(node);

        if (deng > 1 && veri.SalesID > node.Left.Veri.SalesID)
        {
            node.Left = SolaDondur(node.Left);
            return SagaDondur(node);
        }

        if (deng < -1 && veri.SalesID < node.Right.Veri.SalesID)
        {
            node.Right = SagaDondur(node.Right);
            return SolaDondur(node);
        }

        return node;
    }

    public void Sil(Sales veri)
    {
        this.root = Sil(this.root, veri);
    }

    private SalesNode Sil(SalesNode node, Sales veri)
    {
        if (node == null)
            return node;

        if (veri.SalesID < node.Veri.SalesID)
        {
            node.Left = Sil(node.Left, veri);
        }
        else if (veri.SalesID > node.Veri.SalesID)
        {
            node.Right = Sil(node.Right, veri);
        }
        else
        {
            if ((node.Left == null) || (node.Right == null))
            {
                SalesNode temp = null;

                if (temp == node.Left)
                    temp = node.Right;
                else
                    temp = node.Left;

                if (temp == null)
                {
                    temp = node;
                    node = null;
                }
                else
                {
                    node = temp;
                }
            }
            else
            {
                SalesNode temp = KucukNode(node.Right);
                node.Veri = temp.Veri;
                node.Right = Sil(node.Right, temp.Veri);
            }
        }

        if (node == null)
            return node;

        node.Height = 1 + Math.Max(Yukseklik(node.Left), Yukseklik(node.Right));

        int balance = Denge(node);

        if (balance > 1 && Denge(node.Left) >= 0)
            return SagaDondur(node);


        if (balance > 1 && Denge(node.Left) < 0)
        {
            node.Left = SolaDondur(node.Left);
            return SagaDondur(node);
        }

        if (balance < -1 && Denge(node.Right) <= 0)
        {
            return SolaDondur(node);
        }

        if (balance < -1 && Denge(node.Right) > 0)
        {
            node.Right = SagaDondur(node.Right);
            return SolaDondur(node);
        }

        return node;
    }

    public void AraGezinti()
    {
        Console.Write("*" + root.Veri + "* ");
        AraGezinti(this.root);
    }

    private void AraGezinti(SalesNode node)
    {
        if (node != null)
        {
            AraGezinti(node.Left);
            Console.Write(node.Veri + " - ");
            AraGezinti(node.Right);
        }
    }

}

