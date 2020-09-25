using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InvoiceCloud.Extensions
{
	public static class StringExtensions
	{
		public static string EnsureEndsWith (this string str, char c)
		{
			return EnsureEndsWith(str, c, StringComparison.InvariantCulture);
		}

		public static string EnsureEndsWith(this string str, char c, StringComparison comparisonType)
		{
			if(str == null)
			{
				throw new ArgumentNullException("str");
			}

			if (str.EndsWith(c.ToString(CultureInfo.InvariantCulture), comparisonType))
			{
				return str;
			}

			return str + c;
		}

		public static string EnsureEndsWith(this string str, char c, bool ignoreCase, CultureInfo culture)
		{
			if(str == null)
			{
				throw new ArgumentNullException("str");
			}

			if (str.EndsWith(c.ToString(culture), ignoreCase, culture))
			{
				return str;
			}

			return str + c;
		}

		public static string EnsureStartsWith(this string str, char c)
		{
			return EnsureStartsWith(str, c, StringComparison.CurrentCulture);
		}

		public static string EnsureStartsWith(this string str, char c, StringComparison comparisonType)
		{
			if(str == null)
			{
				throw new ArgumentNullException("str");
			}

			if(str.StartsWith(c.ToString(CultureInfo.InvariantCulture), comparisonType))
			{
				return str;
			}

			return str + c;
		}

		public static string EnsureStartsWith(this string str, char c, bool ignoreCase, CultureInfo culture)
		{
			if(str == null)
			{
				throw new ArgumentNullException("str");
			}

			if(str.StartsWith(c.ToString(culture), ignoreCase, culture))
			{
				return str;
			}

			return str + c;
		}

		public static bool IsNullOrEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}

		public static bool IsNullOrWhiteSpace(this string str)
		{
			return string.IsNullOrEmpty(str);
		}

		public static string Left(this string str, int len)
		{
			if(str == null)
			{
				throw new ArgumentNullException("str");
			}

			if(str.Length < len)
			{
				throw new ArgumentException("len argument can not be bigger than given string's length!");
			}

			return str.Substring(0, len);
		}

		public static string NormalizeLineEnding(this string str)
		{
			return str.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", Environment.NewLine);
		}

		public static int NthIndexOf(this string str, char c, int n)
		{
			if(str == null)
			{
				throw new ArgumentNullException(nameof(str));
			}

			var count = 0;
			for(var i =0; i< str.Length; i++)
			{
				if(str[i] != c)
				{
					continue;
				}

				if((++count) == n)
				{
					return i;
				}
			}

			return -1;
		}

		public static string RemovePostFix(this string str, params string[] postFixes)
		{
			if (str.IsNullOrEmpty())
			{
				return null;
			}

			if (postFixes.IsNullOrEmpty())
			{
				return str;
			}

			foreach(var postFix in postFixes)
			{
				if (str.EndsWith(postFix))
				{
					return str.Left(str.Length - postFix.Length);
				}
			}

			return str;
		}

		public static string RemovePreFix(this string str, params string[] preFixes)
		{
			if (str.IsNullOrEmpty())
			{
				return null;
			}

			if (preFixes.IsNullOrEmpty())
			{
				return str;
			}

			foreach(var preFix in preFixes)
			{
				if (str.StartsWith(preFix))
				{
					return str.Right(str.Length - preFix.Length);
				}
			}

			return str;
		}

		public static string Right(this string str, int len)
		{
			if(str == null)
			{
				throw new ArgumentNullException("str");
			}

			if(str.Length < len)
			{
				throw new ArgumentException($"len argument can not be bigger than given string's lenght!");
			}

			return str.Substring(str.Length - len, len);
		}

		public static string[] Split(this string str, string seperator)
		{
			return str.Split(new[] { seperator }, StringSplitOptions.None);
		}

		public static string[] Split(this string str, string seperator, StringSplitOptions options)
		{
			return str.Split(new[] { seperator }, options);
		}

		public static string[] SplitToLines(this string str)
		{
			return str.Split(Environment.NewLine);
		}

        /// <summary>
        /// Uses string.Split method to split given string by <see cref="Environment.NewLine"/>.
        /// </summary>
        /// <param name="str">s</param>
        /// <param name="options"></param>
        public static string[] SplitToLines(this string str, StringSplitOptions options)
        {
            return str.Split(Environment.NewLine, options);
        }

        /// <summary>
        /// Converts PascalCase string to camelCase string.
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <returns>camelCase of the string</returns>
        public static string ToCamelCase(this string str)
        {
            return str.ToCamelCase(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts PascalCase string to camelCase string in specified culture.
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <param name="culture">An object that supplies culture-specific casing rules</param>
        /// <returns>camelCase of the string</returns>
        public static string ToCamelCase(this string str, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            if (str.Length == 1)
            {
                return str.ToLower(culture);
            }

            return char.ToLower(str[0], culture) + str.Substring(1);
        }

        /// <summary>
        /// Converts given PascalCase/camelCase string to sentence (by splitting words by space).
        /// Example: "ThisIsSampleSentence" is converted to "This is a sample sentence".
        /// </summary>
        /// <param name="str">String to convert.</param>
        public static string ToSentenceCase(this string str)
        {
            return str.ToSentenceCase(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts given PascalCase/camelCase string to sentence (by splitting words by space).
        /// Example: "ThisIsSampleSentence" is converted to "This is a sample sentence".
        /// </summary>
        /// <param name="str">String to convert.</param>
        /// <param name="culture">An object that supplies culture-specific casing rules.</param>
        public static string ToSentenceCase(this string str, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1], culture));
        }

        /// <summary>
        /// Converts string to enum value.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value)
            where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Converts string to enum value.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <param name="ignoreCase">Ignore case</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value, bool ignoreCase)
            where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

        //
        public static string ToSecured(this string str)
        {
            // TNN: fixed Cryptographic Algorithm to comply with Veracode
            var hashProvider = HashAlgorithm.Create("SHA256Managed");

            using (hashProvider)
            {
                var inputBytes = Encoding.UTF8.GetBytes(str);
                var hashBytes = hashProvider.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                foreach (var hashByte in hashBytes)
                {
                    sb.Append(hashByte.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Converts camelCase string to PascalCase string.
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <returns>PascalCase of the string</returns>
        public static string ToPascalCase(this string str)
        {
            return str.ToPascalCase(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts camelCase string to PascalCase string in specified culture.
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <param name="culture">An object that supplies culture-specific casing rules</param>
        /// <returns>PascalCase of the string</returns>
        public static string ToPascalCase(this string str, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            if (str.Length == 1)
            {
                return str.ToUpper(culture);
            }

            return char.ToUpper(str[0], culture) + str.Substring(1);
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string if it exceeds maximum length.
        /// </summary>
        /// <param name="str">e</param>
        /// <param name="maxLength"></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
        public static string Truncate(this string str, int maxLength)
        {
            if (str == null)
            {
                return null;
            }

            if (str.Length <= maxLength)
            {
                return str;
            }

            return str.Left(maxLength);
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string if it exceeds maximum length.
        /// It adds a "..." postfix to end of the string if it's truncated.
        /// Returning string can not be longer than maxLength.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="maxLength"></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
        public static string TruncateWithPostfix(this string str, int maxLength)
        {
            return TruncateWithPostfix(str, maxLength, "...");
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string if it exceeds maximum length.
        /// It adds given <paramref name="postfix"/> to end of the string if it's truncated.
        /// Returning string can not be longer than maxLength.
        /// </summary>
        /// <param name="str">x</param>
        /// <param name="maxLength"></param>
        /// <param name="postfix"></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
        public static string TruncateWithPostfix(this string str, int maxLength, string postfix)
        {
            if (str == null)
            {
                return null;
            }

            if (str == string.Empty || maxLength == 0)
            {
                return string.Empty;
            }

            if (str.Length <= maxLength)
            {
                return str;
            }

            if (maxLength <= postfix.Length)
            {
                return postfix.Left(maxLength);
            }

            return str.Left(maxLength - postfix.Length) + postfix;
        }
    }
}
