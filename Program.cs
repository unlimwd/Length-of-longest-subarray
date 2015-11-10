using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] srcArray = new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, };
            List<int[]> InfoAboutSubarrays = new List<int[]>();
            int SearchableSubarrayStartPosition = 0;
            int SearchableSubarrayStopPosition = 0;
            int SearchableSubarrayLength = -1;  // (StopPosition - StartPosition) may be equal 0. because of it SearchableSubarrayLength must be
                                                //less than 0, to get real StopPosition and StartPosition of our current subarray already at first iteration 
                                                //of search after checking condition.

            for (int StopPosition = 0; StopPosition <= srcArray.Length - 1; StopPosition++) //exhaustive search of all subarrays
            {
                for (int StartPosition = 0; StartPosition <= StopPosition; StartPosition ++) //exhaustive search of all subarrays
                {
                    if (CheckSubarrayByCondition(srcArray, StartPosition, StopPosition)) //is current subarray have more 0s than 1s
                    {
                        if (SearchableSubarrayLength < StopPosition - StartPosition)
                        {
                            SearchableSubarrayStartPosition = StartPosition;
                            SearchableSubarrayStopPosition = StopPosition;
                            SearchableSubarrayLength = StopPosition - StartPosition;
                        }
                    }
                }
            }
            //Show the longest subarray
            Console.WriteLine("Lenght of searchable subarray is {0} elements \n", SearchableSubarrayLength);            

            for (int i = SearchableSubarrayStartPosition; i <= SearchableSubarrayStopPosition; i++)
            {
                Console.Write(srcArray[i]);
            }
            Console.ReadLine();
        }

        static bool CheckSubarrayByCondition(int[] srcArray, int StartPosition, int StopPosition)
        {
            int CountOf_0_InArray = 0;
            int CountOf_1_InArray = 0;

            for (int i = StartPosition; i <= StopPosition; i++)
            {

                switch (srcArray[i])
                {
                    case 0:
                        CountOf_0_InArray++;
                        break;
                    case 1:
                        CountOf_1_InArray++;
                        break;
                }
            }
            if (CountOf_0_InArray > CountOf_1_InArray) return true;
            else return false;
        }
    }
}
