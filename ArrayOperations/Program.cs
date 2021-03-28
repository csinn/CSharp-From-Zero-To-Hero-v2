using System;

namespace ArrayOperations
{
  internal static class Program
  {
    private static void Main(string[] args)
    {
      RunArrayOperationsDemo();
    }

    private static void RunArrayOperationsDemo()
    {
      var input = new[] {1, 3, 5, 6, 7, 10, 8, 2};
      
      TestSort(input);
      TestInsertFirst(input);
      TestInsertLast(input);
      TestRemoveFirst(input);
      TestRemoveLast(input);
      TestInsertAtGivenIndex(input);
      TestRemoveAtGivenIndex(input);
    }

    private static void TestSort(int[] input)
    {
      Arrays.Print(input, "Initial array elements:");
      Arrays.Sort(input);
      Arrays.Print(input, "Array after sort operation:");
    }

    private static void TestInsertFirst(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");

      const int numberToInsert = 12;

      var output = Arrays.InsertFirst(input, numberToInsert);
      Arrays.Print(output, $"Array elements after {numberToInsert} was inserted:");
    }

    private static void TestInsertLast(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      
      const int numberToInsert = 4;

      var output = Arrays.InsertLast(input, numberToInsert);
      Arrays.Print(output,$"Array elements after {numberToInsert} was inserted:");
    }

    private static void TestRemoveFirst(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      
      var output = Arrays.RemoveFirst(input);
      Arrays.Print(output,$"Array elements after first element was removed:");
    }

    private static void TestRemoveLast(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      
      var output = Arrays.RemoveLast(input);
      Arrays.Print(output,$"Array elements after last element was removed:");
    }

    private static void TestInsertAtGivenIndex(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      
      const int index = 4;
      const int number = 99;

      var output = Arrays.InsertAt(input, number, index);
      Arrays.Print(output, $"Array elements after inserting {number} at position {index}:");
    }

    private static void TestRemoveAtGivenIndex(int[] input)
    {
      Arrays.Print(input,"Initial array elements:");
      const int index = 5;

      var output = Arrays.RemoveAt(input, index);
      Arrays.Print(output, $"Array elements after removing element at position {index}:");
    }
  }
}