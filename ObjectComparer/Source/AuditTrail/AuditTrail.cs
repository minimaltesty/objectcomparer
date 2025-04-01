using System;
using System.Collections.Generic;
using System.Text;

namespace SIT.Components.ObjectComparer {
    public class AuditTrail {

        private static object _syncRoot = new object();
        private static volatile AuditTrail _instance;
        public static AuditTrail Instance {
            get {
                if ( _instance == null )
                    lock ( _syncRoot )
                        _instance = new AuditTrail();

                return _instance;

            }
        }

        private Dictionary<object, List<Snapshot>> _snapShots = new Dictionary<object, List<Snapshot>>();
        private Dictionary<object, List<ChangeSet>> _changes = new Dictionary<object, List<ChangeSet>>();

        private Dictionary<object, List<AuditTrailEntry>> _entries = new Dictionary<object, List<AuditTrailEntry>>();

        public void TrailInit( object o ) {
            if ( _snapShots.ContainsKey( o ) )
                _snapShots.Remove( o );
            
            _snapShots.Add( o, new List<Snapshot>() );
            _snapShots[ o ].Add( o.CreateSnapshot() );

            if ( _changes.ContainsKey( o ) )
                _changes.Remove( o );

            
            _changes.Add( o, new List<ChangeSet>() );

        }

        public void TrailSnapshot( object o ) {
            var oldSnapShot = _snapShots[ o ][ _snapShots[ o ].Count - 1 ];
            _snapShots[ o ].Add( o.CreateSnapshot() );
            var currentChange = o.GetChanges( oldSnapShot );
            _changes[ o ].Add( currentChange );
            if ( !_entries.ContainsKey( o ) )
                _entries.Add( o, new List<AuditTrailEntry>() );

            foreach ( var item in currentChange.Flatten() ) {
                var newEntry = new AuditTrailEntry();
                newEntry.ChangeType = item.ChangeType;
                newEntry.Date = DateTime.Now;
                newEntry.PropertyPath = item.Path;
                newEntry.TypeDisplayName = currentChange.Name;
                newEntry.TypeName = "";
                _entries[ o ].Add( newEntry );

            }

        }

    }
}
