﻿using Axxes.ToyCollector.DataAccess.Contracts.EF;
using Axxes.ToyCollector.Plugins.Marbles.DataAccess.EntityMapping;
using Microsoft.EntityFrameworkCore;

namespace Axxes.ToyCollector.Plugins.Marbles.DataAccess
{
    public class ToyContextMableExtension : IExtendToyContext
    {
        public void LoadToyContextExtensions(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MarbleMapping());
        }
    }
}