using System;

namespace SecondLessonHomework
{
    internal class Program
    {
        const string USERNAME = "usernaMe";
        const string PASSWORD = "passworDas";

        static void Main(string[] args)
        {
            PrintInformationAboutLogin();
            PrintInformationAboutArrayMethods();
        }

        static void PrintInformationAboutLogin()
        {
            string usernameInput = PromptStringInput("What's your username?");
            string passwordInput = PromptStringInput("What's your password?");

            bool usernameAndPasswordIsCorrect = IsUsernameAndPasswordCorrect(usernameInput, passwordInput);
            if (usernameAndPasswordIsCorrect)
            {
                Console.WriteLine("Information was correct. User is now logged in!\n");
            }
            else
            {
                Console.WriteLine("Information was not correct. Rerun program to try again!\n");
            }
        }

        static string PromptStringInput(string questionToAskUser)
        {
            string textToWrite = $"{questionToAskUser} ";
            Console.Write(textToWrite);

            string textInput = Console.ReadLine();
            return textInput;
        }

        static bool IsUsernameAndPasswordCorrect(string username, string password)
        {
            return username.Equals(USERNAME, StringComparison.OrdinalIgnoreCase) && password.Equals(PASSWORD);
        }

        static void PrintInformationAboutArrayMethods()
        {
            int[] ints = { 1, 9, 6, 4, 3 };

            ints = AddElementAtStartOfArray(ints, 12);
            ints = AddElementAtEndOfArray(ints, 15);
            ints = AddElementAtSelectedPositionOfArray(ints, 4, 10);
            ints = RemoveElementAtStartOfArray(ints);
            ints = RemoveElementAtEndOfArray(ints);
            ints = RemoveElementAtSelectedPositionOfArray(ints, 2);

            SortArray(ints);
            foreach (var item in ints)
            {
                Console.Write(item + " ");
            }
        }

        static int[] AddElementAtStartOfArray(int[] arrayToExpand, int elementToAdd)
        {
            int[] newArray = AddElementAtSelectedPositionOfArray(arrayToExpand, 0, elementToAdd);
            return newArray;
        }

        static int[] AddElementAtEndOfArray(int[] arrayToExpand, int elementToAdd)
        {
            int[] newArray = AddElementAtSelectedPositionOfArray(arrayToExpand, arrayToExpand.Length, elementToAdd);
            return newArray;
        }

        static int[] AddElementAtSelectedPositionOfArray(int[] arrayToExpand, int indexOfArrayToAdd, int elementToAdd)
        {
            if (indexOfArrayToAdd > arrayToExpand.Length + 1)
            {
                indexOfArrayToAdd = arrayToExpand.Length;
            }

            int[] newArray = new int[arrayToExpand.Length + 1];

            Array.Copy(arrayToExpand, 0, newArray, 0, indexOfArrayToAdd);
            newArray[indexOfArrayToAdd] = elementToAdd;
            Array.Copy(arrayToExpand, indexOfArrayToAdd, newArray, indexOfArrayToAdd + 1, arrayToExpand.Length - indexOfArrayToAdd);

            return newArray;
        }

        static int[] RemoveElementAtStartOfArray(int[] arrayToDecrease)
        {
            int[] newArray = RemoveElementAtSelectedPositionOfArray(arrayToDecrease, 0);
            return newArray;
        }

        static int[] RemoveElementAtEndOfArray(int[] arrayToDecrease)
        {
            int[] newArray = RemoveElementAtSelectedPositionOfArray(arrayToDecrease, arrayToDecrease.Length - 1);
            return newArray;
        }

        static int[] RemoveElementAtSelectedPositionOfArray(int[] arrayToDecrease, int indexOfArrayToRemove)
        {
            if (indexOfArrayToRemove >= arrayToDecrease.Length)
            {
                return arrayToDecrease;
            }

            int[] newArray = new int[arrayToDecrease.Length - 1];

            Array.Copy(arrayToDecrease, 0, newArray, 0, indexOfArrayToRemove);
            Array.Copy(arrayToDecrease, indexOfArrayToRemove + 1, newArray, indexOfArrayToRemove, arrayToDecrease.Length - indexOfArrayToRemove - 1);

            return newArray;
        }

        static void SortArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] == array[j]) continue;

                    if (array[i] < array[j])
                    {
                        int temporary = array[i];
                        array[i] = array[j];
                        array[j] = temporary;
                    }
                }
            }
        }
    }
}