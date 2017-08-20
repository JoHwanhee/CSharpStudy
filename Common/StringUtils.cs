using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public static class StringUtils
    {
        public static string GetStringValue(string srcString, string defaultValue = "", bool useTrim = true)
        {
            if (string.IsNullOrWhiteSpace(srcString))
            {
                return defaultValue;
            }

            if (useTrim)
            {
                return srcString.Trim();
            }
            return srcString;
        }

        public static double GetDoubleValue(string srcString, double defaultValue = 0)
        {
            double resValue = defaultValue;
            if (string.IsNullOrWhiteSpace(srcString))
            {
                return defaultValue;
            }

            if (double.TryParse(srcString, out resValue))
            {
                return resValue;
            }
            return defaultValue;
        }

        public static int GetIntValue(string srcString, int defaultValue = 0)
        {
            int resValue = defaultValue;
            if (string.IsNullOrWhiteSpace(srcString))
            {
                return defaultValue;
            }

            if (int.TryParse(srcString, out resValue))
            {
                return resValue;
            }
            return defaultValue;
        }

        public static byte[] GetStringToArray(string stringData)
        {
            if (stringData == null)
            {
                return null;
            }
            int nByteCount = Encoding.Default.GetByteCount(stringData);
            if (nByteCount < 1)
                return null;
            byte[] buf = new byte[nByteCount];
            if (stringData != null)
            {
                byte[] tempBuf = Encoding.Default.GetBytes(stringData);
                Array.Copy(tempBuf, buf, nByteCount);
            }
            return buf;
        }

        public static bool IsName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return true;

            return Regex.Match(name, @"^[0-9a-zA-z_\-*.]*$").Success;
        }

        public static bool IsText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return true;

            return Regex.Match(text, @"^[0-9a-zA-z_\-*. /\\\r\n\t]*$").Success;
        }

        public static bool IsPlatformName(string platformName)
        {
            if (string.IsNullOrEmpty(platformName))
                return true;

            return Regex.Match(platformName, @"^[0-9a-zA-z]+[0-9a-zA-z_\-*. ]*[0-9a-zA-z]+$").Success;
        }

        public static bool IsDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                return true;

            return Regex.Match(description, @"^[0-9a-zA-z_\-*.@/ \r\n\t]*$").Success;
        }

        public static bool IsNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
                return true;

            return Regex.Match(number, @"^[0-9]*$").Success;
        }

        public static string GetDateTimeMillisecString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss.f");
        }

        public static string GetDateTimeMillisecString()
        {
            return GetDateTimeMillisecString(DateTime.Now);
        }

        public static string GetDateTimeSecString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetDateTimeSecString()
        {
            return GetDateTimeString(DateTime.Now);
        }

        public static string GetDateTimeString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm");
        }

        public static string GetCurrentDateTimeString()
        {
            return GetDateTimeString(DateTime.Now);
        }

        public static string GetDateString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        public static string GetCurrentDateString()
        {
            return GetDateTimeString(DateTime.Now);
        }

        public static bool AreStringEquals(string strA, string strB, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            if (string.IsNullOrWhiteSpace(strA))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(strB))
            {
                return false;
            }

            return string.Compare(strA, strB, comparisonType) == 0;
        }

        public static string ToString(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }

        public static bool IsInStringArray(string[] array, string findText)
        {
            if ((array == null) || (IsStringEmpty(findText)))
            {
                return false;
            }

            foreach (string text in array)
            {
                if (text == findText)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsStringEmpty(string source)
        {
            return ((source == null) || (source.Length == 0));
        }

        public static string MultiLineTrim(string source)
        {
            if (IsStringEmpty(source))
            {
                return "";
            }

            string[] splitSource = source.Trim().Split('\n');
            StringBuilder stringBuilder = new StringBuilder();

            foreach (string str in splitSource)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append("\r\n");
                }
                stringBuilder.Append(str.Trim());
            }
            return stringBuilder.ToString();
        }

        public static string ToFirstCharLower(string source)
        {
            if (IsStringEmpty(source))
            {
                return "";
            }

            return source.Substring(0, 1).ToLower() + source.Substring(1);
        }

        public static string ToFirstCharLower(object obj)
        {
            string source = ToString(obj);
            if (IsStringEmpty(source))
            {
                return "";
            }
            return source.Substring(0, 1).ToLower() + source.Substring(1);
        }

        public static string ToFirstCharUpper(string source)
        {
            if (IsStringEmpty(source))
            {
                return "";
            }

            return source.Substring(0, 1).ToUpper() + source.Substring(1);
        }

        public static string ToFirstCharUpper(object obj)
        {
            string source = ToString(obj);
            if (IsStringEmpty(source))
            {
                return "";
            }

            return source.Substring(0, 1).ToUpper() + source.Substring(1);
        }

        public static bool ToBool(string boolString)
        {
            bool retBool = false;
            if (!string.IsNullOrEmpty(boolString))
            {
                boolString = boolString.ToLower();

                switch (boolString)
                {
                    case "true":
                    case "t":
                    case "yes":
                    case "y":
                    case "on":
                    case "o":
                        retBool = true;
                        break;
                }
            }

            return retBool;
        }

        public static string GetTimeString(int time)
        {
            int h;
            int m;
            int s;

            if (time < 1000)
            {
                return string.Format("{0}ms", time);
            }
            if (time < 60 * 1000)
            {
                return string.Format("{0}s {1}ms", time / 1000, time % 1000);
            }
            time += 500;
            if (time < 60 * 60 * 1000)
            {
                m = time / (60 * 1000);
                s = (time - (m * 60 * 1000)) / 1000;
                return string.Format("{0}m {1}s", m, s);
            }
            h = time / (60 * 60 * 1000);
            m = (time % (60 * 60 * 1000)) / (60 * 1000);
            s = (time % (60 * 1000)) / 1000;
            return string.Format("{0}h {1}m {2}s", h, m, s);
        }

        public static string NormalizeToFileTitle(string data)
        {
            string temp = data.Trim();
            string[] split =
                temp.Split(new char[] { ' ', '\\', '/', ':', '*', '?', '\"', '<', '>', '|', '\r', '\n', '\t', '.' });
            return string.Join("_", split);
        }

        public static T ToEnum<T>(string value, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            T result;
            return Enum.TryParse(value, true, out result) ? result : defaultValue;
        }

        public static string[] Split(string namesString, char separator)
        {
            if (string.IsNullOrWhiteSpace(namesString))
            {
                return new string[0];
            }

            List<string> names = new List<string>();
            string[] splitStrings = namesString.Split(separator);
            foreach (string splitString in splitStrings)
            {
                if (!string.IsNullOrWhiteSpace(splitString))
                {
                    names.Add(splitString.Trim());
                }
            }

            return names.ToArray();
        }

        public static byte[] GetBytesFromHexString(string hexStr)
        {
            var byteList = new List<byte>();

            for (int i = 0; i < hexStr.Length; i = i + 2)
            {
                byteList.Add(byte.Parse(
                    $"{hexStr[i]}{hexStr[i + 1]}",
                    System.Globalization.NumberStyles.AllowHexSpecifier));
            }

            return byteList.ToArray();
        }
    }
}