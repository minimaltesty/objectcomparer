using System;
using System.Collections.Generic;
using System.Text;

namespace SIT.Components.ObjectComparer {

    /// <summary>
    /// Base class used to hold meta data for types, properties and fields 
    /// to serialize/deserialize it
    /// </summary>
    [Serializable]
    public abstract class ItemDescription {

        protected string _fullName;
        /// <summary>
        /// Gets or sets the name or full name of the type, property or field which is described
        /// </summary>
        public string FullName { get { return _fullName; } set { _fullName=value; } }

        protected string _displayName;
        /// <summary>
        /// Gets or sets the name to display of the type, property or field which is described
        /// </summary>
        public string DisplayName { get { return _displayName; } set { _displayName=value; } }

    }
}
