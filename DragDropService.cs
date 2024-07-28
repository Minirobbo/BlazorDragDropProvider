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

        public Type? CurrentType => IsDragging ? draggingObject.GetType() : null;

        public void StartDrag(IDragDropZone zone, object obj)
        {
            origin = zone;
            target = null;
            draggingObject = obj;
        }

        public void StopDrag()
        {
            if (origin == null || draggingObject == null || target == null) return;

            if (target != origin && target.CanDropItem(draggingObject))
            {
                target.DropItem(draggingObject);
                origin.RemoveItem(draggingObject);
            }

            draggingObject = null;
        }

        public void SetOver(IDragDropZone zone)
        {
            target = zone;
        }
    }
}
