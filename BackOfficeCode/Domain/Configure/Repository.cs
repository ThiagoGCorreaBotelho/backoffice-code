using Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configure
{
    public class Repository : IRepository
    {

        #region Parameters

        private string _url { get; set; }
        private readonly HttpClient _client;
        private readonly string _urlApi;
        private readonly string _environment;

        #endregion

        #region Builders

        public Repository(string urlApi, string environmentName)
        {
            _urlApi = urlApi;
            _environment = environmentName;

            _client = new HttpClient()
            {
                BaseAddress = new Uri(urlApi),
                Timeout = new TimeSpan(0, 5, 0)
            };

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion

        #region Method

        private async Task<List<T>> GetList<T>()
        {

            HttpResponseMessage response;
            string returnData;

            //Get
            response = await _client.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                returnData = await response.Content.ReadAsStringAsync();

                if (returnData != "[]" && !string.IsNullOrEmpty(returnData))
                {
                    return JsonConvert.DeserializeObject<List<T>>(returnData);
                }
                else
                {
                    return default(List<T>);
                }
            }
            else
            {
                // Treatment if the return is false.
                if (response.ReasonPhrase.ToUpper() == "Unauthorized".ToUpper())
                {
                    returnData = "Unauthorized User";
                }
                else
                {
                    returnData = await response.Content.ReadAsStringAsync();
                }

                throw new Exception(returnData);
            }

        }

        private async Task<T> Get<T>()
        {

            HttpResponseMessage response;
            string returnData;

            response = await _client.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                returnData = await response.Content.ReadAsStringAsync();
                if (returnData != "[]" && !string.IsNullOrEmpty(returnData))
                {
                    return JsonConvert.DeserializeObject<T>(returnData);
                }
                else
                {
                    return default(T);
                }
            }
            else
            {
                // Treatment if the return is false.
                if (response.ReasonPhrase.ToUpper() == "Unauthorized".ToUpper())
                {
                    returnData = "Unauthorized User";
                }
                else
                {
                    returnData = await response.Content.ReadAsStringAsync();
                }

                throw new Exception(returnData);
            }

        }

        private async Task<T> Post<T>(T objectEntity)
        {

            HttpRequestMessage request;
            HttpResponseMessage response;
            string returnData;

            // Send request entity
            request = new HttpRequestMessage(HttpMethod.Post, _url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(objectEntity), Encoding.UTF8, "application/json")
            };

            // Retrieve object return
            response = _client.SendAsync(request).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                returnData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(returnData);
            }
            else
            {
                if (response.ReasonPhrase.ToUpper() == "Unauthorized".ToUpper())
                {
                    returnData = "Unauthorized User.";
                }
                else
                {
                    returnData = await response.Content.ReadAsStringAsync();
                }

                throw new Exception(returnData);
            }
        }

        private async Task<T> Post<T, Request>(Request objectEntity)
        {
            HttpRequestMessage request;
            HttpResponseMessage response;
            string returnData;

            // Send request
            request = new HttpRequestMessage(HttpMethod.Post, _url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(objectEntity), Encoding.UTF8, "application/json")
            };

             //Retrieve object return
            response = _client.SendAsync(request).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                returnData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(returnData);
            }
            else
            {
                if (response.ReasonPhrase.ToUpper() == "Unauthorized".ToUpper())
                {
                    returnData = "Unauthorized User.";
                }
                else
                {
                    returnData = await response.Content.ReadAsStringAsync();
                }

                throw new Exception(returnData);
            }
        }

        private async Task<bool> Put<T>(T objectEntity)
        {
            HttpRequestMessage request;
            HttpResponseMessage response;
            string returnData;


            // Send request
            request = new HttpRequestMessage(HttpMethod.Put, _url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(objectEntity), Encoding.UTF8, "application/json")
            };

            // Retrieve object return
            response = _client.SendAsync(request).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {

                if (response.ReasonPhrase.ToUpper() == "Unauthorized".ToUpper())
                {
                    returnData = "Unauthorized User.";
                }
                else
                {
                    returnData = await response.Content.ReadAsStringAsync();
                }

                throw new Exception(returnData);
            }
        }

        private async Task<bool> Inactivate<T>(T objectEntity)
        {
            HttpRequestMessage request;
            HttpResponseMessage response;
            string returnData;

            // Send request
            request = new HttpRequestMessage(HttpMethod.Delete, _url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(objectEntity), Encoding.UTF8, "application/json")
            };

            // Retrieve object return
            response = _client.SendAsync(request).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                if (response.ReasonPhrase.ToUpper() == "Unauthorized".ToUpper())
                {
                    returnData = "Unauthorized User.";
                }
                else
                {
                    returnData = await response.Content.ReadAsStringAsync();
                }

                throw new Exception(returnData);
            }
        }

        #endregion

        #region Calls Consult

        public async Task<T> Consult<T>(string call, string user, string token)
        {

            #region Settings URL

            _url = $"api/{call}/?";
            // parte autenticação
            _url += $"user={user}&token={token}";

            #endregion

            #region Call

            try
            {
                return await Get<T>();
            }
            catch (Exception ex)
            {
                // em caso de erro
                throw ex;
            }

            #endregion

        }

        public async Task<T> Consult<T>(string call, long id, string user, string token)
        {

            #region Settings URL

            _url = $"api/{call}/{id}?";
            _url += $"user={user}&token={token}";

            #endregion

            #region Call

            try
            {
                return await Get<T>();
            }
            catch (Exception ex)
            {
                // em caso de erro
                throw ex;
            }

            #endregion

        }

        public async Task<T> Consult<T>(string call, string action, string user, string token)
        {

            #region Settings URL

            _url = $"api/{call}/{action}/?";
            _url += $"user={user}&token={token}";

            #endregion

            #region Call

            try
            {
                return await Get<T>();
            }
            catch (Exception ex)
            {
                // em caso de erro
                throw ex;
            }

            #endregion

        }

        public async Task<T> Consult<T>(string call, string action, long id, string user, string token)
        {

            #region Settings URL

            // chamada da url
            _url = $"api/{call}/{action}/?id={id}&";
            // parte autenticação
            _url += $"user={user}&token={token}";

            #endregion

            #region Call

            try
            {
                return await Get<T>();
            }
            catch (Exception ex)
            {
                // em caso de erro
                throw ex;
            }

            #endregion

        }

        public async Task<T> Consult<T>(string call, string action, string query, string user, string token)
        {

            #region Settings URL

            _url = $"api/{call}/{action}/?{query}";
            _url += $"&user={user}&token={token}";

            #endregion

            #region Call

            try
            {
                return await Get<T>();
            }
            catch (Exception ex)
            {
                // em caso de erro
                throw ex;
            }

            #endregion

        }

        public async Task<T> Consult<T>(string call, string action, long id, string query, string user, string token)
        {

            #region Settings URL

            _url = $"api/{call}/{action}/?id={id}&{query}";
            _url += $"&user={user}&token={token}";

            #endregion

            #region Call

            try
            {
                return await Get<T>();
            }
            catch (Exception ex)
            {
                // em caso de erro
                throw ex;
            }

            #endregion

        }

        #endregion

        #region Calls List

        public async Task<List<T>> ConsultList<T>(string call, string filter, string user, string token)
        {

            #region Configure URL

            _url = $"api/{call}/All?";
            // parte autenticação
            _url += $"filter={filter}&user={user}&token={token}";

            #endregion

            #region Call

            try
            {
                var list = await GetList<T>();

                if (list == null)
                {
                    return new List<T>();
                }
                else
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                // em caso de erro
                throw ex;
            }

            #endregion

        }

        public async Task<List<T>> ConsultList<T>(string call, long id, string filter, string user, string token)
        {

            #region Configure URL

            // chamada da url
            _url = $"api/{call}/All/?id={id}&";
            // parte autenticação
            _url += $"filter={filter}&user={user}&token={token}";

            #endregion

            #region Chamada

            try
            {
                var list = await GetList<T>();

                if (list == null)
                {
                    return new List<T>();
                }
                else
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                // em caso de erro
                throw ex;
            }

            #endregion

        }


        public async Task<List<T>> ConsultList<T>(string call, string action, string filter, string user, string token)
        {

            #region Configure URL

            // chamada da url
            _url = $"api/{call}/{action}/?";
            // parte autenticação
            _url += $"filter={filter}&user={user}&token={token}";

            #endregion

            #region Call

            try
            {
                var list = await GetList<T>();

                if (list == null)
                {
                    return new List<T>();
                }
                else
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                // em caso de erro
                throw ex;
            }

            #endregion

        }

        public async Task<List<T>> ConsultList<T>(string call, string action, long id, string filter, string user, string token)
        {

            #region Configure URL

            // chamada da url
            _url = $"api/{call}/{action}?id={id}&";
            // parte autenticação
            _url += $"filter={filter}&user={user}&token={token}";

            #endregion

            #region Call

            try
            {
                var list = await GetList<T>();

                if (list == null)
                {
                    return new List<T>();
                }
                else
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                // em caso de erro
                throw ex;
            }

            #endregion

        }
        public async Task<List<T>> ConsultList<T>(string call, string action, string query, string filter, string user, string token)
        {

            #region Configure URL

            // chamada da url
            _url = $"api/{call}/{action}/?{query}";
            // parte autenticação
            _url += $"&filter={filter}&user={user}&token={token}";

            #endregion

            #region Call

            try
            {
                var list = await GetList<T>();

                if (list == null)
                {
                    return new List<T>();
                }
                else
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                // em caso de erro
                throw ex;
            }

            #endregion

        }

        public async Task<List<T>> ConsultList<T>(string call, string action, long id, string query, string filter, string user, string token)
        {

            #region Configure URL

            // chamada da url
            _url = $"api/{call}/{action}/?id={id}&{query}&";
            // parte autenticação
            _url += $"filter={filter}&user={user}&token={token}";

            #endregion

            #region Call

            try
            {
                var list = await GetList<T>();

                if (list == null)
                {
                    return new List<T>();
                }
                else
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                // em caso de erro
                throw ex;
            }

            #endregion

        }

        #endregion

        #region Insert

        public async Task<T> Insert<T>(string call, T objectEntity)
        {

            #region Configure URL

            _url = $"{_urlApi}api/{call}/";

            #endregion

            #region Call

            try
            {
                return await Post<T>(objectEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion

        }

        public async Task<T> Insert<T>(string call, string action, T objectEntity)
        {

            #region Configure URL

            _url = $"{_urlApi}api/{call}/{action}";

            #endregion

            #region Call

            try
            {
                return await Post<T>(objectEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion

        }

        public async Task<T> Insert<T, Request>(string call, string action, Request objectRequest)
        {

            #region Configure URL

            _url = $"{_urlApi}api/{call}/{action}";

            #endregion

            #region Call

            try
            {
                return await Post<T, Request>(objectRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion

        }

        #endregion

        #region Change

        public async Task<bool> Change<T>(string call, long id, T objectEntity)
        {

            #region Configure URL

            _url = $"{_urlApi}api/{call}/{id}";

            #endregion

            #region Call

            try
            {
                return await Put<T>(objectEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion

        }

        public async Task<bool> Change<T>(string call, string action, T objectEntity)
        {

            #region Configure URL

            _url = $"{_urlApi}api/{call}/{action}";

            #endregion

            #region Call

            try
            {
                return await Put<T>(objectEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion

        }

        public async Task<bool> Change<T>(string call, string action, long id, T objectEntity)
        {

            #region Configure URL

            _url = $"{_urlApi}api/{call}/{action}/{id}";

            #endregion

            #region Call

            try
            {
                return await Put<T>(objectEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion

        }

        public async Task<bool> Change<T>(string call, string action, string query, T objectEntity)
        {
            #region Configure URL

            _url = $"{_urlApi}api/{call}/{action}/?{query}";

            #endregion

            #region Call
            try
            {
                return await Put<T>(objectEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        #endregion

        #region Inactivate

        public async Task<bool> Inactivate<T>(string call, long id, T objectEntity)
        {

            #region Configure URL

            _url = $"{_urlApi}api/{call}/{id}";

            #endregion

            #region Call

            try
            {
                return await Inactivate<T>(objectEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion

        }

        public async Task<bool> Inactivate<T>(string call, string action, long id, T objectEntity)
        {

            #region Configure URL

            _url = $"{_urlApi}api/{call}/{action}/{id}";

            #endregion

            #region Call

            try
            {
                return await Inactivate<T>(objectEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion

        }

        #endregion

        public string GetUrl()
        {
            return _urlApi;
        }


    }
}
