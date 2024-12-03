using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragDropProvider
{
    public class DragDropService<TItem> where TItem : class
    {
        private IDragDropSource<TItem>? origin;
        private IDragDropZone<TItem>? target;
        private TItem? draggingObject;
        private bool IsDragging => draggingObject != null;

        private List<IDragDropZone<TItem>> draggingZones = new();

        public Type? CurrentType => IsDragging ? draggingObject.GetType() : null;

        public void AddZone(IDragDropZone<TItem> zone)
        {
            draggingZones.Add(zone);
        }

        public void RemoveZone(IDragDropZone<TItem> zone)
        {
            draggingZones.Remove(zone);
        }

        public void StartDrag(IDragDropSource<TItem> source, TItem? obj)
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

        public void SetOver(IDragDropZone<TItem> zone)
        {
            if (target != zone)
            {
                target?.UpdateCurrentZone(false);
                target = zone;
                target.UpdateCurrentZone(true);
                //draggingZones.ForEach(zone => { zone.UpdateCurrentZone(zone == target); });
            }
        }

        public bool CanDropHere(IDragDropZone<TItem> zone)
        {
            return origin != null && target != null && IsDragging && (origin != zone || zone.CanReorder) && target == zone && zone.CanDropItem(draggingObject);
        }

        public bool IsCurrent(IDragDropZone<TItem> zone)
        {
            return target == zone && IsDragging;
        }

        public void LeaveZone(IDragDropZone<TItem> zone)
        {
            if (zone == target)
            {
                target = null;
            }
        }
    }
}
