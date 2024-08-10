using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragDropProvider
{
    public interface IDragDropSource
    {
        public void RemoveItem(object item);
    }
}
