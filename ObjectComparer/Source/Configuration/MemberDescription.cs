using System;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace SIT.Components.ObjectComparer {

    [Serializable]
    public class MemberDescription :
        ItemDescription
        
    {

        private ClassDescription _declaringClassDescription;
        [XmlIgnore]
        public ClassDescription DeclaringClassDescription { get { return _declaringClassDescription; } set { _declaringClassDescription = value; } }

        private string _name;
        public string Name { get { return _name; } set { _name=value; } }

        private string _typeName;
        public string TypeName { get { return _typeName; } set { _typeName = value; } }

        private bool _typeIsEnumerable;
        public bool TypeIsEnumerable { get { return _typeIsEnumerable; } set { _typeIsEnumerable=value; } }

        private bool _typeIsString;
        public bool TypeIsString { get { return _typeIsString; } set { _typeIsString=value; } }

        private bool _hasIndexParameters;
        public bool HasIndexParameters { get { return _hasIndexParameters; } set { _hasIndexParameters = value; } }

        private MemberInfo _memberInfo;
        [XmlIgnore]
        public MemberInfo MemberInfo { get { return _memberInfo; } set { _memberInfo = value; } }

        public MemberDescription( ClassDescription declaringClassDescription )
            : base() {
                _declaringClassDescription = declaringClassDescription;
        }

        public override string ToString() {
            return string.Format(
                "DisplayName={0}, "
                +"FullName={1}, "
                +"MemberName={2}",
                _displayName,
                _fullName,
                _name
                );
        }



    }
}

