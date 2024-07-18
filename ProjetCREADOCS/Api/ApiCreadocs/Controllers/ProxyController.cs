using Microsoft.AspNetCore.Mvc;

namespace ApiCreadocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        [HttpPost("proxy")]
        public async Task<IActionResult> Proxy([FromBody] string xmlData)
        {
            using (var client = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(xmlData), "xml:DATA");

                var response = await client.PostAsync("https://contenthub-fr.test.omscloud.eu/mtext-integration-adapter/template/RELEVE_K6/Templates/RELEVE_K6.template/export?document-name=RELEVE1234567&mime-type=application%2Fpdf&user=user_ADV&passwordplain=demo", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStreamAsync();
                    return File(result, "application/pdf", "RELEVE1234567.pdf");
                }

                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }
    }
}
