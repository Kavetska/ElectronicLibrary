using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ElectronicLibrary.DataAccessLayer.HistoryTracker.Interfaces
{
    public interface ITrigger
    {
        //The RegisterChangedEntities method accepts a ChangeTracker so that if need be, we can store the changes that happened for later use.
        void RegisterChangedEntities(ChangeTracker changeTracker);
        Task TriggerAsync();
    }
}
