using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace FolderSynchronizer
{
    internal static class ChecksumCalculator
    {
        public async static Task<byte[]> CalculateAsync(Stream dataStream)
        {
            if (dataStream?.Length < 1)
                throw new InvalidOperationException();

            dataStream.Position = 0;

            return await MD5.Create().ComputeHashAsync(dataStream);
        }
    }
}
