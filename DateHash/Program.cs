
namespace DateHash
{
    public class Program()
    {
        public static void Main()
        {
            int hashTableSize = 256;
            List<Date> dates = [];
            int[] hashList = new int[hashTableSize];

            Generator generator = new ();

            generator.KeyGenerate(dates);

            //for (int i = 0; i < dates.Count; i++)
            //{
            //    Console.WriteLine(dates[i].ToString());
            //}

            for (int i = 0; i < dates.Count; i++)
            {
                hashList[Hash.HashDate(dates[i])]++;
            }

            for (int i = 0; i < hashList.Count(); i++)
            {
                Console.WriteLine($"{i} : {hashList[i]}");
            }
        }
    }
}