using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragDropProvider
{
    public interface IDragDropZone
    {
        public bool CanDropItem(object item);

        public void DropItem(object item);

        public void RemoveItem(object item);
        
        public void ReorderItem(object item);

        public void UpdateCurrentZone(bool isCurrent);

        public bool CanReorder { get; set; }
    }
}
