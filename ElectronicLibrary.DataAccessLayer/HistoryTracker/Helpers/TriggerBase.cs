using System;
using System.Text;
using ElectronicLibrary.DataAccessLayer.HistoryTracker.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ElectronicLibrary.DataAccessLayer.HistoryTracker.Helpers
{
    public abstract class TriggerBase<T> : ITrigger
    {
        protected IEnumerable<TriggerEntityVersion<T>> TrackedEntities;
        protected abstract IEnumerable<TriggerEntityVersion<T>> RegisterChangedEntitiesInternal(ChangeTracker changeTracker);
        protected abstract Task TriggerAsyncInternal(TriggerEntityVersion<T> trackedTriggerEntity);

        public void RegisterChangedEntities(ChangeTracker changeTracker)
        {
            TrackedEntities = RegisterChangedEntitiesInternal(changeTracker).ToArray();
        }
        public async Task TriggerAsync()
        {
            foreach (TriggerEntityVersion<T> triggerEntityVersion in TrackedEntities)
            {
                await TriggerAsyncInternal(triggerEntityVersion);
            }
        }
    }
}
