
namespace DateHash
{
    public static class Hash
    {
        public static int HashDate(Date date)
        {
            int hash = 0;

            hash = ((date.Year - 1920) * 10000 + date.Month + 100 + date.Day) % 256;
            Random random = new Random(date.GetHashCode());
            hash = (hash + random.Next(256)) % 256;
            return hash ;
        }
        


    }
}
