using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Extensions;

namespace ESAPIX.DVH.Query
{
    public class MayoConstraint
    {
        public MayoQuery Query { get; set; }
        public Discriminator Discriminator { get; set; }
        public double ConstraintValue { get; set; }

        /// <summary>
        /// Reads a constraint of the form {MayoQuery} {Discriminator} {ConstraintValue}
        /// </summary>
        /// <param name="constraint"></param>
        /// <returns></returns>
        public static MayoConstraint Read(string constraint)
        {
            var split = constraint.SplitOnWhiteSpace();
            if (split.Length != 3) { throw new ArgumentException("Mayo constraints much be 3 parts separated by whitespace : {MayoQuery} {Discriminator} {ConstraintValue}"); }
            var mq = MayoQuery.Read(split[0]);
            var discrimator = DiscriminatorConverter.ReadDiscrimator(split[1]);
            var constraintValue = double.Parse(split[2]);
            return new MayoConstraint()
            {
                Query = mq,
                Discriminator = discrimator,
                ConstraintValue = constraintValue
            };
        }

        /// <summary>
        /// Writes a constraint of the form {MayoQuery} {Discriminator} {ConstraintValue}
        /// </summary>
        /// <returns>a string of the constraint</returns>
        public string Write()
        {
            var query = MayoQueryWriter.Write(Query);
            var discriminator = DiscriminatorConverter.WriteDiscrimator(this.Discriminator);
            var constraintValue = this.ConstraintValue.ToString();
            return $"{query} {discriminator} {constraintValue}";
        }
    }
}
