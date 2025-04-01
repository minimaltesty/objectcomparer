using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace SIT.Components.ObjectComparer {

    /// <summary>
    /// Delegate for defining function pointer to method that checks if a recursion should stop or not.
    /// </summary>
    /// <param name="context">The context object used</param>
    /// <param name="parentValue">The value of the parent object</param>
    /// <param name="parentType">The type of the parent object</param>
    /// <param name="childValue">The value of the child object belonging to the given parent object</param>
    /// <param name="childPi">The <c>PropertyInfo</c> instance of the child object belonging to the given parent object</param>
    /// <returns><c>true</c>, when recursion should be stoppen, otherwise <c>false</c></returns>
    public delegate bool CheckStopRecursionDelegate(Context context, object parentValue, Type parentType, object childValue, MemberInfo childPi);

    /// <summary>
    /// Represents the method that is used for checking if a member should be ignored
    /// </summary>
    /// <param name="member">Either a string for the members name, a PropertyInfo object or an FieldInfo object</param>
    /// <returns><c>true</c> if member has to be ignored; otherwise <c>false</c></returns>
    public delegate bool CheckIgnoreMemberDelegate(object member);

    /// <summary>
    /// Interface for configuring snaph shot creation
    /// </summary>
    public interface IConfiguration {

        /// <summary>
        /// Gets or sets the delegate for checking about to stop a recursion
        /// </summary>
        CheckStopRecursionDelegate CheckStopRecursionFunc { get; set; }

        /// <summary>
        /// Checks if a recursion should be stopped.
        /// </summary>
        /// <param name="context">The context object used</param>
        /// <param name="parentValue">The value of the parent object</param>
        /// <param name="parentType">The type of the parent object</param>
        /// <param name="childValue">The value of the child object belonging to the given parent object</param>
        /// <param name="childPi">The <c>PropertyInfo</c> instance of the child object belonging to the given parent object</param>
        /// <returns><c>true</c>, when recursion should be stoppen, otherwise <c>false</c></returns>
        /// <remarks>
        /// The check is executed as defined in the delegate <see cref="CheckStopRecursionFunc"/>.
        /// If that property is not set <c>true</c> is returned
        /// </remarks>
        bool CheckStopRecursion(Context context, object parentValue, Type parentType, object childValue, MemberInfo childPi);

        /// <summary>
        /// Gets or sets the delegate for checking about to ignore a class member
        /// </summary>
        CheckIgnoreMemberDelegate CheckIgnoreMemberFunc { get; set; }

        /// <summary>
        /// Checks if a member of a type should be ignored or not.
        /// </summary>
        /// <param name="member">Either a string for the members name, a PropertyInfo object or an FieldInfo object</param>
        /// <returns><c>true</c> if member has to be ignored; otherwise <c>false</c></returns>
        /// <remarks>
        /// The check is executed as defined in the delegate <see cref="CheckIgnoreMemberFunc"/>.
        /// If that property is not set <c>true</c> is returned
        /// </remarks>
        bool CheckIgnoreMember(object member);

        /// <summary>
        /// Gets or sets the attributes used for searching class members
        /// </summary>
        BindingFlags GetMemberBindingFlags { get; set; }

        /// <summary>
        /// Event raised, when property <see cref="MetadataRetrievalOptions"/> is changed.
        /// </summary>
        event EventHandler MetadataRetrievalOptionsChanged;

        /// <summary>
        /// Gets or sets the options for retrieving the meta data of classes (by configured properties or by reflection and use of ComapreAttribute)
        /// </summary>
        MetadataRetrievalOptions MetadataRetrievalOptions { get; set; }

        /// <summary>
        /// Gets or sets a list of class descriptions, describing the types to be regarded by object comparer
        /// </summary>
        ClassDescriptionList ClassDescriptions { get; set; }

        bool AutoPopuplateDerived { get; set; }

    }

    /// <summary>
    /// Class describing how object comparison is performed
    /// </summary>
    [Serializable]
    public class Configuration :
        IConfiguration {

        #region Singleton

        private static object _syncroot = new object();
        private static volatile Configuration _default;
        /// <summary>
        /// Gets the the default <see cref="Configuration"/> instance which
        /// is based on meta data retrieval by CompareAttributes.
        /// </summary>
        /// <value>
        /// The default.
        /// </value>
        public static Configuration Default {
            get {
                if ( _default == null )
                    lock ( _syncroot )
                        _default = GetDefaultConfiguration();

                return _default;

            }
        }

        #endregion

        /// <summary>
        /// Creates a default configuration and returns it
        /// </summary>
        /// <returns>An instance of <c>Configuration</c> class representing a default configuration</returns>
        internal static Configuration GetDefaultConfiguration() {
            var retval = new Configuration();
            retval.CheckStopRecursionFunc = Configuration.DefaultCheckStopRecursion;
            retval.CheckIgnoreMemberFunc = Configuration.DefaultCheckIgnoreMember;
            retval.GetMemberBindingFlags = BindingFlags.Public | BindingFlags.Instance;
            retval.MetadataRetrievalOptions = MetadataRetrievalOptions.ReflectCompareAttributes;
            return retval;

        }

        /// <summary>
        /// Default function used to check if recursion should be stopped
        /// </summary>
        /// <param name="context">The context object used</param>
        /// <param name="parentValue">The value of the parent object</param>
        /// <param name="parentType">The type of the parent object</param>
        /// <param name="childValue">The value of the child object belonging to the given parent object</param>
        /// <param name="childPi">The <c>PropertyInfo</c> instance of the child object belonging to the given parent object</param>
        /// <returns><c>true</c>, when recursion should be stoppen, otherwise <c>false</c></returns>
        public static bool DefaultCheckStopRecursion(Context context, object parentValue, Type parentType, object childValue, MemberInfo childPi) {
            if (childValue != null & !(childValue is ValueType) & !(childValue is string) & context.Cache.ExistsObject(childValue))
                return true;
            context.Cache.AddObject(childValue);

            if (parentType == null) {
                if (parentValue != null) {
                    parentType = parentValue.GetType();
                }
            }
            if (parentType.Name == "DateTime") {
                if (childPi.Name == "Date") return true;
                if (childPi.Name == "Time") return true;

            }
            if (childPi.Name == "Owner")
                Console.Write("X");
            if (parentType.Name == "AccessibleObject" || parentType.GetInterface("Accessibility.IAccessible") != null) {
                //if ( childPi.Name == "Parent" ) return true;
                return true;

            }



            if (parentType.Name == "AccessibilityObject" || parentType.Name == "System.Windows.Forms.AccessibleObject") {
                return true;
            }
            if (childValue != null)
                if (childPi.Name == "Parent" && childValue.GetType().Name == "AccessibleObject")
                    return true;
            return false;

        }

        /// <summary>
        /// Static list of strings containing names of properties which should not be regarded by object comparer
        /// </summary>
        private static string[] _propertyNamesToIgnore = new string[]{
            "SyncRoot",
            "BindingSource",
            "AccessibleObject",
            "BindingContext",
            "Bindings",
            "DataBindings"
        };

        /// <summary>
        /// Default function used to check if a property or field should be ignored by object comparer
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool DefaultCheckIgnoreMember(object o) {
            if (o == null)
                throw new NullReferenceException();

            PropertyInfo pi = null;
            string propertyName = string.Empty;
            if (o is PropertyInfo) {
                pi = o as PropertyInfo;
                propertyName = pi.Name;

            } else if (o is string) {
                propertyName = o as string;

            } else if (o is FieldInfo) {
                var fi = o as FieldInfo;
                propertyName = fi.Name;

            } else {
                throw new ArgumentException("Type must be either string, PropertyInfo or FieldInfo", "property");

            }
            if (!string.IsNullOrEmpty(propertyName)) {
                if (Array.Exists(_propertyNamesToIgnore, x => x.Equals(propertyName)))
                    return true;

            }
            return false;

        }

        private TraceHelper _traceHelper = new TraceHelper(new TraceSource("SIT.ObjectComparer"));

        /// <summary>
        /// Delegate for checking about to stop a recursion
        /// </summary>
        private CheckStopRecursionDelegate _checkStopRecursionFunc = null;
        /// <summary>
        /// Gets or sets the delegate for checking about to stop a recursion
        /// </summary>
        [XmlIgnore]
        public CheckStopRecursionDelegate CheckStopRecursionFunc { get { return _checkStopRecursionFunc; } set { _checkStopRecursionFunc = value; } }

        /// <summary>
        /// Checks if a recursion should be stopped.
        /// </summary>
        /// <param name="context">The context object used</param>
        /// <param name="parentValue">The value of the parent object</param>
        /// <param name="parentType">The type of the parent object</param>
        /// <param name="childValue">The value of the child object belonging to the given parent object</param>
        /// <param name="childPi">The <c>PropertyInfo</c> instance of the child object belonging to the given parent object</param>
        /// <returns>
        ///   <c>true</c>, when recursion should be stoppen, otherwise <c>false</c>
        /// </returns>
        /// <remarks>
        /// The check is executed as defined in the delegate 
        /// <see cref="CheckStopRecursionFunc" />.
        /// If that property is not set 
        /// <c>true</c> is returned
        /// </remarks>
        public bool CheckStopRecursion(Context context, object parentValue, Type parentType, object childValue, MemberInfo childPi) {
            if (_checkStopRecursionFunc == null)
                return false;

            return _checkStopRecursionFunc(context, parentValue, parentType, childValue, childPi);

        }

        /// <summary>
        /// Delegate for checking about to ignore a class member
        /// </summary>
        private CheckIgnoreMemberDelegate _checkIgnoreMemberFunc = null;
        /// <summary>
        /// Gets or sets the delegate for checking about to ignore a class member
        /// </summary>
        [XmlIgnore]
        public CheckIgnoreMemberDelegate CheckIgnoreMemberFunc { get { return _checkIgnoreMemberFunc; } set { _checkIgnoreMemberFunc = value; } }

        /// <summary>
        /// Checks if a member of a type should be ignored or not.
        /// </summary>
        /// <param name="member">Either a string for the members name, a PropertyInfo object or an FieldInfo object</param>
        /// <returns>
        ///   <c>true</c> if member has to be ignored; otherwise <c>false</c>
        /// </returns>
        /// <remarks>
        /// The check is executed as defined in the delegate 
        /// <see cref="CheckIgnoreMemberFunc" />.
        /// If that property is not set 
        /// <c>true</c> is returned
        /// </remarks>
        public bool CheckIgnoreMember(object member) {
            if (_checkIgnoreMemberFunc == null)
                return false;

            return _checkIgnoreMemberFunc(member);

        }

        /// <summary>
        /// the attributes used for searching class members
        /// </summary>
        private BindingFlags _getPropertiesBindingFlags = BindingFlags.Instance | BindingFlags.Public;
        /// <summary>
        /// Gets or sets the attributes used for searching class members
        /// </summary>
        public BindingFlags GetMemberBindingFlags { get { return _getPropertiesBindingFlags; } set { _getPropertiesBindingFlags = value; } }


        /// <summary>
        /// The options for retrieving the meta data of classes (by configured properties or by reflection and use of ComapreAttribute)
        /// </summary>
        private MetadataRetrievalOptions _metadataRetrievalOptions = MetadataRetrievalOptions.ReflectCompareAttributes;
        /// <summary>
        /// Gets or sets the options for retrieving the meta data of classes (by configured properties or by reflection and use of ComapreAttribute)
        /// </summary>
        public MetadataRetrievalOptions MetadataRetrievalOptions { 
            get { return _metadataRetrievalOptions; } 
            set { 
                _metadataRetrievalOptions = value;
                OnMetadataRetrievalOptionsChanged();
            } 
        }

        /// <summary>
        /// Event raised, when property <see cref="MetadataRetrievalOptions" /> is changed.
        /// </summary>
        public event EventHandler MetadataRetrievalOptionsChanged;
        /// <summary>
        /// Called when [metadata retrieval options changed].
        /// </summary>
        protected void OnMetadataRetrievalOptionsChanged() {
            if (this.MetadataRetrievalOptionsChanged == null)
                return;

            this.MetadataRetrievalOptionsChanged(this, new EventArgs());
        }

        /// <summary>
        /// List of class descriptions, describing the types to be regarded by object comparer
        /// </summary>
        private ClassDescriptionList _classDescriptions = new ClassDescriptionList();
        /// <summary>
        /// Gets or sets a list of class descriptions, describing the types to be regarded by object comparer
        /// </summary>
        public ClassDescriptionList ClassDescriptions { get { return _classDescriptions; } set { _classDescriptions = value; } }

        /// <summary>
        /// Creates Xml of this configuration instance
        /// </summary>
        /// <returns>A stream</returns>
        public Stream ToXml() {
            _traceHelper.Enter();
            var memoryStream = new MemoryStream();
            var xmlSer = new XmlSerializer(this.GetType());
            xmlSer.Serialize(memoryStream, this);
            _traceHelper.Return(memoryStream);
            return memoryStream;
        }

        /// <summary>
        /// Creates Xml of this configuration
        /// </summary>
        /// <returns>A string</returns>
        public string ToXmlString() {
            _traceHelper.Enter();
            using (var ms = ToXml()) {
                ms.Position = 0;
                var bytesToRead = (int)ms.Length;
                var sb = new StringBuilder(bytesToRead);
                var buf = new byte[bytesToRead];
                int bytesRead = 0;
                while ((bytesRead = ms.Read(buf, (int)ms.Position, bytesToRead -= bytesRead)) > 0)
                    sb.Append(Encoding.Default.GetString(buf));

                _traceHelper.Return(sb);
                return sb.ToString();

            }
        }

        /// <summary>
        /// Creates a new <see cref="Configuration"/> instance from the given xml <paramref name="input"/>
        /// </summary>
        /// <param name="input">A stream containing xml string</param>
        /// <returns>A new <see cref="Configuration"/> instance</returns>
        public static Configuration FromXml(Stream input) {
            var xmlSer = new XmlSerializer(typeof(Configuration));
            var retval = xmlSer.Deserialize(input) as Configuration;
            retval.UpdateMetadataFromNames();
            return retval;
        }

        /// <summary>
        /// Creates a new <see cref="Configuration"/> instance from the given xml <paramref name="input"/>
        /// </summary>
        /// <param name="input">A string containing the xml data</param>
        /// <returns>A new <see cref="Configuration"/> instance</returns>
        public static Configuration FromXmlString(string input) {
            using (var ms = new MemoryStream(Encoding.Default.GetBytes(input)))
                return FromXml(ms);

        }

        //private PropertyInfo TryAutoPopulate( System.Type t, ClassDescription cd, MemberDescription pd ){
        //    var ifTypes = t.GetInterfaces();
        //    Convert.ChangeType()
        //    PropertyInfo pi = null;
        //    foreach(var ifType in ifTypes)
        //        if ((pi = ifType.GetProperty(pd.FullName)) != null) {
        //            var derivedCd = _classDescriptions.Find(x => x.FullName == ifType.FullName);
        //            if (derivedCd == null) 
        //                derivedCd = new ClassDescription();
        //            if(!cd.Properties.Exists(x=>x.FullName==pd.FullName)
                        
        //                cd.Properties.Add(new MemberDescription(derivedCd){
        //                  DisplayName=pd.DisplayName,
        //                   FullName=pd.FullName,
        //                     HasIndexParameters=pd.HasIndexParameters,
        //                      MemberInfo=pi,
        //                       Name=pd.Name,
        //                        TypeIsEnumerable=pd.TypeIsEnumerable,
        //                         TypeIsString=
        //                })
                  
        //            cd.Properties.ForEach(x=>derivedCd.Properties.Add(new MemberDescription(derivedCd){
                                 
        //            }));
        //            derivedCd.FullName = ifType.FullName;
        //            _classDescriptions.Add(derivedCd);
        //        }        
            
        //}

        /// <summary>
        /// Updates the metadata from names.
        /// </summary>
        /// <exception cref="System.TypeLoadException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        private void UpdateMetadataFromNames() {
            _traceHelper.Enter();
            //foreach( var cd in _classDescriptions ){
            int cdIndexDelta = 0;
            for(int cdIndex = 0; cdIndex < _classDescriptions.Count;cdIndex++){
                var cd = _classDescriptions[cdIndex];
                if(cd.IsDerived)
                    continue;

                var t = Tools.GetType(cd.FullName);

                //var t = Type.GetType(cd.FullName);
                if (t == null){
                    foreach( var asm in AppDomain.CurrentDomain.GetAssemblies()){
                        t = asm.GetType(cd.FullName);
                        if(t!=null)
                            break;
                    }
                }
                if (t == null)
                    throw new TypeLoadException(string.Format("Could not load type with name '{0}'", cd.FullName));

                foreach (var pd in cd.Properties) {
                    var pi = t.GetProperty(pd.FullName, _getPropertiesBindingFlags);
                    pd.DeclaringClassDescription=null;
                    if (pi == null) {
                        var ifTypes = t.GetInterfaces();
                        foreach (var ifType in ifTypes) {
                            var tmpPi = ifType.GetProperty(pd.FullName);
                            if (tmpPi != null) {
                                var derivedCd = _classDescriptions.Find(x => x.FullName == ifType.FullName);
                                if (derivedCd == null) {
                                    derivedCd = new ClassDescription() {
                                        DisplayName = cd.DisplayName,
                                        FullName=ifType.FullName,
                                        IdPropertyName=cd.IdPropertyName,
                                        IsDerived=true
                                    };
                                    _classDescriptions.Add(derivedCd);

                                }
                                pd.DeclaringClassDescription = derivedCd;
                                pi = tmpPi;

                            }
                        }
                    }
                    if (pi == null)
                        throw new ArgumentException(string.Format("Could not find property with name '{0}' in type '{1}' by using BindingFlags=={2}", pd.FullName, t.FullName, _getPropertiesBindingFlags));

                    pd.HasIndexParameters = pi.GetIndexParameters().Length > 0;
                    pd.MemberInfo = pi;
                    pd.Name = pi.Name;
                    pd.TypeIsEnumerable = Tools.CheckIsEnumerable(pi);
                    pd.TypeIsString = pi.PropertyType == typeof(string);
                    pd.TypeName = pi.PropertyType.FullName;
                }

            }
        
            _traceHelper.Leave();

        }

        private bool _autoPopulateDerived = false;
        public bool AutoPopuplateDerived { get { return _autoPopulateDerived; } set { _autoPopulateDerived = value; } }


    }

    /// <summary>
    /// Options defining types of how metadata about objects are retrieved.
    /// </summary>
    [Serializable]
    public enum MetadataRetrievalOptions {

        /// <summary>
        /// Get types and properties to read by reflection through defined CompareAttributes (Default)
        /// </summary>
        /// <remarks>
        /// This is the default option and lets you decorate your classes with the CompareAttribute attribute.
        /// <c>ObjectComparer</c> iterates all properties of the objects which have to be compared and 
        /// searches for the CompareAttribute.
        /// </remarks>
        ReflectCompareAttributes,

        /// <summary>
        /// Get types and properties to read by reflection through pre-configured lists of properties
        /// </summary>
        /// <remarks>
        /// This option is used in a scenario where you describe the types and their properties which have
        /// to be reflected in an external data store. If you use this option then <c>ObjectComparer</c>
        /// does not search for the CompareAttribute attributes. The advantage is that not all properties
        /// of an object which has to be compared are iterated.
        /// </remarks>
        ReflectDescriptions,


        /// <summary>
        /// Reserved for future use.
        /// </summary>
        /// <remarks>
        /// Feature has to be designed and implemented.
        /// </remarks>
        EmitPropertyDescription

    }


}
