using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace DNWS
{
    class ClientInfoPlugin : IPlugin
    {
        public void PreProcessing(HTTPRequest request)
        {
            
        }

        public HTTPResponse GetResponse(HTTPRequest request)
        {
            HTTPResponse response = new HTTPResponse(200);
            StringBuilder sb = new StringBuilder();

            IPEndPoint ep = IPEndPoint.Parse(
                request.getPropertyByKey("remoteendpoint")
            );

            sb.Append("<html><body><pre>");
            sb.Append("Client IP Address: " + ep.Address + "\n");
            sb.Append("Client Port: " + ep.Port + "\n");
            sb.Append("Browser Information: " + request.getPropertyByKey("user-agent") + "\n");
            sb.Append("Accept-Language: " + request.getPropertyByKey("accept-language") + "\n");
            sb.Append("Accept-Encoding: " + request.getPropertyByKey("accept-encoding") + "\n");
            sb.Append("</pre></body></html>");

            response.body = Encoding.UTF8.GetBytes(sb.ToString());
            return response;
        }

        public HTTPResponse PostProcessing(HTTPResponse response)
        {
            return response;
        }
    }
}
