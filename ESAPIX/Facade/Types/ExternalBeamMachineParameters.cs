using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class ExternalBeamMachineParameters
    {
        internal dynamic _client;
        public ExternalBeamMachineParameters() { }
        public ExternalBeamMachineParameters(dynamic client) { _client = client; }
        public ExternalBeamMachineParameters(System.String machineId, System.String energyModeId, System.Int32 doseRate, System.String techniqueId, System.String primaryFluenceModeId) { X.Instance.CurrentContext.Thread.Invoke(_client = VMSConstructor.Instance.ConstructExternalBeamMachineParameters(machineId, energyModeId, doseRate, techniqueId, primaryFluenceModeId)); }
        public System.String MachineId
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.MachineId; });
            }
        }
        public System.String EnergyModeId
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.EnergyModeId; });
            }
        }
        public System.Int32 DoseRate
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.Int32>((sc) => { return local._client.DoseRate; });
            }
        }
        public System.String PrimaryFluenceModeId
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.PrimaryFluenceModeId; });
            }
        }
        public System.String TechniqueId
        {
            get
            {
                var local = this;
                return X.Instance.CurrentContext.GetValue<System.String>((sc) => { return local._client.TechniqueId; });
            }
        }
    }
}