using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragDropProvider
{
    public class DragDropService
    {
        private IDragDropSource? origin;
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

        public void StartDrag(IDragDropSource source, object obj)
        {
            origin = source;
            target = null;
            draggingObject = obj;
        }

        public void StopDrag()
        {
            if (origin == null || draggingObject == null || target == null)
            {
                draggingObject = null;
            }
            else if ((target != origin || target.CanReorder) && target.CanDropItem(draggingObject))
            {
                if (target == origin)
                {
                    target.ReorderItem(draggingObject);
                }
                else
                {
                    origin.RemoveItem(draggingObject);
                    target.DropItem(draggingObject);
                }
                draggingObject = null;
            }
            origin = null;
            target = null;
            draggingZones.ForEach(zone => { zone.UpdateCurrentZone(false); });
        }

        public void SetOver(IDragDropZone zone)
        {
            if (target != zone)
            {
                target?.UpdateCurrentZone(false);
                target = zone;
                target.UpdateCurrentZone(true);
                //draggingZones.ForEach(zone => { zone.UpdateCurrentZone(zone == target); });
            }
        }

        public bool CanDropHere(IDragDropZone zone)
        {
            return origin != null && target != null && IsDragging && (origin != zone || zone.CanReorder) && target == zone && zone.CanDropItem(draggingObject);
        }

        public bool IsCurrent(IDragDropZone zone)
        {
            return target == zone && IsDragging;
        }

        public void LeaveZone(IDragDropZone zone)
        {
            if (zone == target)
            {
                target = null;
            }
        }
    }
}
