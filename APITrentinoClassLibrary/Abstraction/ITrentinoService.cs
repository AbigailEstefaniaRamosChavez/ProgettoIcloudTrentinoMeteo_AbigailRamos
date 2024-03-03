using TrentinoClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TrentinoClassLibrary.Abstraction {
    [ServiceContract]
    public interface ITrentinoService {
        [OperationContract]
        public Task<Giorni?> GetMeteo(string comune, DateTime giorno);
    }
}
