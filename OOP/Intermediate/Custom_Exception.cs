using System;

namespace Intermediate;

public class Custom_Exception : Exception
{
    public Custom_Exception(string message, Exception innerException) : base(message, innerException)
    {
        Console.WriteLine("Custom Exception \"" + message + "\" with Inner Exception \"" + innerException.Message + "\"");
    }
    public Custom_Exception(string message, int errorCode) : base(message)
    {
        Console.WriteLine("Custom Exception \"" + message + "\" with Error Code " + errorCode);
    }
}
public class Exceptions
{
    public void CustomExceptionWithErrorCode()
    {
        try
        {
            throw new Custom_Exception("This is a custom exception", 404);
        }
        catch (Custom_Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void CustomExceptionWithInnerException()
    {
        try
        {
            try
            {
                throw new Exception("This is inner exception");
            }
            catch (Exception e)
            {
                throw new Custom_Exception("This is a custom exception", e);
            }
        }
        catch (Custom_Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

/****
//Custom exception is created by inheriting from Exception class
//It is used to create user defined exceptions that are not available in the .NET framework
//It makes the code more readable and maintainable
Exceptions exceptions = new Exceptions();
Console.WriteLine("\n*****Custom Exception with Error Code*****");
exceptions.CustomExceptionWithErrorCode();
Console.WriteLine("\n*****Custom Exception with Inner Exception*****");
exceptions.CustomExceptionWithInnerException();
 ****/
