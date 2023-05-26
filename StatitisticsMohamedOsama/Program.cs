using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatitisticsMohamedOsama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter length of your dataset");
            int length = int.Parse(Console.ReadLine());
            float[] data = new float[length];
            Console.WriteLine("Enter data: ");
            for (int i = 0; i < length; i++)
            {
                Console.Write($"{i}. ");
                data[i] = int.Parse(Console.ReadLine());
                Console.Write("\n");
            }
            Array.Sort(data);
            Console.WriteLine("Mean =" + Mean(data));
            Console.WriteLine("Mode =" + Mode(data));
            Console.WriteLine("Median =" + Median(data));
            Console.WriteLine("Range =" + Range(data));
            Console.WriteLine("Q1 =" + Q1(data));
            Console.WriteLine("Q3 =" + Q3(data));
            Console.WriteLine("P90 =" + P90(data));
            Console.WriteLine("IQR =" + IQR(data));
            Console.WriteLine("Lower boundary = {0}, Upper boundary = {1}", Boundaries(data)[0], Boundaries(data)[1]);
            Console.Write("Enter number to determine if it's an outlier: ");
            float outlierNumber = float.Parse(Console.ReadLine());
            Console.WriteLine();
            if (outlierNumber < Boundaries(data)[0] || outlierNumber > Boundaries(data)[1])
            {
                Console.WriteLine(outlierNumber + "Is an outlier!");
            }
            else
            {
                Console.WriteLine(outlierNumber + "Is not an outlier.");
            }

        }
        static float Mean(float[] values)
        {
            float sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum / values.Length;
        }
        static float Median(float[] values)
        {
            if (values.Length % 2 == 0)
            {
                return (values[values.Length / 2 - 1] + values[values.Length / 2]) / 2;
            }
            else
            {
                return values[values.Length / 2 - 1];
            }
        }
        static float Mode(float[] values)
        {
            int highestCount = 0;
            int currentCount = 0;
            float highestNumber = 0;
            for (int i = 0; i < values.Length - 1; i++)
            {
                if (values[i] == values[i + 1])
                {
                    currentCount++;
                }
                else if (currentCount > highestCount)
                {
                    highestCount = currentCount;
                    highestNumber = values[i];
                }
                else
                {
                    currentCount = 0;
                }
            }
            return highestNumber;
        }
        static float Range(float[] values)
        {
            return values[values.Length - 1] - values[0];
        }
        static float Q1(float[] values)
        {
            float index = (values.Length * 0.25f) - 1;
            int ceilIndex = (int) Math.Ceiling(index);
            if (index == ceilIndex)
            {
                return (values[ceilIndex] + values[ceilIndex + 1]) / 2;
            }
            else
            {
                return values[ceilIndex];
            }
        }
        static float Q3(float[] values)
        {
            float index = (values.Length * 0.75f) - 1;
            int ceilIndex = (int)Math.Ceiling(index);
            if (index == ceilIndex)
            {
                return (values[ceilIndex] + values[ceilIndex + 1]) / 2;
            }
            else
            {
                return values[ceilIndex];
            }
        }
        static float P90(float[] values)        // 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        {
            float index = (values.Length * 0.9f) - 1;
            int ceilIndex = (int)Math.Ceiling(index);
            if (index == ceilIndex)
            {
                return (values[ceilIndex] + values[ceilIndex + 1]) / 2;
            }
            else
            {
                return values[ceilIndex];
            }
        }
        static float IQR(float[] values)
        {
            return Q3(values) - Q1(values);
        }
        static float[] Boundaries(float[] values)
        {
            float iqr = IQR(values);
            float q1 = Q1(values);
            float q3 = Q3(values);
            float boundaryLow = q1 - (iqr * 1.5f);
            float boundaryHigh = q3 + (iqr * 1.5f);
            float[] boundaries = new float[2] { boundaryLow, boundaryHigh };
            return boundaries;
        }

    }
}
