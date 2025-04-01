using System.Collections.Generic;
using System.Reflection;

namespace SIT.Components.ObjectComparer {

    public interface IMetadataReader {

        ClassDescription GetClassDescription( object value );
        MemberDescription GetPropertyDescription( object value, MemberInfo pi );
        ItemDescription GetDescription(object item, MemberInfo pi);
        List<MemberInfo> GetMembers(object value);
        SnapshotData GetSnapshotData(object value, MemberInfo mi);
        void UpdateSnapshotData(SnapshotData data, object value, MemberInfo mi);

    }

    //public class MetadataReader :
    //    IMetadataReader
    //{

    //    private IContext _context = null;
    //    public IContext Context { get { return _context; } }

    //    public MetadataReader(IContext context)
    //        :base() {
    //            _context = context;

    //    }

    //    public ClassDescription GetClassDescription( object value ) {
    //        var typeOfValue = value.GetType();
            
    //        if( _context.Cache.ExistsClassDescription( typeOfValue.FullName ) )
    //            return _context.Cache.GetClassDescription( typeOfValue.FullName );

    //        var classDesc = new ClassDescription();
    //        classDesc.DisplayName = typeOfValue.Name;
    //        classDesc.FullName = typeOfValue.FullName;
    //        var ca = Attribute.GetCustomAttribute( typeOfValue, typeof( CompareClassAttribute ) ) as CompareClassAttribute;
    //        if( ca != null ) {
    //            if( !string.IsNullOrEmpty( ca.DisplayName ) )
    //                classDesc.DisplayName = ca.DisplayName;

    //            classDesc.IdPropertyName = ca.IdPropertyName;

    //        }
    //        _context.Cache.Add( classDesc );
    //        return classDesc;
    //    }

    //    public MemberDescription GetPropertyDescription( object value, PropertyInfo pi ) {
    //        var propertyFullname = pi.DeclaringType.FullName + "." + pi.Name;

    //        if( _context.Cache.ExistsPropertyDescription( propertyFullname ) )
    //            return _context.Cache.GetPropertyDescription( propertyFullname );

    //        ClassDescription classDesc = null;
    //        if( !_context.Cache.ExistsClassDescription( pi.DeclaringType.FullName ) )
    //            classDesc = GetClassDescription( value );

    //        else
    //            classDesc = _context.Cache.GetClassDescription( pi.DeclaringType.FullName );

    //        var propDesc = new MemberDescription( classDesc );
    //        propDesc.DisplayName = pi.Name;
    //        propDesc.FullName = classDesc.FullName + "." + pi.Name;
    //        propDesc.TypeName = pi.PropertyType.Name;
    //        propDesc.Name = pi.Name;
    //        propDesc.TypeIsEnumerable = pi.PropertyType.GetInterface( typeof( IEnumerable ).Name ) != null;
    //        propDesc.TypeIsString = pi.PropertyType == typeof( string );
    //        propDesc.HasIndexParameters = pi.GetIndexParameters().Length > 0;
    //        propDesc.MemberInfo = pi;
    //        var ca = Attribute.GetCustomAttribute( pi, typeof( ComparePropertyAttribute ) ) as CompareAttribute;
    //        if( ca != null ) {
    //            if( !string.IsNullOrEmpty( ca.DisplayName ) )
    //                propDesc.DisplayName = ca.DisplayName;

    //        }
    //        _context.Cache.Add( propDesc );
    //        return propDesc;
    //    }

    //    public ItemDescription GetDescription( object value, PropertyInfo pi ) {
    //        if( pi == null ) {
    //            return GetClassDescription( value );

    //        } else {
    //            return GetPropertyDescription( value, pi );

    //        }
    //        throw new ArgumentException();

    //     }

    //    public List<MemberInfo> GetMembers(object value) {
    //        throw new NotImplementedException();

            
    //    }

    //}

    public abstract class MetadataReader : IMetadataReader {

        protected IContext _context = null;
        public IContext Context { get { return _context; } }

        public MetadataReader(IContext context)
            : base() {
            _context = context;

        }

        public abstract ClassDescription GetClassDescription(object value);

        public abstract MemberDescription GetPropertyDescription(object value, MemberInfo pi);

        public abstract ItemDescription GetDescription(object item, MemberInfo pi);

        public abstract List<MemberInfo> GetMembers(object value);

        public SnapshotData GetSnapshotData(object value, MemberInfo mi) {
            var retval = new SnapshotData();
            UpdateSnapshotData(retval, value, mi);
            return retval;

        }

        public abstract void UpdateSnapshotData(SnapshotData data, object value, MemberInfo mi);
    }

    

}
