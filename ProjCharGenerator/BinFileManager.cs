using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BinFileManager
{
  public class BinFileManager
  {
    public static void WriteObjectToBinFile(string path, object obj)
    {
      File.WriteAllBytes(path, ToByteArray(obj));
    }

    public static T ReadFromBinFileToObject<T>(string path)
    {
      return FromByteArray<T>(File.ReadAllBytes(path));
    }

    private static byte[] ToByteArray<T>(T obj)
    {
      if (obj == null)
        return null;
      BinaryFormatter bf = new BinaryFormatter();
      using (MemoryStream ms = new MemoryStream())
      {
        bf.Serialize(ms, obj);
        return ms.ToArray();
      }
    }

    private static T FromByteArray<T>(byte[] data)
    {
      if (data == null)
        return default(T);
      BinaryFormatter bf = new BinaryFormatter();
      using (MemoryStream ms = new MemoryStream(data))
      {
        object obj = bf.Deserialize(ms);
        return (T)obj;
      }
    }

  }
}
