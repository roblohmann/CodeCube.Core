using System;
using System.Globalization;
using System.Linq;

namespace CodeCube.Core.Helpers
{
    /// <summary>
    /// Helper class to validate a dutch social security number against the 'elf-proef'
    /// </summary>
    public static class BSNHelper
    {
        /// <summary>
        /// Execute the elf-proef for the given social security number
        /// </summary>
        /// <param name="bsn">The social secutity number to validate.</param>
        /// <returns>True if the BSN passes the test, otherwise false.</returns>
        public static bool Elfproef(string bsn)
        {
            if (string.IsNullOrWhiteSpace(bsn)) return false;
            bsn = bsn.Replace(" ", string.Empty);

            try
            {
                if (bsn.Length == 8) bsn = ParseBSN8Cijferig(bsn);
                if (bsn.Length != 9) return false;

                var bsnArray = bsn.Select(b => int.Parse(b.ToString(CultureInfo.InvariantCulture))).ToArray();
                var som = (bsnArray[0] * 9) + (bsnArray[1] * 8) + (bsnArray[2] * 7) + (bsnArray[3] * 6) + (bsnArray[4] * 5) +
                        (bsnArray[5] * 4) + (bsnArray[6] * 3) + (bsnArray[7] * 2) - (bsnArray[8] * 1);

                return (som % 11) == 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string ParseBSN8Cijferig(string bsn)
        {
            return bsn.Length == 8 ? $"0{bsn}" : bsn;
        }
    }
}