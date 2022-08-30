using System.Globalization;

namespace TaskManager.Extensions
{
    /// <summary>
    /// Расширения для формата DateTime.
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Преобразовывает DateTime к заданному формату.
        /// </summary>
        /// <param name="dateTime"> Значение DateTime. </param>
        /// <returns> Дата в формтае строки в нужном формате. </returns>
        public static string ConvertToFormat(this DateTime dateTime, string format)
        {
            var dT = DateTime.ParseExact(dateTime.ToString(), "yyyy-MM-dd hh:mm:ss tt",
                CultureInfo.InvariantCulture);

            return dT.ToString(format, CultureInfo.InvariantCulture);
        }

        public static DateTime ConvertToDateTime (this string date)
        {
            return DateTime.ParseExact(date, "yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture);
        }
    }
}
