namespace DateHash
{
    public class Generator
    {
        private Random random;
        private HashSet<Date> usedKeys;

        public Generator()
        {
            random = new Random();
            usedKeys = new HashSet<Date>();
        }

        public void KeyGenerate(List<Date> dates, int generateCount = 2000)
        {
            Date date;
            for (int i = 0; i < generateCount;)
            {
                date = GenerateDate();
                if (usedKeys.Contains(date))
                {
                    continue;
                }
                usedKeys.Add(date);
                dates.Add(date);
                i++;
            }
        }

        public Date GenerateDate()
        {
            Date date = new Date();
            date.Day = random.Next(1, 32); 
            date.Month = random.Next(1, 13);
            date.Year = GenerateYear();
            return date;
        }

        private int GenerateYear()
        {
            const double mu = 1970; // Среднее значение (центр нормального распределения).
            const double sigma = 13; // Стандартное отклонение.

            // Генерируем случайную величину с нормальным распределением.
            double u1 = 1.0 - random.NextDouble(); // Случайное число от 0 до 1.
            double u2 = 1.0 - random.NextDouble(); // Следующее случайное число от 0 до 1.
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); // Случайная величина с нормальным распределением.

            // Преобразуем нормальную величину в год.
            int year = (int)(mu + sigma * randStdNormal);

            // Убеждаемся, что год находится в допустимом диапазоне (1920-2008).
            return Math.Max(1920, Math.Min(2008, year));
        }
    }
}
