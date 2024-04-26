
namespace DateHash
{
    public static class Hash
    {
        public static int HashDate(Date date, int hashTableSize)
        {
            int hash = 55;

            if (date.Year == 1970)
            {
                hash += 200;
            }

            hash = hash * 31 + (date.Year - 1920);
            hash = hash * 31 + date.Month;
            hash = hash * 31 + date.Day;

            hash += 15;
            return hash % hashTableSize;
        }
    }
}
