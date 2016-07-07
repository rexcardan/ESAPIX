using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using ESAPIX.Interfaces;


namespace ESAPIX.Proxies
{
    public class ControlPointCollection : VMSProxy, IControlPointCollection
    {
        public IControlPoint this[int index]
        {
            get { return DynamicWrap<ControlPoint>(cpc => cpc[index]); }
        }

        public int Count
        {
            get
            {
                return DynamicWrap<int>(cpc => cpc.Count);
            }
        }

        public IEnumerator<IControlPoint> GetEnumerator()
        {
            return WrapSelfEnumerator<ControlPoint>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return WrapSelfEnumerator<ControlPoint>();
        }
    }
}