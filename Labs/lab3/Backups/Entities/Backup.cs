using System;
using System.Collections.Generic;
using Backups.Algorithms;
using Backups.Models;
using Backups.Tools;

namespace Backups.Entities
{
    public class Backup
    {
        private List<RestorePoint> _restorePoints = new List<RestorePoint>();
        public IReadOnlyCollection<RestorePoint> RestorePoints => _restorePoints.AsReadOnly();
        
        public void AddRestorePoint(RestorePoint restorePoint)
        {
            if(restorePoint is null) 
                throw new BackupsException("");
            _restorePoints.Add(restorePoint);
        }
    }
}