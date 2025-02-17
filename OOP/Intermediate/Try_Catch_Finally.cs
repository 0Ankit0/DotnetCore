using System;

namespace Intermediate;

public class Try_Catch_Finally
{
    public void ExceptionHandlingEx()
    {
        //try block is used to enclose the code that might throw an exception
        try
        {
            int[] numbers = new int[3];
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[2] = 3;
            throw new Exception("This is an exception");
            // numbers[3] = 4;
        }//you can catch individual exceptions or use a generic exception while catching
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        } //finally block is always executed whether exception is thrown or not
        finally
        {
            Console.WriteLine("Finally block");
        }
    }

}

/****
Try_Catch_Finally tcf = new Try_Catch_Finally();
tcf.ExceptionHandlingEx();
 ****/