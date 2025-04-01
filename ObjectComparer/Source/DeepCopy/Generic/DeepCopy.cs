using System;
using System.Collections;
using System.Reflection;


namespace SIT.Components.ObjectComparer.Generic {

    /// <summary>
    /// Provides static methods to deep copy objects
    /// </summary>
    public static class DeepCopy {

        /// <summary>
        /// Creates a deep copy of the specified source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source object to create a deep copy of.</param>
        /// <returns>The deep copy of the given source object</returns>
        public static T Copy<T>( T source ) {

            System.Type type;

            if( source == null )
                return default( T );

            type = source.GetType();

            if( type.GetInterface( "ICollection" ) != null )
                return (T)CopyCollection( source );
            else
                return (T)CopyObject( source );

        }

        internal static T CopyObject<T>( T source ) {

            object copy;

            if( source == null )
                return default( T );

            copy = Activator.CreateInstance( source.GetType() );
            System.Type type = source.GetType();
            FieldInfo[] fields = type.GetFields( BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance );

            foreach( FieldInfo field in fields ) {

                if( field.FieldType.IsValueType | field.FieldType == typeof( String ) ) {
                    field.SetValue( copy, field.GetValue( source ) );

                } else {

                    if( field.FieldType.GetInterface( "ICollection" ) != null )
                        field.SetValue( copy, CopyCollection<ICollection>( (ICollection)field.GetValue( source ) ) );

                    else
                        field.SetValue( copy, Copy<T>( (T)field.GetValue( source ) ) );

                }
            }

            return (T)copy;

        }

        internal static T CopyCollection<T>( T source ) {

            System.Type type;

            object destinationCollection = null;
            object newItem;
            object enumerator;
            System.Type enumType;

            MethodInfo movenextMethod;
            MethodInfo addMethod;
            PropertyInfo currentProperty;

            if( source == null )
                return default( T );

            type = source.GetType();

            if( type.GetInterface( "ICollection" ) != null ) {
                destinationCollection = Activator.CreateInstance( type );
            }

            if( destinationCollection == null )
                throw new ArgumentException( "hmm" );

            enumerator = type.InvokeMember( "GetEnumerator", BindingFlags.InvokeMethod, null, source, new object[] { } );
            enumType = enumerator.GetType();

            movenextMethod = enumType.GetMethod( "MoveNext" );
            currentProperty = enumType.GetProperty( "Current" );
            addMethod = type.GetMethod( "Add" );

            while( (bool)movenextMethod.Invoke( enumerator, new object[] { } ) ) {

                newItem = Copy<object>( currentProperty.GetValue( enumerator, new object[] { } ) );
                addMethod.Invoke( destinationCollection, new object[] { newItem } );

            }

            movenextMethod = null;
            currentProperty = null;
            addMethod = null;

            enumType = null;
            enumerator = null;

            return (T)destinationCollection;


        }

    }
}
