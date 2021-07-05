using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConsoleBaseApp.Utils
{
    public class YamlUtil
    {
        public class YamlImporter<T>
        {
            public T Deserialize(string yamlName)
            {
                var sr = new StreamReader(yamlName);
                string text = sr.ReadToEnd();
                var input = new StringReader(text);
                var deserializer = new Deserializer();
                T deserializeObject = deserializer.Deserialize<T>(input);
                return deserializeObject;
            }
        }

        public class YamlExporter<T>
        {
            public string Serialize(T model)
            {
                ISerializer serializer = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
                return serializer.Serialize(model);
            }
        }
    }
}
