using BootCamp.Chapter1;
using System;

namespace Chapter1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call BMI_Calculator

            //BMICalculator.BMI_Calculator(); 

            //int [] array = { 78, 55, 45, 98, 13 };


            // Call the sort array method

            //var solution = Array_Functions.Sort_Array(array);

            //foreach (int p in solution)
            //    Console.Write(p + " ");
            //Console.Read();

            // Call the add at the beginning method

            // int[] array = { 2, 3, 4, 5 };
            // var solution = Array_Functions.Add_Start_Array(array, 1);

            // foreach (int p in solution)
            //    Console.Write(p + " ");

            // Call the add at the end method 

            // int[] array = { 1, 2, 3, 4 };
            // var solution = Array_Functions.Add_End_Array(array, 5);

            //int[] array = { 1, 2, 3, 4, 5 };
            //var solution = Array_Functions.Remove_Start_Array(array); 

            // foreach (int p in solution)
            //     Console.Write(p + " ");

            // int[] array = { 1, 2, 3, 4, 5 };
            //var solution = Array_Functions.Remove_End_Array(array);

            //foreach (int p in solution)
            //    Console.Write(p + " ");


            Array_Functions.Login("test", "secret");
            Array_Functions.Login("TEST", "secret");
            Array_Functions.Login("TEST", "SECRET");
            Array_Functions.Login("test", "SECRET"); 

            Console.Read();



        }


    }
}
