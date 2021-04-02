using System;

namespace ArrayOperations
{
  /// <summary>
  /// This class contain methods for array operations.
  /// </summary>
  public static class Arrays
  {
    /// <summary>
    /// Sort an array using 'Merge Sort' algorithm.
    /// </summary>
    /// <param name="input">Array to be sorted.</param>
    /// <returns>A new array containing all the elements from 'input' sorted in ascending order.</returns>
    /// <exception cref="ArgumentNullException">The array is not initialized.</exception>
    public static int[] Sort(int[] input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (input.Length == 0 || input.Length == 1)
      {
        return input;
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

      return Merge(left, right);
    }
    
    /// <summary>
    /// Combine the elements of two arrays in to a new array.
    /// </summary>
    /// <param name="left">First array.</param>
    /// <param name="right">Second array.</param>
    /// <returns>A new array witch has the combined size and elements of both input arrays.</returns>
    /// <exception cref="ArgumentNullException">The array is not initialized.</exception>
    /// <exception cref="ArgumentException">The array has no elements.</exception>
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
        else
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
    /// <param name="input">Source array.</param>
    /// <param name="number">Number to insert in the array.</param>
    /// <param name="index">Position at which to insert the new number.</param>
    /// <returns>A new array with it's size increased by one and a new element located at the specified index.</returns>
    /// <exception cref="ArgumentNullException">The source array is not initialized.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Index is outside the bounds of the array.</exception>
    public static int[] InsertAt(int[] input, int number, int index)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
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
    public static int[] InsertFirst(int[] input, int number)
    {
      const int index = 0;
      return InsertAt(input, number, index);
      
    }

    /// <summary>
    /// Inserts a new element at the end of the array.
    /// </summary>
    /// <param name="input">The array</param>
    /// <param name="number">The number to be inserted.</param>
    /// <returns>A new array with it's size increased by one and a new element located at the end of the array.</returns>
    public static int[] InsertLast(int[] input, int number)
    {
      return InsertAt(input, number, input.Length);
    }
    
    /// <summary>
    /// Removes an element from the specified index of the array.
    /// </summary>
    /// <param name="input">The array from which to remove the element.</param>
    /// <param name="index">The position at which we remove the element from the array.</param>
    /// <returns>A new array with the size decreased by 1 and without the element found at specified index.</returns>
    /// <exception cref="ArgumentNullException">Array is not initialized.</exception>
    /// <exception cref="ArgumentException">Array has no elements.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Index is outside the bounds of the array.</exception>
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

      var newSize = input.Length - 1;
      var output = new int[newSize];
      for (var i = 0; i < output.Length; i++)
      {
        output[i] = i < index ? input[i] : input[i + 1];
      }

      return output;
    }
    
    /// <summary>
    /// Removes the first element from the array.
    /// </summary>
    /// <param name="input">The array from which to remove the element.</param>
    /// <returns>A new array with it's size decreased by one and without the first element.</returns>
    public static int[] RemoveFirst(int[] input)
    {
      const int Index = 0;
      return RemoveAt(input, Index);
    }

    /// <summary>
    /// Removes the last element from the array.
    /// </summary>
    /// <param name="input">The array from which to remove the element.</param>
    /// <returns>A new array with it's size decreased by one and without the last element.</returns>
    public static int[] RemoveLast(int[] input)
    {
      var lastIndex = input.Length - 1;
      return RemoveAt(input, lastIndex);
    }

    /// <summary>
    /// Prints the elements of an array separated by comma.
    /// </summary>
    /// <param name="input">The array to be printed.</param>
    /// <exception cref="ArgumentNullException">Array is not initialized.</exception>
    /// <exception cref="ArgumentException">Array has no elements.</exception>
    public static void Print(int[] input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      if (input.Length == 0)
      {
        throw new ArgumentException("Value cannot be an empty collection.", nameof(input));
      }
      
      var output = "";
      output += "[ ";
      output += string.Join(", ", input);
      output += " ]";
      Console.WriteLine(output);
    }
  }
}
