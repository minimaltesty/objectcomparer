using SIT.Components.ObjectComparer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SampleApp.Source.BusinessObjects;

namespace ObjectComparer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ExtensionMethodsTest and is intended
    ///to contain all ExtensionMethodsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExtensionMethodsTest {


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
        ///A test for CreateSnapshot
        ///</summary>
        [TestMethod()]
        public void CreateSnapshotTest() {
            object o = TestData.CreateOrder();
            var actual = ExtensionMethods.CreateSnapshot(o);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ObjectSnapshot));
            Assert.AreEqual(actual.TypeName, typeof(Order).FullName);
            var oss = actual as ObjectSnapshot;

            Assert.IsTrue(oss.Properties.Count == 4);
            Assert.IsTrue(oss.Properties.Exists(x => x.Name == "Id"));
            var id = oss.Properties.Find(x => x.Name == "Id").Value;
            Assert.IsInstanceOfType(id, typeof(int));
            Assert.IsTrue((int)id == 1);
            
            Assert.IsTrue(oss.Properties.Exists(x => x.Name == "Number"));
            var number = oss.Properties.Find(x => x.Name == "Number").Value;
            Assert.IsInstanceOfType(number, typeof(string));
            Assert.IsTrue((string)number == "No1");

            Assert.IsTrue(oss.Properties.Exists(x => x.Name == "Customer"));
            var customer = oss.Properties.Find(x => x.Name == "Customer");
            Assert.AreEqual(customer.TypeName, typeof(Customer).FullName);
            Assert.IsInstanceOfType(customer, typeof(ObjectSnapshot));
            var customer2 = customer as ObjectSnapshot;
            Assert.IsTrue(customer2.Properties.Count == 6);

            Assert.IsTrue(oss.Properties.Exists(x => x.Name == "Positions"));

            
            

            

        }

        /// <summary>
        ///A test for GetChanges
        ///</summary>
        [TestMethod()]
        public void GetChangesTest() {
            
            var order = TestData.CreateOrder();
            var ss1 = new ObjectSnapshot(order);
            TestData.ModifyOrder(order);
            var actual = order.GetChanges(ss1);
            var actualXml = actual.ToXml();

        }

        /// <summary>
        ///A test for GetChanges
        ///</summary>
        [TestMethod()]
        public void GetChangesTest1() {
            object o = null; // TODO: Initialize to an appropriate value
            Snapshot oldData = null; // TODO: Initialize to an appropriate value
            ChangeSet expected = null; // TODO: Initialize to an appropriate value
            ChangeSet actual;
            actual = ExtensionMethods.GetChanges(o, oldData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetChanges
        ///</summary>
        [TestMethod()]
        public void GetChangesTest2() {
            object o = null; // TODO: Initialize to an appropriate value
            object oldData = null; // TODO: Initialize to an appropriate value
            ChangeSet expected = null; // TODO: Initialize to an appropriate value
            ChangeSet actual;
            actual = ExtensionMethods.GetChanges(o, oldData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
