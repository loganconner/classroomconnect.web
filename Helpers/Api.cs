using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Helpers
{
    public static class Api
    {

        /// <summary>
        /// Handles and API request.
        /// </summary>
        /// <returns></returns>
        public static string GetApiRequest(string service)
        {
            return GetApiRequest(service, null);
        }


        /// <summary>
        /// Handles and API request.
        /// </summary>
        /// <returns></returns>
        public static string GetApiRequest(string service, string parameter = null)
        {
            try
            {
                string apiUrl = AppSettingsProvider.ClassroomConnectApiUrl;

                string apiCall = string.Format("{0}/{1}/{2}", apiUrl, service, parameter);

                //Logging.log.DebugFormat("Making DTS call: {0}", dtsCall);

                WebRequest req = WebRequest.Create(apiCall);
                req.Method = "GET";
                req.Timeout = 60000;
                HttpWebResponse webResp = (HttpWebResponse)req.GetResponse();
                Stream respStream = webResp.GetResponseStream();
                StreamReader sr = new StreamReader(respStream);
                string response = sr.ReadToEnd();

                sr.Close();
                respStream.Close();
                webResp.Close();
                webResp.Close();

                return response;
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string responseFromServer = reader.ReadToEnd();

                        //if (!string.IsNullOrEmpty(responseFromServer))
                        //    Logging.log.Debug($"Web exception response ({ex.Status}): {responseFromServer}", ex);

                        return responseFromServer;
                    }
                }
            }
            catch (Exception ex)
            {
                //Logging.log.Debug($"Error making DTS call: {ex.Message}");
            }

            return null;
        }

        /// <summary>
        /// Handles and API request.
        /// </summary>
        /// <returns></returns>
        public static string PostApiRequest(string service)
        {
            return PostApiRequest(service, null, null);
        }

        /// <summary>
        /// Handles and API request.
        /// </summary>
        /// <returns></returns>
        public static string PostApiRequest(string service, object model)
        {
            return PostApiRequest(service, model, null);
        }


        /// <summary>
        /// Handles and API request.
        /// </summary>
        /// <returns></returns>
        public static string PostApiRequest(string service, object model = null, string parameter = null)
        {
            try
            {
                string apiUrl = AppSettingsProvider.ClassroomConnectApiUrl;

                string apiCall = string.Format("{0}/{1}/{2}", apiUrl, service, parameter);

                //Logging.log.DebugFormat("Making DTS call: {0}", dtsCall);

                WebRequest req = WebRequest.Create(apiCall);
                req.Method = "POST";
                req.Timeout = 60000;
                if(model != null)
                {
                    var jsonObject = JsonConvert.SerializeObject(model);
                    req.ContentType = "application/json";
                    using (var streamWriter = new StreamWriter(req.GetRequestStream()))
                    {
                        streamWriter.Write(jsonObject);
                    }
                }

                HttpWebResponse webResp = (HttpWebResponse)req.GetResponse();
                Stream respStream = webResp.GetResponseStream();
                StreamReader sr = new StreamReader(respStream);
                string response = sr.ReadToEnd();

                sr.Close();
                respStream.Close();
                webResp.Close();
                webResp.Close();

                return response;
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string responseFromServer = reader.ReadToEnd();

                        //if (!string.IsNullOrEmpty(responseFromServer))
                        //    Logging.log.Debug($"Web exception response ({ex.Status}): {responseFromServer}", ex);

                        return responseFromServer;
                    }
                }
            }
            catch (Exception ex)
            {
                //Logging.log.Debug($"Error making DTS call: {ex.Message}");
            }

            return null;
        }

        /// <summary>
        /// Handles and API request.
        /// </summary>
        /// <returns></returns>
        public static string PutApiRequest(string service)
        {
            return PutApiRequest(service, null, null);
        }

        /// <summary>
        /// Handles and API request.
        /// </summary>
        /// <returns></returns>
        public static string PutApiRequest(string service, object model)
        {
            return PutApiRequest(service, model, null);
        }


        /// <summary>
        /// Handles and API request.
        /// </summary>
        /// <returns></returns>
        public static string PutApiRequest(string service, object model = null, string parameter = null)
        {
            try
            {
                string apiUrl = AppSettingsProvider.ClassroomConnectApiUrl;

                string apiCall = string.Format("{0}/{1}/{2}", apiUrl, service, parameter);

                //Logging.log.DebugFormat("Making DTS call: {0}", dtsCall);

                WebRequest req = WebRequest.Create(apiCall);
                req.Method = "PUT";
                req.Timeout = 60000;
                if (model != null)
                {
                    var jsonObject = JsonConvert.SerializeObject(model);
                    req.ContentType = "application/json";
                    using (var streamWriter = new StreamWriter(req.GetRequestStream()))
                    {
                        streamWriter.Write(jsonObject);
                    }
                }

                HttpWebResponse webResp = (HttpWebResponse)req.GetResponse();
                Stream respStream = webResp.GetResponseStream();
                StreamReader sr = new StreamReader(respStream);
                string response = sr.ReadToEnd();

                sr.Close();
                respStream.Close();
                webResp.Close();
                webResp.Close();

                return response;
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    //using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                    //{
                    //    string responseFromServer = reader.ReadToEnd();

                    //    //if (!string.IsNullOrEmpty(responseFromServer))
                    //    //    Logging.log.Debug($"Web exception response ({ex.Status}): {responseFromServer}", ex);

                    //}
                }
            }
            catch (Exception ex)
            {
                //Logging.log.Debug($"Error making DTS call: {ex.Message}");
            }

            return null;
        }
    }
}
