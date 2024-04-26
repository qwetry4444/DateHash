
namespace DateHash
{
    public class Program()
    {
        public static void Main()
        {
            int dataSize = 2000;
            int hashTableSize = 256;
            List<Date> dates = [];
            int[] yearCount = new int[89];
            int[] hashList = new int[hashTableSize];
            double medium;
            int sum = 0;

            double x2;



            Generator generator = new ();

            generator.KeyGenerate(dates);

            

            for (int i = 0; i < dates.Count; i++)
            {
                int x = Hash.HashDate(dates[i], hashTableSize);
                hashList[x]++;
            }
            int maxValue = hashList.Max();
            int maxIndex = hashList.ToList().IndexOf(maxValue);

            x2 = (double)hashTableSize / dataSize;
            for (int i = 0; i < hashList.Count(); i++)
            {
                x2 *= Math.Pow((double)hashList[i] - (double)dataSize / hashTableSize, 2);
            }


            for (int i = 0; i < dates.Count; i++)
            {
                yearCount[dates[i].Year - 1920]++;
            }

            for (int i = 0; i < hashList.Count(); i++)
            {
                sum += hashList[i];
            }
            medium = (double)sum / hashList.Count();
            Console.WriteLine($"Medium = {medium}");
            Console.WriteLine($"Max index = {maxIndex}");
            Console.WriteLine($"X2 = {x2}");

            for (int i = 0; i < hashList.Count(); i++)
            {
                //Console.WriteLine($"{i} : {hashList[i]}");
                //Console.WriteLine($"{i}");
                //Console.WriteLine($"{hashList[i]}");
            }
        }

        public static void PrintDates(List<Date> dates)
        {
            for (int i = 0; i < dates.Count; i++)
            {
                Console.WriteLine(dates[i].ToString());
            }
        }

        public static void PrintYearsCount(int[] yearCount)
        {
            for (int i = 0; i < yearCount.Count(); i++)
            {
                Console.WriteLine($"{i + 1920} : {yearCount[i]}");
            }
        }

    }
}