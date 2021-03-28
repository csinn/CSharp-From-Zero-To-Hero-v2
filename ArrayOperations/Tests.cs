using System;

namespace ArrayOperations
{
  public static class Demo
  {
    public static void RunArrayOperations()
    {
      var input = new[] {1, 3, 5, 6, 7, 10, 8, 2};
      
      Sort(input);
      Pause();

      InsertFirst(input);
      Pause();
      
      InsertLast(input);
      Pause();

      RemoveFirst(input);
      Pause();

      RemoveLast(input);
      Pause();

      InsertAtGivenIndex(input);
      Pause();

      RemoveAtGivenIndex(input);
      Pause();
    }

    private static void Sort(int[] input)
    {
      Arrays.Print(input, "Initial array elements:");
      Arrays.Sort(input);
      Arrays.Print(input, "Array after sort operation:");
    }

    private static void InsertFirst(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");

      const int numberToInsert = 12;

      var output = Arrays.InsertFirst(input, numberToInsert);
      Arrays.Print(output, $"Array elements after {numberToInsert} was inserted:");
    }

    private static void InsertLast(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      
      const int numberToInsert = 4;

      var output = Arrays.InsertLast(input, numberToInsert);
      Arrays.Print(output,$"Array elements after {numberToInsert} was inserted:");
    }

    private static void RemoveFirst(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      
      var output = Arrays.RemoveFirst(input);
      Arrays.Print(output,$"Array elements after first element was removed:");
    }

    private static void RemoveLast(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      
      var output = Arrays.RemoveLast(input);
      Arrays.Print(output,$"Array elements after last element was removed:");
    }

    private static void InsertAtGivenIndex(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      
      const int index = 4;
      const int number = 99;

      var output = Arrays.InsertAt(input, number, index);
      Arrays.Print(output, $"Array elements after inserting {number} at position {index}:");
    }

    private static void RemoveAtGivenIndex(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      const int index = 5;

      var output = Arrays.RemoveAt(input, index);
      Arrays.Print(output, $"Array elements after removing element at position {index}:");
    }

    private static void Pause(string message = "Press ENTER to continue...")
    {
      Console.WriteLine(message);
      Console.ReadLine();
    }
  }
}