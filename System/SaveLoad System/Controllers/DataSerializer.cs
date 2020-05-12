using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

/// <summary>
/// Special data serializer which serializes data in binary format and encodes it to base64.
/// </summary>
public static class DataSerializer
{
    /// <summary>
    /// Convert object into base64 string.
    /// </summary>
    /// <param name="obj">Object to convert</param>
    /// <returns>Covnerted object as string</returns>
    public static string SerializeObject(object obj)
    {
        string data = string.Empty;
        using (var stream = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            data = Convert.ToBase64String(stream.ToArray());
        }
        return data;
    }

    /// <summary>
    /// Deserialize object from base64 string.
    /// </summary>
    /// <typeparam name="T">Final object type</typeparam>
    /// <param name="data">Base64 string</param>
    /// <returns></returns>
    public static T DeserializeObject<T>(string data)
    {
        try
        {
            using (var stream = new MemoryStream(Convert.FromBase64String(data)))
            {
                var formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
        catch(SerializationException e)
        {
            Debug.LogWarning(e.Message);
            return default;
        }
    }
}
