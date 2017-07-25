using System;

namespace Shared.Infrasctructure.ObjectExtensions
{
    public static class ObjectExtensions
    {
        public static void NotNull<T>(this T obj, string paramName) where T : class
        {
            if (obj == null) throw new ArgumentException($"{paramName} can not be null");
        }

        public static void NotNull<T>(this T obj) where T : class
        {
            NotNull(obj, "Object property can not be null");
        }
    }
}
