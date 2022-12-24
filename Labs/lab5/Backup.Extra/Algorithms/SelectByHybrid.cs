using System.Collections.Generic;
using System.Linq;
using Backup.Extra.Entities;
using Backup.Extra.Tools;
using Backups.Entities;

namespace Backup.Extra.Algorithms
{
    public class SelectPointToCleaningByHybrid: ISelectPointToCleaningAlgorithm
    {
        private bool _forAll;
        private bool _atLeastOne;
        private List<ISelectPointToCleaningAlgorithm> _algorithms;

        public SelectPointToCleaningByHybrid(bool forAll, bool atLeastOne, List<ISelectPointToCleaningAlgorithm> algorithms)
        {
            if (forAll && atLeastOne) throw new BackupExtraException("select one requirement");
            _forAll = forAll;
            _atLeastOne = atLeastOne;

            _algorithms = algorithms;
        }
        
        public List<RestorePoint> SelectPoints(BackupTaskExtra backupTaskExtra)
        {
            List<RestorePoint> selectedPoints = new List<RestorePoint>();

            foreach (ISelectPointToCleaningAlgorithm cleaningAlgorithm in _algorithms)
            {
                List<RestorePoint> tmpPoints = cleaningAlgorithm.SelectPoints(backupTaskExtra);

                if (_atLeastOne)
                {
                    selectedPoints.AddRange(tmpPoints.Where(point => !selectedPoints.Contains(point)));
                }

                if (_forAll)
                {
                    if (selectedPoints.Count == 0)
                    {
                        selectedPoints.AddRange(tmpPoints);
                    }
                    else
                    {
                        foreach (RestorePoint restorePoint in tmpPoints)
                        {
                            if (!selectedPoints.Contains(restorePoint)) selectedPoints.Remove(restorePoint);
                        }
                    }
                }
            }

            return selectedPoints;
        }
    }
}