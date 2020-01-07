using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Models
{
    public interface iCacheProvider
    {
        bool Set(string key, object value, int minutes);

        T Get<T>(string key);

        void Remove(string key);
    }
}
