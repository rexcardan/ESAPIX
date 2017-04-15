using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class ExternalBeamMachineParameters
    {
        internal dynamic _client;
        public ExternalBeamMachineParameters() { _client = new ExpandoObject(); }
        public ExternalBeamMachineParameters(dynamic client) { _client = client; }
        public ExternalBeamMachineParameters(System.String machineId, System.String energyModeId, System.Int32 doseRate, System.String techniqueId, System.String primaryFluenceModeId) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructExternalBeamMachineParameters(machineId, energyModeId, doseRate, techniqueId, primaryFluenceModeId)); }
        public System.String MachineId
        {
            get
            {
                if (_client is ExpandoObject) { return _client.MachineId; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MachineId; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.MachineId = value; }
            }
        }
        public System.String EnergyModeId
        {
            get
            {
                if (_client is ExpandoObject) { return _client.EnergyModeId; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.EnergyModeId; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.EnergyModeId = value; }
            }
        }
        public System.Int32 DoseRate
        {
            get
            {
                if (_client is ExpandoObject) { return _client.DoseRate; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.DoseRate; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.DoseRate = value; }
            }
        }
        public System.String PrimaryFluenceModeId
        {
            get
            {
                if (_client is ExpandoObject) { return _client.PrimaryFluenceModeId; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PrimaryFluenceModeId; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.PrimaryFluenceModeId = value; }
            }
        }
        public System.String TechniqueId
        {
            get
            {
                if (_client is ExpandoObject) { return _client.TechniqueId; }
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.TechniqueId; });
            }
            set
            {
                if (_client is ExpandoObject) { _client.TechniqueId = value; }
            }
        }
    }
}