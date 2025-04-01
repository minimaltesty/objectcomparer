using SIT.Components.ObjectComparer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ObjectComparer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CompareItemTest and is intended
    ///to contain all CompareItemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CompareItemTest
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


        internal virtual CompareItem CreateCompareItem()
        {
            // TODO: Instantiate an appropriate concrete class.
            CompareItem target = null;
            return target;
        }

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
            CompareItem target = CreateCompareItem(); // TODO: Initialize to an appropriate value
            Snapshot a = null; // TODO: Initialize to an appropriate value
            Snapshot b = null; // TODO: Initialize to an appropriate value
            ChangeType expected = new ChangeType(); // TODO: Initialize to an appropriate value
            ChangeType actual;
            actual = target.Create(a, b);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateEmpty
        ///</summary>
        [TestMethod()]
        public void CreateEmptyTest()
        {
            CompareItem target = CreateCompareItem(); // TODO: Initialize to an appropriate value
            CompareItem expected = null; // TODO: Initialize to an appropriate value
            CompareItem actual;
            actual = target.CreateEmpty();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateEmpty
        ///</summary>
        [TestMethod()]
        public void CreateEmptyTest1()
        {
            CompareItem target = CreateCompareItem(); // TODO: Initialize to an appropriate value
            string typeName = string.Empty; // TODO: Initialize to an appropriate value
            CompareItem expected = null; // TODO: Initialize to an appropriate value
            CompareItem actual;
            actual = target.CreateEmpty(typeName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
