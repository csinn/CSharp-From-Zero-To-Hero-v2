using System;

namespace ArrayOperations
{
  public static class Demo
  {
    public static void Run()
    {
      var input = new[] {1, 3, 5, 6, 7, 10, 8, 2};
      
      try
      {
        SortArray(input);
        Pause();
        
        InsertAnElementAtBeginningOfTheArray(input);
        Pause();

        InsertAnElementAtEndOfArray(input);
        Pause();

        RemoveFirstElementOfArray(input);
        Pause();

        RemoveLastElementOfArray(input);
        Pause();

        InsertElementAtGivenIndex(input);
        Pause();

        RemoveElementAtGivenIndex(input);
        Pause("Press ENTER to exit...");
      }
      catch (Exception ex) when (ex is ArgumentException 
                                 || ex is ArgumentNullException 
                                 || ex is ArgumentOutOfRangeException)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private static void SortArray(int[] input)
    {
      Arrays.Print(input, "Initial array elements:");
      var output = Arrays.Sort(input);
      Arrays.Print(output, "Array after sort operation:");
    }

    private static void InsertAnElementAtBeginningOfTheArray(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");

      const int NumberToInsert = 12;

      var output = Arrays.InsertFirst(input, NumberToInsert);
      Arrays.Print(output, $"Array elements after {NumberToInsert} was inserted:");
    }

    private static void InsertAnElementAtEndOfArray(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      
      const int NumberToInsert = 4;

      var output = Arrays.InsertLast(input, NumberToInsert);
      Arrays.Print(output,$"Array elements after {NumberToInsert} was inserted:");
    }

    private static void RemoveFirstElementOfArray(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      
      var output = Arrays.RemoveFirst(input);
      Arrays.Print(output,$"Array elements after first element was removed:");
    }

    private static void RemoveLastElementOfArray(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      
      var output = Arrays.RemoveLast(input);
      Arrays.Print(output,$"Array elements after last element was removed:");
    }

    private static void InsertElementAtGivenIndex(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      
      const int Index = 4;
      const int Number = 99;

      var output = Arrays.InsertAt(input, Number, Index);
      Arrays.Print(output, $"Array elements after inserting {Number} at position {Index}:");
    }

    private static void RemoveElementAtGivenIndex(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      const int Index = 5;

      var output = Arrays.RemoveAt(input, Index);
      Arrays.Print(output, $"Array elements after removing element at position {Index}:");
    }

    private static void Pause(string message = "Press ENTER to continue...")
    {
      Console.WriteLine(message);
      Console.ReadLine();
    }
  }
}
