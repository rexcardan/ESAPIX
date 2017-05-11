#region

using System;
using ESAPIX.Constraints.DVH.Query;

#endregion

namespace ESAPIX.DVH
{
    public class DiscriminatorConverter
    {
        /// <summary>
        ///     Reads a discriminator from a string
        /// </summary>
        /// <param name="discString">
        ///     the string discriminator (eg <, <=, etc)</param>
        /// <returns></returns>
        public static Discriminator ReadDiscrimator(string discString)
        {
            switch (discString)
            {
                case "<=": return Discriminator.LESS_THAN_OR_EQUAL;
                case "<": return Discriminator.LESS_THAN;
                case ">=": return Discriminator.GREATHER_THAN_OR_EQUAL;
                case ">": return Discriminator.GREATER_THAN;
                case "=": return Discriminator.EQUAL;
                default: throw new ArgumentException("Not a valid comparitor (eg >=, =, <=...)");
            }
        }


        /// <summary>
        ///     Writes a discriminator to a string
        /// </summary>
        /// <param name="disc">the constraint discriminator</param>
        /// <returns>a string representation of the discriminator</returns>
        public static string WriteDiscrimator(Discriminator disc)
        {
            switch (disc)
            {
                case Discriminator.EQUAL: return "=";
                case Discriminator.GREATER_THAN: return ">";
                case Discriminator.GREATHER_THAN_OR_EQUAL: return ">=";
                case Discriminator.LESS_THAN: return "<";
                case Discriminator.LESS_THAN_OR_EQUAL: return "<=";
                default: throw new ArgumentException("Not a valid discriminator!");
            }
        }
    }
}