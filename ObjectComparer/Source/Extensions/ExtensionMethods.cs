using System;
using System.Collections.Generic;
using System.Text;

namespace SIT.Components.ObjectComparer {
    public static class  ExtensionMethods {

        public static Snapshot CreateSnapshot(this object o) {
            Snapshot retval = null;
            if (Tools.CheckIsEnumerable(o))
                retval = new EnumerableSnapshot(o);

            else
                retval = new ObjectSnapshot(o);

            return retval;

        }

        public static ChangeSet GetChanges(this object o, object oldData) {
            if (!Tools.CheckTypeEquality(oldData, o))
                throw new ArgumentException("Types are not equal");

            ChangeSet retval = null;
            var ss1 = CreateSnapshot(oldData);
            var ss2 = CreateSnapshot(o);
            CompareItem ci = null;
            if (Tools.CheckIsEnumerable(o))
                ci = new EnumerableCompareItem();

            else
                ci = new ObjectCompareItem();

            ci.Create(ss1, ss2);
            retval = new ChangeSet();
            retval.Create(ci);
            return retval;

        }

        public static ChangeSet GetChanges(this object o, Snapshot oldData) {
            ChangeSet retval = null;
            CompareItem ci = null;
            var ss2 = CreateSnapshot( o );
            if (oldData is EnumerableSnapshot)
                ci = new EnumerableCompareItem();
            else
                ci = new ObjectCompareItem();

            ci.Create(oldData, ss2);
            retval = new ChangeSet();
            retval.Create(ci);
            return retval;
        }

        public static ChangeSet GetChanges(this Snapshot o, Snapshot oldData) {
            ChangeSet retval = null;
            
            return retval;
        }


    }
}
