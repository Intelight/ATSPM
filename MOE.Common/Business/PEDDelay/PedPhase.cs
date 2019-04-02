﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MOE.Common.Business.PEDDelay
{
    public class PedPhase : ControllerEventLogs
    {
        public PedPhase(int phaseNumber, string signalID, DateTime startDate, DateTime endDate,
            PlansBase plansData) : base(signalID, startDate, endDate, phaseNumber, new List<int> {21, 22, 45})
        {
            SignalID = signalID;
            StartDate = startDate;
            EndDate = endDate;
            PhaseNumber = phaseNumber;
            StartDate = startDate;
            EndDate = endDate;
            Plans = new List<PedPlan>();
            Cycles = new List<PedCycle>();
            HourlyTotals = new List<PedHourlyTotal>();

            for (var i = 0; i < plansData.Events.Count; i++)
                //if this is the last plan then we want the end of the plan
                //to cooincide with the end of the graph
                if (plansData.Events.Count - 1 == i)
                {
                    var plan = new PedPlan(signalID, phaseNumber, plansData.Events[i].Timestamp, endDate,
                        plansData.Events[i].EventParam);
                    Plans.Add(plan);
                }
                //else we add the plan with the next plans' time stamp as the end of the plan
                else
                {
                    var plan = new PedPlan(signalID, phaseNumber, plansData.Events[i].Timestamp,
                        plansData.Events[i + 1].Timestamp, plansData.Events[i].EventParam);

                    Plans.Add(plan);
                }

            GetCycles();
            AddCyclesToPlans();
            SetHourlyTotals();
        }

        public int PhaseNumber { get; }
        public string SignalID { get; }

        public double PedActuations
        {
            get { return Plans.Sum(p => p.PedActuations); }
        }

        public List<PedCycle> Cycles { get; }
        public List<PedPlan> Plans { get; }
        public List<PedHourlyTotal> HourlyTotals { get; }
        public double MinDelay { get; private set; }
        public double AverageDelay { get; private set; }
        public double MaxDelay { get; private set; }
        public double TotalDelay { get; set; }

        private void AddCyclesToPlans()
        {
            foreach (var p in Plans)
            {
                var cycles = (from c in Cycles
                    where c.CallRegistered >= p.StartDate &&
                          c.CallRegistered < p.EndDate
                    select c).ToList();
                p.Cycles = cycles;
            }
        }

        private void GetCycles()
        {
            for (var i = 0; i < Events.Count; i++)
                if (i < Events.Count - 2 && Events[i].EventCode == 21 &&
                    Events[i + 1].EventCode == 45 && Events[i + 2].EventCode == 22)
                {
                    Cycles.Add(new PedCycle(Events[i].Timestamp, Events[i].Timestamp));
                    i = i + 2;
                }
                else if (i < Events.Count - 2 && Events[i].EventCode == 22 &&
                         Events[i + 1].EventCode == 45 && Events[i + 2].EventCode == 21)
                {
                    Cycles.Add(new PedCycle( Events[i + 2].Timestamp, Events[i + 1].Timestamp));
                    i = i + 2;
                }
        }

        private void SetHourlyTotals()
        {
            //Get Min Max and Average
            if (Cycles.Count > 0)
            {
                MinDelay = Cycles.Min(c => c.Delay);
                MaxDelay = Cycles.Max(c => c.Delay);
                AverageDelay = Cycles.Average(c => c.Delay);
                TotalDelay = Cycles.Sum(c => c.Delay);

                var dt = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartDate.Hour, 0, 0);
                var nextDt = dt.AddHours(1);
                while (dt < EndDate)
                {
                    var hourDelay = (from c in Cycles
                        where c.CallRegistered >= dt &&
                              c.CallRegistered < nextDt
                        select c.Delay).Sum();
                    HourlyTotals.Add(new PedHourlyTotal(dt, hourDelay));
                    dt = dt.AddHours(1);
                    nextDt = nextDt.AddHours(1);
                }
            }
        }
    }
}