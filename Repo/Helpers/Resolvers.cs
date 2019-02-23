using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repo.Helpers
{
    public class Resolvers
    {
        public static string ResolveQueryByName(string queryName)
        {
            var currDirectory = Directory.GetCurrentDirectory();
            var sqlDirectory = Path.Combine(currDirectory, "sql");
            if(!Directory.Exists(sqlDirectory))
                throw new DirectoryNotFoundException($"Can`t find directory: {sqlDirectory}");

            var fileName = $"{queryName}.sql";
            var fullFilePath = Path.Combine(sqlDirectory, fileName);
            if(!File.Exists(fullFilePath))
                throw new FileNotFoundException($"Can`t find file: {fullFilePath}");

            return File.ReadAllText(fullFilePath);
        }
    }
}
