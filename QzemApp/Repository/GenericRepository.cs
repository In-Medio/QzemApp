﻿using Newtonsoft.Json;
using Polly;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using QzemApp.Exceptions;
using QzemApp.Models;
using QzemApp.Repository;
using QzemApp.Services.Settings;

namespace QzemApp.Repository;

public class GenericRepository : IGenericRepository
{
    private readonly ISettingsService _settingsService;

    public GenericRepository(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    public async Task<T> GetAsync<T>(string uri, string authToken = "")
    {
        try
        {
            HttpClient httpClient = CreateHttpClient(uri, authToken);
            string jsonResult = string.Empty;

            var responseMessage = await Policy
                .Handle<WebException>(ex =>
                {
                    Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                    return true;
                })
                .WaitAndRetryAsync
                (
                    5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(async () => await httpClient.GetAsync(uri));

            if (responseMessage.IsSuccessStatusCode)
            {
                jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var json = JsonConvert.DeserializeObject<T>(jsonResult);
                return json;
            }

            if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ServiceAuthenticationException(jsonResult);
            }

            throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"{e.GetType().Name + " : " + e.Message}");
            throw;
        }
    }

    public async Task<T> PostAsync<T>(string uri, T data, string authToken = "")
    {
        try
        {
            HttpClient httpClient = CreateHttpClient(uri, authToken);

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            string jsonResult = string.Empty;

            var responseMessage = await Policy
                .Handle<WebException>(ex =>
                {
                    Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                    return true;
                })
                .WaitAndRetryAsync
                (
                    5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(async () => await httpClient.PostAsync(uri, content));

            if (responseMessage.IsSuccessStatusCode)
            {
                jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var json = JsonConvert.DeserializeObject<T>(jsonResult);
                return json;
            }

            if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ServiceAuthenticationException(jsonResult);
            }

            throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"{e.GetType().Name + " : " + e.Message}");
            throw;
        }
    }

    public async Task<TR> PostAsync<T, TR>(string uri, T data, string authToken = "")
    {
        try
        {
            HttpClient httpClient = CreateHttpClient(uri, authToken);

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            string jsonResult = string.Empty;

            var responseMessage = await Policy
                .Handle<WebException>(ex =>
                {
                    Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                    return true;
                })
                .WaitAndRetryAsync
                (
                    5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(async () => await httpClient.PostAsync(uri, content));

            if (responseMessage.IsSuccessStatusCode)
            {
                jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var json = JsonConvert.DeserializeObject<TR>(jsonResult);
                return json;
            }

            if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                responseMessage.StatusCode == HttpStatusCode.Unauthorized ||
                responseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ServiceAuthenticationException(jsonResult);
            }

            throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"{e.GetType().Name + " : " + e.Message}");
            throw;
        }
    }

    public async Task<T> PutAsync<T>(string uri, T data, string authToken = "")
    {
        try
        {
            HttpClient httpClient = CreateHttpClient(uri, authToken);

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            string jsonResult = string.Empty;

            var responseMessage = await Policy
                .Handle<WebException>(ex =>
                {
                    Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                    return true;
                })
                .WaitAndRetryAsync
                (
                    5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(async () => await httpClient.PutAsync(uri, content));

            if (responseMessage.IsSuccessStatusCode)
            {
                jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var json = JsonConvert.DeserializeObject<T>(jsonResult);
                return json;
            }

            if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ServiceAuthenticationException(jsonResult);
            }

            throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"{e.GetType().Name + " : " + e.Message}");
            throw;
        }
    }

    public async Task<TR> PutAsync<T, TR>(string uri, T data, string authToken = "")
    {
        try
        {
            HttpClient httpClient = CreateHttpClient(uri, authToken);

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            string jsonResult = string.Empty;

            var responseMessage = await Policy
                .Handle<WebException>(ex =>
                {
                    Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                    return true;
                })
                .WaitAndRetryAsync
                (
                    5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(async () => await httpClient.PutAsync(uri, content));

            if (responseMessage.IsSuccessStatusCode)
            {
                jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var json = JsonConvert.DeserializeObject<TR>(jsonResult);
                return json;
            }

            if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ServiceAuthenticationException(jsonResult);
            }

            throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"{e.GetType().Name + " : " + e.Message}");
            throw;
        }
    }

    public async Task DeleteAsync(string uri, string authToken = "")
    {
        HttpClient httpClient = CreateHttpClient(uri, authToken);
        await httpClient.DeleteAsync(uri);
    }

    private HttpClient CreateHttpClient(string uri, string authToken)
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(uri);
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        authToken = _settingsService.AuthToken;

        if (!string.IsNullOrEmpty(authToken))
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        }
        return httpClient;
    }
}