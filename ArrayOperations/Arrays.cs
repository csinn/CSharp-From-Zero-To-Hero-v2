using System;

namespace ArrayOperations
{
  /// <summary>
  /// This class contain methods for array operations.
  /// </summary>
  public static class Arrays
  {
    public static int[] Sort(int[] input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (input.Length == 0)
      {
        throw new ArgumentException("Value cannot be an empty collection.", nameof(input));
      }

      if (input.Length == 1)
      {
        return  input;
      }

      var midPoint = input.Length / 2;  
      
      var left = new int[midPoint];
      var right = input.Length % 2 == 0 ? new int[midPoint] : new int[midPoint + 1];

      for (var i = 0; i < midPoint; i++)
      {
        left[i] = input[i];
      }  

      var counter = 0;
      for (var i = midPoint; i < input.Length; i++)
      {
        right[counter] = input[i];
        counter++;
      }
      
      left = Sort(left);
      right = Sort(right);

      var output = Merge(left, right);  
      
      return output;
    }
    
    /// <summary>
    /// Combine the elements of two arrays in to a new array.
    /// </summary>
    /// <param name="left">First source array.</param>
    /// <param name="right">Second source array.</param>
    /// <returns>A new array witch has the combined size and elements of both input arrays.</returns>
    /// <exception cref="ArgumentNullException">The source array is not initialized.</exception>
    /// <exception cref="ArgumentException">The source array has no elements.</exception>
    public static int[] Merge(int[] left, int[] right)
    {
      if (left == null) throw new ArgumentNullException(nameof(left));
      if (right == null) throw new ArgumentNullException(nameof(right));
      if (left.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(left));
      if (right.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(right));

      var outputLength = right.Length + left.Length;
      var output = new int[outputLength];
      
      var indexLeft = 0;
      var indexRight = 0;
      var indexOutput = 0;  

      while (indexLeft < left.Length || indexRight < right.Length)
      {
        if (indexLeft < left.Length && indexRight < right.Length)  
        {  
          if (left[indexLeft] <= right[indexRight])
          {
            output[indexOutput] = left[indexLeft];
            indexLeft++;
            indexOutput++;
          }
          else
          {
            output[indexOutput] = right[indexRight];
            indexRight++;
            indexOutput++;
          }
        }
        else if (indexLeft < left.Length)
        {
          output[indexOutput] = left[indexLeft];
          indexLeft++;
          indexOutput++;
        }
        else if (indexRight < right.Length)
        {
          output[indexOutput] = right[indexRight];
          indexRight++;
          indexOutput++;
        }  
      }
      return output;
    }
 
    /// <summary>
    /// Inserts a new element in an array at the specified position.
    /// </summary>
    /// <param name="input">Destination array.</param>
    /// <param name="number">Number to insert in the array.</param>
    /// <param name="index">Position at which to insert the new number.</param>
    /// <returns>A new array with it's size increased by one and a new element located at the specified index.</returns>
    /// <exception cref="ArgumentNullException">The source array is not initialized.</exception>
    /// <exception cref="ArgumentException">The destination array has no elements.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Destination index is outside the bounds of the array.</exception>
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
    /// <param name="input">Destination array.</param>
    /// <param name="number">The number to be inserted.</param>
    /// <returns>A new array with it's size increased by one and a new element located at the front of the array.</returns>
    /// <exception cref="ArgumentNullException">The source array is not initialized.</exception>
    /// <exception cref="ArgumentException">The destination array has no elements.</exception>
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
    /// <param name="input">Destination array.</param>
    /// <param name="number">The number to be inserted.</param>
    /// <returns>A new array with it's size increased by one and a new element located at the end of the array.</returns>
    /// <exception cref="ArgumentNullException">The destination array is not initialized.</exception>
    /// <exception cref="ArgumentException">The destination array has no elements.</exception>
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
    /// <param name="input">Source array.</param>
    /// <param name="index">The position at which we remove an element from the array.</param>
    /// <returns>A new array with the size decreased by one and without the element found at specified index.</returns>
    /// <exception cref="ArgumentNullException">The source array is not initialized.</exception>
    /// <exception cref="ArgumentException">The source array has no elements.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Destination index is outside the bounds of the array.</exception>
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
    /// <param name="input">Source array.</param>
    /// <returns>A new array with it's size decreased by one and without the first element.</returns>
    /// <exception cref="ArgumentNullException">The source array is not initialized.</exception>
    /// <exception cref="ArgumentException">The source array has no elements.</exception>
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
    /// <param name="input">Source array.</param>
    /// <returns>A new array with it's size decreased by one and without the last element.</returns>
    /// <exception cref="ArgumentNullException">The source array is not initialized.</exception>
    /// <exception cref="ArgumentException">The source has no elements.</exception>
    public static int[] RemoveLast(int[] input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (input.Length == 0)
      {
        throw new ArgumentException("Value cannot be an empty collection.", nameof(input));
      }
      
      var output = RemoveAt(input, input.Length - 1);
      return output;
    }

    /// <summary>
    /// Prints the elements of an array separated by an empty space.
    /// </summary>
    /// <param name="input">Source array.</param>
    /// <param name="message">Explanatory message displayed to the user.</param>
    /// <param name="separator"></param>
    /// <exception cref="ArgumentNullException">The source array is not initialized.</exception>
    /// <exception cref="ArgumentException">The source has no elements.</exception>
    /// <exception cref="ArgumentException">The message is null or empty.</exception>
    public static void Print(int[] input, string message, char separator = ' ')
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

      var output = string.Join(separator, input);
      Console.WriteLine(output);
    }
  }
}
