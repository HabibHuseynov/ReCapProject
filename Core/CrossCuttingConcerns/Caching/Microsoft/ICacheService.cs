using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public interface ICacheService
    {
        void Add(string key, object value, int duration);
        T Get<T>(string key);
        object Get(string key);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
