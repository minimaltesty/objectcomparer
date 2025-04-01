using System;
using System.Collections.Generic;
using System.Text;

namespace System.Runtime.CompilerServices {
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ExtensionAttribute : Attribute {
    }

    //public class Tuple<T1, T2> {

    //    public Tuple(T1 item1, T2 item2) {
    //        _item1 = item1;
    //        _item2 = item2;
    //    }

    //    private T1 _item1;
    //    public T1 Item1 { get { return _item1; } }

    //    private T2 _item2;
    //    public T2 Item2 { get { return _item2; } }


    //}

    //public class Tuple<T1, T2, T3> : Tuple<T1,T2> {

    //    public Tuple(T1 item1, T2 item2, T3 item3) :base(item1, item2) {
    //        _item3 = item3;
    //    }

    //    private T3 _item3;
    //    public T3 Item3 { get { return _item3; } }



    //}

    //public class Tuple<T1, T2, T3, T4> : Tuple<T1, T2, T3> {

    //    public Tuple(T1 item1, T2 item2, T3 item3, T4 item4)
    //        : base(item1, item2, item3) {
    //        _item4 = item4;
    //    }

    //    private T4 _item4;
    //    public T4 Item4 { get { return _item4; } }



    //}

}
