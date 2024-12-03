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
        /// Checks if another type is compatible with the current type.
        /// 
        /// A type is compatible with the current type if:
        /// It is the same type or is a subclass of current type.
        /// 
        /// </summary>
        /// <param name="self">This Type class</param>
        /// <param name="other">Type class to be compared to</param>
        /// <returns>True, if the other Type class is compatible with the current Type, otherwise False</returns>
        public static bool IsCompatibleType(this Type self, Type other)
        {
            return self.IsAssignableFrom(other);
        }

        ///// <summary>
        ///// Adds required services to a dependancy injection IServiceCollection
        ///// </summary>
        ///// <param name="services">Current services to be added to</param>
        //public static void AddDragDropServices(this IServiceCollection services)
        //{
        //    services.AddScoped<DragDropService>();
        //}
    }
}
