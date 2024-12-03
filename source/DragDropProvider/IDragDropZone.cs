using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragDropProvider
{
    public interface IDragDropZone<TItem> : IDragDropSource<TItem>
    {
        public bool CanDropItem(TItem item);

        public void DropItem(TItem item);
        
        public void ReorderItem(TItem item);

        public void UpdateCurrentZone(bool isCurrent);

        public bool CanReorder { get; set; }
    }
}
