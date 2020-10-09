using System;
using System.ComponentModel;

namespace GenericsAndReflections.App.Classes
{
    public static class StringExtensions
    {
        public static TEnum ParseEnum<TEnum>(this string value)
        {
            return(TEnum)Enum.Parse(typeof(TEnum), value);
        }


        public static T ChangeType<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}
