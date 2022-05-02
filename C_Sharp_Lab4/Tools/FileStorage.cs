using System;
using System.IO;


namespace CSharp.Lab04.Tools
{
    internal static class FileStorage
    {

        internal static readonly string DatabaseFilePath =
            Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Lab4.Csharp"), "Database");

        internal static bool CreateFileWithFilePathIfNotExist(string filePath)
        {
            var file = new FileInfo(filePath);
            return file.CreateFileIfNotExist();
        }

        internal static bool CreateFileIfNotExist(this FileInfo file)
        {
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }
            return file.Exists;
        }
    }
}
