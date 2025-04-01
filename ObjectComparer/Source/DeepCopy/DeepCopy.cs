
namespace SIT.Components.ObjectComparer {

    /// <summary>
    /// Provides static methods to deep copy objects
    /// </summary>
    public static class DeepCopy {


        /// <summary>
        /// Creates a deep copy of the specified source.
        /// </summary>
        /// <param name="source">The source object to create a deep copy of.</param>
        /// <returns>The deep copy of the given source object</returns>
        public static object Copy( object source ) {
            if( source == null )
                return null;

            if( source.GetType().GetInterface( "ICollection" ) != null )
                return CopyCollection( source );

            else
                return CopyObject( source );

        }

        /// <summary>
        /// Creates a deep copy of the specified source.
        /// </summary>
        /// <typeparam name="T">The type of object to copy</typeparam>
        /// <param name="source">The source object to create a deep copy of.</param>
        /// <returns>The deep copy of the given source object</returns>
        public static T Copy<T>( T source ) where T:class{
            if( source == null )
                return null;

            if( source.GetType().GetInterface( "ICollection" ) != null )
                return CopyCollection( source ) as T;

            else
                return CopyObject( source ) as T;

        }

        /// <summary>
        /// Creates a deep copy of the specified source.
        /// </summary>
        /// <param name="source">The source object to create a deep copy of.</param>
        /// <returns>The deep copy of the given source object</returns>
        /// <remarks>
        /// For internal use only.
        /// </remarks>
        internal static object CopyObject( object source ) {
            return Generic.DeepCopy.CopyObject<object>( source );

        }

        /// <summary>
        /// Creates a deep copy of the specified source collection.
        /// </summary>
        /// <param name="source">The source object to create a deep copy of.</param>
        /// <returns>The deep copy of the given source collection</returns>
        /// <remarks>
        /// For internal use only.
        /// </remarks>
        internal static object CopyCollection( object source ) {
            return Generic.DeepCopy.CopyCollection<object>( source );


        }
    }
}
