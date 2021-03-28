using System;

namespace ArrayOperations
{
  /// <summary>
  /// This class contain methods for array operations.
  /// </summary>
  public static class Arrays
  {
    /// <summary>
    /// Sort an array using 'Bubble Sort' algorithm.
    /// </summary>
    /// <param name="input"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
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
      
      for (var i = 0; i < input.Length - 1; i++)
      {
        for (var j = 0; j < input.Length - i - 1; j++)
        {
          if (input[j] > input[j + 1 ])
          {
            SwapElements(input, j, j + 1);
          }
        }
      }
    }
    
    /// <summary>
    /// Swap the elements of an array.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
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
    
    /// <summary>
    /// Inserts a new element in an array at the specified position.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="number"></param>
    /// <param name="index"></param>
    /// <returns>A new array with it's size increased by one and a new element located at the specified index.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
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
    
    /// <summary>
    /// Inserts a new element at the beginning of the array.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="number"></param>
    /// <returns>A new array with it's size increased by one and a new element located at the front of the array.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
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

    /// <summary>
    /// Inserts a new element at the end of the array.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="number"></param>
    /// <returns> new array with it's size increased by one and a new element located at the end of the array.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
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
    
    /// <summary>
    /// Removes an element from the specified index of the array.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="index"></param>
    /// <returns>A new array with the size decreased by one and without the element found at specified index.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
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
    
    /// <summary>
    /// Removes the first element from the array.
    /// </summary>
    /// <param name="input"></param>
    /// <returns>A new array with it's size decreased by one and without the first element.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
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

    /// <summary>
    /// Removes the last element from the array.
    /// </summary>
    /// <param name="input"></param>
    /// <returns>A new array with it's size decreased by one and without the last element.</returns>
    public static int[] RemoveLast(int[] input)
    {
      var output = RemoveAt(input, input.Length - 1);
      return output;
    }

    /// <summary>
    /// Prints the elements of an array separated by an empty space.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="message"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
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

      var output = string.Join(" ", input);
      Console.WriteLine(output);
    }
  }
}
