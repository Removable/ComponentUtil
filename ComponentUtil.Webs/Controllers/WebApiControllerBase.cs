using Microsoft.AspNetCore.Mvc;

namespace ComponentUtil.Webs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class WebApiControllerBase
    {
        /// <summary>
        ///     返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        protected virtual IActionResult Success(dynamic data = null, string message = null)
        {
            message ??= "成功";
            return new Result(StateCode.Ok, message, data);
        }

        /// <summary>
        ///     返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        protected virtual IActionResult Fail(string message)
        {
            return new Result(StateCode.Fail, message);
        }
    }
}