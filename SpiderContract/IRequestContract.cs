using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using HttpTaskModel;
using System.ServiceModel.Web;
using SpiderContract.WebServices;
using SpiderContract.WebServices.Models;
using SpiderContract.WebServices.Requests;
using HttpTaskManage;

namespace SpiderContract
{
    //[ServiceContract(CallbackContract = typeof(IResponseCallback))]
    [ServiceContract]
    public interface IRequestContract
    {
        #region  HttpRequest
        /// <summary>
        /// 获取任务
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpTask/HttpRequestCfgGet?webname={webname}&level={level}&status={status}", Method = "GET",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(ResponseDataBase<HttpRequestCfgDataUI>))]
        ResponseDataBase<HttpRequestCfgDataUI> HttpRequestCfgGet(string webname, int level, TaskStatus status);

        /// <summary>
        /// 获取指定数量的任务
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpRequest/HttpRequestCfgSingleGet?level={level}&count={count}", Method = "GET",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(ResponseDataBase<HttpRequestCfgDataUI>))]
        ResponseDataBase<HttpRequestCfgDataUI> HttpRequestCfgSingleGet(int level, int count);

        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpRequest/HttpRequestCfgSave", Method = "POST",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(ResponseBase))]
        ResponseBase HttpRequestCfgSave(HttpRequestCfgDataUI data);


        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpRequest/HttpRequestCfgAdd", Method = "POST",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(ResponseBoolBase))]
        [ServiceKnownType(typeof(HttpRequestCfg))]

        ResponseBoolBase HttpRequestCfgAdd(HttpRequestCfg data);

        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpRequest/HttpRequestChildCfgSave", Method = "POST",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(ResponseBoolBase))]
        ResponseBoolBase HttpRequestChildCfgAdd(HttpRequestChildCfgDataUI data);
        //[OperationContract]
        //[DataContractFormat]
        //[WebInvoke(UriTemplate = "HttpTask/HttpResultCfgSave", Method = "POST",
        //             ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        //ResponseBoolBase HttpResultCfgAdd(HttpResultCfgRequest data);

        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpRequest/HttpRequestCfgSaveStatus", Method = "POST",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [ServiceKnownType(typeof(ResponseBoolBase))]
        ResponseBoolBase HttpRequestCfgSaveStatus(long id, TaskStatus status, int CurrentPage, DateTime? CurrentDate, string info = "");
        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpRequest/HttpRequestChildCfgSaveStatus", Method = "POST",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [ServiceKnownType(typeof(ResponseBoolBase))]
        ResponseBoolBase HttpRequestChildCfgSaveStatus(long id, HttpTaskModel.TaskStatus status);
        #endregion

        #region HttpResultCfg

        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpResult/HttpResultCfgAdd", Method = "POST",
             ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(ResponseBoolBase))]
        ResponseBoolBase HttpResultCfgAdd(HttpResultCfgDataUI data);

        /// <summary>
        /// 获取任务
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpResult/HttpResultCfgGet", Method = "POST",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(ResponseDataBase<HttpRequestCfgDataUI>))]
        ResponseDataBase<HttpResultCfg>  HttpResultCfgGet(string webname, int level, int count);
        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpResult/HttpResultCfgSaveStatus", Method = "POST",
        ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [ServiceKnownType(typeof(ResponseBoolBase))]
        ResponseBoolBase HttpResultSaveStatus(long id, HttpTaskModel.TaskStatus status, AnalyseHtmlStatus astatus);
        #endregion

        //[OperationContract(IsOneWay = true, AsyncPattern = true)]
        void Subscribe();

        //[OperationContract(IsOneWay = true, AsyncPattern = true)]
        void Unsubscribe();
    }
}
