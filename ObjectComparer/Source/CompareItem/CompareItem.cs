using System;
using System.Diagnostics;

namespace SIT.Components.ObjectComparer {

    /// <summary>
    /// Abstract. Holds data of two snap shots as base for creating a change set
    /// </summary>
    public abstract class CompareItem {

        /// <summary>
        /// Trace helper
        /// </summary>
        private static TraceHelper _trace = null;

        /// <summary>
        /// Trace helper singleton
        /// </summary>
        private TraceHelper Trace {
            get {
                if ( _trace == null )
                    _trace = new TraceHelper( new TraceSource( "SIT.ObjectComparer" ) );
                return _trace;
            }
        }

        /// <summary>
        /// Creates an empty <c>CompareItem</c>
        /// </summary>
        /// <returns>An instance of <c>CompareItem</c></returns>
        public CompareItem CreateEmpty() {
            this.Trace.Enter();
            this.Trace.Return();
            return CreateEmpty( null );
            
        }

        /// <summary>
        /// Creates an empty <c>CompareItem</c>
        /// </summary>
        /// <param name="typeName">The value to set for <c>TypeName</c> property
        /// <returns>An instance of <c>CompareItem</c></returns>
        public CompareItem CreateEmpty( string typeName ) {
            this.Trace.Enter( "typeName='{0}'", typeName );
            var retval=Activator.CreateInstance( this.GetType() ) as CompareItem;
            if( !string.IsNullOrEmpty( typeName ) )
                retval.TypeName=typeName;

            else
                retval.TypeName=_typeName;

            this.Trace.Return( retval );
            return retval;

        }

        /// <summary>
        /// Holds the value for type ofg change
        /// </summary>
        protected ChangeType _changeType= ChangeType.Unchanged;
        /// <summary>
        /// Gets or sets the type of change
        /// </summary>
        public ChangeType ChangeType { get { return _changeType; } set { _changeType=value; } }

        /// <summary>
        /// Holds the type name of the objects in <c>ValueA</c> and <c>ValueB</c>
        /// </summary>
        protected string _typeName;
        /// <summary>
        /// Gets or sets the type name of the objects in <c>ValueA</c> and <c>ValueB</c>
        /// </summary>
        public string TypeName { get { return _typeName; } set { _typeName=value; } }

        /// <summary>
        /// Holds the display name of the objects in <c>ValueA</c> and <c>ValueB</c>
        /// </summary>
        protected string _name;
        /// <summary>
        /// Gets or sets the display name of the objects in <c>ValueA</c> and <c>ValueB</c>
        /// </summary>
        public string Name { get { return _name; } set { _name = value; } }

        /// <summary>
        /// Holds object A
        /// </summary>
        protected object _valueA;
        /// <summary>
        /// Gets or sets object A
        /// </summary>
        public object ValueA { get { return _valueA; } set { _valueA = value; } }

        /// <summary>
        /// Holds object B
        /// </summary>
        protected object _valueB;
        /// <summary>
        /// Gets or sets object B
        /// </summary>
        public object ValueB { get { return _valueB; } set { _valueB = value; } }

        /// <summary>
        /// Holds the name of the property which is used for list comparison of <c>ValueA</c> and <c>ValueB</c>
        /// </summary>
        protected string _idPropertyName;
        /// <summary>
        /// Gets or sets the name of the property which is used for list comparison of <c>ValueA</c> and <c>ValueB</c>
        /// </summary>
        public string IdPropertyName { get { return _idPropertyName; } set { _idPropertyName = value; } }
        /// <summary>
        /// Holds the value of the property with name <c>_idPropertyName</c> of object A
        /// </summary>
        protected object _idPropertyValueA;
        /// <summary>
        /// Gets or sets the value the property with name <c>IdPropertyName</c> of object A
        /// </summary>
        public object IdPropertyValueA { get { return _idPropertyValueA; } set { _idPropertyValueA=value; } }
        /// <summary>
        /// Holds the value of the property with name <c>_idPropertyName</c> of object B
        /// </summary>
        protected object _idPropertyValueB;
        /// <summary>
        /// Gets or sets the value the property with name <c>IdPropertyName</c> of object B
        /// </summary>
        public object IdPropertyValueB { get { return _idPropertyValueB; } set { _idPropertyValueB=value; } }
        /// <summary>
        /// Holds reference to a possible parent <c>CompareItem</c>
        /// </summary>
        protected CompareItem _parent;
        /// <summary>
        /// Gets or sets the reference to a possible parent <c>CompareItem</c>
        /// </summary>
        public CompareItem Parent { get { return _parent; } internal set { _parent = value; } }
        /// <summary>
        /// Default constructor
        /// </summary>
        public CompareItem()
            : base() {
        }

        /// <summary>
        /// Used in derived class for creating/extracting base infos of given snap shots
        /// </summary>
        /// <param name="a">Snap shot A</param>
        /// <param name="b">Snap shot B</param>
        /// <returns>The type of change</returns>
        public virtual ChangeType Create( Snapshot a, Snapshot b ) {
            if ( !string.Equals( a.TypeName, b.TypeName ) )
                return ObjectComparer.ChangeType.Changed;

            _typeName = a.TypeName;
            _name = a.Name;
            if ( string.IsNullOrEmpty( a.Name ) && !string.IsNullOrEmpty( b.Name ) )
                _name = b.Name;

            _valueA = a.Value;
            _valueB = b.Value;
            this.Trace.Verbose( "_valueA=={0}; _valueB=={1}", _valueA, _valueB );
            if ( !string.Equals( a.IdPropertyName, b.IdPropertyName ) ) {
                if ( string.IsNullOrEmpty( a.IdPropertyName ) )
                    _idPropertyName = b.IdPropertyName;

                else
                    _idPropertyName = a.IdPropertyName;

            } else
                _idPropertyName = a.IdPropertyName;

            _idPropertyValueA = a.IdPropertyValue;
            _idPropertyValueB = b.IdPropertyValue;
            
            return Snapshot.CompareByValue( a, b ) == 0 
                ? ChangeType.Unchanged
                : ChangeType.Changed;

        }
    }
}
