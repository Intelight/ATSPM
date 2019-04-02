﻿using System;
using System.Collections.Generic;
using System.Linq;
using MOE.Common.Business.WCFServiceLibrary;
using MOE.Common.Models;
using MOE.Common.Models.Repositories;

namespace MOE.Common.Business
{
    public static class CycleFactory
    {
        public static List<RedToRedCycle> GetRedToRedCycles(Approach approach, DateTime startTime, DateTime endTime,
            bool getPermissivePhase, List<Controller_Event_Log> detectorEvents)
        {
            var cycleEvents = GetCycleEvents(getPermissivePhase, startTime, endTime, approach);
            if (cycleEvents != null && cycleEvents.Count > 0 && GetEventType(cycleEvents.LastOrDefault().EventCode) !=
                RedToRedCycle.EventType.ChangeToRed)
                GetEventsToCompleteCycle(getPermissivePhase, endTime, approach, cycleEvents);
            var cycles = new List<RedToRedCycle>();
            for (var i = 0; i < cycleEvents.Count; i++)
                if (i < cycleEvents.Count - 3
                    && GetEventType(cycleEvents[i].EventCode) == RedToRedCycle.EventType.ChangeToRed
                    && GetEventType(cycleEvents[i + 1].EventCode) == RedToRedCycle.EventType.ChangeToGreen
                    && GetEventType(cycleEvents[i + 2].EventCode) == RedToRedCycle.EventType.ChangeToYellow
                    && GetEventType(cycleEvents[i + 3].EventCode) == RedToRedCycle.EventType.ChangeToRed)
                    cycles.Add(new RedToRedCycle(cycleEvents[i].Timestamp, cycleEvents[i + 1].Timestamp,
                        cycleEvents[i + 2].Timestamp, cycleEvents[i + 3].Timestamp));
            return cycles;
        }

        public static List<CyclePcd> GetPcdCycles(DateTime startDate, DateTime endDate, Approach approach,
            List<Controller_Event_Log> detectorEvents, bool getPermissivePhase)
        {
            var cycleEvents = GetCycleEvents(getPermissivePhase, startDate, endDate, approach);
            if (cycleEvents != null && cycleEvents.Count > 0 && GetEventType(cycleEvents.LastOrDefault().EventCode) !=
                RedToRedCycle.EventType.ChangeToRed)
                GetEventsToCompleteCycle(getPermissivePhase, endDate, approach, cycleEvents);
            var cycles = new List<CyclePcd>();
            for (var i = 0; i < cycleEvents.Count; i++)
                if (i < cycleEvents.Count - 3
                    && GetEventType(cycleEvents[i].EventCode) == RedToRedCycle.EventType.ChangeToRed
                    && GetEventType(cycleEvents[i + 1].EventCode) == RedToRedCycle.EventType.ChangeToGreen
                    && GetEventType(cycleEvents[i + 2].EventCode) == RedToRedCycle.EventType.ChangeToYellow
                    && GetEventType(cycleEvents[i + 3].EventCode) == RedToRedCycle.EventType.ChangeToRed)
                    cycles.Add(new CyclePcd(cycleEvents[i].Timestamp, cycleEvents[i + 1].Timestamp,
                        cycleEvents[i + 2].Timestamp, cycleEvents[i + 3].Timestamp));
            if (cycles.Any())
                foreach (var cycle in cycles)
                {
                    var eventsForCycle = detectorEvents
                        .Where(d => d.Timestamp >= cycle.StartTime && d.Timestamp < cycle.EndTime).ToList();
                    foreach (var controllerEventLog in eventsForCycle)
                        cycle.AddDetectorData(new DetectorDataPoint(cycle.StartTime, controllerEventLog.Timestamp,
                            cycle.GreenEvent, cycle.YellowEvent));
                }
            //var totalSortedEvents = cycles.Sum(d => d.DetectorEvents.Count);
            return cycles;
        }

        private static RedToRedCycle.EventType GetEventType(int eventCode)
        {
            switch (eventCode)
            {
                case 1:
                    return RedToRedCycle.EventType.ChangeToGreen;
                // overlap green
                case 61:
                    return RedToRedCycle.EventType.ChangeToGreen;
                case 8:
                    return RedToRedCycle.EventType.ChangeToYellow;
                // overlap yellow
                case 63:
                    return RedToRedCycle.EventType.ChangeToYellow;
                case 9:
                    return RedToRedCycle.EventType.ChangeToRed;
                // overlap red
                case 64:
                    return RedToRedCycle.EventType.ChangeToRed;
                default:
                    return RedToRedCycle.EventType.Unknown;
            }
        }

        public static List<CycleSpeed> GetSpeedCycles(DateTime startDate, DateTime endDate, bool getPermissivePhase,
            Models.Detector detector)
        {
            var cycleEvents = GetCycleEvents(getPermissivePhase, startDate, endDate, detector.Approach);
            if (cycleEvents != null && cycleEvents.Count > 0 && GetEventType(cycleEvents.LastOrDefault().EventCode) !=
                RedToRedCycle.EventType.ChangeToRed)
                GetEventsToCompleteCycle(getPermissivePhase, endDate, detector.Approach, cycleEvents);
            var cycles = new List<CycleSpeed>();
            for (var i = 0; i < cycleEvents.Count; i++)
                if (i < cycleEvents.Count - 3
                    && GetEventType(cycleEvents[i].EventCode) == RedToRedCycle.EventType.ChangeToRed
                    && GetEventType(cycleEvents[i + 1].EventCode) == RedToRedCycle.EventType.ChangeToGreen
                    && GetEventType(cycleEvents[i + 2].EventCode) == RedToRedCycle.EventType.ChangeToYellow
                    && GetEventType(cycleEvents[i + 3].EventCode) == RedToRedCycle.EventType.ChangeToRed)
                    cycles.Add(new CycleSpeed(cycleEvents[i].Timestamp, cycleEvents[i + 1].Timestamp,
                        cycleEvents[i + 2].Timestamp, cycleEvents[i + 3].Timestamp));
            if (cycles.Any())
            {
                var speedEventRepository = SpeedEventRepositoryFactory.Create();
                var speedEvents = speedEventRepository.GetSpeedEventsByDetector(startDate,
                    cycles.LastOrDefault().EndTime, detector, detector.MinSpeedFilter ?? 5);
                foreach (var cycle in cycles)
                    cycle.FindSpeedEventsForCycle(speedEvents);
            }
            return cycles;
        }

        private static List<Controller_Event_Log> GetCycleEvents(bool getPermissivePhase, DateTime startDate,
            DateTime endDate, Approach approach)
        {
            var celRepository = ControllerEventLogRepositoryFactory.Create();
            List<Controller_Event_Log> cycleEvents;
            if (getPermissivePhase)
            {
                var cycleEventNumbers = approach.IsPermissivePhaseOverlap
                    ? new List<int> {61, 63, 64, 66}
                    : new List<int> {1, 8, 9};
                cycleEvents = celRepository.GetEventsByEventCodesParam(approach.SignalID, startDate,
                    endDate, cycleEventNumbers, approach.PermissivePhaseNumber.Value);

                //cycleEvents = celRepository.GetEventsByEventCodesParam(approach.SignalID, startDate,
                //    endDate, new List<int>() {1, 8, 9}, approach.PermissivePhaseNumber.Value);
            }
            else
            {
                var cycleEventNumbers = approach.IsProtectedPhaseOverlap
                    ? new List<int> {61, 63, 64,66}
                    : new List<int> {1, 8, 9};
                cycleEvents = celRepository.GetEventsByEventCodesParam(approach.SignalID, startDate,
                    endDate, cycleEventNumbers, approach.ProtectedPhaseNumber);
            }
            return cycleEvents;
        }

        private static void GetEventsToCompleteCycle(bool getPermissivePhase, DateTime endDate, Approach approach,
            List<Controller_Event_Log> cycleEvents)
        {
            var celRepository = ControllerEventLogRepositoryFactory.Create();
            if (getPermissivePhase)
            {
                var cycleEventNumbers = approach.IsPermissivePhaseOverlap
                    ? new List<int> {61, 63, 64, 66}
                    : new List<int> {1, 8, 9};
                var eventsAfterEndDate = celRepository.GetTopEventsAfterDateByEventCodesParam(approach.SignalID,
                    endDate, cycleEventNumbers, approach.PermissivePhaseNumber.Value, 3);
                if (eventsAfterEndDate != null)
                    cycleEvents.AddRange(eventsAfterEndDate);
            }
            else
            {
                var cycleEventNumbers = approach.IsProtectedPhaseOverlap
                    ? new List<int> {61, 63, 64, 66}
                    : new List<int> {1, 8, 9};
                var eventsAfterEndDate = celRepository.GetTopEventsAfterDateByEventCodesParam(approach.SignalID,
                    endDate, cycleEventNumbers, approach.ProtectedPhaseNumber, 3);
                if (eventsAfterEndDate != null)
                    cycleEvents.AddRange(eventsAfterEndDate);
            }
        }

        public static List<CycleSplitFail> GetSplitFailCycles(SplitFailOptions options, Approach approach,
            bool getPermissivePhase)
        {
            var cycleEvents = GetCycleEvents(getPermissivePhase, options.StartDate, options.EndDate, approach);
            if (cycleEvents != null && cycleEvents.Count > 0 && GetEventType(cycleEvents.LastOrDefault().EventCode) !=
                RedToRedCycle.EventType.ChangeToGreen)
                GetEventsToCompleteCycle(getPermissivePhase, options.EndDate, approach, cycleEvents);
            var terminationEvents =
                GetTerminationEvents(getPermissivePhase, options.StartDate, options.EndDate, approach);
            var cycles = new List<CycleSplitFail>();
            for (var i = 0; i < cycleEvents.Count - 3; i++)
                if ( GetEventType(cycleEvents[i].EventCode) == RedToRedCycle.EventType.ChangeToGreen
                    && GetEventType(cycleEvents[i + 1].EventCode) == RedToRedCycle.EventType.ChangeToYellow
                    && GetEventType(cycleEvents[i + 2].EventCode) == RedToRedCycle.EventType.ChangeToRed
                    && (GetEventType(cycleEvents[i + 3].EventCode) == RedToRedCycle.EventType.ChangeToGreen || cycleEvents[i + 3].EventCode == 66))
                {
                    var termEvent = GetTerminationEventBetweenStartAndEnd(cycleEvents[i].Timestamp,
                        cycleEvents[i + 3].Timestamp, terminationEvents);
                    cycles.Add(new CycleSplitFail(cycleEvents[i].Timestamp, cycleEvents[i + 2].Timestamp,
                        cycleEvents[i + 1].Timestamp, cycleEvents[i + 3].Timestamp, termEvent,
                        options.FirstSecondsOfRed));
                    //i = i + 2;
                }
            return cycles;
        }

        private static CycleSplitFail.TerminationType GetTerminationEventBetweenStartAndEnd(DateTime start,
            DateTime end, List<Controller_Event_Log> terminationEvents)
        {
            var terminationType = CycleSplitFail.TerminationType.Unknown;
            var terminationEvent = terminationEvents.FirstOrDefault(t => t.Timestamp > start && t.Timestamp <= end);
            if (terminationEvent != null)
                switch (terminationEvent.EventCode)
                {
                    case 4:
                        terminationType = CycleSplitFail.TerminationType.GapOut;
                        break;
                    case 5:
                        terminationType = CycleSplitFail.TerminationType.MaxOut;
                        break;
                    case 6:
                        terminationType = CycleSplitFail.TerminationType.ForceOff;
                        break;
                    default:
                        terminationType = CycleSplitFail.TerminationType.Unknown;
                        break;
                }
            return terminationType;
        }

        private static List<Controller_Event_Log> GetTerminationEvents(bool getPermissivePhase, DateTime startDate,
            DateTime endDate,
            Approach approach)
        {
            var celRepository = ControllerEventLogRepositoryFactory.Create();
            var cycleEvents = celRepository.GetEventsByEventCodesParam(approach.SignalID, startDate,
                endDate, new List<int> {4, 5, 6},
                getPermissivePhase ? approach.PermissivePhaseNumber.Value : approach.ProtectedPhaseNumber);
            return cycleEvents;
        }
    }
}