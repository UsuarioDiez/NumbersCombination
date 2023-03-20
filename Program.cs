using System;

namespace NumberCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array size.");
            int[] numbers = new int[Math.Abs(ReadInt())];
            Console.WriteLine("\nEnter array values");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Enter value {i}: ");
                numbers[i] = ReadInt();
            }
            FindCombinations(numbers);
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
        static int ReadInt()
        {
            int result=0;
            bool sizeAssigned = false;
            while (!sizeAssigned)
            {
                try
                {
                    result =int.Parse(Console.ReadLine());
                    sizeAssigned = true;
                }
                catch
                {
                    Console.WriteLine("You must enter an int");
                }
            }
            return result;
        }
        static void FindCombinations(int[] numbers)
        {
            int maxValue = numbers.Max();
            int count = 0;
            int sum;
            int maxValueIndex = Array.IndexOf(numbers, maxValue);
            numbers[maxValueIndex] = 0;
            List<int[]> binaryArrays = GetBinaryArrays(numbers);
            for (int i = 0; i < binaryArrays.Count; i++)
            {
                sum = 0;
                for(int j=0; j<numbers.Length; j++)
                {
                    sum = sum + binaryArrays[i][j] * numbers[j];          
                }
                if (sum == maxValue & binaryArrays[i][maxValueIndex]!=1)
                {
                    count++;
                    Console.WriteLine("\nSuccesful combination found!");
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (binaryArrays[i][k] != 0 & numbers[k]!=0)
                        {
                            Console.Write($"{numbers[k]}+");
                        }
                    }
                    Console.Write($"={sum}");
                }
            }
            Console.WriteLine($"\n\nThere were found {count} succesful combinations out of {binaryArrays.Count} posibilities");
        }
    }
}