using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIT.Components.ObjectComparer;
using System.Diagnostics;

namespace ObjectComparer.Tests.ComponentTests {
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public partial class ComponentTest {

        SampleApp.Source.BusinessObjects.Order _testDataOrder;
        SIT.Components.ObjectComparer.Configuration _testDataConfiguration;

        public ComponentTest() {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        static TraceHelper _trace;
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) {
            



        }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize() {
            _testDataOrder = TestData.CreateOrder();
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        public void TestMethod1() {
            //
            // TODO: Add test logic here
            //
        }
    }
}
