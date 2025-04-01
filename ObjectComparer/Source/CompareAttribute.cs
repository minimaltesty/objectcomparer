using System;

namespace SIT.Components.ObjectComparer {

    /// <summary>
    /// Defines the base (must be derived) for attributes analyzed by the ObjectComparer.
    /// </summary>
    public abstract class CompareAttribute : Attribute {

        /// <summary>
        /// Constructor
        /// </summary>
        public CompareAttribute() : base() { }

        /// <summary>
        /// Constructor setting the DisplayName property
        /// </summary>
        /// <param name="displayName">The displayname to set</param>
        public CompareAttribute( string displayName )
            : this() {
            _displayName = displayName;

        }

        /// <summary>
        /// Displayname
        /// </summary>
        protected string _displayName;

        /// <summary>
        /// Gets the DisplayName
        /// </summary>
        public string DisplayName { get { return _displayName; } }

    }

    /// <summary>
    /// Attribute used to tag a type (class) to be processed by ObjectComparer
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CompareClassAttribute : CompareAttribute {

        private string _idPropertyName;
        /// <summary>
        /// Gets or sets the name of the property which makes the runtime object of the described type uniqe.
        /// </summary>
        /// <example>
        /// The following example shows how objects in a list are found which has to be compared.
        /// <code source="..\Documentation\Examples\Example_IdPropertyName\Program.cs" lang="cs"/>
        /// </example>
        /// <remarks>
        /// This identifier (id) is used to find same/compareable objects in lists of snapshots.
        /// </remarks>
        public string IdPropertyName { get { return _idPropertyName; } set { _idPropertyName=value; } }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompareClassAttribute() : base() {}

        /// <summary>
        /// Creates an instance of <see cref="SIT.Components.ObjectComparer.CompareClassAttribute"/>
        /// </summary>
        /// <param name="displayName">The display name which should be used</param>
        public CompareClassAttribute( string displayName ) : base( displayName ) { }

        /// <summary>
        /// Creates an instance of <see cref="SIT.Components.ObjectComparer.CompareClassAttribute"/>
        /// </summary>
        /// <param name="displayName">The display name which should be used</param>
        /// <param name="idPropertyNamedisplayName">
        /// The name of the property which holds the unique identifier for objects of this type
        /// <example>
        /// The following example shows how objects in a list are found which has to be compared.
        /// <code source="..\Documentation\Examples\Example_IdPropertyName\Program.cs" lang="cs"/>
        /// </example>
        /// </param>
        public CompareClassAttribute( string displayName, string idPropertyNamedisplayName )
            : this(displayName) {
                _idPropertyName=idPropertyNamedisplayName;
        }

    }


    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ComparePropertyAttribute :CompareAttribute {
        public ComparePropertyAttribute() : base() { }
        public ComparePropertyAttribute( string displayName ) : base( displayName ) { }

    }

}