using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SIT.Components.ObjectComparer;
using System.Collections;

namespace YouNameSpace {
    public class Person {

        public Person() {

        }
        public Person( string name) {
            _name = name;
        }

        private string _name;

        public string Name {
            get { return _name; }
            set { _name = value; }
        }



    }

    public class Person2 {

        public Person2() {

        }
        public Person2(int id, string name) {
            _id = id;
            _name = name;
        }

        private string _name;

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        private int _id;

        public int Id {
            get { return _id; }
            set { _id = value; }
        }



    }


}

namespace SIT.Components.ObjectComparer.Documentation.Examples.Example_Configuration {
    class Program {



        static void Main(string[] args) {

            var x = new Dictionary<int, YouNameSpace.Person>();
            var y = new KeyValuePair<int, YouNameSpace.Person>();

            var t1 = x.GetType().FullName;
            var t2 = y.GetType().FullName;
            var xxx = t1 + t2;

            //CompareWithConfigurationBasic();
            //CompareWithConfigurationGenericDictionary();
            CompareWithConfigurationIDictionary();
            //CompareWithConfigurationIEnumerable();




        }

        public class MyContext : Context {

            public MyContext() {
                this.Cache = new Cache();
                this.Configuration = new Configuration();
                
                this.Configuration.CheckIgnoreMemberFunc = global::SIT.Components.ObjectComparer.Configuration.Default.CheckIgnoreMember;
                this.Configuration.CheckStopRecursionFunc = global::SIT.Components.ObjectComparer.Configuration.Default.CheckStopRecursionFunc;
                this.Configuration.GetMemberBindingFlags = global::SIT.Components.ObjectComparer.Configuration.Default.GetMemberBindingFlags;
                this.Configuration.MetadataRetrievalOptions = MetadataRetrievalOptions.ReflectCompareAttributes;

                this.MetadataReader = new MetadataReaderReflectComapreAttributes(this);

            }

        }

        private static void CompareWithConfigurationGenericDictionary() {
            /* Get the default context for ObjectComparer */
            Context ctx = Context.Default;

            /* Load the object comparer configuation that
             * defines how member infos (properties and fields)
             * are retrieved (in this case via the description in
             * the configuration file: ReflectDescription instead of
             * using default ReflectCompareAttribute)
             * */
            var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CompareConfigGenericDictionary.xml");
            using (var fs = new FileStream(xmlPath, FileMode.Open))
                ctx.Configuration = Configuration.FromXml(fs);

            /* Try with value types */
            var dict = new Dictionary<int, string>();
            dict.Add(1, "a");
            dict.Add(2, "b");
            dict.Add(3, "c");

            var ss1 = new EnumerableSnapshot(dict, ctx);
            dict.Add(4, "d");
            dict.Remove(2);

            var ss2 = new EnumerableSnapshot(dict, ctx);
            var ci = new EnumerableCompareItem();
            ci.Create(ss1, ss2);

            var cs = new ChangeSet();
            cs.Create(ci);

            Console.WriteLine(cs.ToXml());


            
            


        }


        

        static void CompareWithConfigurationBasic() {
            /* Get the default context for ObjectComparer */
            Context ctx = Context.Default;

            /* Load the object comparer configuation that
             * defines how member infos (properties and fields)
             * are retrieved (in this case via the description in
             * the configuration file: ReflectDescription instead of
             * using default ReflectCompareAttribute)
             * */
            var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CompareConfigBasic.xml");
            using (var fs = new FileStream(xmlPath, FileMode.Open))
                ctx.Configuration = Configuration.FromXml(fs);

            /* Create sample data */
            var myOrder = SampleData.CreateSampleOrder1();

            /* Create snapshot ss1; Use ctx */
            var ss1 = new ObjectSnapshot(myOrder, ctx);

            /* Modify the sample data */
            SampleData.ModifyOrder(myOrder);

            /* Create snapshot ss2; Use ctx */
            var ss2 = new ObjectSnapshot(myOrder, ctx);

            /* Create compare item */
            var ci = new ObjectCompareItem();
            ci.Create(ss1, ss2);

            /* Get change set from compare item */
            var changes = new ChangeSet();
            changes.Create(ci);

            /* Print changes in xml format to console */
            Console.WriteLine(changes.ToXml());
        }

        private static void CompareWithConfigurationIDictionary() {
            /* Get the default context for ObjectComparer */
            Context ctx = Context.Default;

            /* Load the object comparer configuation that
             * defines how member infos (properties and fields)
             * are retrieved (in this case via the description in
             * the configuration file: ReflectDescription instead of
             * using default ReflectCompareAttribute)
             * */
            var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CompareConfigIDictionary.xml");
            using (var fs = new FileStream(xmlPath, FileMode.Open))
                ctx.Configuration = Configuration.FromXml(fs);

            IDictionary dict = new Dictionary<int, string>();
            dict.Add(1, "a");
            dict.Add(2, "b");
            dict.Add(3, "c");

            var ss1 = new EnumerableSnapshot(dict, ctx);
            dict.Add(4, "d");
            dict.Remove(2);
            dict[3] = "c-changed";

            var ss2 = new EnumerableSnapshot(dict, ctx);
            var ci = new EnumerableCompareItem();
            ci.Create(ss1, ss2);

            var cs = new ChangeSet();
            cs.Create(ci);

            Console.WriteLine(cs.ToXml());


            /* Try with complex type */
            dict = new Dictionary<int, YouNameSpace.Person>();
            dict.Add(1, new YouNameSpace.Person("a"));
            dict.Add(2, new YouNameSpace.Person("b"));
            dict.Add(3, new YouNameSpace.Person("c"));

            ss1 = new EnumerableSnapshot(dict, ctx);
            dict.Add(4, new YouNameSpace.Person("d"));
            dict.Remove(2);
            dict[3] = new YouNameSpace.Person("c-changed");
            (dict[1] as YouNameSpace.Person).Name = "a-changed";

            ss2 = new EnumerableSnapshot(dict, ctx);
            ci = new EnumerableCompareItem();
            ci.Create(ss1, ss2);

            cs = new ChangeSet();
            cs.Create(ci);
            Console.WriteLine(cs.ToXml());
        }

        private static void CompareWithConfigurationIEnumerable() {
            /* Get the default context for ObjectComparer */
            Context ctx = Context.Default;

            /* Load the object comparer configuation that
             * defines how member infos (properties and fields)
             * are retrieved (in this case via the description in
             * the configuration file: ReflectDescription instead of
             * using default ReflectCompareAttribute)
             * */
            var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CompareConfigIEnumerable.xml");
            using (var fs = new FileStream(xmlPath, FileMode.Open))
                ctx.Configuration = Configuration.FromXml(fs);

            IList lst = new List<YouNameSpace.Person2>();
            lst.Add(new YouNameSpace.Person2() {
                Id = 1,
                Name = "Name1"
            });
            lst.Add(new YouNameSpace.Person2() {
                Id = 2,
                Name = "Name2"
            });
            lst.Add(new YouNameSpace.Person2() {
                Id = 3,
                Name = "Name3"
            });

            IEnumerable ienum = lst;
            var ss1 = new EnumerableSnapshot(ienum, ctx);
            lst.Add(new YouNameSpace.Person2() {
                Id = 4,
                Name = "Name4"
            });
            lst.RemoveAt(1);
            var p = lst[1] as YouNameSpace.Person2;
            p.Name += "Chanded";
            lst[1] = p;
            ienum = lst;
            var ss2 = new EnumerableSnapshot(ienum, ctx);
            var ci = new EnumerableCompareItem();
            ci.Create(ss1, ss2);

            var cs = new ChangeSet();
            cs.Create(ci);

            Console.WriteLine(cs.ToXml());



        }

    }
}
