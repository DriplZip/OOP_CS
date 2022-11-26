using System;
using System.Collections.Generic;
using Backups.Interfaces;
using Backups.Tools;

namespace Backups.Entities
{
    public class RestorePoint
    {
        private List<Storage> _storages;
        
        public RestorePoint(List<Storage> storages)
        {
            _storages = storages;
            CreationTime = DateTime.Now;
        }

        public DateTime CreationTime { get; }
        public IReadOnlyCollection<Storage> Storages => _storages.AsReadOnly();

        public void AddStorage(string name, List<BackupObject> info)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BackupsException("incorrect name input");
            if (info is null)
                throw new BackupsException("incorrect info input");
            _storages.Add(new Storage(name, info));
        }
        
        
    }
}