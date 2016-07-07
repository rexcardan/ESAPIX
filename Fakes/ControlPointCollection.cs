using System;
using System.Collections;
using System.Collections.Generic;
using ESAPIX.Interfaces;


namespace ESAPIX.Fakes
{
    public class ControlPointCollection : IControlPointCollection
    {
        public IControlPoint this[int index]
        {
            get { throw new NotImplementedException(); }
        }

        public int Count { get; set; }

        public IEnumerator<IControlPoint> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}