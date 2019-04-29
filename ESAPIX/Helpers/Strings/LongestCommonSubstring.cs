using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Helpers.Strings
{
    public class LongestCommonSubstring
    {
        /// <summary>
        /// Distance metric based on Longest Common Subsequence, computed as
        /// 1 - |LCS(s1, s2)| / max(|s1|, |s2|).
        /// </summary>
        /// <param name="s1">The first string to compare.</param>
        /// <param name="s2">The second string to compare.</param>
        /// <returns>LCS distance metric</returns>
        /// <exception cref="ArgumentNullException">If s1 or s2 is null.</exception>
        public static double ComputeDistance(string s1, string s2)
        {
            if (s1 == null)
            {
                throw new ArgumentNullException(nameof(s1));
            }

            if (s2 == null)
            {
                throw new ArgumentNullException(nameof(s2));
            }

            if (s1.Equals(s2))
            {
                return 0;
            }

            int m_len = Math.Max(s1.Length, s2.Length);

            if (m_len == 0) return 0.0;

            return 1.0
                    - (1.0 * LongestCommonSubstring.Length(s1, s2))
                    / m_len;
        }
        /// <summary>
        /// Return the LCS distance between strings s1 and s2, computed as |s1| +
        /// |s2| - 2 * |LCS(s1, s2)|.
        /// </summary>
        /// <param name="s1">The first string to compare.</param>
        /// <param name="s2">The second string to compare.</param>
        /// <returns>
        /// The LCS distance between strings s1 and s2, computed as |s1| +
        /// |s2| - 2 * |LCS(s1, s2)|
        /// </returns>
        /// <exception cref="ArgumentNullException">If s1 or s2 is null.</exception>
        public static double Distance(string s1, string s2)
        {
            if (s1 == null)
            {
                throw new ArgumentNullException(nameof(s1));
            }

            if (s2 == null)
            {
                throw new ArgumentNullException(nameof(s2));
            }

            if (s1.Equals(s2))
            {
                return 0;
            }

            return s1.Length + s2.Length - 2 * Length(s1, s2);
        }

        /// <summary>
        ///  Return the length of Longest Common Subsequence (LCS) between strings s1
        ///  and s2.
        /// </summary>
        /// <param name="s1">The first string to compare.</param>
        /// <param name="s2">The second string to compare.</param>
        /// <returns>The length of LCS(s2, s2)</returns>
        /// <exception cref="ArgumentNullException">If s1 or s2 is null.</exception>
        public static int Length(string s1, string s2)
        {
            if (s1 == null)
            {
                throw new ArgumentNullException(nameof(s1));
            }

            if (s2 == null)
            {
                throw new ArgumentNullException(nameof(s2));
            }

            /* function LCSLength(X[1..m], Y[1..n])
             C = array(0..m, 0..n)
             for i := 0..m
             C[i,0] = 0
             for j := 0..n
             C[0,j] = 0
             for i := 1..m
             for j := 1..n
             if X[i] = Y[j]
             C[i,j] := C[i-1,j-1] + 1
             else
             C[i,j] := max(C[i,j-1], C[i-1,j])
             return C[m,n]
             */
            int s1_length = s1.Length;
            int s2_length = s2.Length;
            char[] x = s1.ToCharArray();
            char[] y = s2.ToCharArray();

            int[,] c = new int[s1_length + 1, s2_length + 1];

            for (int i = 0; i <= s1_length; i++)
            {
                c[i, 0] = 0;
            }

            for (int j = 0; j <= s2_length; j++)
            {
                c[0, j] = 0;
            }

            for (int i = 1; i <= s1_length; i++)
            {
                for (int j = 1; j <= s2_length; j++)
                {
                    if (x[i - 1] == y[j - 1])
                    {
                        c[i, j] = c[i - 1, j - 1] + 1;

                    }
                    else
                    {
                        c[i, j] = Math.Max(c[i, j - 1], c[i - 1, j]);
                    }
                }
            }

            return c[s1_length, s2_length];
        }
    }
}

