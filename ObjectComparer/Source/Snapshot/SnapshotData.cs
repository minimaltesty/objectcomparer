using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SIT.Components.ObjectComparer {

    public class SnapshotData : SnapshotSerializableData {

        /// <summary>
        /// Value which represents this snapshot
        /// </summary>
        protected object _value;

        /// <summary>
        /// Gets or sets the value which represents this snapshot
        /// </summary>
        /// <remarks>
        /// If this is a SnapShot of a business class instance of type <c>Person</c> then the <c>Value</c> holds the reference to the <c>Person</c> object.
        /// </remarks>
        public object Value { get { return _value; } set { _value = value; } }
    }
}
