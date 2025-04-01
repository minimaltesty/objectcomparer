using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace SIT.Components.ObjectComparer {
    public class MetadataReaderReflectComapreAttributes : MetadataReader {

        public MetadataReaderReflectComapreAttributes( IContext context ):base(context) {}

        public override ClassDescription GetClassDescription(object value) {
            throw new NotImplementedException();
        }

        public override MemberDescription GetPropertyDescription(object value, MemberInfo pi) {
            throw new NotImplementedException();
        }

        public override ItemDescription GetDescription(object item, MemberInfo pi) {
            throw new NotImplementedException();
        }

        public override List<MemberInfo> GetMembers(object value) {
            var retval = new List<MemberInfo>();
            if (value == null)
                return retval;

            retval.AddRange(value.GetType().GetProperties(_context.Configuration.GetMemberBindingFlags));
            retval.AddRange(value.GetType().GetFields(_context.Configuration.GetMemberBindingFlags));
            return retval;

        }

        public override void UpdateSnapshotData(SnapshotData data, object value, MemberInfo mi) {
            if (data == null)
                throw new ArgumentNullException("data");

            CompareAttribute ca = null;
            if (mi != null) {
                if (mi is PropertyInfo)
                    data.TypeName = (mi as PropertyInfo).PropertyType.FullName;
                else
                    data.TypeName = (mi as FieldInfo).FieldType.FullName;

                ca = Attribute.GetCustomAttribute(mi, typeof(ComparePropertyAttribute)) as CompareAttribute;
                if (ca != null)
                    data.Name = string.IsNullOrEmpty(ca.DisplayName) ? mi.Name : ca.DisplayName;

                else
                    data.Name = mi.Name;

                if (ca is CompareClassAttribute)
                    data.IdPropertyName = (ca as CompareClassAttribute).IdPropertyName;

            }
            if (value == null) {
                return;
            }

            if (string.IsNullOrEmpty(data.TypeName))
                data.TypeName = value.GetType().FullName;


            if (string.IsNullOrEmpty(data.Name)) {
                
                ca = Tools.GetCompareMetadata(_context, value);
                if (ca != null) {
                    data.Name = string.IsNullOrEmpty(ca.DisplayName) ? value.GetType().Name : ca.DisplayName;
                    if (ca is CompareClassAttribute)
                        data.IdPropertyName = (ca as CompareClassAttribute).IdPropertyName;

                }
            }
            if (string.IsNullOrEmpty(data.IdPropertyName)) {
                ca = Tools.GetCompareMetadata(_context, value);
                if (ca != null)
                    data.IdPropertyName = (ca as CompareClassAttribute).IdPropertyName;

            }
            if (string.IsNullOrEmpty(data.Name))
                data.Name = value.GetType().Name;

            data.Value = value;
            if (value.GetType().IsValueType | value is string)
                return;

            data.Value = null;       
     
        }
    }
}
