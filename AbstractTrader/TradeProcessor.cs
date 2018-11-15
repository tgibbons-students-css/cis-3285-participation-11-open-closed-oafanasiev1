using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AbstractTrader
{
    public abstract class TradeProcessor
    {
        protected abstract IEnumerable<string> ReadTradeData(Stream stream);

        protected abstract IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> tradeData);


        protected void LogMessage(string message, params object[] args)
        {
            Console.WriteLine(message, args);
            // added for Request 408
            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log>"+message+"</log>", args);
            }

        }

        protected virtual void StoreTrades(IEnumerable<TradeRecord> trades)
        {

        }




        public virtual void ProcessTrades(Stream stream)
        //public void ProcessTrades(string url)
        {
            LogMessage("activating trades");
            base.ParseTrades(stream);

        }


    }
}
