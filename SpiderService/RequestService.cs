using SpiderContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderContract.WebServices;
using SpiderContract.WebServices.Models;
using SpiderContract.WebServices.Requests;
using System.Threading;
using HttpTaskDbContext;
using System.Data.Entity;
using log4net;
using System.Reflection;
using HttpTaskModel;
using HttpTaskManage;

namespace SpiderService
{
    public class RequestService : IRequestContract
    {
        ReaderWriterLockSlim datapro = new ReaderWriterLockSlim();
        //static List<IResponseCallback> subscribers = new List<IResponseCallback>();
        //private IResponseCallback _callback;
        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public ResponseBoolBase HttpRequestCfgAdd(HttpRequestCfg data)
        {
            ResponseBoolBase obj = new ResponseBoolBase();
            try
            {
                datapro.EnterWriteLock();
                HttpTaskDBContext db = new HttpTaskDBContext();
                db.HttpRequestCfg.Add(data);
                int i = db.SaveChanges();
                if (i == 0)
                    obj.IsSuccess = false;
                else obj.IsSuccess = true;
            }
            catch (Exception ex)
            {
                obj.IsSuccess = false;
                obj = ResponseBase.GetResponseByException<ResponseBoolBase>(ex);
                logger.ErrorFormat("HttpRequestCfgAdd", ex);
            }
            finally
            {
                datapro.ExitWriteLock();
            }
            return obj;
        }

        public ResponseDataBase<HttpRequestCfgDataUI> HttpRequestCfgGet(string webname, int level, HttpTaskModel.TaskStatus status)
        {
            ResponseDataBase<HttpRequestCfgDataUI> obj = new ResponseDataBase<HttpRequestCfgDataUI>();
            try
            {
                datapro.EnterReadLock();
                HttpTaskDBContext db = new HttpTaskDBContext();
                var d = db.HttpRequestCfg.Where(x => ((x.WebName.Trim() == webname.Trim() || string.IsNullOrEmpty(webname)) || (level == -1 ? x.Level >= 0 : x.Level == level)) && x.IsDelete == false && x.TaskStatus == status).Include(x => x.HttpRequestChildCfgs);

                foreach (var item in d)
                {
                    item.TaskStatus = HttpTaskModel.TaskStatus.ServerSent;
                    var o = new HttpRequestCfgDataUI() { Cookie = item.Cookie, Level = item.Level, CreatedTime = item.CreatedTime, DeletedTime = item.DeletedTime, HasChildTask = item.HasChildTask, Host = item.Host, Id = item.Id, Key = item.Key, IsDelete = item.IsDelete, ProcessName = item.ProcessName, Quartz = item.Quartz, SeqNo = item.SeqNo, TaskStatus = item.TaskStatus, TaskTimeOut = item.TaskTimeOut, UpdatedTime = item.UpdatedTime, WebName = item.WebName };
                    o.HttpRequestChildCfgs = item.HttpRequestChildCfgs;
                    obj.data.Add(o);
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                obj = ResponseBase.GetResponseByException<ResponseDataBase<HttpRequestCfgDataUI>>(ex);
            }
            finally
            {
                datapro.ExitReadLock();
            }
            return obj;
        }

        public ResponseBase HttpRequestCfgSave(HttpRequestCfgDataUI data)
        {
            ResponseBase obj = new ResponseBase();
            try
            {
                datapro.EnterWriteLock();
                using (HttpTaskDBContext db = new HttpTaskDBContext())
                {
                    HttpRequestCfg d = new HttpRequestCfg()
                    {
                        UpdatedTime = data.UpdatedTime,
                        TaskStatus = data.TaskStatus,
                        SeqNo = data.SeqNo,
                        SearchKey = data.SearchKey,
                        Cookie = data.Cookie,
                        CreatedTime = data.CreatedTime,
                        CurrentDate = data.CurrentDate,
                        DateMax = data.DateMax,
                        CurrentPage = data.CurrentPage,
                        DateMin = data.DateMin,
                        DeletedTime = data.DeletedTime,
                        HasChildTask = data.HasChildTask,
                        Host = data.Host,
                        //HttpRequestChildCfgs =data.HttpRequestChildCfgs,
                        Id = data.Id,
                        info = data.info,
                        IsDelete = data.IsDelete,
                        Key = data.Key,
                        Level = data.Level,
                        PageMax = data.PageMax,
                        PageMin = data.PageMin,
                        ProcessName = data.ProcessName,
                        Quartz = data.Quartz,
                        SchedulerType = data.SchedulerType,
                        SearchKeys = data.SearchKeys,
                        TaskTimeOut = data.TaskTimeOut,
                        WebName = data.WebName
                    };
                    db.HttpRequestCfg.Add(d);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = ResponseBase.GetResponseByException<ResponseBase>(ex);
            }
            finally
            {
                datapro.ExitWriteLock();
            }
            return obj;
        }

        public ResponseBoolBase HttpRequestCfgSaveStatus(long id, HttpTaskModel.TaskStatus status, int CurrentPage, DateTime? CurrentDate, string info = "")
        {
            ResponseBoolBase obj = new ResponseBoolBase();
            try
            {
                datapro.EnterWriteLock();
                HttpTaskDBContext db = new HttpTaskDBContext();
                var d = db.HttpRequestCfg.Find(id);
                d.TaskStatus = status;
                d.CurrentPage = CurrentPage;
                d.CurrentDate = CurrentDate;
                d.info = info;
                int i = db.SaveChanges();
                if (i == 0)
                    obj.IsSuccess = false;
                else obj.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj.IsSuccess = false;
                obj = ResponseBase.GetResponseByException<ResponseBoolBase>(ex);
            }
            finally
            {
                datapro.ExitWriteLock();
            }
            return obj;
        }

        public ResponseDataBase<HttpRequestCfgDataUI> HttpRequestCfgSingleGet(int level, int count)
        {
            ResponseDataBase<HttpRequestCfgDataUI> obj = new ResponseDataBase<HttpRequestCfgDataUI>();
            try
            {
                datapro.EnterReadLock();
                HttpTaskDBContext db = new HttpTaskDBContext();
                var d = db.HttpRequestCfg.Where(x => (level == -1 ? x.Level >= 0 : x.Level == level) && x.IsDelete == false).Take(count).Include(x => x.HttpRequestChildCfgs);// && x.TaskStatus == HttpTaskModel.TaskStatus.Ready

                foreach (var item in d)
                {
                    item.TaskStatus = HttpTaskModel.TaskStatus.ServerSent;
                    var o = new HttpRequestCfgDataUI() { Cookie = item.Cookie, Level = item.Level, CreatedTime = item.CreatedTime, DeletedTime = item.DeletedTime, HasChildTask = item.HasChildTask, Host = item.Host, Id = item.Id, Key = item.Key, IsDelete = item.IsDelete, ProcessName = item.ProcessName, Quartz = item.Quartz, SeqNo = item.SeqNo, TaskStatus = item.TaskStatus, TaskTimeOut = item.TaskTimeOut, UpdatedTime = item.UpdatedTime, WebName = item.WebName, CurrentDate = item.CurrentDate, CurrentPage = item.CurrentPage, DateMax = item.DateMax, DateMin = item.DateMin, info = item.info, PageMax = item.PageMax, PageMin = item.PageMin, SchedulerType = item.SchedulerType, SearchKey = item.SearchKey, SearchKeys = item.SearchKeys };
                    o.HttpRequestChildCfgs = item.HttpRequestChildCfgs;
                    obj.data.Add(o);
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = ResponseBase.GetResponseByException<ResponseDataBase<HttpRequestCfgDataUI>>(ex);
            }
            finally
            {
                datapro.ExitReadLock();
            }
            return obj;
        }

        public ResponseBoolBase HttpRequestChildCfgAdd(HttpRequestChildCfgDataUI data)
        {
            ResponseBoolBase obj = new ResponseBoolBase();
            try
            {
                datapro.EnterWriteLock();
                using (HttpTaskDBContext db = new HttpTaskDBContext())
                {
                    db.HttpRequestChildCfg.Add(data);
                    int i = db.SaveChanges();
                    if (i == 0)
                        obj.IsSuccess = false;
                    else obj.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj.IsSuccess = false;
                obj = ResponseBase.GetResponseByException<ResponseBoolBase>(ex);
            }
            finally
            {
                datapro.ExitWriteLock();
            }
            return obj;
        }

        public ResponseBoolBase HttpRequestChildCfgSaveStatus(long id, HttpTaskModel.TaskStatus status)
        {
            ResponseBoolBase obj = new ResponseBoolBase();
            try
            {
                datapro.EnterWriteLock();
                HttpTaskDBContext db = new HttpTaskDBContext();
                var d = db.HttpRequestCfg.Find(id);
                d.TaskStatus = status;
                int i = db.SaveChanges();
                if (i == 0)
                    obj.IsSuccess = false;
                else obj.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj.IsSuccess = false;
                obj = ResponseBase.GetResponseByException<ResponseBoolBase>(ex);
            }
            finally
            {
                datapro.ExitWriteLock();
            }
            return obj;
        }

        #region 结果处理

        public ResponseBoolBase HttpResultCfgAdd(HttpResultCfgDataUI data)
        {
            ResponseBoolBase obj = new ResponseBoolBase();
            try
            {
                //datapro.EnterWriteLock();
                HttpTaskDBContext db = new HttpTaskDBContext();
                HttpResponseCfg d = new HttpResponseCfg() { Binary = data.Binary, CreatedTime = data.CreatedTime, DeletedTime = data.DeletedTime, FullText = data.FullText, HttpStatusCode = data.HttpStatusCode, Id = data.Id, info = data.info, IsDelete = data.IsDelete, Key = data.Key, Page = data.Page, RequstChildId = data.RequstChildId, ResponseType = data.ResponseType, SearchKey = data.SearchKey, SeqNo = data.SeqNo, TaskStatus = data.TaskStatus, UpdatedTime = data.UpdatedTime, AnalyseStatus = HttpTaskManage.AnalyseHtmlStatus.Created, WebName = data.WebName, Date = data.Date };
                db.HttpResultCfg.Add(d);
                int i = db.SaveChanges();
                if (i == 0)
                    obj.IsSuccess = false;
                else obj.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj.IsSuccess = false;
                obj = ResponseBase.GetResponseByException<ResponseBoolBase>(ex);
                logger.ErrorFormat("HttpResultCfgAdd", ex);
            }
            finally
            {
                //datapro.ExitWriteLock();
            }
            return obj;
        }

        public ResponseDataBase<HttpResponseCfg> HttpResultCfgGet(string webname, int level, int count)
        {
            ResponseDataBase<HttpResponseCfg> obj = new ResponseDataBase<HttpResponseCfg>();
            try
            {
                datapro.EnterReadLock();
                HttpTaskDBContext db = new HttpTaskDBContext();
                var d = db.HttpResultCfg.Where(x => x.IsDelete == false).Take(count);
                obj.data.AddRange(d);
            }
            catch (Exception ex)
            {
                obj = ResponseBase.GetResponseByException<ResponseDataBase<HttpResponseCfg>>(ex);
            }
            finally
            {
                datapro.ExitReadLock();
            }
            return obj;
        }

        public ResponseBoolBase HttpResultCfgSave(HttpResultCfgDataUI data)
        {
            ResponseBoolBase obj = new ResponseBoolBase();
            try
            {
                //datapro.EnterWriteLock();
                HttpTaskDBContext db = new HttpTaskDBContext();
                var d = db.HttpResultCfg.Find(data.Id);
                d = data;
                int i = db.SaveChanges();
                if (i == 0)
                    obj.IsSuccess = false;
                else obj.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj.IsSuccess = false;
                obj = ResponseBase.GetResponseByException<ResponseBoolBase>(ex);
                logger.ErrorFormat("HttpResultCfgSave", ex);
            }
            finally
            {
                //datapro.ExitWriteLock();
            }
            return obj;
        }

        public ResponseBoolBase HttpResultSaveStatus(long id, HttpTaskModel.TaskStatus status, AnalyseHtmlStatus astatus)
        {
            ResponseBoolBase obj = new ResponseBoolBase();
            try
            {
                datapro.EnterWriteLock();
                HttpTaskDBContext db = new HttpTaskDBContext();
                var d = db.HttpResultCfg.Find(id);
                d.TaskStatus = status;
                d.AnalyseStatus = astatus;
                int i = db.SaveChanges();
                if (i == 0)
                    obj.IsSuccess = false;
                else obj.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj.IsSuccess = false;
                obj = ResponseBase.GetResponseByException<ResponseBoolBase>(ex);
            }
            finally
            {
                datapro.ExitWriteLock();
            }
            return obj;
        }
        #endregion



        public void Subscribe()
        {
        }

        public void Unsubscribe()
        {
        }
    }
}
