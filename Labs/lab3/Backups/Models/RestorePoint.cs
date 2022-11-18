using System;
using System.Collections.Generic;
using Backups.Algorithms;
using Backups.Tools;

namespace Backups.Models
{
    public class RestorePoint
    {
        private List<Storage> _storages;
        private int _archiveNumber;

        public RestorePoint(DateTime timeOfCreation, List<Storage> storages, int archiveNumber)
        {
            if (storages.Count == 0) throw new BackupsException("Nothing to save");
            _storages = storages;

            _archiveNumber = archiveNumber;

            Date = timeOfCreation;
            Id = Guid.NewGuid();
        }
        public DateTime Date { get; }
        public Guid Id { get; }

        public IReadOnlyCollection<Storage> Storages => _storages.AsReadOnly();
    }
}