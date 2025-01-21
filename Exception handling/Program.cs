using System;
using CustomExceptions;
namespace MyApp;

class Program{

    public static void Main(string[] args){
        // Console.WriteLine("Hello");

        //Custom excetptions
        // try
        // {
            // int n1,n2;
            // n1=Convert.ToInt32(Console.ReadLine());
            // n2=Convert.ToInt32(Console.ReadLine());

            // Console.WriteLine($"{n1}/{n2}={n1/n2}");
        // }
        // catch (DivideByZeroException ex)
        // {
        //     Console.WriteLine(ex.Message);
        //     Console.WriteLine(ex.Source);
        //     Console.WriteLine(ex.HelpLink);
        //     Console.WriteLine(ex.StackTrace);
        //     Console.WriteLine($"Divide by zero Exception Occued while performing the operation");
        // }
        // catch(FormatException ex){
        //     Console.WriteLine(ex.Message);
        //     Console.WriteLine(ex.Source);
        //     Console.WriteLine(ex.HelpLink);
        //     Console.WriteLine(ex.StackTrace);
        //     Console.WriteLine($"Fromat Exception Occued while performing the operation");
        // }
        // catch(Exception ex){
            // Console.WriteLine(ex.Message);
            // Console.WriteLine(ex.Source);
            // Console.WriteLine(ex.HelpLink);
            // Console.WriteLine(ex.StackTrace);
            // Console.WriteLine($"Unknown Exception Occued while performing the operation");
        // }
        // finally{
        //     Console.WriteLine($"Finally block is executed");
        // }



        //ex.innerexecetion
        // try
        // {
            // int n1,n2;
            // n1=Convert.ToInt32(Console.ReadLine());
            // n2=Convert.ToInt32(Console.ReadLine());
            // if(n2%2!=0)
            // throw new OddNumberException();
            // Console.WriteLine($"{n1}/{n2}={n1/n2}");
        // }
        // catch(OddNumberException ex){
        //     // Console.WriteLine(ex.Message);
        //     // Console.WriteLine(ex.Source);
        //     // Console.WriteLine(ex.HelpLink);
        //     // Console.WriteLine(ex.StackTrace);
        //     Console.WriteLine($"OddNumber Exception Occued while performing the operation");

        //     try
        //     {
        //         throw new FormatException("Exception thrown after getting the OddNumberException",ex);  //second params is InnerException
        //     }
        //     catch (Exception ex1)
        //     {
        //         Console.WriteLine(ex1.Message);
        //         Console.WriteLine(ex1.Source);

        //         if(ex1.InnerException!=null){
        //             Console.WriteLine($"\n\n {ex1.InnerException.Message}");
        //             Console.WriteLine($"{ex1.InnerException.Source}");
        //         }
        //     }
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        //     Console.WriteLine(ex.Source);
        //     Console.WriteLine(ex.HelpLink);
        //     Console.WriteLine(ex.StackTrace);
        //     Console.WriteLine($"Unknown Exception Occued while performing the operation");
        // } finally{
        //     System.Console.WriteLine("Finally statement executed");
        // }




        try
        {
            int n1,n2;
            n1=Convert.ToInt32(Console.ReadLine());
            n2=Convert.ToInt32(Console.ReadLine());
            if(n2%2!=0)
            throw new OddNumberException();
            Console.WriteLine($"{n1}/{n2}={n1/n2}");
        }
        catch (System.Exception)
        {
            
        }

    }
}