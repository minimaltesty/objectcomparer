using System;
using System.Collections.Generic;
using System.Text;

namespace SIT.Components.ObjectComparer {

    public interface IContext {

        IConfiguration Configuration { get; set; }
        ICache Cache { get; set; }
        IMetadataReader MetadataReader { get; set; }
    }
    
    public class Context :
        IContext
    {

        private static Context _default;
        public static Context Default {
            get {
                if( _default==null )
                    _default = GetDefaultContext();

                return _default;

            }
        }


        internal static Context GetDefaultContext() {
            var retval = new Context();
            retval._id = Guid.NewGuid();
            retval.Cache = 
                global::SIT.Components.ObjectComparer.Cache.GetDefaultCache();

            retval.Configuration = 
                global::SIT.Components.ObjectComparer.Configuration.GetDefaultConfiguration();

            retval.MetadataReader = 
                new global::SIT.Components.ObjectComparer.MetadataReaderReflectComapreAttributes( retval );

            return retval;

        }

        private Guid _id;
        public Guid Id { get { return _id; } }

        private IConfiguration _configuration;
        public IConfiguration Configuration { 
            get { return _configuration; } 
            set { 
                _configuration=value;
                ResetMetadataReader();
                _configuration.MetadataRetrievalOptionsChanged += new EventHandler(delegate {
                    ResetMetadataReader();
                }); 
            } 
        }

        private ICache _cache;
        public ICache Cache { get { return _cache; } set { _cache=value; } }

        private IMetadataReader _metadataReader;
        public IMetadataReader MetadataReader { get { return _metadataReader; } set { _metadataReader=value; } }

        private void ResetMetadataReader() {
            switch (_configuration.MetadataRetrievalOptions) {
                case MetadataRetrievalOptions.ReflectCompareAttributes:
                    _metadataReader = new MetadataReaderReflectComapreAttributes(this);
                    break;

                case MetadataRetrievalOptions.ReflectDescriptions:
                    _metadataReader = new MetadataReaderReflectDescriptions(this);
                    break;

                case MetadataRetrievalOptions.EmitPropertyDescription:
                    break;

                default:
                    break;
            }
        }

    }
}
