using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CreditSuisse
{
    public interface ITrade
    {
        double Value { get; set; }
        string ClientSector { get; set; }
    }
    public class TradeList
    {
        public double Value;
        public string ClientSector;
    }

    public class Trade
    {
        public List<string> TradeCategories(List<TradeList> portfolio)
        {         
         
            List<string> items = new List<string>();
            Risk risk = new Risk();

            foreach (TradeList item in portfolio)
            {
                items.Add(risk.returnRisk(item.Value, item.ClientSector));
            }

            return items;
        }

        public List<TradeList> returnTradeList (string jsonFile)
        {
            try
            {
                StreamReader str = new StreamReader(jsonFile);
                var jsonText = str.ReadToEnd();
                var trade = JsonConvert.DeserializeObject<List<TradeList>>(jsonText);
                return trade;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }


}

