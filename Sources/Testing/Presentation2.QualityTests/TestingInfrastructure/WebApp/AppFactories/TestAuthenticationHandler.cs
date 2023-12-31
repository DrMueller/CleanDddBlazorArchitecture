﻿using System.Security.Claims;
using System.Text.Encodings.Web;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Mmu.CleanBlazor.Presentation2.QualityTests.TestingInfrastructure.WebApp.AppFactories
{
    [UsedImplicitly]
    public class TestAuthenticationHandler : AuthenticationHandler<TestAuthenticationOptions>
    {
        public TestAuthenticationHandler(
            IOptionsMonitor<TestAuthenticationOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authenticationTicket = new AuthenticationTicket(
                new ClaimsPrincipal(Options.Identity),
                new AuthenticationProperties(),
                "Test Scheme");

            return Task.FromResult(AuthenticateResult.Success(authenticationTicket));
        }
    }

    public class TestAuthenticationOptions : AuthenticationSchemeOptions
    {
        public ClaimsIdentity Identity { get; } = new(
            new[]
            {
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", Guid.NewGuid().ToString())
            },
            "test");
    }
}