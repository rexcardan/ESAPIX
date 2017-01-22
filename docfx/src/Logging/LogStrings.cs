using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPIX.Logging
{
    public class LogStrings
    {
        public static string QUE_WORK = "Queing work for {0} <{1}>=><{2}>";
        public static string FINDING_PROXY = "Looking for proxy {0}";
        public static string PROXY_FOUND = "Found proxy {0}";
        public static string START_WORK = "Beginning work on proxy {0}";
        public static string START_COLLECTION_WORK = "Beginning collection work on proxy {0}";
        public static string CONVERTING_TYPE = "Converting types...";
        public static string ADDING_PROXY = "Adding {0} (GUID = {1}) to proxies";
        public static string COMPLETING_WORK = "Completing work";
        public static string RELEASING_PROXY = "Releasing {0} (GUID = {1}) from proxies";
        public static string NULL_ACTOR = "Actor {0} was null in the proxy collection";
    }
}
