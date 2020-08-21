using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace NM.Template.Bdc.Api.Utils
{
    /// <summary>
    /// ApiResult封装
    /// </summary>
    public class ApiResultFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Action执行完成,返回结果处理
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null)
            {   //执行成功 取得由 API 返回的资料
                ObjectResult result = actionExecutedContext.Result as ObjectResult;
                if (result != null)
                {   // 重新封装回传格式
                    Robj<object> robj = new Robj<object>();
                    robj.Success(result.Value);
                    ObjectResult objectResult = new ObjectResult(robj);
                    actionExecutedContext.Result = objectResult;
                }
            }
            else
            {
                Robj<string> robj = new Robj<string>();
                robj.Error(actionExecutedContext.Exception.Message);
                ObjectResult objectResult = new ObjectResult(robj);
                actionExecutedContext.Result = objectResult;
                actionExecutedContext.Exception = null;
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }

    /// <summary>
    /// 返回结果对象
    /// ReturnObject Robj 
    /// 默认RCode为成功,Message为成功.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Robj<T>
    {
        /// <summary>
        /// 结果
        /// </summary>
        public T Result { get; set; } = default;
        /// <summary>
        /// 执行结果
        /// </summary>
        public RCode Code { get; set; } = RCode.Success;
        /// <summary>
        /// 提示消息
        /// </summary>
        public string Message { get; set; } = "操作成功";

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="result">返回结果</param>
        /// <param name="msg">提示消息</param>
        public void Success(T result, string msg = "操作成功")
        {
            Code = RCode.Success;
            Result = result;
            Message = msg;
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="msg">提示消息</param>
        /// <param name="code"></param>
        public void Error(string msg, RCode code = RCode.Exception)
        {
            Code = code;
            Message = msg;
        }
    }

    /// <summary>
    /// 返回Code
    /// </summary>
    public enum RCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [JsonProperty("1000")]
        Success = 1000,

        /// <summary>
        /// 登录超时,需重新登录
        /// </summary>
        [JsonProperty("2000")]
        NeedLogin = 2000,

        /// <summary>
        /// 程序异常
        /// </summary>
        [JsonProperty("3000")]
        Exception = 3000,

        /// <summary>
        /// 系统错误
        /// </summary>
        [JsonProperty("4000")]
        SysError = 4000,
        /// <summary>
        /// 请求失败
        /// </summary>
        [JsonProperty("9000")]
        Failure = 9000,
    }
}
