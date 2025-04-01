using SIT.Components.ObjectComparer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SIT.Components.ObjectComparer.Generic;

namespace ObjectComparer.Tests
{
    
    
    /// <summary>
    ///This is a test class for DeepCopyTest and is intended
    ///to contain all DeepCopyTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DeepCopyTest
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
        ///A test for Copy
        ///</summary>
        public void CopyTest2Helper<T>()
        {
            T source = default(T); // TODO: Initialize to an appropriate value
            T expected = default(T); // TODO: Initialize to an appropriate value
            T actual;
            actual = DeepCopy.Copy<T>(source);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void CopyTest2()
        {
            CopyTest2Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Copy
        ///</summary>
        public void CopyTestHelper<T>()
            where T : class
        {
            T source = null; // TODO: Initialize to an appropriate value
            T expected = null; // TODO: Initialize to an appropriate value
            T actual;
            actual = DeepCopy.Copy<T>(source);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void CopyTest()
        {
            CopyTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Copy
        ///</summary>
        [TestMethod()]
        public void CopyTest1()
        {
            object source = null; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = DeepCopy.Copy(source);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CopyCollection
        ///</summary>
        [TestMethod()]
        public void CopyCollectionTest()
        {
            object source = null; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = DeepCopy.CopyCollection(source);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CopyObject
        ///</summary>
        [TestMethod()]
        public void CopyObjectTest()
        {
            object source = null; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = DeepCopy.CopyObject(source);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
