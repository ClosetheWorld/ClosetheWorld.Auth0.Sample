using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Authentication
{
    public static class Auth0ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static AuthenticationBuilder AddAuth0Bearer(this AuthenticationBuilder builder, Action<Auth0Settings> settings)
        {
            builder.Services.Configure(settings);
            builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureAuth0Options>();
            builder.AddJwtBearer();
            return builder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static AuthenticationBuilder AddAuth0Bearer(this AuthenticationBuilder builder)
            => builder.AddAuth0Bearer(_ => { });

        /// <summary>
        /// 
        /// </summary>
        private class ConfigureAuth0Options : IConfigureNamedOptions<JwtBearerOptions>
        {
            private readonly Auth0Settings auth0Settings;

            /// <summary>
            /// constructor
            /// </summary>
            /// <param name="auth0Settings"></param>
            public ConfigureAuth0Options(IOptions<Auth0Settings> auth0Settings)
            {
                this.auth0Settings = auth0Settings.Value;
            }

            /// <summary>
            /// Set authority, audience
            /// </summary>
            /// <param name="name"></param>
            /// <param name="options"></param>
            public void Configure(string name, JwtBearerOptions options)
            {
                options.Authority = auth0Settings.TenantUrl;
                options.Audience = auth0Settings.Identifier;
            }

            /// <summary>
            /// Call Configure method
            /// </summary>
            /// <param name="options"></param>
            public void Configure(JwtBearerOptions options)
            {
                Configure(Options.DefaultName, options);
            }
        }
    }
}
