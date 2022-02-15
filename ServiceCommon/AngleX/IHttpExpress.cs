using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AngleX
{
    public interface IHttpExpress
    {
        HttpClient Create();
        byte[] DownLoad(string url);
        string DownLoadXml(string url);
        string DownLoadJson(string url);
        T DownLoadJson<T>(string url);
        string DownLoadString(string url, string Accept, Encoding encoding);



        T PostData<T>(string url, object postdata);
        T PostData<T>(string url, Dictionary<string, string> headers, object postdata);

        
        string PostData(string url, string postdata);
        string PostData(string url, string contenttype, string postadata, Encoding encoding);

        string PostData2(string url, object JsonObj);

        byte[] PostDataByte(string url, object JsonObj);

        byte[] Upload(string url, Dictionary<string, string> headers, HttpMethod httpMethod, byte[] postdata);



        byte[] UploadFile(string url, byte[] data, string fileName);

        byte[] UploadFile(string url, string filePath);
    }
}
