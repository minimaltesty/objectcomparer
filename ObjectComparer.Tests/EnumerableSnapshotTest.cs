using SIT.Components.ObjectComparer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace ObjectComparer.Tests
{
    
    
    /// <summary>
    ///This is a test class for EnumerableSnapshotTest and is intended
    ///to contain all EnumerableSnapshotTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EnumerableSnapshotTest
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
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
            EnumerableSnapshot target = new EnumerableSnapshot(); // TODO: Initialize to an appropriate value
            Context context = null; // TODO: Initialize to an appropriate value
            object value = null; // TODO: Initialize to an appropriate value
            MemberInfo pi = null; // TODO: Initialize to an appropriate value
            bool stopRecursion = false; // TODO: Initialize to an appropriate value
            target.Create(context, value, pi, stopRecursion);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EnumerableSnapshot Constructor
        ///</summary>
        [TestMethod()]
        public void EnumerableSnapshotConstructorTest()
        {
            EnumerableSnapshot target = new EnumerableSnapshot();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
