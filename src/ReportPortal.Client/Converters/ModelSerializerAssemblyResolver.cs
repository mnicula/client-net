using System;
using System.Linq;
using System.Reflection;

namespace ReportPortal.Client.Converters
{
    public class ModelSerializerAssemblyResolver
    {
        static ModelSerializerAssemblyResolver()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("Newtonsoft.Json"))
            {
                var resourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().First(r => r == "ReportPortal.Client.Newtonsoft.Json.dll");
                using (var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    var bytes = new byte[resourceStream.Length];
                    resourceStream.Read(bytes, 0, bytes.Length);
                    return Assembly.Load(bytes);
                }
            }

            return null;
        }

        public static void Init()
        {

        }
    }
}
