using System;
using System.Collections.Generic;
using Backups.Tools;

namespace Backups.Entities
{
    public class RestorePoint
    {
        private List<Storage> _storages;
        
        public RestorePoint(DateTime createTime, List<Storage> storages)
        {
            if (storages.Count == 0) 
                throw new BackupsException("");
            _storages = storages;
            CreateTime = createTime;
            Id = Guid.NewGuid();
        }
        
        public DateTime CreateTime { get; }
        public Guid Id { get; }
        public IReadOnlyCollection<Storage> Storages => _storages.AsReadOnly();
    }
}