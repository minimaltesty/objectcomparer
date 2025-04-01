using SIT.Components.ObjectComparer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace ObjectComparer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ObjectSnapshotTest and is intended
    ///to contain all ObjectSnapshotTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ObjectSnapshotTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test

        private SampleApp.Source.BusinessObjects.Order _testData = null;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _testData = TestData.CreateSampleOrder1();
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ObjectSnapshot Constructor
        ///</summary>
        [TestMethod()]
        public void ObjectSnapshotConstructorTest()
        {
            object value = null; // TODO: Initialize to an appropriate value
            ObjectSnapshot target = new ObjectSnapshot(value);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ObjectSnapshot Constructor
        ///</summary>
        [TestMethod()]
        public void ObjectSnapshotConstructorTest1()
        {
            ObjectSnapshot target = new ObjectSnapshot();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void ObjectSnapshot_Create_AllParamsNull()
        {
            ObjectSnapshot target = new ObjectSnapshot();
            Context context = null;
            object value = null;
            MemberInfo pi = null;
            bool stopRecursion = false;
            target.Create(context, value, pi, stopRecursion);
            Assert.AreEqual(target.Properties.Count, 0);
            Assert.AreEqual(target.Name, string.Empty);
            Assert.AreEqual(target.TypeName, null);
            Assert.AreEqual(target.Value, null);
            Assert.AreEqual(target.IdPropertyName, null);
            Assert.AreEqual(target.IdPropertyValue, null);
            Assert.AreEqual(target.Parent, null);
            
        }

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void ObjectSnapshot_Create_ContextOnly()
        {
            ObjectSnapshot target = new ObjectSnapshot(); 
            Context context = Context.Default;
            object value = null; 
            MemberInfo pi = null; 
            bool stopRecursion = false;
            target.Create(context, value, pi, stopRecursion);
            Assert.AreEqual(target.Properties.Count, 0);
            Assert.AreEqual(target.Name, string.Empty);
            Assert.AreEqual(target.TypeName, null);
            Assert.AreEqual(target.Value, null);
            Assert.AreEqual(target.IdPropertyName, null);
            Assert.AreEqual(target.IdPropertyValue, null);
            Assert.AreEqual(target.Parent, null);

        }

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void ObjectSnapshot_Create_ValueOnlyInt()
        {
            ObjectSnapshot target = new ObjectSnapshot();
            Context context = Context.Default;
            object value = (int)13;
            MemberInfo pi = null;
            bool stopRecursion = false;

            target.Create(context, value, pi, stopRecursion);
            Assert.AreEqual(target.Properties.Count, 0);
            Assert.AreEqual(target.Name, "Int32");
            Assert.AreEqual(target.TypeName, "System.Int32");
            Assert.AreEqual(target.Value, 13);
            Assert.AreEqual(target.IdPropertyName, null);
            Assert.AreEqual(target.IdPropertyValue, null);
            Assert.AreEqual(target.Parent, null);


        }

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void ObjectSnapshot_Create_PropertyInfoOnly()
        {
            ObjectSnapshot target = new ObjectSnapshot();
            Context context = Context.Default;
            object value = null;
            MemberInfo pi = _testData.GetMemberInfo("Id")[0];
            bool stopRecursion = false;
            
            target.Create(context, value, pi, stopRecursion);
            Assert.AreEqual(target.Properties.Count, 0);
            Assert.AreEqual(target.Name, "Id");
            Assert.AreEqual(target.TypeName, "System.Int32");
            Assert.AreEqual(target.Value, null);
            Assert.AreEqual(target.IdPropertyName, null);
            Assert.AreEqual(target.IdPropertyValue, null);
            Assert.AreEqual(target.Parent, null);

        }

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void ObjectSnapshot_Create_NoParent()
        {
            ObjectSnapshot target = new ObjectSnapshot();
            Context context = Context.Default;
            object value = _testData.Id;
            MemberInfo pi = _testData.GetMemberInfo("Id")[0];
            bool stopRecursion = false;

            target.Create(context, value, pi, stopRecursion);
            Assert.AreEqual(target.Properties.Count, 0);
            Assert.AreEqual(target.Name, "Id");
            Assert.AreEqual(target.TypeName, "System.Int32");
            Assert.AreEqual(target.Value, 1);
            Assert.AreEqual(target.IdPropertyName, null);
            Assert.AreEqual(target.IdPropertyValue, null);
            Assert.AreEqual(target.Parent, null);

        }

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void ObjectSnapshot_Create_ObjectOnly_Order()
        {
            ObjectSnapshot target = new ObjectSnapshot();
            Context context = Context.Default;
            object value = _testData.Id;
            MemberInfo pi = _testData.GetMemberInfo("Id")[0];
            bool stopRecursion = false;

            target.Create(context, value, pi, stopRecursion);
            Assert.AreEqual(target.Properties.Count, 0);
            Assert.AreEqual(target.Name, "Id");
            Assert.AreEqual(target.TypeName, "System.Int32");
            Assert.AreEqual(target.Value, 1);
            Assert.AreEqual(target.IdPropertyName, null);
            Assert.AreEqual(target.IdPropertyValue, null);
            Assert.AreEqual(target.Parent, null);

        }



    }
}
