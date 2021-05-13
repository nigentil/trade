using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse
{
    class Risk
    {

        public string returnRisk(double Value, string ClientSector)
        {
            //se for private e menor que 1000000 vai retornar alt risco
            if (Value < 1000000 && ClientSector == "Public")
                return "LOWRISK";
            else if (Value >= 1000000 && ClientSector == "Public")
                return "MEDIUMRISK";
            else 
                return "HIGHRISK";

        }
    }
}
