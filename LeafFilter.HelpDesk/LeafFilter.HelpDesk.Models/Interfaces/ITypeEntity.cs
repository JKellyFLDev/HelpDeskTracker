﻿using System;

namespace LeafFilter.HelpDesk.Models.Interfaces
{
    /// <summary>
    /// Used for any static models that need to be active
    /// </summary>
    public interface ITypeEntity : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
