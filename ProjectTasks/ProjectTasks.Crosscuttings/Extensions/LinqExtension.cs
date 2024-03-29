﻿namespace ProjectTasks.Crosscuttings.Extensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides utils to extend LinQ.
    /// </summary>
    public static class LinqExtension
    {
        /// <summary>
        /// This method extends the LINQ methods to flatten a collection of items that have a property of children of the same type.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="childPropertySelector">Child property selector delegate of each item. IEnumerable'T' childPropertySelector(T itemBeingFlattened)</param>
        /// <param name="result">The result.</param>
        public static void Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childPropertySelector, ref List<T> result)
        {
            if (source == null) return;

            foreach(var item in source)
            {
                result.Add(item);
                childPropertySelector(item).Flatten(sub => childPropertySelector(sub), ref result);
            }

            return;
        }
    }
}
