using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using SIT.Components.ObjectComparer;
using System.IO;
using System.Text;

namespace SampleApp.Source.Forms {
    public partial class OrderDetailsForm :Form
    {

        #region Just some tests
        
        private Snapshot _form1;
        private Snapshot _form2;

        #endregion

        /// <summary>
        /// Our business object
        /// </summary>
        private BusinessObjects.Order _order;

        /// <summary>
        /// The first (initial) snapshot of the business object
        /// </summary>
        private Snapshot _orderSnapshot1;

        /// <summary>
        /// Some tracing tools
        /// </summary>
        private static TraceHelper _trace = null;

        /// <summary>
        /// Gets the TraceHelper instance
        /// </summary>
        private TraceHelper Trace {
            get {
                if ( _trace == null )
                    _trace = new TraceHelper( new TraceSource( "SIT.ObjectComparer" ) );
                return _trace;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public OrderDetailsForm() {
            InitializeComponent();
            this.Trace.TraceSource.Listeners.Add( new TextboxTraceListener(this.textBox1) );
            _order=BusinessObjects.SampleData.CreateSampleOrder1();
            _orderSnapshot1 = new ObjectSnapshot(_order);
            _orderSnapshot1 = new ObjectSnapshot(_order, this.ObjectComparerContext);
            
            //AuditTrail.Instance.TrailInit( _order );
            orderBindingSource.DataSource = _order;
            customerBindingSource.DataSource = _order.Customer;
            addressBindingSource.DataSource = _order.Customer.Address;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="order"></param>
        public OrderDetailsForm(BusinessObjects.Order order) {
            InitializeComponent();
            _order=order;
            _orderSnapshot1=new ObjectSnapshot( _order, this.ObjectComparerContext );
            //_orderSnapshot1 = new ObjectSnapshot(_order);
            orderBindingSource.DataSource=_order;
        }


        #region Just some tests
        
        public struct Test {
            public int Height;
            public int Width;
        }

        #endregion

        private void btnDiff_Click( object sender, EventArgs e )
        {


            #region Just some tests
            
            //Test a = new Test();
            //a.Height = 5;
            //a.Width = 10;

            //var ss1 = new ObjectSnapshot( a );
            //a.Height = 7;
            //var ss2 = new ObjectSnapshot( a );
            //var ssCi = new ObjectCompareItem();
            //ssCi.Create( ss1, ss2 );
            //var ssCs = new ChangeSet();
            //ssCs.Create( ssCi );
            //using ( DiffForm df = new DiffForm( ssCs ) )
            //    df.ShowDialog( this );

            //_form2 = new ObjectSnapshot( this );
            //CompareItem formCi = new ObjectCompareItem();
            //formCi.Create( _form1, _form2 );
            //ChangeSet formCs = new ChangeSet();
            //formCs.Create( formCi );
            //using ( DiffForm df = new DiffForm( formCs ) )
            //    df.ShowDialog( this );

            //var col = BackColor;
            //var props = col.GetType().GetProperties( BindingFlags.Instance | BindingFlags.Public   );

            //AuditTrail.Instance.TrailSnapshot( _order );

            #endregion

            /* Create the second snapshot from the business object */
            Snapshot _orderSnapshot2 = new ObjectSnapshot( _order, this.ObjectComparerContext );
            //Snapshot _orderSnapshot2 = new ObjectSnapshot(_order);

            /* Create a compare item based on the two snapshots of the business object */
            CompareItem ci = new ObjectCompareItem();
            ci.Create( _orderSnapshot1, _orderSnapshot2 );

            /* Create a change set based on the compare item */
            ChangeSet cs = new ChangeSet();
            cs.Create( ci );

            /* Show the diff form, showing the change set */
            using( DiffForm df = new DiffForm( cs ) )
                df.ShowDialog( this );

        }

        private void btnDeepCopy_Click( object sender, EventArgs e ) {

            /* Create a deep copy by using the static copy method */
            var orderDeepCopy = DeepCopy.Copy( _order );

            /* Create a deep copy by using the the DeepCopy method of the abstract base class */
            /* Alternatively, you can create a DeepCopy method as extension method */
            var orderDeepCopy2 = _order.DeepCopy();

            /* Create a shallow copy, make some changes and see that the "original" object is also changed */
            var orderCopy = _order.Clone() as BusinessObjects.Order;
            orderCopy.Customer.Address=new BusinessObjects.Address() {
                Id=4,
                City="C4",
                Street="S4",
                Zip="Z4"
            };
            orderCopy.Customer.Displayname="Customer4";

            orderDeepCopy.Customer.Address=new BusinessObjects.Address() {
                Id=5,
                City="C5",
                Street="S5",
                Zip="Z5"
            };
            orderDeepCopy.Customer.Displayname="Customer5";

            orderDeepCopy2.Customer.Address=new BusinessObjects.Address() {
                Id=6,
                City="C6",
                Street="S6",
                Zip="Z6"
            };
            orderDeepCopy2.Customer.Displayname="Customer6";
            
            /* Show the different order objects */
            this.Text="Original Order";
            orderBindingSource.ResetBindings( false );
            var copy1Form = new OrderDetailsForm( orderCopy ) { Text="Cloned Order", StartPosition= FormStartPosition.WindowsDefaultLocation };
            var copy2Form = new OrderDetailsForm( orderDeepCopy ) { Text="DeepCopy Order", StartPosition= FormStartPosition.WindowsDefaultLocation };
            var copy3Form = new OrderDetailsForm( orderDeepCopy2 ) { Text="DeepCopy Order (inheritance)", StartPosition= FormStartPosition.WindowsDefaultLocation };
            copy1Form.Show();
            copy2Form.Show();
            copy3Form.Show();

        }

        private void OrderDetailsForm_Shown( object sender, EventArgs e )
        {
            #region Just some tests

            //_form1 = new ObjectSnapshot( this );

            #endregion
        }

        private Context _context;
        private Context ObjectComparerContext {
            get {
                if (_context == null)
                    _context = Context.Default;

                if (_configuration != null)
                    _context.Configuration = _configuration;

                return _context;

            }
        }

        private IConfiguration _configuration;

        private void btnLoadConfiguration_Click(object sender, EventArgs e) {
            var xml = Properties.Resources.CompareConfig;
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                _configuration = Configuration.FromXml(ms);

            this.Reset();
            
            
        }

        private void Reset() {
            _order = BusinessObjects.SampleData.CreateSampleOrder1();
            orderBindingSource.DataSource = _order;
            customerBindingSource.DataSource = _order.Customer;
            addressBindingSource.DataSource = _order.Customer.Address;
            _orderSnapshot1 = new ObjectSnapshot(_order, this.ObjectComparerContext);

        }

        private void btnReset_Click(object sender, EventArgs e) {
            this.Reset();
            
        }

    }
}
