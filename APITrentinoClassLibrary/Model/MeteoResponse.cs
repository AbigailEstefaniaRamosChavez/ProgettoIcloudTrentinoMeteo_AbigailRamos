using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrentinoClassLibrary.Model
{

    public class MeteoResponse {
        public string fontedacitare { get; set; }
        public string codiceipatitolare { get; set; }
        public string nometitolare { get; set; }
        public string codiceipaeditore { get; set; }
        public string nomeeditore { get; set; }
        public string dataPubblicazione { get; set; }
        public int idPrevisione { get; set; }
        public string evoluzione { get; set; }
        public string evoluzioneBreve { get; set; }
        public object[] AllerteList { get; set; }
        public Previsione[] previsione { get; set; }
    }

}
