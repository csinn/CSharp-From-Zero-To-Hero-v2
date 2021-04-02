using System;
using System.Linq.Expressions;

namespace lesson_number_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {5, 3, 1, 4, 2, 12, 15, 9, 8};

            int[] a = SortArray(numbers);
            int[] b = AddElementEndOfArray(numbers, 6);
            int[] c = AddElementStartOfArray(numbers, 6);
            int[] d = AddElementAnyPositionInArray(numbers, 6, 5);
            int[] e = RemoveElementStartOfArray(numbers);
            int[] f = RemoveElementEndOfArray(numbers);
            int[] g = RemoveElementAnyPositionInArray(numbers, 2);
          
            //change the parameter below to show the outputs of the various array methods
            PrintUpdatedArray(a);
            
            //send in correct username/password
            string loginMsg = Login("Username", "Passw0rd");
            Console.WriteLine(loginMsg);
        }

        private static void PrintUpdatedArray(int[] g)
        {
            for (int i = 0; i < g.Length; i++)
            {
                Console.WriteLine(g[i]);
            }
        }

        private static string Login(string savedUsername, string savedPassword)
        {
            string loginMsg = "";
            
            Console.WriteLine("Please enter username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Please enter password: ");
            string password = Console.ReadLine();

            if (username.Equals(savedUsername, StringComparison.OrdinalIgnoreCase) &&
                password.Equals(savedPassword, StringComparison.Ordinal))
            {
                loginMsg = "Logged In!";
                return loginMsg;
            }

            loginMsg = "Username or password was incorrect!";
            return loginMsg;
        }

        static int[] SortArray(int[] numbers)
        {
            int[] newArray = new int[numbers.Length];
            
            for (int i = 0; i < numbers.Length; i++)
            {
                var num = FindNewLowestNumber(numbers, newArray);

                newArray[i] = num;
            }
            return newArray;
        }

        private static int FindNewLowestNumber(int[] numbers, int[] newArray)
        {
            //So first comparison is always set to num
            int num = 999;

            for (int e = 0; e < numbers.Length; e++)
            {
                if (numbers[e] < num)
                {
                    int lowestNumber = numbers[e];
                    bool numberAlreadyInNewArray = CheckIfNumberAlreadyInNewArray(lowestNumber, newArray, e);

                    if (!numberAlreadyInNewArray) num = lowestNumber;
                }
            }

            return num;
        }

        private static bool CheckIfNumberAlreadyInNewArray(int lowestNumber, int[] newArray, int e)
        {
            bool numberAlreadyInNewArray = false;

            foreach (var newArrayNum in newArray)
            {
                if (lowestNumber == newArrayNum)
                {
                    numberAlreadyInNewArray = true;
                }
            }

            return numberAlreadyInNewArray;
        }

        static int[] AddElementEndOfArray(int[] numbers, int newNum)
        {
            int[] newArray = new int[numbers.Length + 1];

            for (int i = 0; i < newArray.Length; i++)
            {
                if (i + 1 == newArray.Length)
                {
                    newArray[i] = newNum;
                    continue;
                }
                newArray[i] = numbers[i];
            }
            
            return newArray;
        }

        static int[] AddElementStartOfArray(int[] numbers, int newNum)
        {
            int[] newArray = new int[numbers.Length + 1];
 
            for (int i = 0; i < newArray.Length; i++)
            {
                if (i == 0)
                {
                    newArray[i] = newNum;
                    continue;
                }
                newArray[i] = numbers[i - 1];
            } 
            
            return newArray;
        }

        static int[] AddElementAnyPositionInArray(int[] numbers, int newNum, int position)
        {
            int[] newArray = new int[numbers.Length + 1];
            bool newNumberWasAdded = false;

            for (int i = 0; i < newArray.Length; i++)
            {
                if (i + 1 == position)
                {
                    newArray[i] = newNum;
                    newNumberWasAdded = true;
                    continue;
                    
                }

                if (newNumberWasAdded)
                {
                    newArray[i] = numbers[i - 1];
                    continue;
                }
                
                newArray[i] = numbers[i];
            }

            return newArray;
        }

        static int[] RemoveElementStartOfArray(int[] numbers)
        {
            int[] newArray = new int[numbers.Length - 1];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = numbers[i + 1];
            }

            return newArray;
        }

        static int[] RemoveElementEndOfArray(int[] numbers)
        {
            int[] newArray = new int[numbers.Length - 1];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = numbers[i];
            }

            return newArray;
        }

        static int[] RemoveElementAnyPositionInArray(int[] numbers, int position)
        {
            int[] newArray = new int[numbers.Length - 1];
            bool wasNumberRemoved = false;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i + 1 == position)
                {
                    wasNumberRemoved = true;
                    continue;
                }

                if (wasNumberRemoved)
                {
                    newArray[i - 1] = numbers[i];
                    continue;
                }

                newArray[i] = numbers[i];
            }
            
            return newArray;
        }
    }
}