using System.Collections.Generic;
using System;

namespace SIT.Components.ObjectComparer {

    [Serializable]
    public class MemberDescriptionList : List<MemberDescription> {

        public MemberDescriptionList() :base(){

        }

        public MemberDescriptionList(IEnumerable<MemberDescription> list):this() {
            AddRange(list);

        }

        public void AddRange( IEnumerable<MemberDescription> list ) {
            base.AddRange( list );

        }

    }
}
