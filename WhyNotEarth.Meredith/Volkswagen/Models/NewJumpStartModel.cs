﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using WhyNotEarth.Meredith.Validation;

namespace WhyNotEarth.Meredith.Volkswagen.Models
{
    public class NewJumpStartModel
    {
        [NotNull]
        [Mandatory]
        public DateTime? DateTime { get; set; }

        [NotNull]
        [Mandatory]
        public string? Subject { get; set; }

        [NotNull]
        [Mandatory]
        public List<string>? DistributionGroups { get; set; }

        public List<string>? Tags { get; set; }

        public string? Body { get; set; }

        public string? PdfUrl { get; set; }
    }
}