using System;

public class Product
{
    private string _productName;
    private string _productID;
    private double _price;
    private int _quantity;
    private double _productTotal;

    public Product()
    {
        _productName = "";
        _productID = "";
        _price = 0;
        _quantity = 0;
        _productTotal = 0;
    } 

    public Product(string name, string productID, double price, int quantity)
    {
        _productName = name;
        _productID = productID;
        _price = price;
        _quantity = quantity;
        _productTotal = CalculateProductTotal();
    }

    private double CalculateProductTotal()
    {
        return _quantity * _price;
    }

    public string GetProductName()
    {
        return _productName;
    }

    public string GetProductID()
    {
        return _productID;
    }

    public double GetPrice()
    {
        return _price;
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    public double GetProductTotal()
    {
        return _productTotal;
    }

    public void SetProductName(string name)
    {
        _productName = name;
        _productTotal = CalculateProductTotal();
    }

    public void SetProductID(string productID)
    {
        _productID = productID;
    }

    public void SetPrice(double price)
    {
        _price = price;
        _productTotal = CalculateProductTotal();
    }

    public void SetQuantity(int quantity)
    {
        _quantity = quantity;
        _productTotal = CalculateProductTotal();
    }
}
