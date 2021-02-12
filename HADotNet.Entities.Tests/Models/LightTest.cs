﻿using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using HADotNet.Core;
using HADotNet.Core.Clients;
using HADotNet.Entities.Models;

namespace HADotNet.Entities.Tests.Models
{
    public class LightTest
    {
        private const string MY_LIGHT = "my_light";

        private EntitiesService _entitiesService;

        [SetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey);

            var statesClient = ClientFactory.GetClient<StatesClient>();
            var entityClient = ClientFactory.GetClient<EntityClient>();

            _entitiesService = new EntitiesService(entityClient, statesClient);
        }

        [Test, Explicit]
        public async Task TurnOn_ShouldTurnLightOn()
        {
            var light = await _entitiesService.GetEntity<Light>(MY_LIGHT);

            await light.TurnOn();

            Thread.Sleep(5000);

            await light.TurnOff();
        }
    }
}
