using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrentinoClassLibrary.Model {

    public class City {
		public string localita { get; set; } = string.Empty;
		public string comune { get; set; } = string.Empty;
		public int quota { get; set; }
		public string latitudine { get; set; } = string.Empty;
		public string longitudine { get; set; } = string.Empty;
	}

}
