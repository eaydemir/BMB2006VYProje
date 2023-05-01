using System;
using System.Xml.Linq;
using ShoppingSite.Entities;

namespace ShoppingSite.DataStructures;


public class ProductBSTNode
{
    public Product Veri;

    public ProductBSTNode Left;

    public ProductBSTNode Right;

    public ProductBSTNode(Product veri)
    {
        this.Veri = veri;
        Left = null;
        Right = null;
    }
}

public class ProductBinarySearchTree
{
    public ProductBSTNode Root { get; set; }

    public ProductBinarySearchTree(Product veri)
    {
        this.Root = new ProductBSTNode(veri);
    }

    public ProductBSTNode Max(ProductBSTNode node)
    {
        if (node.Right != null)
            return Max(node.Right);
        else
            return node.Right;
    }

    public ProductBSTNode Min(ProductBSTNode node)
    {
        if (node.Left != null)
            return Min(node.Left);
        else
            return node.Left;
    }

    public void Insert(Product veri)
    {
        Insert(Root, veri);
    }

    public ProductBSTNode Insert(ProductBSTNode node, Product veri)
    {
        if (node == null)
        {
            return new ProductBSTNode(veri);
        }

        if (veri.ProductID < node.Veri.ProductID)
        {
            node.Left = Insert(node.Left, veri);
        }
        else if (veri.ProductID > node.Veri.ProductID)
        {
            node.Right = Insert(node.Right, veri);
        }

        return node;
    }

    public void Delete(Product value)
    {
        DeleteNode(Root, value);
    }

    public ProductBSTNode DeleteNode(ProductBSTNode node, Product value)
    {
        if (node == null)
            return null;

        if (value.ProductID < node.Veri.ProductID)
        {
            node.Left = DeleteNode(node.Left, value);
        }
        else if (value.ProductID > node.Veri.ProductID)
        {
            node.Right = DeleteNode(node.Right, value);
        }
        else
        {
            if (node.Left == null && node.Right == null)
            {
                node = null;
            }
            else if (node.Left == null)
            {
                node = node.Right;
            }
            else if (node.Right == null)
            {
                node = node.Left;
            }
            else
            {
                ProductBSTNode temp = Min(node.Right);
                node.Veri = temp.Veri;
                node.Right = DeleteNode(node.Right, temp.Veri);
            }
        }

        return node;
    }

    public void AraGezinti()
    {
        AraGezinti(Root);
    }

    private void AraGezinti(ProductBSTNode node)
    {
        if (node != null)
        {
            AraGezinti(node.Left);
            Console.Write(node.Veri + " ");
            AraGezinti(node.Right);
        }
    }

    public bool ikiliAramaAgaciMi()
    {
        return ikiliAramaAgaciMi(Root);
    }

    private bool ikiliAramaAgaciMi(ProductBSTNode node)
    {
        if (node == null)
            return true;

        return AltAgaclarKucukMu(node.Left, node.Veri) &&
            AltAgaclarBuyukMu(node.Right, node.Veri) &&
            ikiliAramaAgaciMi(node.Left) &&
            ikiliAramaAgaciMi(node.Right);
    }

    private bool AltAgaclarKucukMu(ProductBSTNode node, Product value)
    {
        if (node == null)
            return true;

        return node.Veri.ProductID <= value.ProductID && AltAgaclarKucukMu(node.Left, value) && AltAgaclarKucukMu(node.Right, value);
    }

    private bool AltAgaclarBuyukMu(ProductBSTNode node, Product value)
    {
        if (node == null)
            return true;

        return node.Veri.ProductID >= value.ProductID && AltAgaclarBuyukMu(node.Left, value) && AltAgaclarBuyukMu(node.Right, value);

    }

    public void OnceGezinti()
    {
        OnceGezinti(Root);
    }

    private void OnceGezinti(ProductBSTNode node)
    {
        if (node != null)
        {
            Console.Write(node.Veri + " ");
            OnceGezinti(node.Left);
            OnceGezinti(node.Right);
        }
    }

    public void SonraGezinti()
    {
        SonraGezinti(Root);
    }

    private void SonraGezinti(ProductBSTNode node)
    {
        if (node != null)
        {
            SonraGezinti(node.Left);
            SonraGezinti(node.Right);
            Console.Write(node.Veri + " ");
        }
    }



}
