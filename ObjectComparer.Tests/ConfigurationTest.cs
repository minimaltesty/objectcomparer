using SIT.Components.ObjectComparer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.IO;
using SampleApp.Source.BusinessObjects;

namespace ObjectComparer.Tests
{
    
    
    /// <summary>
    ///This is a test class for ConfigurationTest and is intended
    ///to contain all ConfigurationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConfigurationTest
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
        ///A test for DefaultCheckIgnoreProperty
        ///</summary>
        [TestMethod()]
        public void DefaultCheckIgnorePropertyTest()
        {
            object property = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;

            //
            // Create change set with default "ignorance"
            //
            var testData = TestData.CreateOrder();
            var ss1 = new ObjectSnapshot(testData);
            TestData.ModifyOrder(testData);
            var ss2 = new ObjectSnapshot(testData);
            var ci = new ObjectCompareItem();
            ci.Create(ss1, ss2);
            var cs = new ChangeSet();
            cs.Create(ci);
            var containsNumber = cs.Flatten().TrueForAll(x => !string.Equals(x.Name, "Number"));
            Assert.IsFalse(containsNumber);

            //
            // Create change set with custom "ignorance"
            //
            var myContext = Context.GetDefaultContext();
            myContext.Configuration.CheckIgnoreMemberFunc = new CheckIgnoreMemberDelegate(delegate(object o) {
                var ignore = false;
                //
                // Check to ignore by name of member (field or property)
                //
                var memberNameToCheck = string.Empty;
                if (o is PropertyInfo) {
                    memberNameToCheck = (o as PropertyInfo).Name;

                } else if (o is FieldInfo) {
                    memberNameToCheck = (o as FieldInfo).Name;

                } else if (o is string)
                    memberNameToCheck = o as string;
                
                ignore |= string.Equals(memberNameToCheck, "Number");

                //
                // Check to ignore by PropertyInfo
                //
                if (o is PropertyInfo) {
                    var pi = o as PropertyInfo;
                    ignore |= pi == typeof(Order).GetProperty("Customer");
                        
                }
                //
                // Return value
                //
                return ignore;

            });
            testData = TestData.CreateOrder();
            ss1 = new ObjectSnapshot(testData, myContext);
            TestData.ModifyOrder(testData);
            ss2 = new ObjectSnapshot(testData, myContext);
            ci = new ObjectCompareItem();
            ci.Create(ss1, ss2);
            cs = new ChangeSet();
            cs.Create(ci);

            containsNumber = cs.Flatten().TrueForAll(x => !string.Equals(x.Name, "Number"));
            Assert.IsTrue(containsNumber);

        }

        /// <summary>
        ///A test for DefaultCheckStopRecursion
        ///</summary>
        [TestMethod()]
        public void DefaultCheckStopRecursionTest()
        {
            Context context = null; // TODO: Initialize to an appropriate value
            object parentValue = null; // TODO: Initialize to an appropriate value
            Type parentType = null; // TODO: Initialize to an appropriate value
            object childValue = null; // TODO: Initialize to an appropriate value
            MemberInfo childPi = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = Configuration.DefaultCheckStopRecursion(context, parentValue, parentType, childValue, childPi);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetDefaultConfiguration
        ///</summary>
        [TestMethod, Ignore]
        public void GetDefaultConfigurationTest()
        {
            Configuration expected = null; // TODO: Initialize to an appropriate value
            Configuration actual;
            actual = Configuration.GetDefaultConfiguration();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        private Configuration GetXmlTestdata() {
            return TestData.GetConfiguration_ClassDescriptions();

        }

        /// <summary>
        ///A test for ToXmlString
        ///</summary>
        [TestMethod()]
        public void ToXmlStringTest()
        {
            var target = GetXmlTestdata();
            var expected = string.Empty; // TODO: Initialize to an appropriate value
            var actual = string.Empty;
            actual = target.ToXmlString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FromXmlString
        ///</summary>
        [TestMethod()]
        public void FromXmlStringTest()
        {
            AppDomain.CurrentDomain.Load("SampleApp");
            var target = GetXmlTestdata();
            var input = target.ToXmlString();
            var actual = Configuration.FromXmlString(input);
            var output = actual.ToXmlString();

            Assert.AreEqual(input, output);

        }
    }
}
