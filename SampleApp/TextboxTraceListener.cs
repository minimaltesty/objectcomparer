using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace SampleApp {
    public class TextboxTraceListener : TraceListener{

        TextBox _textBox;

        public TextboxTraceListener( TextBox textBox) {
            _textBox = textBox;
        }

        private bool CanWrite {
            get {
                if ( _textBox == null )
                    return false;
                if ( _textBox.IsDisposed )
                    return false;
                if ( !_textBox.IsHandleCreated )
                    return false;
                return true;
                    
            }

        }

        public override void Write( string message ) {
            if ( !this.CanWrite ) return;
            message.PadLeft( this.IndentLevel, '\t' );
            _textBox.AppendText( message );
        }

        public override void WriteLine( string message ) {
            if ( !this.CanWrite ) return;
            _textBox.AppendText( Environment.NewLine );
            message.PadLeft( this.IndentLevel, '\t' );
            _textBox.AppendText( message );
            
        }
    }
}
