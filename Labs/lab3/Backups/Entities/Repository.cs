using System.IO;
using Backups.Interfaces;
using Backups.Tools;

namespace Backups.Entities
{
    public class Repository : IRepository
    {
        private string _path;

        public Repository(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new BackupsException("incorrect path input");
            _path = path;
        }
        public void Create(BackupTask backupTask)
        {
            backupTask.SetBackupPath(Path.Combine(Path.GetFullPath(_path), backupTask.BackupName));
            if (!Directory.Exists(backupTask.BackupPath))
                Directory.CreateDirectory(backupTask.BackupPath);
        }
    }
}