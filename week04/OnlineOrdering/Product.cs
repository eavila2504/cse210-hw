using System;

public class Product
{
    private string _name;
    private string _productID;
    private double _price;
    private int _quantity;
    private double _productTotal;

    public Product()
    {
        _name = "";
        _productID = "";
        _price = 0;
        _quantity = 0;
        _productTotal = 0;
    } 

    public Product(string name, string productID, double price, int quantity)
    {
        
    }
}