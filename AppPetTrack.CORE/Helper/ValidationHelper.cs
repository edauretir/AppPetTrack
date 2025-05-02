
namespace AppPetTrack.CORE.Helper
{
    public class ValidationHelper
    {
        public static string SetData(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException($"{nameof(value)} boş veya null olamaz!");

            return value;
        }

        public static double ValidatePositiveDouble(double value) //Pozitif değer kontrolü yapar.
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException($"{nameof(value)} 0 dan küçük olmaz!!!");
            return value;
        }

        public static TimeSpan ValidateTimeSpan(TimeSpan value)
        {
            if (value < TimeSpan.Zero || value > TimeSpan.FromHours(24))
                throw new ArgumentException($"{nameof(value)} 0 ile 24 saat arasında olmalı.");
            return value;
        }

        public static DateTime ValidateDate(DateTime value)
        {
            if (value == DateTime.UtcNow)
                throw new ArgumentException($"{nameof(value)} 0 ile 24 saat arasında olmalı.");
            return value;
        }

    }
}
