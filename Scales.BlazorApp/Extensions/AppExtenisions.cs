namespace Scales.BlazorApp.Extensions
{
    public static class AppExtenisions
    {
        public static string ConvertValueToString<T>(this T number) where T : struct
        {
            return string.Format("{0:f}", number);
        }

        public static string[] GetStringValues<T>(this IEnumerable<T> numbers) where T : struct
        {
            var array = new string[numbers.Count()];
            int k = 0;
            foreach (var number in numbers)
            {
                array[k] = string.Format("{0:f2}", number);
            }
            return array;
        }
    }
}
