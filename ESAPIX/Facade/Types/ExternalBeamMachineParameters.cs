using System.Dynamic;
using X = ESAPIX.Facade.XContext;

namespace ESAPIX.Facade.Types
{
    public class ExternalBeamMachineParameters
    {
        internal dynamic _client;

        public ExternalBeamMachineParameters()
        {
            _client = new ExpandoObject();
        }

        public ExternalBeamMachineParameters(dynamic client)
        {
            _client = client;
        }

        public ExternalBeamMachineParameters(string machineId, string energyModeId, int doseRate, string techniqueId,
            string primaryFluenceModeId)
        {
            if (X.Instance.CurrentContext != null)
            {
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructExternalBeamMachineParameters(machineId, energyModeId,
                        doseRate, techniqueId, primaryFluenceModeId);
                });
            }
            else
            {
                _client = new ExpandoObject();
                _client.MachineId = machineId;
                _client.EnergyModeId = energyModeId;
                _client.DoseRate = doseRate;
                _client.TechniqueId = techniqueId;
                _client.PrimaryFluenceModeId = primaryFluenceModeId;
            }
        }

        public bool IsLive => !DefaultHelper.IsDefault(_client);

        public string MachineId
        {
            get
            {
                if (_client is ExpandoObject) return _client.MachineId;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.MachineId; });
            }
            set
            {
                if (_client is ExpandoObject) _client.MachineId = value;
            }
        }

        public string EnergyModeId
        {
            get
            {
                if (_client is ExpandoObject) return _client.EnergyModeId;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.EnergyModeId; });
            }
            set
            {
                if (_client is ExpandoObject) _client.EnergyModeId = value;
            }
        }

        public int DoseRate
        {
            get
            {
                if (_client is ExpandoObject) return _client.DoseRate;
                var local = this;
                return X.Instance.CurrentContext.GetValue<int>(sc => { return local._client.DoseRate; });
            }
            set
            {
                if (_client is ExpandoObject) _client.DoseRate = value;
            }
        }

        public string PrimaryFluenceModeId
        {
            get
            {
                if (_client is ExpandoObject) return _client.PrimaryFluenceModeId;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.PrimaryFluenceModeId; });
            }
            set
            {
                if (_client is ExpandoObject) _client.PrimaryFluenceModeId = value;
            }
        }

        public string TechniqueId
        {
            get
            {
                if (_client is ExpandoObject) return _client.TechniqueId;
                var local = this;
                return X.Instance.CurrentContext.GetValue<string>(sc => { return local._client.TechniqueId; });
            }
            set
            {
                if (_client is ExpandoObject) _client.TechniqueId = value;
            }
        }
    }
}