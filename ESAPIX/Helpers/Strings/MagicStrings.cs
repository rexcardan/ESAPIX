namespace ESAPIX.Helpers.Strings
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
            public const string EXTERNAL = "EXTERNAL";
        }

        public static class CourseIntent
        {
            public const string BENIGN = "Benign";
            public const string CONCOMITANT = "Concomitant";
            public const string CONCURRENT = "Concurrent";
            public const string CONSULT_ONLY = "Consult Only";
            public const string CURATIVE = "Curative";
            public const string CURATIVE_W_CHEMO = "Curative w/chemo";
            public const string EMERGENCY = "Emergency";
            public const string PALLIATIVE = "Palliative";
            public const string PALLIATIVE_W_CHEMO = "Palliative w/chemo";
            public const string POST_OP = "Post-op";
            public const string PRE_OP = "Pre-op";
            public const string PROTOCOL = "Protocol";
            public const string RADICAL = "Radical";
            public const string UNKNOWN = "Unknown";
        }

        public static class PlanIntent
        {
            public const string PROPHYLACTIC = "Prophylactic";
            public const string RESEARCH = "Research";
            public const string PALLIATIVE = "Palliative";
            public const string SERVICE = "Service";
            public const string MACHINE_QA = "Machine QA";
            public const string CURATIVE = "Curative";
        }
    }
}