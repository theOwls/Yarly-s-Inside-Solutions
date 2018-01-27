using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Helpers
{
    public static class StringExtensions
    {
        public static T CastTo<T>(this String s)
        {
            try
            {
                return s.IsNullEmptyOrWhiteSpace() ? default(T) : (T)Convert.ChangeType(s, typeof(T));
            }
            catch (FormatException)
            {
                return s.GetDefaultValue<T>();
            }
        }

        public static bool IsEmptyOrNull(this String s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNotEmptyOrNull(this String s)
        {
            return !IsEmptyOrNull(s);
        }

        public static bool IsNullEmptyOrWhiteSpace(this String s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static bool IsNotNullEmptyOrWhiteSpace(this String s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        public static char GetFirstLetter(this String s, bool toUpper = false)
        {
            if (s.IsNullEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException();
            }
            char firstLetter = s[0];

            return toUpper ? Char.ToUpper(firstLetter) : firstLetter;
        }

        public static Guid ToGuid(this string s)
        {
            if (s.IsNullEmptyOrWhiteSpace())
            {
                return Guid.NewGuid();
            }

            Guid parseGuid = Guid.Empty;

            if(!Guid.TryParse(s, out parseGuid))
            {
                const string ParseFailExceptionMessage
                    = "Unable to parse {0} to Guid";
                throw new ArgumentException(string.Format(ParseFailExceptionMessage, s));
            }

            return parseGuid;
        }
    }
}
