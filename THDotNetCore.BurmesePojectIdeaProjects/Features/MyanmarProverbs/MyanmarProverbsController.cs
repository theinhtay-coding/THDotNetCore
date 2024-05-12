using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using THDotNetCore.BurmesePojectIdeaProjects.Models;

namespace THDotNetCore.BurmesePojectIdeaProjects.Features.MyanmarProverbs
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbsController : ControllerBase
    {
        private readonly MMProverbModel _data;
        public MyanmarProverbsController()
        {

        }

        private async Task<MMProverbModel> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("MyanmarProverbs_Data.json");
            var model = JsonConvert.DeserializeObject<MMProverbModel>(jsonStr);
            return model!;
        }

        [HttpGet("title")]
        public async Task<IActionResult> Titles()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbsTitle);
        }

        [HttpGet("subtitle/{titleId}")]
        public async Task<IActionResult> GetSubtitleById(int titleId)
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbs
                            .Where(x => x.TitleId == titleId)
                            .Select(x => new { x.ProverbId, x.ProverbName })
                            .ToList());
        }

        [HttpGet("mmproverbs/{titleId}/{proverbId}")]
        public async Task<IActionResult> Proverbs(int titleId, int proverbId)
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbs.Where(x => x.TitleId == titleId && x.ProverbId == proverbId).FirstOrDefault());
        }
    }
}
