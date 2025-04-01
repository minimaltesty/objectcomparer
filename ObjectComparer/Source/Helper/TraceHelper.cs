using System.Diagnostics;

namespace SIT.Components.ObjectComparer {
    
    public class TraceHelper {

        private TraceSource _traceSource = null;
        private int _indentLevel = 0;
        public TraceSource TraceSource { get { return _traceSource; } }

        public TraceHelper( TraceSource traceSource ) {
            _traceSource = traceSource;

        }

        [Conditional( "DEBUG" )]
        public void Trace( TraceEventType eventType, string message ) {
            Trace( 2, eventType, message, null );

        }

        [Conditional( "DEBUG" )]
        public void Trace( TraceEventType eventType, string format, params object[] args ) {
            Trace( 2, eventType, format, args );

        }

        [Conditional( "DEBUG" )]
        private void Trace( int stackFramesToSkip, TraceEventType eventType, string format, params object[] args ) {
            var sf = new StackFrame( stackFramesToSkip );
            var m = sf.GetMethod();
            if ( _indentLevel > 2900 )
                Debugger.Break();

            format = string.Format( "".PadLeft(_indentLevel, '\t') + "Method: {0}.{1}: {2}", m.DeclaringType.FullName, m.Name, format );
            _traceSource.TraceEvent( eventType, 0, format, args );

        }

        [Conditional( "DEBUG" )]
        public void Verbose( string format, params object[] args ) {
            Trace( 2, TraceEventType.Verbose, format, args );
        }

        [Conditional( "DEBUG" )]
        public void Enter() {
            _indentLevel++;
            Trace( 2, TraceEventType.Verbose, "Enter" );
        }

        [Conditional( "DEBUG" )]
        public void Enter( string format, params object[] args ) {
            _indentLevel++;
            format = string.Format( "Enter: {0}", format );
            Trace( 2, TraceEventType.Verbose, format, args );
        }

        [Conditional( "DEBUG" )]
        public void Leave() {
            Trace( 2, TraceEventType.Verbose, "Leave" );
            _indentLevel--;
        }

        [Conditional( "DEBUG" )]
        public void Leave( string format, params object[] args ) {
            format = string.Format( "Leave: {0}", format );
            Trace( 2, TraceEventType.Verbose, format, args );
            _indentLevel--;
        }

        [Conditional( "DEBUG" )]
        public void Return() {
            Trace( 2, TraceEventType.Verbose, "Return" );
            _indentLevel--;
        }

        [Conditional( "DEBUG" )]
        public void Return( string format, params object[] args ) {
            format = string.Format( "Return: {0}", format );
            Trace( 2, TraceEventType.Verbose, format, args );
            _indentLevel--;
        }

        [Conditional( "DEBUG" )]
        public void Return( object o ) {
            Trace( 2, TraceEventType.Verbose, "Return: IsNull={0}; Type='{1}'; ToString()='{2}'", 
                o==null, 
                (o==null)?"-":o.GetType().FullName,  
                (o==null)?"-":o.ToString()
                );
            _indentLevel--;
        }


    }
}
