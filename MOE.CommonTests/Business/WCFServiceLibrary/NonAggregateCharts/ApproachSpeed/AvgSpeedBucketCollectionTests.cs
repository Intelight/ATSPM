﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MOE.Common.Business;

namespace MOE.CommonTests.Business.WCFServiceLibrary.NonAggregateCharts.ApproachSpeed
{
    [TestClass()]
    public class AvgSpeedBucketCollectionTests
    {
        [TestMethod()]
        public void AvgSpeedBucketCollectionTest()
        {
            List<CycleSpeed> cycles = new List<CycleSpeed>(); 
            AvgSpeedBucketCollection asbc = new AvgSpeedBucketCollection(DateTime.Now.AddDays(-1), DateTime.Now, 5, 5, cycles);

            List<Common.Models.Speed_Events> lse = new List<Common.Models.Speed_Events>();

            Common.Models.Speed_Events se1 = new Common.Models.Speed_Events();
            se1.DetectorID = "100001";
            se1.MPH = 30;
            se1.timestamp = Convert.ToDateTime("10/26/2017 12:01");

            Common.Models.Speed_Events se2 = new Common.Models.Speed_Events();
            se2.DetectorID = "100001";
            se2.MPH = 30;
            se2.timestamp = Convert.ToDateTime("10/26/2017 12:02");

            Common.Models.Speed_Events se3 = new Common.Models.Speed_Events();
            se3.DetectorID = "100001";
            se3.MPH = 30;
            se3.timestamp = Convert.ToDateTime("10/26/2017 12:03");

            lse.Add(se1);
            lse.Add(se2);
            lse.Add(se3);


            int testAverage = asbc.GetAverageSpeed(lse);

            Assert.IsTrue(testAverage == 30);
        }
    }
}