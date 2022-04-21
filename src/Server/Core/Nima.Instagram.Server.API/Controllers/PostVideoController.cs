using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nima.Instagram.Server.API.Core.Services.UnitOFWork;
using Nima.Instagram.Shared.Server.Models.Posts.Video.Frame;
using System.Net;

namespace Nima.Instagram.Server.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostVideoController : ControllerBase
    {
        private readonly IUnitOFWorkRepository unitOFWork;

        public PostVideoController(IUnitOFWorkRepository unitOFWork)
        {
            this.unitOFWork = unitOFWork;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(PostVideoController), (int) HttpStatusCode.OK)]
        public async Task<IEnumerable<VideoModel>> GetAll()
        {
            return await unitOFWork.VideoPostRepository.GetAllAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [ProducesResponseType(typeof(PostVideoController), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(PostVideoController), (int) HttpStatusCode.NotFound)]
        public async Task<ActionResult<VideoModel>> GetById(Guid id)
        {
            var item = await unitOFWork.VideoPostRepository.GetByIdAsync(id);
            if (item != null)
                return item;
            return NotFound();
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(PostVideoController), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(PostVideoController), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<VideoModel>> Add([FromForm] VideoModel model)
        {
            return NotFound();
        }
    }
}
