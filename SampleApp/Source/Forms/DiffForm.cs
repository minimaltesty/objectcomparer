using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SIT.Components.ObjectComparer;

namespace SampleApp.Source.Forms {
    public partial class DiffForm :Form {
        public DiffForm() {
            InitializeComponent();
            
        }

        public DiffForm( ChangeSet changeSet )
            : this() {
                this.ChangeSet = changeSet;

        }

        private ChangeSet _changeSet=new ChangeSet();
        public ChangeSet ChangeSet {
            get { return _changeSet; }
            set {
                _changeSet = value ?? new ChangeSet();
                //if( value==null )
                //    _changeSet=new ChangeSet();
                //else
                //    _changeSet=value;
                changeSetBindingSource.DataSource = _changeSet;
            }
        }

        private void changeSetBindingSource_DataSourceChanged( object sender, EventArgs e ) {
            RefreshTreeView();
            changeSetFlattenedBindingSource.DataSource=_changeSet.Flatten();
        }

        private void RefreshTreeView() {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            
            AddNode( _changeSet );

            treeView1.EndUpdate();

        }

        private void AddNode( ChangeSet cs ) {
            AddNode( cs, null );

        }

        private void AddNodes( List<ChangeSet> csList, TreeNode parentNode ) {
            foreach( var cs in csList )
                AddNode( cs, parentNode );
            
        }

        private void AddNode( ChangeSet cs, TreeNode parentNode ) {
            TreeNode node =null;
            string nodeText = string.Format( "{0}: {1}", cs.Name, cs.ChangeType.ToString() );
            if( cs.ChangeType == ChangeType.Changed && !string.IsNullOrEmpty(cs.ValueA) && !string.IsNullOrEmpty(cs.ValueB) )
                nodeText += string.Format( " from '{0}' to '{1}'", cs.ValueA, cs.ValueB );

            else if ( (cs.ChangeType == ChangeType.Removed || cs.ChangeType == ChangeType.Changed) && !string.IsNullOrEmpty( cs.ValueA ) )
                nodeText += string.Format( " old '{0}'", cs.ValueA );

            else if ( (cs.ChangeType == ChangeType.Added || cs.ChangeType == ChangeType.Changed) && !string.IsNullOrEmpty( cs.ValueB ) )
                nodeText += string.Format( " new '{0}'", cs.ValueB );

            
            if(parentNode == null)
                node = treeView1.Nodes.Add( nodeText );
            else
                node = parentNode.Nodes.Add( nodeText );

            AddNodes( cs.Properties, node );
           
        }

    }
}
