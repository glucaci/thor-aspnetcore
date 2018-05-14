﻿using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DiagnosticAdapter;
using Thor.Core.Http;

namespace Thor.AspNetCore
{
    internal class HostingDiagnosticsListener
        : IDiagnosticsListener
    {
        public string Name { get; } = "Microsoft.AspNetCore";

        [DiagnosticName("Microsoft.AspNetCore.Diagnostics.HandledException")]
        public void OnDiagnosticsHandledException(HttpContext httpContext, Exception exception)
        {
            HandleException(httpContext, exception);
        }

        [DiagnosticName("Microsoft.AspNetCore.Diagnostics.UnhandledException")]
        public void OnDiagnosticsUnhandledException(HttpContext httpContext, Exception exception)
        {
            HandleException(httpContext, exception);
        }

        [DiagnosticName("Microsoft.AspNetCore.Hosting.UnhandledException")]
        public void OnHostingException(HttpContext httpContext, Exception exception)
        {
            HandleException(httpContext, exception);
        }

        [DiagnosticName("Microsoft.AspNetCore.Hosting.HttpRequestIn")]
        public void OnHttpRequestIn()
        {
            // do nothing here
        }

        [DiagnosticName("Microsoft.AspNetCore.Hosting.HttpRequestIn.Start")]
        public void OnHttpRequestInStart(HttpContext httpContext)
        {
            // todo: implement advanced request tracing
            // todo: implement tracing id

            Uri requestUri = new Uri(httpContext.Request.GetDisplayUrl());
            ServerRequestActivity activity = ServerRequestActivity.Create(httpContext.Request.Method,
                requestUri, null);

            httpContext.Features.Set(activity);
        }

        [DiagnosticName("Microsoft.AspNetCore.Hosting.HttpRequestIn.Stop")]
        public void OnHttpRequestInStop(HttpContext httpContext)
        {
            ServerRequestActivity activity = httpContext.Features.Get<ServerRequestActivity>();

            if (activity != null)
            {
                activity.SetResponse(httpContext.Response.StatusCode, httpContext.User.GetId());
                activity.Dispose();
            }
        }

        private void HandleException(HttpContext httpContext, Exception exception)
        {
            httpContext?.Features.Get<ServerRequestActivity>()?.HandleException(exception);
        }
    }
}