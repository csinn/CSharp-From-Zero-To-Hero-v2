using System;

namespace BootCamp.Chapter1
{
    public static class Array_Functions
    {
        public static int[] Sort_Array(int[] array)
        {
            int temp;
            for (int j = 0; j <= array.Length - 2; j++)
            {
                for (int i = 0; i <= array.Length - 2; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                    }
                }


            }

            return array;

        }

        public static int[] Add_Start_Array(int [] array, int number)
        {
            return Add_Nth_Place_Array(array, number, 0); 
         }

        public static int[] Add_End_Array(int [] array, int number)
        {
            return Add_Nth_Place_Array(array, number, array.Length); 
        }

        public static int[]  Add_Nth_Place_Array(int [] array, int number, int index)
        {
            var new_array = new int[array.Length +1];

            // Copy old one till the index 

            for (int i = 0; i < index;  i++)
            {
                new_array[i] = array[i]; 
            }

            // Insert new value

            new_array[index] = number;

            //Copy the rest of the old_array 

            for (int i = index ; i < array.Length; i++)
            {
                new_array[i + 1] = array[i]; 
            }

            return new_array; 
        }

        public static int[] Remove_Start_Array(int[] array)
        {
            return Remove_Nth_Place_Array(array, 0);
        }

        public static int[] Remove_End_Array(int [] array)
        {
            return Remove_Nth_Place_Array(array, array.Length -1 ); 
        }

        public static int[] Remove_Nth_Place_Array(int[] array, int index)
        {
            var new_array = new int[array.Length - 1];  
            for (int i = 0; i < array.Length; i++)
            {
                if (i == index)
                {
                    continue; 
                }

                if (i < index)
                {
                    new_array[i] = array[i]; 
                }
                else
                {
                    new_array[i - 1] = array[i]; 
                }
            }

            return new_array; 
        }

        public static void Login(string username, string password)
        {
           if (username.Equals("test", StringComparison.OrdinalIgnoreCase) && password.Equals("secret", StringComparison.Ordinal))
            {
                Console.WriteLine("Loggged In");
            }
        }
    }
}
