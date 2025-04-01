using SIT.Components.ObjectComparer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ObjectComparer.Tests
{
    
    
    /// <summary>
    ///This is a test class for EnumerableCompareItemTest and is intended
    ///to contain all EnumerableCompareItemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EnumerableCompareItemTest
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
            EnumerableCompareItem target = new EnumerableCompareItem(); // TODO: Initialize to an appropriate value
            Snapshot a = null; // TODO: Initialize to an appropriate value
            Snapshot b = null; // TODO: Initialize to an appropriate value
            ChangeType expected = new ChangeType(); // TODO: Initialize to an appropriate value
            ChangeType actual;
            actual = target.Create(a, b);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateFromSnapshotType
        ///</summary>
        [TestMethod()]
        [DeploymentItem("SIT.Components.ObjectComparer.dll")]
        public void CreateFromSnapshotTypeTest()
        {
            EnumerableCompareItem_Accessor target = new EnumerableCompareItem_Accessor(); // TODO: Initialize to an appropriate value
            Snapshot a = null; // TODO: Initialize to an appropriate value
            Snapshot b = null; // TODO: Initialize to an appropriate value
            CompareItem expected = null; // TODO: Initialize to an appropriate value
            CompareItem actual;
            actual = target.CreateFromSnapshotType(a, b);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnumerableCompareItem Constructor
        ///</summary>
        [TestMethod()]
        public void EnumerableCompareItemConstructorTest()
        {
            EnumerableCompareItem target = new EnumerableCompareItem();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
