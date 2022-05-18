using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE22A_JAMZ.src.Utils
{
    internal class FileUtils
    {

        public static String CalculateSize(FileInfo Info)
        {
            string[] Sizes = { "B", "KB", "MB", "GB", "TB" };

            double Length = Info.Length;

            int Order = 0;

            while (Length >= 1024 && Order < Sizes.Length - 1)
            {
                Order++;
                Length /= 1024;
            }

            string Size = String.Format("{0:0.##} {1}", Length, Sizes[Order]);

            return Size;

        }

        public static String CalculateSize(long Length)
        {
            string[] Sizes = { "B", "KB", "MB", "GB", "TB" };

            int Order = 0;

            while (Length >= 1024 && Order < Sizes.Length - 1)
            {
                Order++;
                Length /= 1024;
            }

            string Size = String.Format("{0:0.##} {1}", Length, Sizes[Order]);

            return Size;
        }

    }
}
