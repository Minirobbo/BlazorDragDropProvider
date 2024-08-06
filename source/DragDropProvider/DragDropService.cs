using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragDropProvider
{
    public class DragDropService
    {
        private IDragDropZone? origin;
        private IDragDropZone? target;
        private object? draggingObject;
        private bool IsDragging => draggingObject != null;

        private List<IDragDropZone> draggingZones = new();

        public Type? CurrentType => IsDragging ? draggingObject.GetType() : null;

        public void AddZone(IDragDropZone zone)
        {
            draggingZones.Add(zone);
        }

        public void RemoveZone(IDragDropZone zone)
        {
            draggingZones.Remove(zone);
        }

        public void StartDrag(IDragDropZone zone, object obj)
        {
            origin = zone;
            target = null;
            draggingObject = obj;
        }

        public void StopDrag()
        {
            if (origin == null || draggingObject == null || target == null)
            {
                draggingObject = null;
            }
            else if (target != origin && target.CanDropItem(draggingObject))
            {
                target.DropItem(draggingObject);
                origin.RemoveItem(draggingObject);
                draggingObject = null;
            }
            draggingZones.ForEach(zone => { zone.UpdateCurrentZone(false); });
        }

        public void SetOver(IDragDropZone zone)
        {
            if (target != zone)
            {
                target = zone;
                draggingZones.ForEach(zone => { zone.UpdateCurrentZone(zone == target); });
            }
        }

        public bool CanDropHere(IDragDropZone zone)
        {
            return origin != null && target != null && IsDragging && origin != zone && target == zone && zone.CanDropItem(draggingObject);
        }

        public bool IsCurrent(IDragDropZone zone)
        {
            return target == zone && IsDragging;
        }
    }
}
