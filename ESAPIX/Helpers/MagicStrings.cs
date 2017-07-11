namespace ESAPIX.Helpers
{
    /// <summary>
    ///     Class that holds constant strings from the Eclipse Scripting API
    /// </summary>
    public static class MagicStrings
    {
        public static class VolumeUnits
        {
            public static string PERCENT = "%";
        }

        public static class DICOMType
        {
            public const string PTV = "PTV";
            public const string GTV = "GTV";
            public const string CTV = "CTV";
            public const string DOSE_REGION = "DOSE_REGION";
            public const string NONE = "";
            public const string CONSTRAST_AGENT = "CONSTRAST_AGENT";
            public const string CAVITY = "CAVITY";
            public const string AVOIDANCE = "AVOIDANCE";
            public const string CONTROL = "CONTROL";
            public const string FIXATION = "FIXATION";
            public const string IRRAD_VOLUME = "IRRAD_VOLUME";
            public const string ORGAN = "ORGAN";
            public const string TREATED_VOLUME = "TREATED_VOLUME";
        }
    }
}