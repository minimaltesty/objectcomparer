//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Reflection;

//namespace SIT.Components.ObjectComparer.Source.Helper {
//    public class MemberInspector {

//        public MemberList()
//            : base() {

//        }

//        public MemberList(object obj)
//            : this() {
//            _object = obj;
//        }

//        private object _object;
//        public object Object { get { return _object; } set { _object = value; } }

//        internal List<MemberInfo> GetMembers() {
//            var bf = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
//            return new List<MemberInfo>(_object.GetType().GetMembers(bf));

//        }

//        public IEnumerator<MemberInfo> GetEnumerator() {
            
//        }

//        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
//            return this.GetEnumerator();
//        }
//    }

//    public class MemberIterator : IEnumerator<MemberInfo> {

//        MemberList _parent = null;
//        internal MemberIterator(MemberList parent)
//            : base() {
//                _parent = parent;
//        }

//        List<MemberInfo> _members = null;
//        private void GetMembers() {
//            if (_parent == null)
//                throw NullReferenceException();

//        }


//        MemberInfo _current;
//        public MemberInfo Current {
//            get { throw new NotImplementedException(); }
//        }

//        public void Dispose() {
//            throw new NotImplementedException();
//        }

//        object System.Collections.IEnumerator.Current {
//            get { throw new NotImplementedException(); }
//        }

//        public bool MoveNext() {
//            throw new NotImplementedException();
//        }

//        public void Reset() {
//            throw new NotImplementedException();
//        }
//    }
//}
