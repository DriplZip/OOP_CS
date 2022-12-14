using System.Collections.Generic;
using Backups.Entities;

namespace Backups.Models
{
    public interface IRepository
    {
        public string Name { get; }
        
        public void Read(string path);

        public void Save(BackupTask backupTask, IArchiver archiver);
    }
}