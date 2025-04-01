using System.Collections.Generic;

namespace SIT.Components.ObjectComparer.Documentation.Examples.Example_IdPropertyName {

    /// <summary>
    /// A calss holding data describing a person which is marked with attributes for comparison
    /// </summary>
    [CompareClass(IdPropertyName="Id")]
    public class Person {

        /// <summary>
        /// Unique identifier
        /// </summary>
        private int _id;

        /// <summary>
        /// Gets or sets the value for the unique identifier
        /// </summary>
        [CompareProperty]

        /// <summary>
        /// Gets or sets the value for the unique identifier
        /// </summary>
        public int Id { get { return _id; } set { _id=value; } }

        /// <summary>
        /// Name of the person
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets or sets the name of the person
        /// </summary>
        [CompareProperty]
        public string Name { get { return _name; } set { _name=value; } }


    }

    /// <summary>
    /// Entry class
    /// </summary>
    class Program {

        /// <summary>
        /// Entry point
        /// </summary>
        static void Main() {

            /* A list with business objects */
            List<Person> persons = new List<Person>();
            persons.Add( new Person() { Id=1, Name="Joey" } );
            persons.Add( new Person() { Id=2, Name="Monco" } );
            persons.Add( new Person() { Id=3, Name="Clint" } );

            /* Create a snapshot from the list */
            Snapshot s1 = new EnumerableSnapshot();
            s1.Create( persons );

            /* Make changes to the list (or imagine the user edits it) */
            persons[ 0 ].Name="Joe";        //Change the Name property of the first list item
            persons[ 2 ].Name="TheBlonde";  //Change the Name property of the last list item
            persons.RemoveAt( 1 );          //Remove the middle list item

            /* Create a second snapshot after editing the list */
            Snapshot s2 = new EnumerableSnapshot();
            s2.Create( persons );

            /* Create a compare item of the taken snapshots */
            //
            // At this point we have the two snapshots s1 and s2.
            // - s1 is based on a list of persons which has -three- entries
            // - s2 is based on a list of persons which has -two- entries
            // For the comparison of the two lists and their objects it
            // is necessary that we know which entries of the two lists
            // have to be compared. It makes no sense that we make a
            // comparison by index. 
            // For example (pseudo code):
            // 1. comp( s1.persons[0], s2.persons[0] )  //ok, comp( [Id=1;Name=Joey], [Id=1;Name=Joe] )
            // 2. comp( s1.persons[1], s2.persons[1] )  //nok, comp( [Id=2;Name=Monco], [Id=3;Name=TheBlonde] )
            // 3. comp( s1.persons[2], null )           //nok, comp( [Id=3;Name=Clint], null )
            //
            // The better result is reached when the comparison does the following.
            // For example (pseudo code):
            // 1. comp( s1.persons[0], s2.persons[0] )  //ok, comp( [Id=1;Name=Joey], [Id=1;Name=Joe] )
            // 2. comp( s1.persons[1], null )           //ok, comp( [Id=2;Name=Monco], null )
            // 3. comp( s1.persons[2], s2.persons[1] )  //ok, comp( [Id=3;Name=Clint], [Id=3;Name=TheBlonde] )
            //
            // To realize this the entries which should be compared have to be searched
            // by an identifier. The identifier can be a property of the Person class a this
            // properties name is given through the CompareClassAttribute (see the definition
            // of the Person class above)
            CompareItem ci=new EnumerableCompareItem();
            ci.Create( s1, s2 );

            /* create a change set of the compare item */
            ChangeSet cs = new ChangeSet();
            cs.Create( ci );


        }
    }
}
