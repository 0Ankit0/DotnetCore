using System;

namespace Basics;

public class House
{
    public string? Type;

    //If we don't specify anything it will be private by default
    string? Address;

    //Protected can be accessed by the class itself and the derived class
    protected string? Owner;

    //Private can only be accessed by the class itself or you can create method to access it
    public void SetAddress(string address)
    {
        Address = address;
    }
    public string GetAddress()
    {
        return Address ?? "No Address Specified";
    }

}

/****
House bungalow = new House();
bungalow.Type = "Bungalow"; //you can access public members from outside the class
bungalow.Address = "123, Main Street"; //you can't access private members from outside the class.
bungalow.Owner = "John Doe"; //you can't access protected members from outside the class

bungalow.SetAddress("123, Main Street"); //you can access private members using public methods
Console.WriteLine(bungalow.GetAddress()); //123, Main Street

//Same can be done with protected members
 ****/