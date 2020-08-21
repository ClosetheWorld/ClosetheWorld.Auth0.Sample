namespace Microsoft.AspNetCore.Authentication
{
    /// <summary>
    /// Auth0 setting values for token challenge
    /// </summary>
    public class Auth0Settings
    {
        /// <summary>
        /// Auth0 tenant url
        /// </summary>
        public string TenantUrl { get; set; }

        /// <summary>
        /// Auth0 api identifier ex. https://myapi/
        /// </summary>
        public string Identifier { get; set; }
    }
}
