using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Net.Http.Headers;

namespace SPID_Middleware_Client.Pages
{
    [EnableCors]
    [IgnoreAntiforgeryToken]
    public class authstatusModel : PageModel
    {

        public string requestId { get; set; } = "";

        public string msgToDisp { get; set; } = "";

        public bool ReqStatus { get; set; } = false;
        public string ErrorCode { get; set; } = "";
        public string StatusMessage { get; set; } = "";
        public string ClaimsJSON { get; set; } = "";
        public string SAMLResp { get; set; } = "";

        public IActionResult OnPost()
        {
            msgToDisp = "POST Used";
            var req = Request;
            if(req.Form != null)
            {
                if (req.Form.ContainsKey("id"))
                {
                    requestId = req.Form["id"].ToString();
                }
                if (req.Form.ContainsKey("status"))
                {
                    ReqStatus = bool.Parse(req.Form["status"].ToString());
                }
                if (req.Form.ContainsKey("claimsJSON"))
                {
                    ClaimsJSON = req.Form["claimsJSON"].ToString();
                }
                if (req.Form.ContainsKey("errorCode"))
                {
                    ErrorCode = req.Form["errorCode"].ToString();
                }
                if (req.Form.ContainsKey("statusMsg"))
                {
                    StatusMessage = req.Form["statusMsg"].ToString();
                }
                if (req.Form.ContainsKey("samlresp"))
                {
                    SAMLResp = req.Form["samlresp"].ToString();
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnGet()
        {
            msgToDisp = "Get Used";
            //string reqId = Request.Query["id"];
            //if(string.IsNullOrEmpty(reqId))
            //{
            //    return Page();
            //}
            //var handler = new HttpClientHandler();
            //handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            //handler.ServerCertificateCustomValidationCallback =
            //    (httpRequestMessage, cert, cetChain, policyErrors) =>
            //    {
            //        return true;
            //    };

            //using (HttpClient client = new HttpClient(handler))
            //{
            //    client.BaseAddress = new Uri($"https://192.168.1.103:5001/api/Results?requestId={reqId}");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    HttpResponseMessage resp = await client.GetAsync("");
            //    if (resp.IsSuccessStatusCode)
            //    {
            //        var dat = await resp.Content.ReadAsStringAsync();
            //        ViewData["Resp"] = dat;
            //    }
            //    else
            //    {
            //        ViewData["Resp"] = "Error";
            //    }
            //}
            return Page();
        }
    }
}
