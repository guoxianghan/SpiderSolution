using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections;
using System.IO;

namespace HttpHelper
{
    public class CookieHelper
    {
        /// 遍历CookieContainer
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public static List<System.Net.Cookie> GetAllCookies(CookieContainer cc)
        {
            List<System.Net.Cookie> lstCookies = new List<System.Net.Cookie>();
            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                System.Reflection.BindingFlags.Instance, null, cc, new object[] { });

            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                    | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (System.Net.Cookie c in colCookies) lstCookies.Add(c);
            }
            return lstCookies;
        }
        /// <summary>
        /// 添加Cookie 到 CookieContainer 
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="cc"></param>
        /// <param name="cookie">k0=v0;k1=v1;k2=v2;.....</param>
        /// <returns></returns>
        public static void addCookieToContainer(string cookie, string domain, ref CookieContainer cc)
        {
            string[] tempCookies = cookie.Split(';');
            string tempCookie = null;
            int Equallength = 0;//  =的位置
            string cookieKey = null;
            string cookieValue = null;
            //qg.gome.com.cn  cookie
            for (int i = 0; i < tempCookies.Length; i++)
            {
                if (!string.IsNullOrEmpty(tempCookies[i]))
                {
                    tempCookie = tempCookies[i];
                    Equallength = tempCookie.IndexOf("=");
                    if (Equallength != -1)       //有可能cookie 无=，就直接一个cookiename；比如:a=3;ck;abc=;
                    {
                        cookieKey = tempCookie.Substring(0, Equallength).Trim();
                        //cookie=

                        if (Equallength == tempCookie.Length - 1)    //这种是等号后面无值，如：abc=;
                        {
                            cookieValue = "";
                        }
                        else
                        {
                            cookieValue = tempCookie.Substring(Equallength + 1, tempCookie.Length - Equallength - 1).Trim();
                        }
                    }
                    else
                    {
                        cookieKey = tempCookie.Trim();
                        cookieValue = "";
                    }
                    cc.Add(new System.Net.Cookie(cookieKey, cookieValue, "", domain));
                }
            }
        }

        public static string CookieValue(string key, CookieContainer cc)
        {
            List<System.Net.Cookie> list = GetAllCookies(cc);
            System.Net.Cookie coo = list.FirstOrDefault(i => i.Name == key);
            if (coo == null)
                return "";
            else return coo.Value;
        }

        public static CookieContainer CreateCookieContriner(List<System.Net.Cookie> list, string domain = "")
        {
            string dom = string.IsNullOrEmpty(domain) ? list[0].Domain : domain;
            CookieContainer cc = new CookieContainer();
            foreach (System.Net.Cookie i in list)
            {
                cc.Add(new System.Net.Cookie() { Name = i.Name, Value = i.Value, Domain = dom });
            }
            return cc;
        }

        public static byte[] PostByte(string fullpath, Encoding encode, string header, string footer)
        {
            byte[] bytes = File.ReadAllBytes(fullpath);
            byte[] byteheader = encode.GetBytes(header);
            byte[] bytefooter = encode.GetBytes(footer);
            byte[] all = new byte[byteheader.Length + bytes.Length + bytefooter.Length];
            byteheader.CopyTo(all, 0);
            bytes.CopyTo(all, byteheader.Length);
            bytefooter.CopyTo(all, byteheader.Length + bytes.Length);
            return all;
        }
        public static CookieCollection CookieToCollection(CookieContainer cc)
        {
            List<System.Net.Cookie> c = GetAllCookies(cc);
            CookieCollection list = new CookieCollection();
            foreach (var i in c)
            {
                list.Add(new System.Net.Cookie(i.Name, i.Value) { Domain = i.Domain });
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cc"></param>
        /// <returns>List<Cookie>returns>
        public static List<Cookie> CookieContainerToString(CookieContainer cc)
        {
            if (cc == null)
                return new List<Cookie>(); 
            List<Cookie> lstCookies = new List<Cookie>();
            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                System.Reflection.BindingFlags.Instance, null, cc, new object[] { });

            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                    | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies)
                    {
                        lstCookies.Add(c); 
                    }
            }
            return lstCookies;
        }
        public static CookieContainer StringToCookie(string cookie, string doman = "")
        {
            CookieContainer cc  = new CookieContainer();
            List<Cookie> coo = new List<Cookie>();
            coo = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cookie>>(cookie);
            foreach (var item in coo)
            {
                cc.Add(new System.Net.Cookie(item.Name,item.Value) { Domain=item.Domain });
            }
            return cc;
        }


        public static CookieContainer StringPathToCookie(string txtpath, string doman = "")
        {
            string cookie = File.ReadAllText(txtpath);
            CookieContainer cc = CookieHelper.StringToCookie(cookie, doman);
            return cc;
        }
    }
}
