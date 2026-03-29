using System;

public class Customer
{
    private string _customerName;
    private Address _address;

    public Customer()
    {
        _customerName = "";
        _address = new Address();
    }

    public Customer(string Name, Address address)
    {
        _customerName = Name;
        _address = address;
    }

    public bool LivesInUSA()
    {
        return _address.isInUSA();
    }

    public string GetCustomerName()
    {
        return _customerName;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public void SetCustomerName(string name)
    {
        _customerName = name;
    }

    public void SetAddress(Address address)
    {
        _address = address;
    }
}


