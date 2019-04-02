﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOE.Common;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;
using MOE.Common.Models;
using MOE.Common.Models.Repositories;


namespace GetMaxTimeRecords
{
    class GetMaxTimeRecords
    {
        public static ParallelOptions options = null;

        static void Main(string[] args)
        {
            if (Properties.Settings.Default.forceNonParallel)
            {
                options = new ParallelOptions { MaxDegreeOfParallelism = -1 };
            }
            else
            {
                if (Properties.Settings.Default.MaxThreads < 2)
                {
                    options = new ParallelOptions { MaxDegreeOfParallelism = 1 };
                }
                else
                {
                    options = new ParallelOptions { MaxDegreeOfParallelism = Properties.Settings.Default.MaxThreads };
                }
            }

            MOE.Common.Models.Repositories.ISignalsRepository sr = 
                MOE.Common.Models.Repositories.SignalsRepositoryFactory.Create();

            List<MOE.Common.Models.Signal> signalsDT = sr.GetLatestVerionOfAllSignalsByControllerType(4);
           
         

                Parallel.ForEach(signalsDT, options, row =>
                //foreach (var row in signalsDT )
                {
                    if (TestIPAddress(row))
                    {
                        string signalId = row.SignalID;

                        Console.WriteLine("Starting signal" + signalId);

                        MOE.Common.Business.MaxTimeHDLogClient client = new MOE.Common.Business.MaxTimeHDLogClient();

                        XmlDocument xml = client.GetSince(row.IPAddress, GetMostRecentRecordTime(signalId));

                        SaveToDB(xml, signalId);

                        Console.WriteLine("Finished signal" + signalId);
                    }

                }
                );
            
        }

        private static bool TestIPAddress (MOE.Common.Models.Signal Signal)
        {
            IPAddress ip ;
            bool hasValidIP = true;
            hasValidIP = IPAddress.TryParse(Signal.IPAddress, out ip);

            if (Signal.IPAddress == "0")
            {
                hasValidIP = false;
            }

            //test to see if the address is reachable
            if (hasValidIP)
            {
                Ping pingSender = new Ping();
                PingOptions pingOptions = new PingOptions();

                // Use the default Ttl value which is 128, 
                // but change the fragmentation behavior.
                pingOptions.DontFragment = true;

                // Create a buffer of 32 bytes of data to be transmitted. 
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                PingReply reply = null;
                try
                {
                    reply = pingSender.Send(Signal.IPAddress, timeout, buffer, pingOptions);
                    if (reply.Status != IPStatus.Success)
                    {
                        var errorLog = ApplicationEventRepositoryFactory.Create();
                        errorLog.QuickAdd(System.Reflection.Assembly.GetExecutingAssembly().GetName().ToString(),
                            "GetMaxTimeRecords", "TestIPAddress", ApplicationEvent.SeverityLevels.High, "Signal - " + Signal.SignalID + " IP Address - " + Signal.IPAddress + " - Invalid IP Address");
                        hasValidIP = false;
                    }
                }
                catch( Exception e)
                {
                    if (reply == null || reply.Status != IPStatus.Success)
                    {
                        var errorLog = ApplicationEventRepositoryFactory.Create();
                        errorLog.QuickAdd(System.Reflection.Assembly.GetExecutingAssembly().GetName().ToString(),
                            "GetMaxTimeRecords", e.TargetSite.ToString(), ApplicationEvent.SeverityLevels.High, "Signal - " + Signal.SignalID + " IP Address - " + Signal.IPAddress + " - " + e.Message);

                        hasValidIP = false;
                    }
                }
            }
            return hasValidIP;
        }

        private static DateTime GetMostRecentRecordTime(string signalId)
        {

            DateTime mostRecentEventTime = MOE.Common.Business.ControllerEventLogs.GetMostRecentRecordTimestamp(signalId);

            if (mostRecentEventTime != null)
            {

                return (mostRecentEventTime);
            }
            return (DateTime.Now.AddDays(-2));
        }

       

        private static void SaveToDB(XmlDocument xml, string SignalId)
        {

            MOE.Common.Data.MOE.Controller_Event_LogDataTable elTable = new MOE.Common.Data.MOE.Controller_Event_LogDataTable();
            UniqueConstraint custUnique =
            new UniqueConstraint(new DataColumn[] { elTable.Columns["SignalID"],
                                                    elTable.Columns["Timestamp"], 
                                                    elTable.Columns["EventCode"],
                                                    elTable.Columns["EventParam"]
                                            });

            elTable.Constraints.Add(custUnique);

            XmlNodeList list = xml.SelectNodes("/EventResponses/EventResponse/Event");

            foreach (XmlNode node in list)
            {
                XmlAttributeCollection attrColl = node.Attributes;

                DateTime EventTime = Convert.ToDateTime(attrColl.GetNamedItem("TimeStamp").Value);
                int EventCode = Convert.ToInt32(attrColl.GetNamedItem("EventTypeID").Value);
                int EventParam = Convert.ToInt32(attrColl.GetNamedItem("Parameter").Value);
 
                try
                {
                    MOE.Common.Data.MOE.Controller_Event_LogRow eventrow = elTable.NewController_Event_LogRow();


                    eventrow.Timestamp = EventTime;
                    eventrow.SignalID = SignalId;
                    eventrow.EventCode = EventCode;
                    eventrow.EventParam = EventParam;

                    elTable.AddController_Event_LogRow(eventrow);

                  
                }
                catch 
                {
                }
            }
             MOE.Common.Business.BulkCopyOptions Options = new MOE.Common.Business.BulkCopyOptions(Properties.Settings.Default.SPM, Properties.Settings.Default.DestinationTableName,
                                  Properties.Settings.Default.WriteToConsole,Properties.Settings.Default.forceNonParallel, Properties.Settings.Default.MaxThreads, false, 
                                  Properties.Settings.Default.EarliestAcceptableDate, Properties.Settings.Default.BulkCopyBatchSize, Properties.Settings.Default.BulkCopyTimeOut);

             MOE.Common.Business.SignalFtp.BulktoDb(elTable, Options);
            

        }
    }
}
