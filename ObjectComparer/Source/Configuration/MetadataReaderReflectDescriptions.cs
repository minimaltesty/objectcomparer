using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using System.Collections;

namespace SIT.Components.ObjectComparer {
    public class MetadataReaderReflectDescriptions : MetadataReader {

        public MetadataReaderReflectDescriptions(IContext context) : base(context) { }

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

            var t = value.GetType();
            if (t.IsPrimitive)
                return retval;

            var typeName = t.FullName;
            var classDescription = _context.Configuration.ClassDescriptions.Find(x => string.Equals(x.FullName, typeName));
            if (classDescription == null)
                return retval;
                //throw new ArgumentException(string.Format("Did not found a class description for type '{0}'", typeName));

            classDescription.Properties.ForEach(x => {
                if (x.MemberInfo == null) {
                    var members = t.GetMember(x.FullName, _context.Configuration.GetMemberBindingFlags);
                    x.MemberInfo = members[0];
                }
                retval.Add(x.MemberInfo);

            });
            return retval;

        }

        private ClassDescription FindClassDescription(System.Type type) {
            var retval = _context.Configuration.ClassDescriptions.Find(x => string.Equals(x.FullName, type.FullName));
            if (!_context.Configuration.AutoPopuplateDerived)
                return retval;

            var interfaceTypes = type.GetInterfaces();
            foreach (var cd in _context.Configuration.ClassDescriptions) {
                var ifType = Array.Find(interfaceTypes, x => string.Equals(x.FullName, cd.FullName));
                if (ifType != null) {
                    var derivedCd = DeepCopy.Copy<ClassDescription>(cd);
                    derivedCd.FullName = ifType.FullName;
                    _context.Configuration.ClassDescriptions.Add(derivedCd);
                    retval = derivedCd;
                }
            }
            return retval;

        }

        public override void UpdateSnapshotData(SnapshotData data, object value, MemberInfo mi) {
            if (mi != null) {
                var memberName = mi.Name;
                var declaringTypeName = mi.DeclaringType.FullName;
                //var cd = FindClassDescription(mi.DeclaringType);
                //var md = cd.Properties.Find(x => string.Equals(x.FullName, memberName));
                var md = _context.Configuration.ClassDescriptions.Find(x => string.Equals(x.FullName, declaringTypeName)).Properties.Find(x => string.Equals(x.FullName, memberName));
                data.Name = md.DisplayName;
                data.TypeName = md.FullName;
                data.Value = null;

            } else {
                if (value != null) {
                    var t = value.GetType();
                    var cd = _context.Configuration.ClassDescriptions.Find(x => string.Equals(x.FullName, t.FullName));

                    if (cd == null) {
                        var ifTypes = t.GetInterfaces();
                        foreach (var ifType in ifTypes) {
                            cd = _context.Configuration.ClassDescriptions.Find(x => {
                                if (x.FullName == ifType.FullName)
                                    return true;

                                object convertedValue = null;
                                try {
                                    var destType = System.Type.GetType(x.FullName);
                                    convertedValue = Convert.ChangeType(value, destType);
                                } catch { }
                                if (convertedValue != null)
                                    return true;

                                return false;

                            });
                            if (cd != null)
                                break;
                        }
                        if (t.IsGenericType) {
                            foreach (var ifType in ifTypes) {
                                if (!ifType.IsGenericType)
                                    continue;
                                if (ifType.GetGenericTypeDefinition() != typeof(IEnumerable<>))
                                    continue;

                                var genericArgType = ifType.GetGenericArguments()[0];
                                if (_context.Configuration.ClassDescriptions.Exists(x => x.FullName == genericArgType.FullName))
                                    continue;
                                System.Type typeToAdd = null;
                                typeToAdd = genericArgType.IsGenericType ?
                                    genericArgType.GetGenericTypeDefinition() :
                                    genericArgType;
                                
                                var derivedCd = _context.Configuration.ClassDescriptions.Find(x => x.FullName == typeToAdd.FullName);
                                if (derivedCd == null) {
                                    if (cd.FullName == typeof(IDictionary).FullName && typeToAdd == typeof(KeyValuePair<,>)) {
                                        var tmpDictItemCd = _context.Configuration.ClassDescriptions.Find(x => x.FullName == typeof(DictionaryEntry).FullName);
                                        if (tmpDictItemCd != null) {
                                            derivedCd = new ClassDescription() {
                                                DisplayName = tmpDictItemCd.DisplayName,
                                                FullName = genericArgType.FullName,
                                                IsDerived = true,
                                                IdPropertyName = tmpDictItemCd.IdPropertyName
                                            };
                                            derivedCd.Properties.AddRange(
                                                tmpDictItemCd.Properties.ConvertAll(old=>
                                                        new MemberDescription(derivedCd){
                                                            DisplayName = old.DisplayName,
                                                            FullName=old.FullName,
                                                            HasIndexParameters=old.HasIndexParameters,
                                                            MemberInfo = genericArgType.GetMember(old.MemberInfo.Name)[0],
                                                            Name=old.Name,
                                                            TypeIsEnumerable=old.TypeIsEnumerable,
                                                            TypeIsString=old.TypeIsString,
                                                            TypeName=old.TypeName
                                                        }
                                                    )
                                                );

                                            
                                        }
                                    } else {
                                        Console.WriteLine("Resolve");
                                        //throw new TypeLoadException(string.Format("Cannot find type in config: {0}", t.FullName));

                                    }
                                }
                                if (derivedCd != null)
                                    _context.Configuration.ClassDescriptions.Add(derivedCd);

                            }
                        }
                            
                    }
                    

                    if (cd != null) {
                        data.TypeName = cd.FullName;
                        data.Name = cd.DisplayName;
                        data.IdPropertyName = cd.IdPropertyName;

                    }
                }
            }
            if (value == null)
                return;

            //if (value.GetType().IsValueType | value is string)
            //    return;
            if (value.GetType().IsValueType | value is string)
                data.Value = value;
            

        }
    }
}
