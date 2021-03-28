using System;

namespace ArrayOperations
{
  public static class Arrays
  {
    public static void Sort(int[] input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (input.Length == 0)
      {
        throw new ArgumentException("Value cannot be an empty collection.", nameof(input));
      }
      
      for (var i = input.Length - 1; i >= 0; i--)
      {
        for (var j = 1; j <= i; j++)
        {
          if (input[j - 1] <= input[j])
          {
            continue;
          }

          SwapElements(input, j, j - 1);
        }
      }
    }

    private static void SwapElements(int[] input, int left, int right)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (input.Length == 0)
      {
        throw new ArgumentException("Value cannot be an empty collection.", nameof(input));
      }

      var temp = input[left];
      input[left] = input[right];
      input[right] = temp;
    }
    
    public static int[] InsertAt(int[] input, int number, int index)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (input.Length == 0)
      {
        throw new ArgumentException("Value cannot be an empty collection.", nameof(input));
      }

      if (index < 0 || index > input.Length)
      {
        throw new ArgumentOutOfRangeException(nameof(index));
      }

      var output = new int[input.Length + 1];
      output[index] = number;

      for (var i = 0; i < input.Length; i++)
      {
        if (i < index)
        {
          output[i] = input[i];
        }
        else
        {
          output[i + 1] = input[i];
        }
      }

      return output;
    }

    public static int[] InsertFirst(int[] input, int number)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (input.Length == 0)
      {
        throw new ArgumentException("Value cannot be an empty collection.", nameof(input));
      }
      
      const int index = 0;
      var output = InsertAt(input, number, index);
      return output;
    }

    public static int[] InsertLast(int[] input, int number)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (input.Length == 0)
      {
        throw new ArgumentException("Value cannot be an empty collection.", nameof(input));
      }

      var output = InsertAt(input, number, input.Length);
      return output;
    }
    
    public static int[] RemoveAt(int[] input, int index)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (input.Length == 0)
      {
        throw new ArgumentException("Value cannot be an empty collection.", nameof(input));
      }

      if (index < 0 || index >= input.Length)
      {
        throw new ArgumentOutOfRangeException(nameof(index));
      }

      var output = new int[input.Length - 1];
      for (var i = 0; i < output.Length; i++)
      {
        output[i] = i < index ? input[i] : input[i + 1];
      }

      return output;
    }

    public static int[] RemoveFirst(int[] input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (input.Length == 0)
      {
        throw new ArgumentException("Value cannot be an empty collection.", nameof(input));
      }

      const int index = 0;
      var output = RemoveAt(input, index);
      return output;
    }

    public static int[] RemoveLast(int[] input)
    {
      var output = RemoveAt(input, input.Length - 1);
      return output;
    }

    public static void Print(int[] input, string message)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (input.Length == 0)
      {
        throw new ArgumentException("Value cannot be an empty collection.", nameof(input));
      }
      
      if (string.IsNullOrWhiteSpace(message))
      {
        throw new ArgumentException("Value cannot be null or empty.", nameof(message));
      }

      Console.WriteLine(message);
      var output = "";
      foreach (var item in input)
      {
        output += item;
        output += " ";
      }

      Console.WriteLine(output.Trim());
    }
  }
}
