﻿using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Net.Http.Headers;

namespace EcommerceMedDistUI.Authentication
{
    public class CustomAuthorizationHeaderHandler : DelegatingHandler
    {
        private readonly IAccessTokenProviderAccessor _accessor;

        public CustomAuthorizationHeaderHandler(IAccessTokenProviderAccessor accessor)
        {
            _accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessTokenResult = await _accessor.TokenProvider.RequestAccessToken();
            if (accessTokenResult.TryGetToken(out var accessToken) && !String.IsNullOrWhiteSpace(accessToken.Value))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Value);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
