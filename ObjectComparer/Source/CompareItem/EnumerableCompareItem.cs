using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SIT.Components.ObjectComparer {

    public class EnumerableCompareItem : ObjectCompareItem {

        private static TraceHelper _trace = null;
        private TraceHelper Trace {
            get {
                if ( _trace == null )
                    _trace = new TraceHelper( new TraceSource( "SIT.ObjectComparer" ) );
                return _trace;
            }
        }


        private List<CompareItem> _childs;
        
        /// <summary>
        /// Gets or sets the childs.
        /// </summary>
        /// <value>
        /// The childs.
        /// </value>
        public List<CompareItem> Childs { get { return _childs; } set { _childs=value; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableCompareItem"/> class.
        /// </summary>
        public EnumerableCompareItem()
            : base() {
                this.Trace.Enter();
                _childs=new List<CompareItem>();
                this.Trace.Leave();
        }
        /// <summary>
        /// Fills the content of the compare item
        /// </summary>
        /// <param name="a">Snap shot A</param>
        /// <param name="b">Snap shot B</param>
        /// <returns>Return the type of change of the given snap shots</returns>
        public override ChangeType Create( Snapshot a, Snapshot b ) {
            this.Trace.Enter();
            var retval = base.Create( a, b );
            var sa = a as EnumerableSnapshot;
            var sb = b as EnumerableSnapshot;
            
            /* Sort the childs by its id property value */
            sa.Childs.Sort( Snapshot.CompareByIdPropertyValue );
            sb.Childs.Sort( Snapshot.CompareByIdPropertyValue );

            var aEnum = sa.Childs.GetEnumerator();
            var bEnum = sb.Childs.GetEnumerator();
            aEnum.MoveNext();
            bEnum.MoveNext();
            var aGetNextItem = false;
            var bGetNextItem = false;
            while( aEnum.Current!=null || bEnum.Current!=null ) {
                int compRes = Snapshot.CompareByIdPropertyValue( aEnum.Current, bEnum.Current );
                var child = CreateFromSnapshotType( aEnum.Current, bEnum.Current );
                var childRetval = ObjectComparer.ChangeType.Unchanged;
                switch( compRes ) {
                    case 0:
                        /* a equals b */
                        this.Trace.Verbose( "a=b|{0}={1}", aEnum.Current, bEnum.Current );
                        childRetval = child.Create( aEnum.Current, bEnum.Current );
                        if( retval != ChangeType.Changed )
                            retval=childRetval;

                        aGetNextItem = true;
                        bGetNextItem = true;
                        break;

                    case -1:
                        /* a is smaller than b */
                        this.Trace.Verbose( "a<b|{0}={1}", (aEnum.Current == null) ? "(null)" : aEnum.Current.ToString(), (bEnum.Current == null) ? "(null)" : bEnum.Current.ToString() );
                        if( aEnum.Current==null ) {
                            /* The child was added */
                            childRetval = child.Create( bEnum.Current.CreateEmpty(), bEnum.Current ); //TODOH: endless recursion (interesting when adding a pos 
                            child.ChangeType= ChangeType.Added;
                            aGetNextItem = false;
                            bGetNextItem = true;

                        } else {
                            /* The child was removed */
                            childRetval = child.Create( aEnum.Current, aEnum.Current.CreateEmpty() );
                            child.ChangeType= ChangeType.Removed;
                            aGetNextItem = true;
                            bGetNextItem = false;

                        }
                        if( retval!= ChangeType.Changed )
                            retval = childRetval;

                        break;

                    case 1:
                        /* a is bigger than b */
                        this.Trace.Verbose( "a>b|{0}={1}", (aEnum.Current == null) ? "(null)" : aEnum.Current.ToString(), (bEnum.Current == null) ? "(null)" : bEnum.Current.ToString() );
                        if( bEnum.Current==null ) {
                            childRetval = child.Create( aEnum.Current, aEnum.Current.CreateEmpty() ); //TODOH: endless recursion (interesting when removing a pos
                            child.ChangeType= ChangeType.Removed;
                            aGetNextItem = true;
                            bGetNextItem = false;

                        } else {
                            childRetval = child.Create( bEnum.Current.CreateEmpty(), bEnum.Current );
                            child.ChangeType= ChangeType.Added;
                            aGetNextItem = false;
                            bGetNextItem = true;

                        }
                        
                        if( retval!= ChangeType.Changed )
                            retval = childRetval; //ChangeType.Changed;

                        break;

                }
                if ( aGetNextItem ) aEnum.MoveNext();
                if ( bGetNextItem ) bEnum.MoveNext();
                _childs.Add( child );

            }
            _changeType=retval;
            this.Trace.Return( retval );
            return retval;

        }

        private CompareItem CreateFromSnapshotType( Snapshot a, Snapshot b ) {

            if( a==null && b==null )
                throw new ArgumentException();

            var s = a ?? b;

            if( s is ObjectSnapshot )
                return new ObjectCompareItem();

            if( s is EnumerableSnapshot )
                return new EnumerableCompareItem();

            throw new ArgumentException();

        }
    }
}
