﻿using System;
using Axxes.ToyCollector.Core.Models;

namespace Axxes.ToyCollector.Plugins.Lego.Models
{
    public class LegoSet : Toy
    {
        public string SetNumber { get; set; }
        public bool Unopened { get; set; }
        public DateTime? FinishedBuildDate { get; set; }
    }
}