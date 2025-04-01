using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using SIT.Components.ObjectComparer;

namespace SampleApp {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            //CreateConfigurationForOrder();
            //return;

            var ts = new TraceSource( "SIT.ObjectComparer" );
            ts.Listeners.Add( new ConsoleTraceListener() );

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new SampleApp.Source.Forms.OrderDetailsForm() );
        }


        private static void CreateConfigurationForOrder() {
            var retval = new Configuration();
            retval.GetMemberBindingFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic;
            retval.MetadataRetrievalOptions = MetadataRetrievalOptions.ReflectDescriptions;

            var cd = new ClassDescription();
            cd.DisplayName = "Order";
            cd.FullName = "SampleApp.Source.BusinessObjects.Order";
            cd.IdPropertyName = "Id";
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Id", DisplayName = "Id" });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Number", DisplayName = "Order-No." });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Customer", DisplayName = "Customer" });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Positions", DisplayName = "Order positions" });
            retval.ClassDescriptions.Add(cd);

            cd = new ClassDescription();
            cd.DisplayName = "Order position";
            cd.FullName = "SampleApp.Source.BusinessObjects.OrderPosition";
            cd.IdPropertyName = "Id";
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Id", DisplayName = "Id" });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "OrderId", DisplayName = "Order-Id" });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Number", DisplayName = "Pos-No." });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "OrderIndex", DisplayName = "Idx" });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Text", DisplayName = "Description" });
            retval.ClassDescriptions.Add(cd);

            cd = new ClassDescription() {
                DisplayName = "Customer",
                FullName = "SampleApp.Source.BusinessObjects.Customer",
                IdPropertyName = "Id"
            };
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Id", DisplayName = "Id" });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Number", DisplayName = "Customer-No." });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Displayname", DisplayName = "Displayname" });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Firstname", DisplayName = "Firstname" });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Lastname", DisplayName = "Lastname" });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Address", DisplayName = "Address" });
            retval.ClassDescriptions.Add(cd);

            cd = new ClassDescription() {
                DisplayName = "Adress",
                FullName = "SampleApp.Source.BusinessObjects.Address",
                IdPropertyName = "Id"
            };
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Id", DisplayName = "Id" });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Street", DisplayName = "Street" });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "Zip", DisplayName = "Zip Code" });
            cd.Properties.Add(new MemberDescription(cd) { FullName = "City", DisplayName = "City" });
            retval.ClassDescriptions.Add(cd);

            var s = retval.ToXmlString();
            System.IO.File.WriteAllLines(@"f:\dumpfolder\config.xml", new string[] { s });
            

        }

    }
}
