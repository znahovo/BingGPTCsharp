using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EdgeGPTCsharp
{
    public static class ObjectExtension
    {
        public static string ToJsonStr(this object o)
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}
