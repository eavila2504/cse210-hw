using System;

using System.Text;

public class Address
{
    private string _street;

    private string _city;

    private string _state;
    
    private string _country;

    public Address()
    {
        _street = "";
        _city = "";
        _state = "";
        _country = "";
    }

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool isInUSA()
    {
        return _country.ToUpper() == "USA" || _country.ToUpper() == "UNITED STATES";
    }

    public string GetFullAddres()
    {
        StringBuilder address = new StringBuilder();
        address.AppendLine(_street);
        address.AppendLine($"{_city}, {_state}");
        if (!string.IsNullOrEmpty(_country))
        {
            address.AppendLine();
            address.AppendLine(_country);
        }
        return address.ToString();
    }

    public string GetStreet()
    {
        return _street;
    }

    public string GetCity()
    {
        return _city;
    }

    public string GetState()
    {
        return _state;
    }

    public string GetCountry()
    {
        return _country;
    }

    public void SetStreet(string street)
    {
        _street = street;
    }

    public void SetCity(string city)
    {
        _city = city;
    }

    public void SetState(string state)
    {
        _state = state;
    }

    public void SetCountry(string country)
    {
        _country = country; 
    }
    
}