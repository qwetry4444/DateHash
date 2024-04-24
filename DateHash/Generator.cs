using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void KeyGenerate(List<Date> dates, int hashTableSize = 2000)
        {
            Date date;
            for (int i = 0; i < hashTableSize;)
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
            date.Year = GenerateRandomYear();
            return date;
        }

        // Диапазон измениния Year [1920, 2008] величина изменяется по нормальному закону с максимумом в 1970
        private int GenerateRandomYear()
        {
            double maxYear = 1970;
            double stdDev = (maxYear - 1920) / 3.0; // Стандартное отклонение для нормального распределения
            double mean = (1920 + maxYear) / 2.0; // Среднее значение для нормального распределения

            // Генерируем случайный год на основе нормального распределения
            double u1 = 1.0 - random.NextDouble(); // Случайное число от 0 до 1
            double u2 = 1.0 - random.NextDouble(); // Случайное число от 0 до 1
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); // Нормально распределенное случайное число
            double randNormal = mean + stdDev * randStdNormal; // Нормально распределенное число со сдвигом и масштабированием

            // Ограничиваем значение года диапазоном
            int generatedYear = (int)Math.Round(randNormal);
            generatedYear = Math.Max(1920, Math.Min(2008, generatedYear));

            return generatedYear;
        }
    }
}
