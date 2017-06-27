using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Interfaces
{
    public interface IService<T> where T : class
    {
        List<T> List(string accountId);
        string Create(string accountId, T model);
    }
}
