using System;

namespace Shared.Infrasctructure.ObjectExtensions
{
    public static class StringExtensions
    {
        public static void NotNullOrEmpty(this string obj, string paramName)
        {
            if (string.IsNullOrEmpty(obj)) throw new ArgumentException($"{paramName} can not be null or empty");
        }

        public static void NotNullOrEmpty(this string obj)
        {
            NotNullOrEmpty(obj, "String property can not be null or empty");
        }
    }
}
