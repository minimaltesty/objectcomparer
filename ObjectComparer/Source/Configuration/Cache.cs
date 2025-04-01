using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace SIT.Components.ObjectComparer {

    public interface ICache {


        void Add( ClassDescription desc );
        ClassDescription GetClassDescription( string typeName );

        void Add( MemberDescription desc );
        MemberDescription GetPropertyDescription( string propertyFullName );

        T GetDescription<T>(string name) where T:ItemDescription;

        bool ExistsClassDescription( string name );

        bool ExistsPropertyDescription( string name );

        bool ExistsObject( object o );
        void AddObject( object o );
        
    }

    public class Cache :
        ICache {
        private static Cache _default;
        public static Cache Default {
            get {
                if(_default==null)
                    _default=GetDefaultCache();

                return _default;

            }
        }

        internal static Cache GetDefaultCache() {
            var retval=new Cache();
            return retval;

        }

        public T GetDescription<T>( string name ) where T : ItemDescription {
            if( typeof(T) == typeof(ClassDescription) )
                return GetClassDescription( name ) as T;

            if( typeof(T) == typeof(MemberDescription) )
                return GetPropertyDescription( name ) as T;

            throw new ArgumentException();

        }

        public bool ExistsClassDescription( string name ) {
            return _classDescriptions.ContainsKey( name );
        }

        public bool ExistsPropertyDescription( string name ) {
            return _propertyDescriptions.ContainsKey( name );
        }

        Dictionary<string, ClassDescription> _classDescriptions = new Dictionary<string, ClassDescription>();

        public void Add( ClassDescription desc ) {

            if( _classDescriptions.ContainsKey( desc.FullName ) )
                return;

            _classDescriptions.Add( desc.FullName, desc );
            foreach( var pd in desc.Properties )
                _propertyDescriptions.Add( pd.FullName, pd );
            
        }

        public ClassDescription GetClassDescription( string typeName ) {
            return _classDescriptions[ typeName ];

        }

        Dictionary<string, MemberDescription> _propertyDescriptions = new Dictionary<string, MemberDescription>();

        public void Add( MemberDescription desc ) {

            if( _propertyDescriptions.ContainsKey( desc.FullName ) )
                return;

            _propertyDescriptions.Add( desc.FullName, desc );

            if( !_classDescriptions.ContainsKey( desc.DeclaringClassDescription.FullName ) )
                _classDescriptions.Add( desc.DeclaringClassDescription.FullName, desc.DeclaringClassDescription );

            var propDesc = _classDescriptions[ desc.DeclaringClassDescription.FullName ].Properties.Find( x => string.Equals( x.FullName, desc.FullName ) );
            if( propDesc == null )
                _classDescriptions[ desc.DeclaringClassDescription.FullName ].Properties.Add( desc );

        }

        public MemberDescription GetPropertyDescription( string propertyFullName ) {
            return _propertyDescriptions[ propertyFullName ];

        }

        private System.Collections.ArrayList _objects = new System.Collections.ArrayList();

        public void AddObject( object o ) {
            if ( !_objects.Contains( o ) )
                _objects.Add( o );
        }

        public bool ExistsObject( object o ) {
            return _objects.Contains( o );
        }
            

    }
}
