namespace Net.Light.Framework.Logic.Util
{
    using Net.Light.Framework.Logic.Extensions;
    using System;
    using System.Text;

    public class SecurityUtil
    {
        internal static String EncodeString(String data)
        {
            try
            {
                if (String.IsNullOrEmpty(data) == false)
                {
                    String encodedData = Encode(data);
                    Random rnd = new Random();
                    Int32 shiftCount = 3;
                    String shifted = ShiftAString(encodedData, shiftCount);
                    return Encode(shifted);
                }
                else
                {
                    return String.Empty;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static String DecodeString(String data)
        {
            try
            {
                if (String.IsNullOrEmpty(data) == false)
                {
                    String firstDecode = Decode(data);
                    //Int32 unshiftCount = firstDecode[firstDecode.Length - 1].Char2Int();
                    //firstDecode = firstDecode.Substring(0, firstDecode.Length - 1);
                    firstDecode = UnShiftString(firstDecode, 3);
                    String lastDecode = Decode(firstDecode);
                    return lastDecode;
                }
                else
                {
                    return String.Empty;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static String Decode(String data)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();

                Byte[] toDecodeByte = Convert.FromBase64String(data);
                Int32 charCount = utf8Decode.GetCharCount(toDecodeByte, 0, toDecodeByte.Length);
                Char[] decodedChar = new Char[charCount];
                utf8Decode.GetChars(toDecodeByte, 0, toDecodeByte.Length, decodedChar, 0);
                String result = new String(decodedChar);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static String Encode(String data)
        {
            try
            {
                Byte[] encDataByte = new Byte[data.Length];
                encDataByte = System.Text.Encoding.UTF8.GetBytes(data);
                String encodedData = Convert.ToBase64String(encDataByte);
                return encodedData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static String ShiftAString(String shifted, Int32 shiftCount)
        {
            try
            {
                if (String.IsNullOrEmpty(shifted) == false)
                {
                    Int32 lenStr = shifted.Length;
                    StringBuilder strBuilder = new StringBuilder();
                    for (Int32 lenCounter = 0; lenCounter < lenStr; lenCounter++)
                    {
                        strBuilder.Append(shifted[(lenCounter + shiftCount) % lenStr]);
                    }
                    return strBuilder.ToString();
                }
                else
                {
                    return String.Empty;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static String UnShiftString(String unshifted, Int32 unshiftCount)
        {
            try
            {
                if (String.IsNullOrEmpty(unshifted) == false)
                {
                    Int32 lenStr = unshifted.Length;
                    StringBuilder strBuilder = new StringBuilder();
                    for (Int32 lenCounter = 0; lenCounter < lenStr; lenCounter++)
                    {
                        strBuilder.Append(unshifted[(lenCounter + lenStr - unshiftCount) % lenStr]);
                    }
                    return strBuilder.ToString();
                }
                else
                {
                    return String.Empty;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}