using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using FilmDemo.Models;
using System.Diagnostics;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace FilmDemo.Controllers
{
    public class FilmController : Controller
    {
        // GET: Film
        public string GetApiResult(string Request, string ActionName, object obj = null)
        {
            string json = "";
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:13693/api/LoginAndFirstPage/");
            Task<HttpResponseMessage> task = null;
            switch (Request)
            {
                case "get":
                    task = hc.GetAsync(ActionName);
                    break;
                case "post":
                    task = hc.PostAsJsonAsync(ActionName, obj);
                    break;
                case "put":
                    task = hc.PutAsJsonAsync(ActionName, obj);
                    break;
                case "delete":
                    task = hc.DeleteAsync(ActionName);
                    break;
            }
            task.Wait();
            var result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                var GetResultTask = result.Content.ReadAsStringAsync();
                GetResultTask.Wait();
                json = GetResultTask.Result;
            }
            return json;
        }
        private const String host = "http://dingxin.market.alicloudapi.com";
        private const String path = "/dx/sendSms";
        private const String method = "POST";
        private const String appcode = "e3322da1be4944b8b8a8a73271d6c69c";
        public void MessageTest(string PhoneNum)
        {
            //--

            Random rad = new Random();
            int value = rad.Next(1000, 10000);
            Session["value"] = value;
            String querys = "mobile=" + PhoneNum + "&param=code:" + value + "&tpl_id=TP1711063";
            String bodys = "";
            String url = host + path;
            HttpWebRequest httpRequest = null;
            HttpWebResponse httpResponse = null;

            if (0 < querys.Length)
            {
                url = url + "?" + querys;
            }

            if (host.Contains("https://"))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                httpRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            }
            else
            {
                httpRequest = (HttpWebRequest)WebRequest.Create(url);
            }
            httpRequest.Method = method;
            httpRequest.Headers.Add("Authorization", "APPCODE " + appcode);
            if (0 < bodys.Length)
            {
                byte[] data = Encoding.UTF8.GetBytes(bodys);
                using (Stream stream = httpRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            try
            {
                httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            }
            catch (WebException ex)
            {
                httpResponse = (HttpWebResponse)ex.Response;
            }
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        public ActionResult ForgetPwd()
        {
            return View();
        }
        public ActionResult EditPwd()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        static HttpCookie cookie = null;
        public void UserLogin(string PhoneNum, string Password)
        {
            try
            {
                var result = GetApiResult("get", "UserLogin?userName=" + PhoneNum + "&passWord=" + Password);
                if (!result.Contains("null"))
                {
                    cookie = new HttpCookie(PhoneNum, PhoneNum);
                    cookie.Expires = DateTime.Now.AddMinutes(1);
                    Response.Write("<script>alert('登陆成功！')</script>");

                }
                else
                {
                    Response.Write("<script>alert('登陆失败！')</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('登陆失败！')</script>");
            }

        }
        public string GetCookie()
        {
            if (cookie == null)
            {
                return "";
            }
            UserInfo us = new UserInfo
            {
                PhoneNum = cookie.Value
            };
            return JsonConvert.SerializeObject(us);
        }
        public int ClearCookie()
        {
            if (cookie!=null)
            {
                cookie.Expires = DateTime.Now.AddDays(-5);
                Response.Cookies.Add(cookie);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public string GetPhoneNum()
        {
            return cookie.Value;
        }
        public void RegisterUser(UserInfo ui)
        {
            try
            {
                var result = GetApiResult("post", "RegisterUser",ui);
                if (int.Parse(result) >0)
                {
                    Response.Write("<script>alert('注册成功！')</script>");
                }
                else
                {
                    Response.Write("<script>alert('注册失败！')</script>");
                }
            }
            catch 
            {
                Response.Write("<script>alert('注册失败！')</script>");
            }
            
        }
        public ActionResult FistPage()
        {
            var result = GetApiResult("get", "GetFilm");
            List<FilmInfo> list = JsonConvert.DeserializeObject<List<FilmInfo>>(result);
            return View(list);
        }
        public ActionResult FilmPage()
        {
            return View();
        }
        public ActionResult CinemaPage()
        {
            return View();
        }
        public ActionResult ListPage()
        {
            return View();
        }
        public ActionResult FilmInfo()
        {
            return View();
        }
        public ActionResult GetTicket()
        {
            return View();
        }
        public ActionResult GetSitAndGetTicket()
        { 
            return View();
        }
        public ActionResult GetSit()
        {
            return View();
        }
        public ActionResult CfmInfo()
        {
            return View();
        }
        public ActionResult ChoosePayWay()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult GetAllUserInfo()
        {
            return View();
        }
    }
}