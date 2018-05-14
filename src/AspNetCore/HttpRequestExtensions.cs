using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Thor.AspNetCore
{
    internal static class HttpRequestExtensions
    {
        private static readonly string _activityIdKey = "Thor-ActivityId";

        public static Guid? GetActivityId(this HttpRequest request)
        {
            if (request != null &&
                request.Headers.TryGetValue(_activityIdKey, out StringValues rawActivityIds) &&
                rawActivityIds.Count > 0 &&
                Guid.TryParse(rawActivityIds[0], out Guid id) &&
                id != Guid.Empty)
            {
                return id;
            }

            return null;
        }
    }
}