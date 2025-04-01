using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Collections;

namespace SIT.Components.ObjectComparer {

    /// <summary>
    /// Provides methods and properties to take a defined snapshot of an object.
    /// </summary>
    public abstract partial class Snapshot : SnapshotData {

        /// <summary>
        /// Creates an empty <c>Snapshot</c> object
        /// </summary>
        /// <returns>A <c>Snapshot</c> instance without data</returns>
        public Snapshot CreateEmpty() {
            return CreateEmpty( null );
        }

        /// <summary>
        /// Create an empty <c>Snapshot</c> object with <c>TypeName</c> property set
        /// </summary>
        /// <param name="typeName">The type name to set</param>
        /// <returns>A <c>Snapshot</c> instance without data but <c>TypeName</c> property</returns>
        public Snapshot CreateEmpty( string typeName ) {
            var retval=Activator.CreateInstance( this.GetType() ) as Snapshot;
            if( !string.IsNullOrEmpty( typeName ) )
                retval.TypeName=typeName;
            else
                retval.TypeName=_typeName;
            return retval;

        }

        /// <summary>
        /// The value of the property of the snapshotted object which which is an (unique) identifier
        /// </summary>
        /// <example>
        /// The following example shows how objects in a list are found which has to be compared.
        /// <code source="..\Documentation\Examples\Example_IdPropertyName\Program.cs" lang="cs"/>
        /// </example>
        /// <remarks>
        /// This identifier (id) is used to find same/compareable objects in lists of snapshots.
        /// </remarks>
        protected object _idPropertyValue;

        /// <summary>
        /// Gets or sets value of the property of the snapshotted object which which is an (unique) identifier
        /// </summary>
        /// <value>Gets or sets the data member _idPropertyValue</value>
        /// <example>
        /// The following example shows how objects in a list are found which has to be compared.
        /// <code source="..\Documentation\Examples\Example_IdPropertyName\Program.cs" lang="cs"/>
        /// </example>
        /// <remarks>
        /// This identifier (id) is used to find same/compareable objects in lists of snapshots.
        /// </remarks>
        public object IdPropertyValue { get { return _idPropertyValue; } set { _idPropertyValue=value; } }

        /// <summary>
        /// Reference to a parent SnapShot if one exiss
        /// </summary>
        protected Snapshot _parent;
        
        /// <summary>
        /// Gets the parent.
        /// </summary>
        [XmlIgnore]
        public Snapshot Parent { get { return _parent; } internal set { _parent = value; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Snapshot"/> class.
        /// </summary>
        public Snapshot() : base() {
            _name = "";
        }

        /// <summary>
        /// The context used for generating this snap shot
        /// </summary>
        private Context _context = null;

        /// <summary>
        /// Gets or sets the context object used for the generation of this snap shot
        /// </summary>
        public Context Context { get { return _context; } set { _context = value; } }

        /// <summary>
        /// Fills the snap shot based on the given data <paramref name="value"/>
        /// </summary>
        /// <param name="value"></param>
        public void Create(object value) { this.Create(value, null, null); }

        /// <summary>
        /// Fills the snap shot based on the given data <paramref name="value"/>
        /// with respect to the given context <paramref name="context"/>
        /// </summary>
        /// <param name="value">
        /// An object from which the snap shot should be created
        /// value can be null
        /// </param>
        /// <param name="context">
        /// The context used to create the snap shot
        /// value can be null
        /// </param>
        public void Create(object value, Context context) { this.Create(value, null, context); }

        /// <summary>
        /// Fills the snap shot based on the given data <paramref name="value"/>
        /// and/or <paramref name="pi"/> with respect to the given context <paramref name="context"/>
        /// </summary>
        /// <param name="value">
        /// An object from which the snap shot should be created
        /// value can be null
        /// </param>
        /// <param name="pi">
        /// The member info of a class which gets/sets/returns the given object <paramref name="value"/>
        /// value can be null
        /// </param>
        /// <param name="context">
        /// The context used to create the snap shot
        /// value can be null
        /// </param>
        internal void Create( object value, MemberInfo pi, Context context ) {
            _context = context;
            if (_context == null)
                _context = Context.GetDefaultContext();
            Create( _context, value, pi );

        }

        /// <summary>
        /// Fills the snap shot based on the given data <paramref name="value"/>
        /// and/or <paramref name="pi"/> with respect to the given context <paramref name="context"/>
        /// </summary>
        /// <remarks>
        /// The parameter <paramref name="stopRecursion"/> is used to indicate if searching for child properties should be executed.
        /// </remarks>
        /// <param name="context">
        /// The context used to create the snap shot
        /// value can be null
        /// </param>
        /// <param name="value">
        /// An object from which the snap shot should be created
        /// value can be null
        /// </param>
        /// <param name="mi">
        /// The member info of a class which gets/sets/returns the given object <paramref name="value"/>
        /// value can be null
        /// </param>
        /// <param name="stopRecursion"></param>
        internal virtual void Create( Context context, object value, MemberInfo mi, bool stopRecursion = false ) {
            _context = context;
            _context.MetadataReader.UpdateSnapshotData(this, value, mi);

        }

        /// <summary>
        /// Takes two snap shots of one object and compares the both values
        /// of the property which is defined as IdProperty
        /// </summary>
        /// <param name="a">Snap shot of an object <c>a</c> representing state <c>s0</c></param>
        /// <param name="b">Snap shot of an object <c>a</c> representing state <c>s1</c></param>
        /// <returns>
        /// Returns -1, 0, 1 for value <paramref name="a"/> of the property holding the id being 
        /// less than, equal to, or greater than that of value <paramref name="b"/>, respectively.
        /// </returns>
        public static int CompareByIdPropertyValue( Snapshot a, Snapshot b ) {
            if( a == null && b == null )
                return 0;

            if( a == null )
                return -1;

            if( b == null )
                return 1;

            if( a.IdPropertyValue == null && b.IdPropertyValue == null )
                return 0;

            if( a.IdPropertyValue == null )
                return -1;

            if( b.IdPropertyValue == null )
                return 1;

            var p1 = a.IdPropertyValue as IComparable;
            var p2 = b.IdPropertyValue as IComparable;

            if( p1 == null || p2 == null )
                throw new ArgumentException();

            return p1.CompareTo( p2 );

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int CompareByValue( Snapshot a, Snapshot b ) {
            if( a==null && b==null )
                return 0;

            if( a==null )
                return -1;

            if( b==null )
                return 1;

            if( a.Value == null && b.Value == null )
                return 0;

            if( a.Value==null )
                return -1;

            if( b.Value==null )
                return 1;

            var v1 = a.Value as IComparable;
            var v2 = b.Value as IComparable;

            if ( v1 == null || v2 == null ) {
                Console.WriteLine( "??? CHECK !!!" );
                return 0;

            }
            return v1.CompareTo( v2 );

        }

        public object CreateObject() {
            var t = Type.GetType(_typeName);
            var retval = Activator.CreateInstance( t );
            return retval;

        }


    }
}
