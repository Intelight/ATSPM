﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration;

namespace MOE.Common.Models
{
    public class PreemptionAggregation : Aggregation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        [Required]
        public override DateTime BinStartTime { get; set; }

        [Required]
        [StringLength(10)]
        public string SignalId { get; set; }

        [ForeignKey("Signal")]
        public int VersionId { get; set; }

        public virtual Signal Signal { get; set; }

        [Required]
        public int PreemptNumber { get; set; }

        [Required]
        public int PreemptRequests { get; set; }

        [Required]
        public int PreemptServices { get; set; }
        

        public sealed class PreemptionAggregationClassMap : ClassMap<PreemptionAggregation>
        {
            public PreemptionAggregationClassMap()
            {
                Map(m => m.Signal).Ignore();
                Map(m => m.Id).Name("Record Number");
                Map(m => m.BinStartTime).Name("Bin Start Time");
                Map(m => m.VersionId).Name("Version ID");
                Map(m => m.PreemptNumber).Name("Preempt Number");
                Map(m => m.PreemptRequests).Name("Preempt Requests");
                Map(m => m.PreemptServices).Name("Preempt Services");
            }
        }
    }
}