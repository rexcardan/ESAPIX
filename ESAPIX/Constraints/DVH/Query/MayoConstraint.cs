#region

using System;
using ESAPIX.DVH;
using ESAPIX.Extensions;

#endregion

namespace ESAPIX.Constraints.DVH.Query
{
    public class MayoConstraint
    {
        public MayoQuery Query { get; set; }
        public Discriminator Discriminator { get; set; }
        public double ConstraintValue { get; set; }

        /// <summary>
        ///     Reads a constraint of the form {MayoQuery} {Discriminator} {ConstraintValue}
        /// </summary>
        /// <param name="constraint"></param>
        /// <returns></returns>
        public static MayoConstraint Read(string constraint)
        {
            var split = constraint.SplitOnWhiteSpace();
            if (split.Length != 3)
                throw new ArgumentException(
                    "Mayo constraints much be 3 parts separated by whitespace : {Query} {Discriminator} {ConstraintValue}");
            if (!MayoQueryReader.IsValid(split[0]))
            {
                throw new ArgumentException(
                  "Not a valid TG263 query! (Examples: D90%[Gy], V20Gy[%], etc)");
            }
            var mq = MayoQuery.Read(split[0]);
            var discrimator = DiscriminatorConverter.ReadDiscrimator(split[1]);
            var constraintValue = double.Parse(split[2]);
            return new MayoConstraint
            {
                Query = mq,
                Discriminator = discrimator,
                ConstraintValue = constraintValue
            };
        }

        /// <summary>
        ///     Writes a constraint of the form {MayoQuery} {Discriminator} {ConstraintValue}
        /// </summary>
        /// <returns>a string of the constraint</returns>
        public string Write()
        {
            var query = MayoQueryWriter.Write(Query);
            var discriminator = DiscriminatorConverter.WriteDiscrimator(Discriminator);
            var constraintValue = ConstraintValue.ToString();
            return $"{query} {discriminator} {constraintValue}";
        }
    }
}