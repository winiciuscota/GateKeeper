using System;
using System.Text;
using System.Threading.Tasks;
using GateKeeper.Api.Middlewares.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace GateKeeper.Api.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly BasicAuthentication _basicAuthentication;

        public AuthenticationMiddleware(RequestDelegate next, IOptionsSnapshot<BasicAuthentication> basicAuthentication)
        {
            this._basicAuthentication = basicAuthentication.Value;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                //Extract credentials
                string usernamePassword = authHeader.Substring("Basic ".Length).Trim();
                // Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                // string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                int seperatorIndex = usernamePassword.IndexOf(':');

                var username = usernamePassword.Substring(0, seperatorIndex);
                var password = usernamePassword.Substring(seperatorIndex + 1);

                if (username == _basicAuthentication.Username && password == _basicAuthentication.Password)
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 401; //Unauthorized
                    return;
                }
            }
            else
            {
                // no authorization header
                context.Response.StatusCode = 401; //Unauthorized
                return;
            }
        }
    }
}