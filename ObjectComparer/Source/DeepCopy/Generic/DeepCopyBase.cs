
namespace SIT.Components.ObjectComparer.Generic {
    
    /// <summary>
    /// Provides methods to create a deep copy of the object which is derived from this type
    /// </summary>
    /// <typeparam name="T">The Type which is subject of the deep copy process</typeparam>
    /// <example>
    /// The following example shows how the <c>DeepCopyBase</c> class can be derived
    /// <code>
    /// public class Order : DeepCopyBase<Order>, ICloneable 
    /// {
    ///     ...
    /// }
    /// </code>
    /// </example>
    public abstract class DeepCopyBase<T> {

        /// <summary>
        /// Creates a deep copy of the object
        /// </summary>
        /// <returns>A new instance of the object</returns>
        public T DeepCopy() {
            return (T)Generic.DeepCopy.Copy<object>( this );

        }

    }


}
