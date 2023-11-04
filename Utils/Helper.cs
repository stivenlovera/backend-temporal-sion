using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace api_guardian.Utils
{
    public class Helper
    {
        public static string Log(object data)
        {
            var resultado = JsonConvert.SerializeObject(data, Formatting.Indented);
            return resultado;
        }
    }
}