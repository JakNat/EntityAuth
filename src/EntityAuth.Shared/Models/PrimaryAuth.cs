﻿using System;

namespace EntityAuth.Shared.Models
{
    /// <summary>
    /// Marker for resources.
    /// Supported identifier types:
    /// <see cref="int"/>
    /// ,<see cref="long"/>
    /// ,<see cref="Guid"/>
    /// </summary>
    public interface IResourceId<T> 
    {
        public T Id { get; set; }
    }
}
