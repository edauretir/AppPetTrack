using AppPetTrack.SERVICE.Exceptions;
using System.Reflection;

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

        //public static bool IsDefault<T>(T value)//Boş değer kontrolü yapar.
        //{
        //    if (value == null)
        //        return true;

        //    if (value is string str && string.IsNullOrWhiteSpace(str))
        //        return true;

        //    return EqualityComparer<T>.Default.Equals(value, default(T));
        //}

        //public static void ValidateProperties<T>(T obj)
        //{
        //    if (obj == null)
        //        throw new ArgumentNullException(nameof(obj), "Obje null olamaz");

        //    var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);


        //    foreach ( var prop in props)
        //    {
        //        var value = prop.GetValue(obj);
                  
        //        if(prop.PropertyType == typeof(string))
        //        {
        //            if (string.IsNullOrWhiteSpace(value as string))
        //                throw new ValidationException(prop.Name, $"{prop.Name} boş olamaz!");
        //        }
        //        else if (prop.PropertyType.IsValueType)
        //        {
        //            var defaultValue = Activator.CreateInstance(prop.PropertyType);
        //            if (value?.Equals(defaultValue) == true)
        //                throw new ValidationException(prop.Name, $"{prop.Name} geçersiz değerde!");
        //        }
        //    }
        //}




    }
}
