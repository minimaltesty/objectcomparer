using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace SIT.Components.ObjectComparer {
    public abstract partial class Snapshot {

        public virtual Expression CreateExpressionTree() {
            throw new NotImplementedException();
        }


    }
}
