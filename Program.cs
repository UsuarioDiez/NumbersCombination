using System;

namespace NumberCombinations
{
    class Class
    {
        static void Main(string[] args)
        {
            
        }

        static List<int[]> GetBinaryArrays(int[] numbers)
        {
            int bSize = (int)Math.Pow(2, numbers.Length) - 1;
            List<int[]> result = new List<int[]>();
            int[] tmpArrayFullLength;
            for (int i = 0; i <= bSize; i++)
            {
                int[] tmpArray = Array.ConvertAll(Convert.ToString(i, 2).ToCharArray(), s => int.Parse(s.ToString()));
                if (tmpArray.Length < numbers.Length)
                {
                    tmpArrayFullLength = new int[numbers.Length];
                    for (int j = 0; j < numbers.Length - tmpArray.Length; j++) tmpArrayFullLength[j] = 0;
                    tmpArray.CopyTo(tmpArrayFullLength, numbers.Length - tmpArray.Length);
                    result.Add(tmpArrayFullLength);
                }
                else result.Add(tmpArray);
            }
            return result;
        }

        static int ReadArraySize()
        {
            int result=0;
            bool sizeAssigned = false;
            while (!sizeAssigned)
            {
                try
                {
                    Console.WriteLine("Enter array size:");
                    result = Math.Abs(int.Parse(Console.ReadLine()));
                    sizeAssigned = true;
                }
                catch
                {
                    Console.WriteLine("You must enter a valid array size");
                }
            }
            return result;
        }
    }
}