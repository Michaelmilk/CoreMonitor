using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMonitorProcessor.Json
{
    public static class JsonProcessor
    {
        public static List<string> FlattenAllJsonPaths(string json, string jsonPath, bool withArryIndex)
        {

        }

        public static List<KeyValuePair<string, string>> FlattenJsonByPath(string json, string jsonPath, bool withArryIndex)
        {

        }

        public static List<KeyValuePair<string, string>> Flatten(string json, bool withArryIndex)
        {
            List<KeyValuePair<string, string>> dict = new List<KeyValuePair<string, string>>();
            JToken token = JToken.Parse(json);
            GeneratePathToValuePairs(dict, token, "", withArryIndex);
            return dict;
        }

        private static void GeneratePathToValuePairs(List<KeyValuePair<string, string>> dict, JToken token,
            string prefix, bool withArrayIndex)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    foreach (JProperty prop in token.Children<JProperty>())
                    {
                        GeneratePathToValuePairs(dict, prop.Value, Join(prefix, prop.Name), withArrayIndex);
                    }

                    break;
                case JTokenType.Array:
                    int index = 0;
                    foreach (JToken value in token.Children())
                    {
                        if (withArrayIndex)
                        {
                            GeneratePathToValuePairs(dict, value, Join(prefix, index.ToString()), withArrayIndex);
                        }
                        else
                        {
                            GeneratePathToValuePairs(dict, value, prefix, withArrayIndex);
                        }

                        index++;
                    }

                    break;
                default:
                    dict.Add(new KeyValuePair<string, string>(prefix, ((JValue)token).Value.ToString()));
                    break;
            }
        }

        private static string Join(string prefix, string name)
        {
            return (string.IsNullOrEmpty(prefix) ? name : prefix + "." + name);
        }
    }
}
