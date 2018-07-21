using HttpHelper;
using HttpTaskManage;
using HttpTaskModel;
using log4net;
using SpiderContract;
using SpiderContract.WebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderClient
{
    public class SchedulerTask
    {
        public SchedulerTask(IRequestContract request)
        {
            _RequestContract = request;
        }
        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public IRequestContract _RequestContract { get; set; }
        public void RunSpider(HttpRequestCfgDataUI data)
        {
            switch (data.SchedulerType)
            {
                case SchedulerType.Single:
                    break;
                case SchedulerType.Date:
                    RunDate(data);
                    break;
                case SchedulerType.Page:
                    RunPage(data);
                    break;
            }

            if (data.TaskStatus != HttpTaskModel.TaskStatus.TaskFailed)
                data.TaskStatus = HttpTaskModel.TaskStatus.Complete;
            _RequestContract.HttpRequestCfgSave(data);
        }

        void RunDate(HttpRequestCfgDataUI data)
        {
            HttpServer _HotelServer = new HttpServer();
            HttpResult _Result;
            string info = "";
            var item = data.HttpRequestChildCfgs[0];
            _HotelServer = _createHttpserver(item);
            _HotelServer.Cookies = item.CookieContainer;
            while (data.CurrentDate <= data.DateMax)
            {
                _HotelServer.Url = string.Format(_HotelServer.Url, data.CurrentDate.Value.AddDays(1).ToString("yyyy-MM-DD HH:mm:ss"), data.CurrentDate.Value.ToString("yyyy-MM-DD HH:mm:ss"));
                _HotelServer.PostData = string.Format(_HotelServer.PostData, data.CurrentDate.Value.AddDays(1).ToString("yyyy-MM-DD HH:mm:ss"), data.CurrentDate.Value.ToString("yyyy-MM-DD HH:mm:ss"));
                _Result = _HotelServer.GetHttpResult();
                bool r = saveresult(_Result, item,data, out info);
                data.info = info;
                if (!r)
                {
                    data.TaskStatus = HttpTaskModel.TaskStatus.TaskFailed;
                    break;
                }
                data.CurrentDate = data.CurrentDate.Value.AddDays(1);
                Thread.Sleep(2000);
            }
        }

        private bool saveresult(HttpResult _Result, HttpTaskModel.HttpRequestChildCfg item, HttpRequestCfg data, out string info)
        {
            info = "";
            try
            {
                HttpResultCfgDataUI re = new HttpResultCfgDataUI() { Binary = _Result.ResultByte, CreatedTime = DateTime.Now, FullText = _Result.Html, HttpStatusCode = _Result.StatusCode, Key = item.Key, RequstChildId = item.Id, ResponseType = item.ResponseType, SeqNo = item.SeqNo, TaskStatus = HttpTaskModel.TaskStatus.Complete };
                var r = _RequestContract.HttpResultCfgAdd(re);
                return r.IsSuccess;
            }
            catch (Exception ex)
            {
                info = ex.Message;
                logger.ErrorFormat("提交请求结果失败", ex);
                return false;
            }
        }

        void RunPage(HttpRequestCfgDataUI data)
        {
            HttpServer _HotelServer = new HttpServer();
            HttpResult _Result;
            string info = "";
            var item = data.HttpRequestChildCfgs[0];
            _HotelServer = _createHttpserver(item);
            if (data.CurrentPage == -1)
                data.CurrentPage = data.PageMin;
            while (data.CurrentPage <= data.PageMax)
            {
                _HotelServer.Url = _HotelServer.Url.Replace("{page}", data.CurrentPage.ToString());
                _HotelServer.PostData = _HotelServer.PostData.Replace("{page}", data.CurrentPage.ToString());
                _Result = _HotelServer.GetHttpResult();
                bool r = saveresult(_Result, item, data, out info);
                data.info = info;
                if (!r)
                {
                    data.TaskStatus = HttpTaskModel.TaskStatus.TaskFailed;
                    break;
                }
                var d = _RequestContract.HttpRequestCfgSaveStatus(data.Id, data.TaskStatus, data.CurrentPage, data.CurrentDate, info);
                data.CurrentPage++;
                Thread.Sleep(2000);
            }
        }

        private static HttpServer _createHttpserver(HttpRequestChildCfg item)
        {
            HttpServer _HotelServer;
            _HotelServer = _createHttpserver(item);
            return _HotelServer;
        }

        void RunSingle(HttpRequestCfgDataUI data)
        {
            HttpServer _HotelServer = new HttpServer();
            HttpResult _Result;
            string info = "";
            foreach (var item in data.HttpRequestChildCfgs)
            {
                _HotelServer = _createHttpserver(item);
                _Result = _HotelServer.GetHttpResult();
                bool r = saveresult(_Result, item,data, out info);
                data.info = info;
                if (!r)
                {
                    data.TaskStatus = HttpTaskModel.TaskStatus.TaskFailed;
                    break;
                }
                Thread.Sleep(2000);
            }
        }
    }
}
