﻿using Backups.Entities;

namespace Backups.Interfaces
{
    public interface IRepository
    {
        public void Create(BackupTask backupTask);
    }
}