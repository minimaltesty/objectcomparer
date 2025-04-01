
namespace SIT.Components.ObjectComparer {

    public abstract class DeepCopyBase {

        public object DeepCopy() {
            return Generic.DeepCopy.Copy<object>( this );

        }
    }
}
