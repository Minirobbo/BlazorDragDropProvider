using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragDropProvider
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Checks if another type is the same or is a subclass of current type.
        /// </summary>
        /// <param name="self">This Type class</param>
        /// <param name="other">Type class to be compared to</param>
        /// <returns>True, if the other Type class is the same or is a subclass of the current Type, otherwise False</returns>
        public static bool IsSameOrSubClassOf(this Type self, Type other)
        {
            return self.IsSubclassOf(other) || self == other;
        }

        /// <summary>
        /// Adds required services to a dependancy injection IServiceCollection
        /// </summary>
        /// <param name="services">Current services to be added to</param>
        public static void AddDragDropServices(this IServiceCollection services)
        {
            services.AddScoped<DragDropService>();
        }
    }
}
