using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public static class SessionExtensions
{
    //lay data tu session
    public static T GetComplexData<T>(this ISession session, string key)
    {
        var data = session.GetString(key);
        if (data == null)
        {
            return default(T);
        }
        return JsonConvert.DeserializeObject<T>(data);
    }

    // luu data vao session
    public static void SetComplexData(this ISession session, string key, object value)
    {
        //chuyen doi value thanh json => luu session
        session.SetString(key, JsonConvert.SerializeObject(value));
    }
}

