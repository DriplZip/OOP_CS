using System.IO;
using System.IO.Compression;
using System.Linq;
using Backups.Entities;
using Backups.Tools;

namespace Backups.Models
{
    public class Repository : IRepository
    {
        private DirectoryInfo _directoryInfo;
        
        public Repository(string fullPath)
        {
            if (string.IsNullOrWhiteSpace(fullPath)) throw new BackupsException("Incorrect path");
            
            FullPath = fullPath;
            _directoryInfo = new DirectoryInfo(fullPath);
        }
        
        public string FullPath { get; private set; }

        public void Read(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) throw new BackupsException("Incorrect path");
            FullPath = path;

            _directoryInfo = new DirectoryInfo(path);
        }
        
        /// <summary>
        /// А КАК КАКАТЬ ТО ?!?!?!
        /// </summary>
        /// <param name="backupTask"> ЭТО ПИЗДЕЦ </param>
        public void Save(BackupTask backupTask)
        {
            string path = Path.Combine(_directoryInfo.FullName, backupTask.Name);

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            
            if (!directoryInfo.Exists) directoryInfo.Create();

            
        }
    }
}