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

namespace SpiderContract
{
    //[ServiceContract(CallbackContract = typeof(IResponseCallback))]
    [ServiceContract]
    public interface IRequestContract
    {
        /// <summary>
        /// 获取任务
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpTask/HttpRequestCfgGet?webname={webname}&level={level}", Method = "GET",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(ResponseDataBase<HttpRequestCfgDataUI>))]
        ResponseDataBase<HttpRequestCfgDataUI> HttpRequestCfgGet(string webname, int level);

        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpTask/HttpRequestCfgSave", Method = "POST",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(ResponseBase))]
        ResponseBase HttpRequestCfgSave(HttpRequestCfgDataUI data);


        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpTask/HttpRequestCfgAdd", Method = "POST",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(ResponseBoolBase))]
        ResponseBoolBase HttpRequestCfgAdd(HttpRequestCfgDataUI data);

        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpTask/HttpRequestChildCfgSave", Method = "POST",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(ResponseBoolBase))]
        ResponseBoolBase HttpRequestChildCfgAdd(HttpRequestCfgDataUI data);
        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpTask/HttpResultCfgAdd", Method = "POST",
                     ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        [ServiceKnownType(typeof(ResponseBoolBase))]
        ResponseBoolBase HttpResultCfgAdd(HttpResultCfgDataUI data);
        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpTask/HttpResultCfgSave", Method = "POST",
                     ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ResponseBoolBase HttpResultCfgSave(HttpResultCfgRequest data);

        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpTask/HttpRequestCfgSaveStatus", Method = "POST",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [ServiceKnownType(typeof(ResponseBoolBase))]
        ResponseBoolBase HttpRequestCfgSaveStatus(long id, TaskStatus status);
        [OperationContract]
        [DataContractFormat]
        [WebInvoke(UriTemplate = "HttpTask/HttpRequestChildCfgSaveStatus", Method = "POST",
                ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [ServiceKnownType(typeof(ResponseBoolBase))]
        ResponseBoolBase HttpRequestChildCfgSaveStatus(long id, HttpTaskModel.TaskStatus status);


        //[OperationContract(IsOneWay = true, AsyncPattern = true)]
        void Subscribe();

        //[OperationContract(IsOneWay = true, AsyncPattern = true)]
        void Unsubscribe();
    }
}
