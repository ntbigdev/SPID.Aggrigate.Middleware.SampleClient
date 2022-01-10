using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SPID_Middleware_Client.Pages
{
    public class ResponseModel : PageModel
    {
        public void OnGet()
        {
            var req = Request.Headers;
        }

        public void OnPost()
        {
            var req = Request.Headers;
        }
    }
}
