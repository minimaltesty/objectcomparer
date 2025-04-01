using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;


namespace SIT.Components.ObjectComparer {

    public partial class ObjectSnapshot : Snapshot {

        private static TraceHelper _trace = null;
        private TraceHelper Trace{
            get{
                if(_trace==null)
                    _trace = new TraceHelper( new TraceSource( "SIT.ObjectComparer" ) );
                return _trace;
            }
        }

        protected List<Snapshot> _properties;
        public List<Snapshot> Properties { get { return _properties; } internal set { _properties = value; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectSnapshot"/> class.
        /// </summary>
        [DebuggerStepThrough]
        public ObjectSnapshot()
            : base() {
            _properties = new List<Snapshot>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectSnapshot"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        [DebuggerStepThrough]
        public ObjectSnapshot( object value )
            : this() {
            base.Create( value );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectSnapshot"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="context">Context</param>
        [DebuggerStepThrough]
        public ObjectSnapshot(object value, Context context)
            : this() {
                base.Create(value, context);
        }


        internal override void Create( Context context, object value, MemberInfo pi, bool stopRecursion = false ) {
            this.Trace.Enter( "value={0}; pi.Name='{1}'", (value == null) ? "(null)" : value.ToString(), (pi == null) ? "(null)" : pi.Name );
            base.Create( context, value, pi );
            if ( stopRecursion ) {
                this.Trace.Leave();
                return;
            }
            if ( value == null ) {
                this.Trace.Leave();
                return;
            }
            if ( value is string ) {
                this.Trace.Leave();
                return;
            }
            if ( Tools.CheckIsEnumerable( value ) && !(this is EnumerableSnapshot) )
                throw new ArgumentException( "value is of type IEnumerable" );

            var members = context.MetadataReader.GetMembers(value);
            
            this.CreateMembers(context, value, members);
            this.Trace.Leave();

        }

        private void CreateMembers(Context context, object value, List<MemberInfo> members) {
            var action = new Action<MemberInfo>(m => CreateMember(context, value, m));
            //System.Threading.Tasks.Parallel.ForEach(members, m => action(m));
            foreach (MemberInfo currentMemberInfo in members)
                action(currentMemberInfo);
                
        }

        private void CreateMember(Context context, object value, MemberInfo currentMember) {
            if (Tools.CheckIsIndexerProperty(currentMember))
                return;

            if (context.Configuration.CheckIgnoreMember(currentMember))
                return;

            var currentCa = Attribute.GetCustomAttribute(currentMember, typeof(CompareAttribute)) as CompareAttribute;
            Snapshot child = null;
            object currentMemberValue = null;
            try {
                currentMemberValue = Tools.GetMemberValue(currentMember, value);

            } catch (TargetInvocationException targetInvocEx) {
                if (targetInvocEx.InnerException is NotSupportedException)
                    return;

                if (targetInvocEx.InnerException is InvalidOperationException)
                    return;

                if (targetInvocEx.InnerException is NullReferenceException)
                    return;

                throw;

            }
            if ((Tools.CheckIsEnumerable(currentMember) || Tools.CheckIsEnumerable(currentMemberValue)))
                child = new EnumerableSnapshot();
            else
                child = new ObjectSnapshot();

            child.Create(
                    context,
                    currentMemberValue,
                    currentMember,
                    context.Configuration.CheckStopRecursion(context, value, value.GetType(), currentMemberValue, currentMember)
                    );
            child.Parent = this;
            _properties.Add(child);
            if (string.Equals(_idPropertyName, currentMember.Name, StringComparison.InvariantCultureIgnoreCase))
                _idPropertyValue = child.Value;
        }

        public override string ToString() {
            if( _properties != null )
                if( _properties.Count != 0 )
                    if( _idPropertyValue != null )
                        return Name + ": " + Convert.ToString( _idPropertyValue );
                    else
                        return Name;

            if (_idPropertyValue != null)
                return Name + ": " + Convert.ToString(_idPropertyValue);
            else
                if (Tools.CheckIsEnumerable(this))
                    return Name;
                else
                    return Name + ": " + Convert.ToString(Value);

        }

    }
}
