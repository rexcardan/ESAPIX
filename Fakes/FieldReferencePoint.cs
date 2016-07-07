using System;
using System.Reflection;
using ESAPIX.Interfaces;
using ESAPIX.Types;


namespace ESAPIX.Fakes
{
    public class FieldReferencePoint : IFieldReferencePoint
    {
        public IReferencePoint ReferencePoint
        {
            get;
            set; 
        }

        public VVector RefPointLocation { get; set; }

        public DoseValue FieldDose { get; set; }

        public double EffectiveDepth { get; set; }

        public double SSD { get; set; }

        public bool IsPrimaryReferencePoint { get; set; }

        public bool IsFieldDoseNominal { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public string HistoryUserName { get; set; }

        public DateTime HistoryDateTime { get; set; }
    }
}