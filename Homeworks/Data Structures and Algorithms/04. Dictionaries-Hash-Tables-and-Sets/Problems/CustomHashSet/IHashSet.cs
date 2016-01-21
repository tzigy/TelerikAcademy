namespace Problems.CustomHashSet
{
    using System.Collections.Generic;

    public interface IHashSet<T> : IEnumerable<T>
    {
        /// <summary>
        /// Adding the element to the set and returning false if the element is already present inside the set, 
        /// otherwise returning true.
        /// </summary>
        /// <param name="element">The element to be added.</param>
        /// <returns>Boolean.</returns>
        bool Add(T element);
     
        /// <summary>
        /// Checks if the set already contains the element passed as an argument.
        /// If yes, returns true as a result, otherwise returns false.
        /// </summary>
        /// <param name="element">The element that is checked.</param>
        /// <returns>Boolean.</returns>
        bool Contains(T element);

        /// <summary>
        ///  Removes the element from the set.Returns Boolean if the element has been present inside the set.
        /// </summary>
        /// <param name="element">The element to be removed.</param>
        /// <returns>Boolean.</returns>
        bool Remove(T element);

        /// <summary>
        /// Removes all the elements from the set.
        /// </summary>
        void Clear();

        /// <summary>
        /// Inside the current set remain only the elements of the intersection of both sets – the result is a set, 
        /// containing the elements, which are present in both sets at the same time – the set, 
        /// calling the method and the other, passed as parameter.
        /// </summary>
        /// <param name="other">The other set of elements that should be intersected 
        /// with the current set the method is called upon.</param>
        IHashSet<T> IntersectWith(CustomHashSet<T> other);

        /// <summary>
        /// Inside the current set remain only the elements of the sets union – the result is a set,
        /// containing the elements of either one or the other, or both sets.
        /// </summary>
        /// <param name="other">The other set of elements that should be united 
        /// with the current set the method is called upon.</param>
        IHashSet<T> UnionWith(CustomHashSet<T> other);

        /// <summary>
        /// A property, which returns the current number of elements inside the set.
        /// </summary>
        int Count { get; }
    }
}
