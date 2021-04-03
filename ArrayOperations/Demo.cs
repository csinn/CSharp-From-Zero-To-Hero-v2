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
      Console.WriteLine("Initial array elements:");
      Console.WriteLine(Arrays.ToString(input));

      Console.WriteLine("Array after sort operation:");
      var output = Arrays.Sort(input);
      Console.WriteLine(Arrays.ToString(output));
    }

    private static void InsertAnElementAtBeginningOfTheArray(int[] input)
    {
      Console.WriteLine("Initial array elements:");
      Console.WriteLine(Arrays.ToString(input));

      const int NumberToInsert = 12;

      Console.WriteLine($"Array elements after {NumberToInsert} was inserted:");
      var output = Arrays.InsertFirst(input, NumberToInsert);
      Console.WriteLine(Arrays.ToString(output));
    }

    private static void InsertAnElementAtEndOfArray(int[] input)
    {
      Console.WriteLine("Initial array elements:");
      Console.WriteLine(Arrays.ToString(input));

      const int NumberToInsert = 4;

      Console.WriteLine($"Array elements after {NumberToInsert} was inserted:");
      var output = Arrays.InsertLast(input, NumberToInsert);
      Console.WriteLine(Arrays.ToString(output));
    }

    private static void RemoveFirstElementOfArray(int[] input)
    {
      Console.WriteLine("Initial array elements:");
      Console.WriteLine(Arrays.ToString(input));

      Console.WriteLine("Array elements after first element was removed:");
      var output = Arrays.RemoveFirst(input);
      Console.WriteLine(Arrays.ToString(output));
    }

    private static void RemoveLastElementOfArray(int[] input)
    {
      Console.WriteLine("Initial array elements:");
      Console.WriteLine(Arrays.ToString(input));

      Console.WriteLine("Array elements after last element was removed:");
      var output = Arrays.RemoveLast(input);
      Console.WriteLine(Arrays.ToString(output));
    }

    private static void InsertElementAtGivenIndex(int[] input)
    {
      Console.WriteLine("Initial array elements:");
      Console.WriteLine(Arrays.ToString(input));

      const int Index = 4;
      const int Number = 99;

      Console.WriteLine($"Array elements after inserting {Number} at position {Index}:");
      var output = Arrays.InsertAt(input, Number, Index);
      Console.WriteLine(Arrays.ToString(output));
    }

    private static void RemoveElementAtGivenIndex(int[] input)
    {
      Console.WriteLine("Initial array elements:");
      Console.WriteLine(Arrays.ToString(input));
      const int Index = 5;

      Console.WriteLine($"Array elements after removing element at position {Index}:");
      var output = Arrays.RemoveAt(input, Index);
      Console.WriteLine(Arrays.ToString(output));
    }

    private static void Pause(string message = "Press ENTER to continue...")
    {
      Console.WriteLine(message);
      Console.ReadLine();
    }
  }
}