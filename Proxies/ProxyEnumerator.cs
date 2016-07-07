using AutoMapper;
using System.Collections;
using System.Collections.Generic;

namespace ESAPIX.Proxies
{
    public class ProxyEnumerator<T> : IEnumerator<T>, IEnumerator
    {
        private IEnumerator enumerator;
        public VmsComThread VmsThread { get; internal set; }

        public ProxyEnumerator(IEnumerator ie)
        {
            this.enumerator = ie;
        }

        public T Current
        {
            get
            {
                dynamic proxy = default(T);
                VmsThread.Invoke(() =>
                {
                    object actual = enumerator.Current;
                    if (actual != null)
                    {
                        proxy = Mapper.Map<T>(actual);
                        if (proxy is VMSProxy)
                        {
                            proxy.VmsThread = this.VmsThread;
                            proxy.VmsObject = actual;
                        }
                    }
                });
                return proxy;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            bool move = false;
            VmsThread.Invoke(() =>
            {
                move = enumerator.MoveNext();
            });
            return move;
        }

        public void Reset()
        {
            VmsThread.Invoke(() =>
            {
                enumerator.Reset();
            });
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public IEnumerator Enumerator
        {
            get
            {
                return this;
            }
        }
    }
}
