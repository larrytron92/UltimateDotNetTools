using System;
using System.IO;

namespace UltimateDotNetTools
{
    public static class MiscHelpers
    {
        public static byte[] ConvertFileStreamToBytes(this Stream input, bool throwOnError = false)
        {
            byte[] retVal = null;

            if (input is null)
            {
                if (throwOnError)
                {
                    throw new ArgumentNullException("Stream cannot be null!");
                }

                return retVal;
            }

            if (input.Length == default(long))
            {
                if (throwOnError)
                {
                    throw new ArgumentOutOfRangeException("Stream cannot be empty!");
                }

                return retVal;
            }

            using (var binaryReader = new BinaryReader(input))
            {
                retVal = binaryReader.ReadBytes((int)input.Length);
            }

            if (retVal.IsNullOrEmpty() && throwOnError)
            {
                throw new Exception("The binary file could not output any bytes from the stream!");
            }

            return retVal;
        }

        public static string ConvertToBase64(this byte[] attachment) => attachment.IsNotNullOrEmpty() ? Convert.ToBase64String(attachment) : string.Empty;

        public static string ConvertToBase64(this Stream input, bool throwOnError = false) => ConvertToBase64(ConvertFileStreamToBytes(input, throwOnError));
    }
}