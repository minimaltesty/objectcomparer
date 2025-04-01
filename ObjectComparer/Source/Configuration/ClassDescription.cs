using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace SIT.Components.ObjectComparer {

    /// <summary>
    /// Holds meta data describing types (classes).
    /// - used for configuration
    /// - used for caching
    /// </summary>
    public class ClassDescription :
        ItemDescription,
        IXmlSerializable {
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public ClassDescription()
            : base() {

        }

        private string _idPropertyName;
        public string IdPropertyName { get { return _idPropertyName; } set { _idPropertyName = value; } }

        private MemberDescriptionList _members = new MemberDescriptionList();
        public MemberDescriptionList Properties { get { return _members; } set { _members = value; } }

        #region Serializsation and Deserialization

        public System.Xml.Schema.XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            if (reader.MoveToAttribute("FullName")) {
                reader.ReadAttributeValue();
                _fullName = reader.Value;
            }
            
            reader.MoveToElement();
            reader.ReadStartElement("ClassDescription");
            
            reader.ReadStartElement("DisplayName");
            _displayName = reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadStartElement("IdPropertyName");
            _idPropertyName = reader.ReadContentAsString();
            reader.ReadEndElement();


            reader.ReadStartElement("Members");
            ReadXmlMembers(reader);
            reader.ReadEndElement();
            

            reader.ReadEndElement();

        }

        private void ReadXmlMembers(XmlReader reader) {
            _members = new MemberDescriptionList();
            if (reader.IsEmptyElement || reader.NodeType == XmlNodeType.EndElement)
                return;

            do {
                var md = new MemberDescription(this);
                reader.MoveToAttribute("FullName");
                if (reader.ReadAttributeValue())
                    md.FullName = reader.Value;

                if (reader.NodeType != XmlNodeType.EndElement) {
                    reader.MoveToElement();
                    if (!reader.IsEmptyElement) {
                        reader.ReadStartElement("Member");
                        md.DisplayName = reader.ReadElementString("DisplayName");
                        _members.Add(md);
                    }
                }

            } while (reader.ReadToNextSibling("Member"));
        }


        public void WriteXml(XmlWriter writer) {
            writer.WriteAttributeString("FullName", _fullName );
            writer.WriteElementString("DisplayName", _displayName);
            writer.WriteElementString("IdPropertyName", _idPropertyName);
            WriteXmlMembers(writer);

        }

        private void WriteXmlMembers(XmlWriter writer) {
            writer.WriteStartElement("Members");
            foreach (var pd in _members)
                WriteXmlMember(writer, pd);

            writer.WriteEndElement();

        }

        private void WriteXmlMember(XmlWriter writer, MemberDescription pd) {
            writer.WriteStartElement("Member");
            writer.WriteAttributeString("FullName", pd.FullName);
            writer.WriteElementString("DisplayName", pd.DisplayName);
            writer.WriteEndElement();

        }

        #endregion

        public override string ToString() {
            return string.Format(
                "DisplayName={0}, "
                + "FullName={1}, "
                + "IdPropertyName={2}",
                _displayName,
                _fullName,
                _idPropertyName
                );
        }

        private bool _isDerived;
        public bool IsDerived { get { return _isDerived; } set { _isDerived = value; } }


    }
}
