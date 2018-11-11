using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Model22TextFile.Domain.Extensions
{
    public static class ConvertExtentions
    {
        public static string RemoveCharacter(this string pValue, string pCharacters, string pNewCharacter)
        {
            foreach (var item in pCharacters.ToCharArray())
                pValue = pValue.Replace(item.ToString(), pNewCharacter);

            return pValue;
        }

        public static string MaxLength(this string pText, int pMax)
        {
            return pText.Length > pMax ? pText.Substring(0, pMax) : pText;
        }

        public static string NoAccents(this string pText)
        {
            /** Troca os caracteres acentuados por não acentuados **/
            string[] acentos = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            string[] semAcento = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

            for (int i = 0; i < acentos.Length; i++)
            {
                pText = pText.Replace(acentos[i], semAcento[i]);
            }

            /** Troca os caracteres especiais da string por "" **/
            string[] caracteresEspeciais = { "\\.", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°" };

            for (int i = 0; i < caracteresEspeciais.Length; i++)
            {
                pText = pText.Replace(caracteresEspeciais[i], "");
            }

            /** Troca os espaços no início por "" **/
            pText = pText.Replace("^\\s+", "");
            /** Troca os espaços no início por "" **/
            pText = pText.Replace("\\s+$", "");
            /** Troca os espaços duplicados, tabulações e etc por  " " **/
            pText = pText.Replace("\\s+", " ");

            return pText;
        }

        public static T To<T>(this object value)
        {
            Type conversionType = typeof(T);
            return (T)To(value, conversionType);
        }

        public static object To(this object value, Type conversionType)
        {
            if (conversionType == null)
                throw new ArgumentNullException("conversionType");

            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                    return null;
                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            else if (conversionType == typeof(Guid))
            {
                return new Guid(value.ToString());

            }
            else if (conversionType == typeof(Int64) && value.GetType() == typeof(int))
            {
                throw new InvalidOperationException("Can't convert an Int64 (long) to Int32(int).");
            }

            if ((value is string || value == null || value is DBNull) &&
                (conversionType == typeof(short) ||
                conversionType == typeof(int) ||
                conversionType == typeof(long) ||
                conversionType == typeof(double) ||
                conversionType == typeof(decimal) ||
                conversionType == typeof(float)))
            {
                decimal number;
                if (!decimal.TryParse(value as string, out number))
                    value = "0";
            }

            return Convert.ChangeType(value, conversionType);
        }

        public static string ParseToString(this decimal pValue, int pDecimalPlaces, string cultureInfo = "en-US")
        {
            return pValue.ToString("f" + pDecimalPlaces.ToString(CultureInfo.InvariantCulture) + "", CultureInfo.CreateSpecificCulture(cultureInfo));
        }

        public static string NoSimbols(this string pValue)
        {
            if (string.IsNullOrEmpty(pValue))
                return pValue;

            return pValue.RemoveCharacter(@"-.,/\(){}[]”-%$&-.;:º'", "");
        }

        public static string NoSpaces(this string pValue)
        {
            if (string.IsNullOrEmpty(pValue))
                return pValue;

            return pValue.RemoveCharacter(@" ", "");
        }

        public static Boolean IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null || source.Count() == 0)
                return true;

            return !source.Any();
        }
    }
}
