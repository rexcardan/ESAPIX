#region

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using ESAPIX.Extensions;
using XC = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.API
{
    public class StructureSet : ApiDataObject, System.Xml.Serialization.IXmlSerializable
    {
        public StructureSet()
        {
            _client = new ExpandoObject();
        }

        public StructureSet(dynamic client)
        {
            _client = client;
        }

        public IEnumerable<Structure> Structures
        {
            get
            {
                if (_client is ExpandoObject)
                {
                    if ((_client as ExpandoObject).HasProperty("Structures"))
                        foreach (var item in _client.Structures)
                            yield return item;
                    else
                        yield break;
                }
                else
                {
                    IEnumerator enumerator = null;
                    XC.Instance.CurrentContext.Thread.Invoke(() =>
                        {
                            var asEnum = (IEnumerable) _client.Structures;
                            enumerator = asEnum.GetEnumerator();
                        }
                    );
                    while (XC.Instance.CurrentContext.GetValue(sc => enumerator.MoveNext()))
                    {
                        var facade = new Structure();
                        XC.Instance.CurrentContext.Thread.Invoke(() =>
                            {
                                var vms = enumerator.Current;
                                if (vms != null)
                                    facade._client = vms;
                            }
                        );
                        if (facade._client != null)
                            yield return facade;
                    }
                }
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Structures = value;
            }
        }

        public Image Image
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("Image"))
                        return _client.Image;
                    else
                        return default(Image);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return new Image(_client.Image); }
                    );
                return default(Image);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.Image = value;
            }
        }

        public string UID
        {
            get
            {
                if (_client is ExpandoObject)
                    if (((ExpandoObject) _client).HasProperty("UID"))
                        return _client.UID;
                    else
                        return default(string);
                if (XC.Instance.CurrentContext != null)
                    return XC.Instance.CurrentContext.GetValue(sc => { return _client.UID; }
                    );
                return default(string);
            }

            set
            {
                if (_client is ExpandoObject)
                    _client.UID = value;
            }
        }

        public Structure AddStructure(string dicomType, string id)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return new Structure(_client.AddStructure(dicomType, id)); }
                );
                return vmsResult;
            }
            return _client.AddStructure(dicomType, id);
        }

        public bool CanAddStructure(string dicomType, string id)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.CanAddStructure(dicomType, id); }
                );
                return vmsResult;
            }
            return (bool) _client.CanAddStructure(dicomType, id);
        }

        public bool CanRemoveStructure(Structure structure)
        {
            if (XC.Instance.CurrentContext != null)
            {
                var vmsResult = XC.Instance.CurrentContext.GetValue(
                    sc => { return _client.CanRemoveStructure(structure._client); }
                );
                return vmsResult;
            }
            return (bool) _client.CanRemoveStructure(structure);
        }

        public void RemoveStructure(Structure structure)
        {
            if (XC.Instance.CurrentContext != null)
                XC.Instance.CurrentContext.Thread.Invoke(() => { _client.RemoveStructure(structure._client); }
                );
            else
                _client.RemoveStructure(structure);
        }
    }
}