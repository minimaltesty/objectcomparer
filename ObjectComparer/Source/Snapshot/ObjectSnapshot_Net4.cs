using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace SIT.Components.ObjectComparer {
    public partial class ObjectSnapshot {

        public override Expression CreateExpressionTree() {

            var valueType = this.Value.GetType();
            var delegateArgs = new Type[]{ valueType,valueType,typeof(int) };
            var delegateTypeTemp = typeof(Func<,,>);
            var delegateType = delegateTypeTemp.MakeGenericType(delegateArgs);
            //var del = Activator.CreateInstance(delegateType);

            var returnTarget = Expression.Label(typeof(int));


            if (this.Properties.Count == 0) {
                if (this.Value is ValueType) {
                    var retval = Expression.Lambda(delegateType,
                        Expression.IfThenElse(
                            Expression.LessThan(Expression.Parameter(valueType, "a"), Expression.Parameter(valueType, "b")),
                            Expression.Return(returnTarget, Expression.Constant(-1)),
                            Expression.IfThenElse(
                                Expression.Equal(Expression.Parameter(valueType, "a"), Expression.Parameter(valueType, "b")),
                                Expression.Return(returnTarget, Expression.Constant(0)),
                                Expression.Return(returnTarget, Expression.Constant(1))
                            )
                            ),
                            
                            );
                    retval.Body.
                }
            } else {

            }
            return base.CreateExpressionTree();
        }
    }
}
