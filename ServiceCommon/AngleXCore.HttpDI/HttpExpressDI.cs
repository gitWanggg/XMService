using AngleX;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace AngleXCore.HttpDI
{
    public class HttpExpressDI : RESTfulExpress, IHttpExpress
    {
        static string htmlHeader = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        static string jsonHeader = "application/json, text/javascript, */*; q=0.01";
        static string jsoncontent = "application/json";
        public ISerializeable ISerial { get; set; }

        public HttpExpressDI(ISerializeable ISer, IHttpClientFactory hcFactory)
            : base(hcFactory)
        {
            this.ISerial = ISer;
        }
       
        protected byte[] HandExeR(Task<HttpResponseMessage> task)
        {
            HttpResponseMessage response = task.Result;
            byte[] bR = response.Content.ReadAsByteArrayAsync().Result;
            if (response.IsSuccessStatusCode) {
                return bR;
            }
            else {
                
                HttpXResponseR r = new HttpXResponseR((int)response.StatusCode);
                r.Data = bR;
                r.ErrorMessage = bR != null && bR.Length > 0 ? System.Text.Encoding.UTF8.GetString(bR) : null;               
                HttpXException hError = new HttpXException(r.ErrorMessage);
                hError.ICommonR = r;
                throw hError;

            }
        }

      
        public byte[] DownLoad(string url)
        {
            var t = base.HttpExe(url, HttpMethod.Get, null);
            return HandExeR(t);
        }

        public string DownLoadJson(string url)
        {
            return DownLoadString(url, jsonHeader, Encoding.UTF8);
        }

        public T DownLoadJson<T>(string url)
        {
            string jdata = DownLoadJson(url);
            if (string.IsNullOrEmpty(jdata))
                return default(T);
            return ISerial.DeserializeObject<T>(jdata);
        }

        public string DownLoadString(string url, string Accept, Encoding encoding)
        {
            var t = base.HttpExe(url, Accept, HttpMethod.Get, null);
            byte[] bR = HandExeR(t);
            return encoding.GetString(bR);
        }

        public string DownLoadXml(string url)
        {
            return DownLoadString(url, htmlHeader, Encoding.UTF8);
        }

        public T PostData<T>(string url, object postdata)
        {
            string jData = ISerial.SerializeObject(postdata);
            string data = PostData(url, jData);
            if (string.IsNullOrEmpty(data))
                return default(T);
            return ISerial.DeserializeObject<T>(data);
        }

        public T PostData<T>(string url, Dictionary<string, string> headers, object postdata)
        {
            string jData = ISerial.SerializeObject(postdata);
            HttpContent hc = new StringContent(jData, Encoding.UTF8, jsoncontent);
            var t = base.HttpExe(url, headers, HttpMethod.Post, hc);
            byte[] tR = HandExeR(t);
            string jR = Encoding.UTF8.GetString(tR);
            if (string.IsNullOrEmpty(jR))
                return default(T);
            return ISerial.DeserializeObject<T>(jR);
        }
        public string PostData(string url, string postdata)
        {
            return PostData(url, jsoncontent, postdata, System.Text.Encoding.UTF8);
        }
        public string PostData(string url, string contenttype, string postadata, Encoding encoding)
        {
            byte[] br = PostData2(url, contenttype, postadata, encoding);
            if (br == null)
                return "";
            return encoding.GetString(br);
            //if (postadata == null)
            //    postadata = "";
            //HttpContent hc = new StringContent(postadata, encoding, contenttype);
            //var t = base.HttpExe(url, HttpMethod.Post, hc);
            //byte[] tR = HandExeR(t);
            //return Encoding.UTF8.GetString(tR);
        }

        byte[] PostData2(string url, string contenttype, string postadata, Encoding encoding)
        {
            if (postadata == null)
                postadata = null;
            HttpContent hc = new StringContent(postadata, encoding, contenttype);
            var t = base.HttpExe(url, HttpMethod.Post, hc);
            byte[] tR = HandExeR(t);
            return tR;
        }
        public byte[] Upload(string url, Dictionary<string, string> headers, HttpMethod httpMethod, byte[] data)
        {
            HttpContent hc = new ByteArrayContent(data);
            var t = headers == null ? base.HttpExe(url, httpMethod, hc) : base.HttpExe(url, headers, httpMethod, hc);
            return HandExeR(t);
        }

        public byte[] UploadFile(string url, byte[] data, string fileName)
        {
            ByteArrayContent fileContent = new ByteArrayContent(data);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = "file", FileName = fileName };
            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Add(fileContent);
            var t = base.HttpExe(url, HttpMethod.Post, fileContent);
            return HandExeR(t);
        }

        public byte[] UploadFile(string url, string filePath)
        {
            byte[] data = System.IO.File.ReadAllBytes(filePath);
            return UploadFile(url, data, filePath);
        }

        public HttpClient Create()
        {
            HttpClient hc = this._hcFactory.CreateClient();
            return hc;
        }

        public string PostData2(string url, object JsonObj)
        {
            string jData = ISerial.SerializeObject(JsonObj);
            string data = PostData(url, jData);
            return data;
        }

        public byte[] PostDataByte(string url, object JsonObj)
        {
            string jData = ISerial.SerializeObject(JsonObj);
            byte[] br = PostData2(url, jsoncontent, jData, System.Text.Encoding.UTF8);
            return br;
        }
    }
}
