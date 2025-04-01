using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIT.Components.ObjectComparer;

namespace ObjectComparer.Tests.ComponentTests {
    public partial class ComponentTest {

        

        private Tuple<Snapshot, Snapshot> CreateSnapshots_UsingAttributes() {
            var ctx = Context.GetDefaultContext();
            var conf = TestData.GetConfiguration_Default();
            ctx.Configuration = conf;
            var order = TestData.CreateOrder();
            var ss1 = new ObjectSnapshot(order, ctx);
            TestData.ModifyOrder(order);
            ctx = Context.GetDefaultContext();
            conf = TestData.GetConfiguration_Default();
            ctx.Configuration = conf;
            var ss2 = new ObjectSnapshot(order, ctx);

            return new Tuple<Snapshot, Snapshot>(ss1, ss2);

        }

        private string CreateChangeSetXml(Tuple<Snapshot, Snapshot> snapshots) {
            var ci = new ObjectCompareItem();
            ci.Create(snapshots.Item1, snapshots.Item2);
            var cs = new ChangeSet();
            cs.Create(ci);
            var retval = cs.ToXml();
            return retval;

        }

        [TestMethod]
        public void Snapshot_UsingAttributes() {
            var snapshots = CreateSnapshots_UsingAttributes();
            var csXml = CreateChangeSetXml(snapshots);
    
        }

        private Tuple<Snapshot, Snapshot> CreateSnapshots_UsingConfiguration() {
            var ctx = Context.GetDefaultContext();
            var conf = TestData.GetConfiguration_ClassDescriptions();
            ctx.Configuration = conf;
            var order = TestData.CreateOrder();
            var ss1 = new ObjectSnapshot(order, ctx);
            TestData.ModifyOrder(order);
            ctx = Context.GetDefaultContext();
            conf = TestData.GetConfiguration_ClassDescriptions();
            ctx.Configuration = conf;
            var ss2 = new ObjectSnapshot(order, ctx);

            return new Tuple<Snapshot, Snapshot>(ss1, ss2);

        }

        [TestMethod]
        public void Snapshot_UsingConfiguration() {
            var snapshotsAttributes = CreateSnapshots_UsingConfiguration();
            
            var c1 = snapshotsAttributes.Item1.Context.Id;
            var c2 = snapshotsAttributes.Item2.Context.Id;

            var csXmlAttributes = CreateChangeSetXml(snapshotsAttributes);
            var snapshotsConfiguration = CreateSnapshots_UsingConfiguration();
            var csXmlConfiguration = CreateChangeSetXml(snapshotsConfiguration);
            Assert.AreEqual(csXmlAttributes, csXmlConfiguration);


        }

        private Tuple<Snapshot, Snapshot> CreateSnapshots_NoExplicitConfiguration() {
            var order = TestData.CreateOrder();
            var ss1 = new ObjectSnapshot(order);
            TestData.ModifyOrder(order);
            var ss2 = new ObjectSnapshot(order);
            return new Tuple<Snapshot, Snapshot>(ss1, ss2);

        }

        [TestMethod]
        public void Snapshot_NoExplicitConfiguration() {
            var snapshotsAttributes = CreateSnapshots_UsingAttributes();

            var c1 = snapshotsAttributes.Item1.Context.Id;
            var c2 = snapshotsAttributes.Item2.Context.Id;

            var csXmlAttributes = CreateChangeSetXml(snapshotsAttributes);
            var snapshotsConfiguration = CreateSnapshots_NoExplicitConfiguration();
            var csXmlConfiguration = CreateChangeSetXml(snapshotsConfiguration);
            Assert.AreEqual(csXmlAttributes, csXmlConfiguration);


        }

    }
}
