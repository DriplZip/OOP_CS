using System.IO;
using System.Net;
using Backup.Extra.Tools;

namespace Backup.Extra.Entities
{
    public class FileLogger : ILogger
    {
        private string _filePath;

        public FileLogger(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new BackupExtraException("incorrect file path");

            _filePath = filePath;
        }
            
        public void Log(string message)
        {
            File.AppendAllText(_filePath, message);
        }
    }
}