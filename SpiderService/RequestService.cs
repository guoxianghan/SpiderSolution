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
                datapro.EnterReadLock();
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
            }
            finally
            {
                datapro.ExitReadLock();
            }
            return obj;
        }

        public ResponseDataBase<HttpRequestCfgDataUI> HttpRequestCfgGet(string webname, int level)
        {
            ResponseDataBase<HttpRequestCfgDataUI> obj = new ResponseDataBase<HttpRequestCfgDataUI>();
            try
            {
                datapro.EnterReadLock();
                HttpTaskDBContext db = new HttpTaskDBContext();
                //db.ContextOptions.ProxyCreationEnabled = false;
                //var d = db.HttpRequestCfg.Where(x => ((x.WebName.Trim() == webname.Trim() || string.IsNullOrEmpty(webname)) || (level == 0 ? x.Level >= 0 : x.Level == level)) && x.IsDelete == false).Include(x => x.HttpRequestChildCfgs);
                var d = db.HttpRequestCfg.Where(x => ((x.WebName.Trim() == webname.Trim() || string.IsNullOrEmpty(webname)) || (level == -1 ? x.Level >= 0 : x.Level == level)) && x.IsDelete == false).Include(x => x.HttpRequestChildCfgs);

                foreach (var item in d)
                {
                    var o = new HttpRequestCfgDataUI() { Cookie = item.Cookie, Level = item.Level, CreatedTime = item.CreatedTime, DeletedTime = item.DeletedTime, HasChildTask = item.HasChildTask, Host = item.Host, Id = item.Id, Key = item.Key, IsDelete = item.IsDelete, ProcessName = item.ProcessName, Quartz = item.Quartz, RequestRule = item.RequestRule, ResponseType = item.ResponseType, SeqNo = item.SeqNo, TaskStatus = item.TaskStatus, TaskTimeOut = item.TaskTimeOut, UpdatedTime = item.UpdatedTime, WebName = item.WebName };
                    o.HttpRequestChildCfgs = item.HttpRequestChildCfgs;
                    obj.data.Add(o);
                }
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
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
            }
            throw new NotImplementedException();
        }

        public ResponseBoolBase HttpRequestCfgSaveStatus(long id, global::HttpTaskModel.TaskStatus status)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
            }
            throw new NotImplementedException();
        }

        public ResponseBoolBase HttpRequestChildCfgAdd(HttpRequestCfgDataUI data)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
            }
            throw new NotImplementedException();
        }

        public ResponseBoolBase HttpRequestChildCfgSaveStatus(long id, HttpTaskModel.TaskStatus status)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
            }
            throw new NotImplementedException();
        }

        public ResponseBoolBase HttpResultCfgAdd(HttpResultCfgDataUI data)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
            }
            throw new NotImplementedException();
        }

        public ResponseBoolBase HttpResultCfgSave(HttpResultCfgDataUI data)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public ResponseBoolBase HttpResultCfgSave(HttpResultCfgRequest data)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public void Subscribe()
        {
        }

        public void Unsubscribe()
        {
        }
    }
}
