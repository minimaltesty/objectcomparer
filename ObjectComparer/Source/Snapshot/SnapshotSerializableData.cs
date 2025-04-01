using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace SIT.Components.ObjectComparer {

    [Serializable]
    public class SnapshotSerializableData {

        /// <summary>
        /// Type name of the instance from which the <c>SnapShot</c> is taken
        /// </summary>
        protected string _typeName;

        /// <summary>
        /// Gets or sets the type name of the instance from which the <c>SnapShot</c> is taken
        /// </summary>
        public string TypeName { get { return _typeName; } set { _typeName = value; } }

        /// <summary>
        /// Display name from the object
        /// </summary>
        protected string _name;

        /// <summary>
        /// Gets or sets the display name from the object.
        /// <remarks>
        /// Commonly the displayable name is set through the <c>CompareAttributes</c>
        /// </remarks>
        /// </summary>
        public string Name { get { return _name; } set { _name = value; } }

        /// <summary>
        /// The name of the property of the snapshotted object which holds an (unique) identifier.
        /// This identifier (id) is used to find same/compareable objects in lists of snapshots.
        /// </summary>
        /// <example>
        /// The following example shows how objects in a list are found which has to be compared.
        /// <code source="..\Documentation\Examples\Example_IdPropertyName\Program.cs" lang="cs"/>
        /// </example>
        protected string _idPropertyName;

        /// <summary>
        /// Gets or sets the name of the property of the snapshotted object which holds an (unique) identifier.
        /// This identifier (id) is used to find same/compareable objects in lists of snapshots.
        /// </summary>
        /// <value>Gets or sets the data member _idPropertyName</value>
        /// <example>
        /// The following example shows how objects in a list are found which has to be compared.
        /// <code source="..\Documentation\Examples\Example_IdPropertyName\Program.cs" lang="cs"/>
        /// </example>
        public string IdPropertyName { get { return _idPropertyName; } set { _idPropertyName = value; } }

        public string ToXml() {
            var xmlsb = new StringBuilder();
            var ser = new XmlSerializer(typeof(SnapshotSerializableData));
            using (StringWriter writer = new StringWriter(xmlsb)) {
                ser.Serialize(writer, this);
                return writer.ToString();

            }
        }

        public static SnapshotSerializableData FromXml(string xmlstr) {
            var ser = new XmlSerializer(typeof(SnapshotSerializableData));
            var reader = new StringReader(xmlstr);
            return ser.Deserialize(reader) as SnapshotSerializableData;

        }


    }
}
