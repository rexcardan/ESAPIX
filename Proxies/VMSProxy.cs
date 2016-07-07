using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Documents;
using System.Windows.Threading;
using AutoMapper;
using ESAPIX.Interfaces;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace ESAPIX.Proxies
{
    public abstract class VMSProxy : IVmsProxy
    {
        /// <summary>
        /// The dispatcher holds the thread reference where VMS proxy objects may
        /// be called. Trying to access the actual object on another thread will
        /// result in an error
        /// </summary>
        [JsonIgnore]       
        public VmsComThread VmsThread { get; set; }

        /// <summary>
        /// The underlying real VMS object reference which must be accessed
        /// only from the dispatcher thread
        /// </summary>
        [JsonIgnore]
        public dynamic VmsObject { get; set; }

        public T Wrap<T>(string propName)
        {
            dynamic proxy = default(T);
            VmsThread.Invoke(() =>
            {
                object actual = GetPropValue(propName);
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

        public IEnumerable<T> WrapEnumerable<T>(string propName)
        {
            var objects = GetEnumerable(propName);
            var enumer = objects.GetEnumerator();
            while (enumer.MoveNext())
            {
                dynamic proxy = default(T);
                VmsThread.Invoke(() =>
                {
                    var actual = enumer.Current;
                    proxy = Mapper.Map<T>(actual);
                    if (proxy is VMSProxy)
                    {
                        proxy.VmsThread = this.VmsThread;
                        proxy.VmsObject = actual;
                    }
                });
                yield return (T)proxy;
            }
        }

        protected ProxyEnumerator<T> WrapSelfEnumerator<T>()
        {
            ProxyEnumerator<T> proxy = null;
            VmsThread.Invoke(() =>
            {
                var enumer = VmsObject.GetEnumerator();
                proxy = new ProxyEnumerator<T>(enumer);
                proxy.VmsThread = this.VmsThread;
            });
            return proxy;
        }

        private IEnumerable GetEnumerable(string propName)
        {
            IEnumerable objects = null;
            VmsThread.Invoke(() =>
            {
                var type = VmsObject.GetType() as Type;
                objects = type.GetProperty(propName).GetValue(VmsObject, null);       
            });
            return objects;
        }


        public T InvokeAndWrap<T>(string methodName, params object[] methodParams)
        {
            dynamic proxy = default(T);
            Type thisType = VmsObject.GetType();
            MethodInfo theMethod = thisType.GetMethod(methodName);
            ParameterInfo[] pars = theMethod.GetParameters();

            methodParams = GetMappedMethodParams(methodParams, pars);
            CheckParams(methodParams, pars);
            try
            {
                VmsThread.Invoke(() =>
                {
                    dynamic actual = theMethod.Invoke(VmsObject, methodParams);
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
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
            return proxy;
        }

        public void Invoke(string methodName, params object[] methodParams)
        {
            Type thisType = VmsObject.GetType();
            MethodInfo theMethod = thisType.GetMethod(methodName);
            ParameterInfo[] pars = theMethod.GetParameters();

            methodParams = GetMappedMethodParams(methodParams, pars);
            CheckParams(methodParams, pars);
            VmsThread.Invoke(() =>
            {
                theMethod.Invoke(VmsObject, methodParams);
            });
        }

        private void CheckParams(object[] methodParams, ParameterInfo[] pars)
        {
            for (int i = 0; i < methodParams.Length; i++)
            {
                var type1 = methodParams[i].GetType();
                var type2 = pars[i].ParameterType;
                if (type1 != type2)
                {
                    throw new Exception();
                }
            }
        }


        public T DynamicWrap<T>(Func<dynamic, dynamic> getVmsObjectFunc)
        {
            dynamic proxy = default(T);
            VmsThread.Invoke(() =>
            {
                var proxyVmsObject = getVmsObjectFunc(VmsObject);
                if (proxyVmsObject != null)
                {
                    proxy = Mapper.Map<T>(proxyVmsObject);
                    if (proxy is VMSProxy)
                    {
                        proxy.VmsThread = this.VmsThread;
                        proxy.VmsObject = proxyVmsObject;
                    }
                }
            });
            return proxy;
        }

        protected object GetPropValue(string propName)
        {
            object t = null;
            VmsThread.Invoke(() =>
             {
                 var type = VmsObject.GetType() as Type;
                 t = type.GetProperty(propName).GetValue(VmsObject, null);
             });
            return t;
        }

        public void SetVMS(dynamic vmsObject, VmsComThread thread = null)
        {
            this.VmsThread = thread ?? new VmsComThread();
            this.VmsObject = vmsObject;
        }

        private object[] GetMappedMethodParams(object[] methodParams, ParameterInfo[] pars)
        {
            List<dynamic> mappedParams = new List<object>();
            for (int i = 0; i < methodParams.Length; i++)
            {
                var mp = methodParams[i];
                object mapped = mp;
                if (mp is Enum)
                {
                    mapped = Mapper.Map(mp, mp.GetType(), pars[i].ParameterType);
                }
                else if (mp is VMSProxy)
                {
                    mapped = (mp as VMSProxy).VmsObject;
                }
                mappedParams.Add(mapped);
            }
            return mappedParams.ToArray();
        }
    }
}