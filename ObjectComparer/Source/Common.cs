using System.Reflection;
using System;
using System.Collections;
using System.Text;

namespace SIT.Components.ObjectComparer {

    /// <summary>
    /// Type of change
    /// </summary>
    public enum ChangeType {

        /// <summary>
        /// Item is new or added
        /// </summary>
        Added,

        /// <summary>
        /// Item is not existent or removed
        /// </summary>
        Removed,

        /// <summary>
        /// Item has changed
        /// </summary>
        Changed,

        /// <summary>
        /// Item has not changed
        /// </summary>
        Unchanged

    }

    /// <summary>
    /// Some helping tools
    /// </summary>
    public class Tools {



        /// <summary>
        /// Searches for a attribute of a type on a given object
        /// </summary>
        /// <param name="value">The object which to search on</param>
        /// <param name="attribute">The type of the attribute to search</param>
        /// <returns>If the attribute is found it is returned, otherwise <c>null</c></returns>
        /// <remarks>
        /// The search for the attribute also includes checks for the BaseType of the attribute.
        /// That means, if you create a new attribute class "A2Attribute" which derives from <c>A1Attribute</c>
        /// and you use <c>A2Attribute</c> on a class <c>C</c> then the search for <c>A1Attribute</c>
        /// on class <c>C</c> returns an instance of <c>A1Attribute</c>.
        /// </remarks>
        /// <example>
        /// The following example shows how to get the Displayname attribute of an object
        /// <code>
        /// [AttributeUsage( AttributeTargets.Class | AttributeTargets.Property)]
        /// public class DisplaynameAttribute : Attribute {
        /// 
        ///     protected string _displayname;
        ///     public property Displayname{ get{return _displayname;} set{_displayname=value;} }
        ///     
        ///     public DisplaynameAttribute() : base() {}
        ///     public DisplaynameAttribute( string displayname ) : this(){
        ///         _displayname = displayname;
        ///     }
        /// 
        /// }
        /// 
        /// [AttributeUsage( AttributeTargets.Class | AttributeTargets.Property)]
        /// public class DisplaynameExAttribute : DisplaynameAttribute{
        /// 
        ///     private string _displayname2;
        ///     public property Displayname2{ get{return _displayname2;} set{_displayname=value2;} }
        ///
        ///     public DisplaynameAttributeEx() : base() {}
        ///     public DisplaynameAttributeEx( string displayname ) : base(displayname){}
        ///     public DisplaynameAttributeEx( string displayname, string displayname2 ) : this(displayname){
        ///         _displayname2 = displayname2;
        ///     }
        ///     
        /// }
        /// 
        /// [DisplayName("PersonEntity")]
        /// public class Person {
        /// 
        ///     private string _fullname;
        ///     
        ///     [DisplayName("Persons full name")]
        ///     public string Fullname{ get{return _fullname;} set{_fullname=value;} }
        ///     
        ///     private string _nickname;
        ///     
        ///     [DisplayNameEx("Persons nick name", "the nick")]
        ///     public string Nickname{ get{return _nickname;} {_nickname=value;} }
        /// 
        /// }
        /// 
        /// public class Program{
        /// 
        ///     public void main(){
        ///         // Get the Displayname of the Person class its self
        ///         Person myPerson = new Person();
        ///         System.ComponentModel.DisplayNameAttribute foundAttribute = 
        ///             SIT.Components.ObjectComparer.Tools.GetAttribute( myPerson, typeof(System.ComponentModel.DisplayNameAttribute) );
        ///         Console.WriteLine( "Object myPerson has Displayname: {0}", foundAttribute.DisplayName );
        ///         
        ///         // Get the Displayname of the property Fullname of the class Person class
        ///         System.Type personType = typeof( Person );
        ///         System.Reflection.PropertyInfo pi = personType.GetProperty( "Fullname" );
        ///         foundAttribute = 
        ///             SIT.Components.ObjectComparer.Tools.GetAttribute( pi, typeof(System.ComponentModel.DisplayNameAttribute) );
        ///         Console.WriteLine( "Property Fullname has Displayname: {0}", foundAttribute.DisplayName );
        ///         
        ///         System.Reflection.PropertyInfo pi = personType.GetProperty( "Nickname" );
        ///         foundAttribute = 
        ///             SIT.Components.ObjectComparer.Tools.GetAttribute( pi, typeof(System.ComponentModel.DisplayNameAttribute) );
        ///         Console.WriteLine( "Property Fullname has Displayname: {0}", foundAttribute.DisplayName );
        ///
        ///     }
        /// 
        /// }
        /// </code>
        /// The console output is:
        /// PersonEntity
        /// Persons full name
        /// Persons nick name
        /// </example>
        internal static object GetAttribute( object value, System.Type attribute ) {
            object[] customAttributes;
            object currentAttribute;

            // Check if the given value is of type object or if it is already a PropertyInfo
            if( value is PropertyInfo )
                customAttributes = ( value as PropertyInfo ).GetCustomAttributes( attribute, true );
            else
                customAttributes = value.GetType().GetCustomAttributes( attribute, true );

            // Iterate through the found attributes
            for( int i = 0; i < customAttributes.Length; i++ ) {
                currentAttribute = customAttributes[ i ];
                
                // Check if the attribute its self is the correct type or if it is derived
                if( currentAttribute.GetType() == attribute || currentAttribute.GetType().BaseType == attribute )
                    return currentAttribute;

            }
            return null;

        }

        internal static Context EnsureContext( IContext context ) {
            if( context==null )
                return Context.Default;

            var retval = new Context();
            retval.Configuration=context.Configuration;
            retval.Cache=context.Cache;
            if( retval.Configuration==null )
                retval.Configuration=Configuration.Default;

            if( retval.Cache==null )
                retval.Cache=Cache.Default;

            return retval;
        }

        internal static CompareAttribute GetCompareMetadata( IContext context, object value ) {
            var configuration = EnsureContext(context).Configuration;
            if( configuration.MetadataRetrievalOptions== MetadataRetrievalOptions.ReflectCompareAttributes ) {
                CompareAttribute ca = Tools.GetAttribute(
                    value,
                    typeof( CompareAttribute )
                ) as CompareAttribute;
                return ca;

            }
            if( configuration.MetadataRetrievalOptions== MetadataRetrievalOptions.ReflectDescriptions ) {
                if (value is MemberInfo) {

                } else {

                }

                throw new NotImplementedException();

            }
            if( configuration.MetadataRetrievalOptions== MetadataRetrievalOptions.EmitPropertyDescription ) {
                throw new NotImplementedException();

            }
            throw new NotImplementedException();

        }

        internal static bool CheckIsEnumerable(object value) {
            return
                (value is IEnumerable) &&
                !(value is string) &&
                !(value == null)
                ;

        }

        internal static bool CheckIsEnumerable(PropertyInfo pi) {
            return
                pi.PropertyType.GetInterface(typeof(System.Collections.IEnumerable).Name) != null &&
                pi.PropertyType != typeof(string)
                ;
        }

        public static object GetMemberValue(MemberInfo info, object obj) {
            if (info == null)
                throw new ArgumentNullException("info");

            if (obj == null)
                throw new ArgumentNullException("obj");

            if (info is PropertyInfo)
                return (info as PropertyInfo).GetValue(obj, null);

            else if (info is FieldInfo)
                return (info as FieldInfo).GetValue(obj);

            else
                throw new ArgumentException("Unhandled member info type: {0}", info.GetType().FullName);

        }

        public static System.Type GetType(string name) {
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies()) {
                var retval = asm.GetType(name);
                if (retval != null)
                    return retval;

            }
            return null;

        }

        internal static bool CheckIsIndexerProperty(MemberInfo currentMemberInfo) {
            if(currentMemberInfo is PropertyInfo) {
                var pi = currentMemberInfo as PropertyInfo;
                if (pi != null)
                    if (pi.GetIndexParameters().Length > 0)
                        return true;
                
            }
            return false;

        }

        internal static bool CheckTypeEquality(object a, object b) {
            if( a == null | b == null )
                return true;
            return string.Equals(a.GetType().FullName, b.GetType().FullName);
        }
    }
}
