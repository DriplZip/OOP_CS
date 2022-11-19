using System.Collections.Generic;
using Backups.Entities;

namespace Backups.Models
{
    public interface IRepository
    {
        public void Read(string path);

        public void Save(BackupTask backupTask);

        public string GetName();
    }
}