using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
using THE_MBURUS_FARM.DBL;
using THE_MBURUS_FARM;

namespace THE_MBURUS_FARM.Middlewares
{
    public class ClientAppAuth
    {

        private readonly RequestDelegate _next;

        public ClientAppAuth(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string authMessage = "Authorization failed!";
            try
            {
                //---- Get auth header
                string authHeader = httpContext.Request.Headers["Authorization"];
                //Util.LogError("ClientAppAuth", new Exception(authHeader));

                if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Basic", StringComparison.OrdinalIgnoreCase))
                {
                    //---- Readrequest data
                    httpContext.Request.EnableRewind();
                    string jsonData = new StreamReader(httpContext.Request.Body).ReadToEnd();
                    Util.LogError("ClientAppAuth", new Exception(jsonData));

                    var reqData = JsonConvert.DeserializeObject<dynamic>(jsonData);
                    // Util.LogError("ClientAppAuth", new Exception(reqData));
                    string timeStamp = reqData.tmp;
                    Bl bl = new Bl(Util.GetDbConnString());
                    var resp = bl.AuthorizeClientApp(authHeader, timeStamp);
                    if (resp.RespStatus == 0)
                    {
                        //---- Add data
                        reqData.AppCode = Convert.ToInt32(resp.Data1);
                        reqData.ServiceCode = Convert.ToInt32(resp.Data2);
                        jsonData = JsonConvert.SerializeObject(reqData);
                        Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                        var myData = encoding.GetBytes(jsonData);
                        var stream = new MemoryStream(myData);
                        httpContext.Request.Body = stream;
                        return _next(httpContext);
                    }
                    else
                        authMessage = resp.RespMessage;
                }
                else
                    authMessage = "Authorization details not found!";
            }
            catch (Exception ex)
            {
                Util.LogError("ClientAppAuth", ex);
                authMessage = "Failed to authorize request due to an error!";
            }

            httpContext.Response.StatusCode = 401; //Unauthorized
            return httpContext.Response.WriteAsync(authMessage);
        }
    }


    public static class ClientAppAuthExtensions
    {
        public static IApplicationBuilder UseClientAppAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ClientAppAuth>();
        }
    }
}
