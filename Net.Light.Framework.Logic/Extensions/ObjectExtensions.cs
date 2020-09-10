using System;

namespace Net.Light.Framework.Logic.Extensions
{
    public static class ObjectExtensions
    {

        public static Boolean IsNull(this Object o)
        {
            return o == null;
        }

        public static Boolean IsNullOrDbNull(this Object obj)
        {
            return (null == obj || obj == DBNull.Value);
        }

        public static String ToStr(this Object obj)
        {
            return obj.IsNullOrDbNull() == true ? String.Empty : obj.ToString();
        }

        public static Boolean ToBool(this object obj)
        {
            bool result = false;
            try
            {
                result = bool.Parse(string.Format("{0}", obj));
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public static byte ToByte(this object obj)
        {
            byte result = 0;
            try
            {
                result = byte.Parse(string.Format("{0}", obj));
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public static short ToShort(this object obj)
        {
            short result = 0;
            try
            {
                result = Int16.Parse(string.Format("{0}", obj));
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public static Int32 ToInt(this Object obj)
        {
            int result = 0;
            try
            {
                result = obj.ToStr().Str2Int();
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public static long ToLong(this object obj)
        {
            long result = 0;
            try
            {
                result = long.Parse(string.Format("{0}", obj));
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public static float ToSingle(this object obj)
        {
            float result = .0f;
            try
            {
                result = Single.Parse(string.Format("{0}", obj));
            }
            catch (Exception)
            {
                result = .0f;
            }
            return result;
        }

        public static double ToDouble(this object obj)
        {
            double result = .0d;
            try
            {
                result = double.Parse(string.Format("{0}", obj));
            }
            catch (Exception)
            {
                result = .0d;
            }
            return result;
        }

        public static decimal ToDecimal(this object obj)
        {
            decimal result = 0.0M;
            try
            {
                result = decimal.Parse(string.Format("{0}", obj));
            }
            catch (Exception)
            {
                result = 0.0M;
            }
            return result;
        }

        public static DateTime ToDateTime(this object obj)
        {
            DateTime result = new DateTime();
            try
            {
                result = DateTime.Parse(string.Format("{0}", obj));
            }
            catch (Exception)
            {
                result = new DateTime();
            }
            return result;
        }
        public static DateTime ToDateTime(this object obj, string format)
        {
            DateTime result = new DateTime();
            try
            {
                result = DateTime.ParseExact(string.Format("{0}", obj), format, null);
            }
            catch (Exception)
            {
                result = new DateTime();
            }
            return result;
        }

        public static DateTime ToDateTime(this object obj, string format, IFormatProvider formatProvider)
        {
            DateTime result = new DateTime();
            try
            {
                result = DateTime.ParseExact(string.Format("{0}", obj), format, formatProvider);
            }
            catch (Exception)
            {
                result = new DateTime();
            }
            return result;
        }

        public static Int32 Str2Int(this String str)
        {
            int result = 0;
            try
            {
                result = int.Parse(str);
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public static Int32 Char2Int(this char ch)
        {
            int result = 0;
            try
            {
                result = Convert.ToInt32(ch);
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public static Boolean IsNullOrEmpty(this String str)
        {
            if (str == null)
            {
                return true;
            }
            else
            {
                return str.Length == 0;
            }
        }

        public static Boolean IsNullOrSpace(this String str)
        {
            if (str == null)
            {
                return true;
            }
            else
            {
                return str.Trim().Length == 0;
            }
        }

        public static int FirstIndexOf(this string str, char ch)
        {
            try
            {
                if (str.IsNullOrEmpty())
                    return -1;

                if (ch.IsNull())
                    return -1;

                char[] chs = str.ToCharArray();
                int _index = -1;
                for (int charCounter = 0; charCounter < chs.Length; charCounter++)
                {
                    if (string.Format("{0}", ch).Equals(string.Format("{0}", chs[charCounter])))
                    {
                        _index = charCounter;
                        break;
                    }
                }
                return _index;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}