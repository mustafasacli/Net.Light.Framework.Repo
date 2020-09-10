using System;
using System.Text;

namespace Net.Light.Framework.ConnectionStringBuilding.Encryption
{
    internal class Encryptor
    {
        public static string EncodeString(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data) == false)
                {
                    string encodedData = Encode(data);
                    Random rnd = new Random();
                    int shiftCount = 3;
                    string shifted = ShiftString(encodedData, shiftCount);
                    return Encode(shifted);
                }
                else
                    return string.Empty;

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static string Encode(string data)
        {
            try
            {
                byte[] encDataByte = new byte[data.Length];
                encDataByte = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encDataByte);
                return encodedData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static string ShiftString(string shifted, int shiftCount)
        {
            try
            {
                if (string.IsNullOrEmpty(shifted) == false)
                {
                    int lenStr = shifted.Length;
                    StringBuilder strBuilder = new StringBuilder();
                    for (int lenCounter = 0; lenCounter < lenStr; lenCounter++)
                    {
                        strBuilder.Append(shifted[(lenCounter + shiftCount) % lenStr]);
                    }
                    return strBuilder.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}