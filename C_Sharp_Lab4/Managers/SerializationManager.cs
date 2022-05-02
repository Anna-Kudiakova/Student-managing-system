using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace CSharp.Lab04.Tools.Managers
{
    internal static class SerializationManager
    {
        internal static void Serialize<TObject>(TObject obj, string path)
        {
            try
            {
                var file = new FileInfo(path);
                if (file.CreateFileIfNotExist())
                {
                    file.Delete();
                }
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    formatter.Serialize(stream, obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to serialize file [{path}]", ex);
            }
        }

        internal static TObject Deserialize<TObject>(string filePath) where TObject : class
        {
            try
            {
                if (!FileStorage.CreateFileWithFilePathIfNotExist(filePath))
                    throw new FileNotFoundException("Failed to find a file");
                var formatter = new BinaryFormatter();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    return (TObject)formatter.Deserialize(stream);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"Failed to deserialize file [{filePath}]", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to deserialize file [{filePath}]", ex);
            }
        }
    }
}
