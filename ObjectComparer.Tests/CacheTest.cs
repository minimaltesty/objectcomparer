using SIT.Components.ObjectComparer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ObjectComparer.Tests
{
    
    
    /// <summary>
    ///This is a test class for CacheTest and is intended
    ///to contain all CacheTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CacheTest
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
        ///A test for AddObject
        ///</summary>
        [TestMethod()]
        public void AddObjectTest()
        {
            Cache target = new Cache(); // TODO: Initialize to an appropriate value
            object o = null; // TODO: Initialize to an appropriate value
            target.AddObject(o);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExistsObject
        ///</summary>
        [TestMethod()]
        public void ExistsObjectTest()
        {
            Cache target = new Cache(); // TODO: Initialize to an appropriate value
            object o = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.ExistsObject(o);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetDefaultCache
        ///</summary>
        [TestMethod()]
        public void GetDefaultCacheTest()
        {
            Cache expected = null; // TODO: Initialize to an appropriate value
            Cache actual;
            actual = Cache.GetDefaultCache();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Default
        ///</summary>
        [TestMethod()]
        public void DefaultTest()
        {
            Cache actual;
            actual = Cache.Default;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
