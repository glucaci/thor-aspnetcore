using Thor.Core.Abstractions;

namespace Thor.AspNetCore
{
    /// <summary>
    /// A concrete configuration for the <c>AspNetCore</c> which contains specific <c>aspnet</c> parts.
    /// </summary>
    public class TracingStartupConfiguration
        : TracingConfiguration
    {
        /// <summary>
        /// Gets or sets the application id.
        /// </summary>
        public int ApplicationId { get; set; }
    }
}