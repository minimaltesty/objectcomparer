
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace SIT.Components.ObjectComparer {

    public class EnumerableSnapshot : ObjectSnapshot, IEnumerable<Snapshot>  {

        private static TraceHelper _trace = null;
        private TraceHelper Trace {
            get {
                if ( _trace == null )
                    _trace = new TraceHelper( new TraceSource( "SIT.ObjectComparer" ) );
                return _trace;
            }
        }

        protected List<Snapshot> _childs;
        public List<Snapshot> Childs { get { return _childs; } set { _childs=value; } }

        public EnumerableSnapshot() : base() {
            _childs=new List<Snapshot>();

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableSnapshot"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        [DebuggerStepThrough]
        public EnumerableSnapshot(object value)
            : this() {
            base.Create(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableSnapshot"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="context">Context</param>
        [DebuggerStepThrough]
        public EnumerableSnapshot(object value, Context context)
            : this() {
            base.Create(value, context);
        }

        internal override void Create( Context context, object value, MemberInfo mi, bool stopRecursion = false ) {
            this.Trace.Enter( "value={0}; mi.Name='{1}'", (value == null) ? "(null)" : value.ToString(), (mi == null) ? "(null)" : mi.Name );
            base.Create( context, value, mi );
            if ( value == null ) {
                this.Trace.Leave();
                return;

            }
            if ( stopRecursion ) {
                this.Trace.Leave();
                return;

            }
            if ( !(value is IEnumerable || value is string) )
                throw new ArgumentException( "value is not of type IEnumerable" );

            IEnumerator enumerator =null;
            if( value is IEnumerable )
                enumerator = ( value as IEnumerable ).GetEnumerator();

            if ( enumerator == null ) {
                this.Trace.Leave();
                return;

            }
            while( enumerator.MoveNext() ) {
                Snapshot child = null;
                if ( Tools.CheckIsEnumerable( enumerator.Current ) )
                    child = new EnumerableSnapshot();

                else
                    child = new ObjectSnapshot();                

                child.Create( context, enumerator.Current, null );
                child.Parent=this;
                _childs.Add( child );

            }
            this.Trace.Leave();

        }

        #region IEnumerable<Snapshot> Members

        public IEnumerator<Snapshot> GetEnumerator() {
            return _childs.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator() {
            return _childs.GetEnumerator();
        }

        #endregion
    }
}
