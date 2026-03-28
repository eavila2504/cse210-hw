using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private const double US_SHIPPING_COST = 5.0;
    private const double INTERNATIONAL_SHIPPING_COST = 35.0;

    public Order()
    {
        _products = new List<Product>();
        _customer = new Customer();
    }

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    private double GetShippingCost()
    {
        return _customer.LivesInUSA() ? US_SHIPPING_COST : INTERNATIONAL_SHIPPING_COST;
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetProductTotal();
        }
        return total + GetShippingCost();
    }

    public string GetPackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder();
        packingLabel.AppendLine("PACKING LABEL");
        packingLabel.AppendLine("-------------");
        foreach (Product product in _products)
        {
            packingLabel.AppendLine($"{product.GetProductName()} (ID: {product.GetProductID()}) - Quantity: {product.GetProductID()}");
        }
        return packingLabel.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder shippingLabel = new StringBuilder();
        shippingLabel.AppendLine("SHIPPING LABEL");
        shippingLabel.AppendLine("--------------");
        shippingLabel.AppendLine($"Customer: {_customer.GetCustomer()}");
        shippingLabel.AppendLine("ADDRESS:");
        shippingLabel.AppendLine(_customer.GetAddress().ToString());
        return shippingLabel.ToString();
    }

    public string GetCustomerName()
    {
        
    }
}