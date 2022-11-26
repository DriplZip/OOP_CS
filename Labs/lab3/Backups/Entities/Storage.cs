using System.Collections.Generic;
using System.Net;
using Backups.Tools;

namespace Backups.Entities
{
    public class Storage
    {
        private List<BackupObject> _info;
        
        public Storage(string name, List<BackupObject> info)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BackupsException("incorrect name input");
            Name = name;
            _info = info;
        }

        public IReadOnlyCollection<BackupObject> Info => _info.AsReadOnly();
        public string Name { get; }
    }
}