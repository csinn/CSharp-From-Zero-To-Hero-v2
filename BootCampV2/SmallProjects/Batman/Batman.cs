using System;
using System.Collections.Generic;
using System.Text;

namespace BootCampV2.SmallProjects.Batman
{
    class Batman
    {
        static void PrintVerse(int naRepeatTimes, int batmanRepeatTimes)
        {
            Repeat("na", naRepeatTimes);
            // Finish with ! and give space for batmans.
            Console.Write("! ");
            Repeat("Batman! ", batmanRepeatTimes);
            // Finish the verse by starting a new line.
            Console.WriteLine();
        }

        static void Repeat(string word, int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.Write(word);
            }
        }

        static void PrintBatmanSong(int _lastVerse, int _nanaRepeat)
        {
            int lastVerse = _lastVerse;
            int nanaRepeatStart = _nanaRepeat;

            for (int verse = 0; verse <= lastVerse; verse++)
            {
                bool isLast = verse == 3;
                int batmanRepeat;
                if (isLast)
                {
                    batmanRepeat = 3;
                }
                else
                {
                    batmanRepeat = 1;
                }

                PrintVerse(nanaRepeatStart - verse, batmanRepeat);
            }
        }
    }
}
