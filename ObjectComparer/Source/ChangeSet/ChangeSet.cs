using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace SIT.Components.ObjectComparer {

    [Serializable]
    public class ChangeSet {

        //private string _idPropertyValue;
        //public string IdPropertyValue { get { return _idPropertyValue; } set { _idPropertyValue=value; } }

        private string _name;
        public string Name { get { return _name; } set { _name=value; } }

        private string _valueA;
        public string ValueA { get { return _valueA; } set { _valueA=value; } }

        private string _valueB;
        public string ValueB { get { return _valueB; } set { _valueB=value; } }

        private ChangeType _changeType;
        public ChangeType ChangeType { get { return _changeType; } set { _changeType=value; } }

        private List<ChangeSet> _properties;
        public List<ChangeSet> Properties { get { return _properties; } set { _properties=value; } }

        private string _path;
        public string Path { get { return _path; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeSet"/> class.
        /// </summary>
        [DebuggerStepThrough]
        public ChangeSet()
            : base() {
                _properties=new List<ChangeSet>();
        }

        public virtual void Create( CompareItem ci ) {
            //_idPropertyValue=ci.IdPropertyValueA;
            _name=ci.Name;
            _valueA=Convert.ToString( ci.ValueA );
            _valueB=Convert.ToString( ci.ValueB );
            _changeType=ci.ChangeType;
            List<CompareItem> itemsToIterate = null;
            if( ci is ObjectCompareItem )
                itemsToIterate = ( ci as ObjectCompareItem ).Properties;

            if( ci is EnumerableCompareItem )
                itemsToIterate = ( ci as EnumerableCompareItem ).Childs;

            foreach( var item in itemsToIterate ) {
                if( item.ChangeType == ChangeType.Unchanged ) continue;
                var cs = new ChangeSet();
                cs.Create( item );
                _properties.Add( cs );

            }
        }

        public override string ToString() {
            if( string.IsNullOrEmpty( _valueA ) && string.IsNullOrEmpty( _valueB ) )
                return string.Format( "{0}", _name );

            return string.Format( "{0}: ({1}) > ({2})", _name, _valueA, _valueB );
        }

        public List<ChangeSet> Flatten() {
            return InternalFlatten( _name );
        }

        private List<ChangeSet> InternalFlatten( string path ) {
            List<ChangeSet> retval = new List<ChangeSet>();
            if( !( string.IsNullOrEmpty( _valueA ) && string.IsNullOrEmpty( _valueB ) ) ) {
                //Console.WriteLine( path );
                this._path=path;
                retval.Add( this );
            }
            foreach( var item in _properties ) {
                retval.AddRange( item.InternalFlatten( path + "." + item._name ) );
            }
            return retval;
        }

        public string ToXml() {
            var xmlsb = new StringBuilder();
            var ser = new XmlSerializer(this.GetType());
            using (StringWriter writer = new StringWriter(xmlsb)) {
                ser.Serialize(writer, this);
                return writer.ToString();

            }
        }

        public static ChangeSet FromXml(string xmlstr) {
            var ser = new XmlSerializer(typeof(ChangeSet));
            var reader = new StringReader(xmlstr);
            return ser.Deserialize(reader) as ChangeSet;

        }

    }
}
