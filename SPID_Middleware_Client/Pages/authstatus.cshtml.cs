using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Net.Http.Headers;

namespace SPID_Middleware_Client.Pages
{
    public class authstatusModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            string reqId = Request.Query["id"];
            if(string.IsNullOrEmpty(reqId))
            {
                return Page();
            }
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };

            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri($"https://192.168.1.103:5001/api/Results?requestId={reqId}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resp = await client.GetAsync("");
                if (resp.IsSuccessStatusCode)
                {
                    var dat = await resp.Content.ReadAsStringAsync();
                    ViewData["Resp"] = dat;
                }
                else
                {
                    ViewData["Resp"] = "Error";
                }
            }
            return Page();
        }
    }
}
