using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SIT.Components.ObjectComparer {
    /// <summary>
    /// Represents an compare item of a not enumerable object for creating a change set
    /// </summary>
    public class ObjectCompareItem : CompareItem {

        /// <summary>
        /// Holds trace helper
        /// </summary>
        private static TraceHelper _trace = null;
        /// <summary>
        /// Gets Trace helper singleton
        /// </summary>
        private TraceHelper Trace {
            get {
                if ( _trace == null )
                    _trace = new TraceHelper( new TraceSource( "SIT.ObjectComparer" ) );
                return _trace;
            }
        }

        /// <summary>
        /// Holds a list of properties of the subjected object type
        /// </summary>
        protected List<CompareItem> _properties;
        /// <summary>
        /// Gets or sets the list of properties of the subjected object type
        /// </summary>
        public List<CompareItem> Properties { get { return _properties; } internal set { _properties = value; } }
        /// <summary>
        /// Default constructor
        /// </summary>
        public ObjectCompareItem()
            : base() {
                _properties=new List<CompareItem>();
        }
        /// <summary>
        /// Fills the content of the compare item
        /// </summary>
        /// <param name="a">Snap shot A</param>
        /// <param name="b">Snap shot B</param>
        /// <returns>Return the type of change of the given snap shots</returns>
        public override ChangeType Create( Snapshot a, Snapshot b ) {
            var retval = base.Create( a, b );
            var sa = a as ObjectSnapshot;
            var sb = b as ObjectSnapshot;
            var enum1 = sa.Properties.GetEnumerator();
            var enum2 = sb.Properties.GetEnumerator();
            while( enum1.MoveNext() | enum2.MoveNext() ) {
                CompareItem ci = null;
                if( enum1.Current is EnumerableSnapshot ) {
                    ci = new EnumerableCompareItem();

                } else {
                    ci = new ObjectCompareItem();

                }
                var p1 = ( enum1.Current == null )?enum2.Current.CreateEmpty():enum1.Current;
                var p2 = ( enum2.Current == null )?enum1.Current.CreateEmpty():enum2.Current;

                var childRetval = ci.Create( p1, p2 );
                if( retval!= ChangeType.Changed )
                    retval=childRetval;
                _properties.Add( ci );

            }
            _changeType=retval;
            return retval;

        }

        /// <summary>
        /// Returns a string representing the changes between the origin snap shots
        /// </summary>
        /// <returns>A string representing the changes between the origin snap shots</returns>
        public override string ToString() {
            string retval=string.Empty;
            switch( _changeType ) {
                case ChangeType.Unchanged:
                    retval = string.Format( "={0}", Name );
                    break;

                case ChangeType.Changed:
                    retval = string.Format( "~{0}", Name );
                    break;

                case ChangeType.Added:
                    retval = string.Format( "+{0}", Name );
                    break;

                case ChangeType.Removed:
                    retval = string.Format( "-{0}", Name );
                    break;

            }
            if( _properties != null )
                if( _properties.Count != 0 )
                    return retval;

            switch(_changeType){
                case ChangeType.Unchanged:
                    retval = string.Format( retval + ": {0}", Convert.ToString( ValueA ) );
                    break;

                case ChangeType.Changed:
                    retval = string.Format( retval + ": ({0}) > ({1})", Convert.ToString( ValueA ), Convert.ToString( ValueB ) );
                    break;

                case ChangeType.Added:
                    retval = string.Format( retval + ": ({0})", Convert.ToString( ValueB ) );
                    break;

                case ChangeType.Removed:
                    retval = string.Format( retval + ": ({0})", Convert.ToString( ValueA ) );
                    break;

            }
            return retval;

        }

    }
}
