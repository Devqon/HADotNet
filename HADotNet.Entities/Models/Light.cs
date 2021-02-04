﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HADotNet.Core.Constants;
using HADotNet.Core.Models;

namespace HADotNet.Entities.Models
{
    /// <summary>
    /// Represents a light entity
    /// </summary>
    public class Light : Entity
    {
        /// <summary>
        /// Creates a light entity
        /// </summary>
        public Light() : base(DomainConstants.Light)
        {
        }

        /// <summary>
        /// Turn on the light
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> TurnOn()
        {
            return CallService(ServiceConstants.TurnOn);
        }

        /// <summary>
        /// Turn off the light
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> TurnOff()
        {
            return CallService(ServiceConstants.TurnOff);
        }

        /// <summary>
        /// Toggle the light
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> Toggle()
        {
            return CallService(ServiceConstants.Toggle);
        }
    }
}