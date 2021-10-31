﻿using System;
using System.Threading.Tasks;
using AerisWeather.Net.Models.Exceptions;
using Xunit;

namespace AerisWeather.Net.Tests.Unit.SunMoonUnitTests
{
    public class Today_Zip : BaseSunMoonUnitTests
    {
        [Fact]
        public async Task Today_Location_Happy_Path()
        {
            HappySetUp();

            var result = await this.sunMoon.TodayAsync(35143);

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task Today_Location_WHEN_client_returns_EMPTY_LIST()
        {
            EmptyListSetUp();

            var result = await this.sunMoon.TodayAsync(35143);

            Assert.Empty(result);
        }

        [Fact]
        public async Task Today_Location_WHEN_client_returns_NULL()
        {
            NullSetUp();

            var result = await this.sunMoon.TodayAsync(35143);

            Assert.Null(result);

        }

        [Fact]
        public async Task Today_Location_WHEN_client_throws_LocationNotFound()
        {
            LocationNotFoundSetUp();

            await Assert.ThrowsAsync<LocationNotFoundException>(() => this.sunMoon.TodayAsync(35143));
        }
    }
}
