using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragDropProvider
{
    public static class TypeExtension
    {
        public static bool IsSameOrSubClassOf(this Type self, Type other)
        {
            return self.IsSubclassOf(other) || self == other;
        }
    }
}
