using System;
using System.Collections.Generic;
using System.Text;

namespace SIT.Components.ObjectComparer {
    public class AuditTrailEntry {

        private DateTime _date;

        public DateTime Date {
            get { return _date; }
            set { _date = value; }
        }

        private ChangeType _changeType;

        public ChangeType ChangeType {
            get { return _changeType; }
            set { _changeType = value; }
        }

        private string _typeName;

        public string TypeName {
            get { return _typeName; }
            set { _typeName = value; }
        }

        private string _typeDisplayName;

        public string TypeDisplayName {
            get { return _typeDisplayName; }
            set { _typeDisplayName = value; }
        }

        private string _propertyPath;

        public string PropertyPath {
            get { return _propertyPath; }
            set { _propertyPath = value; }
        }

        private string _valueA;

        public string ValueA {
            get { return _valueA; }
            set { _valueA = value; }
        }

        private string _valueB;

        public string ValueB {
            get { return _valueB; }
            set { _valueB = value; }
        }


    }
}
