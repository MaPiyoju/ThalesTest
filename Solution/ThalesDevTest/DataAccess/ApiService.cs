using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace DataAccess
{
    public class ApiService
    {
        private readonly HttpClient httpClient;

        public ApiService(HttpClient httpClient) {
            this.httpClient = httpClient;
        }

        public async Task<ApiResponse<T>> GetData<T>(string restUrl) {
            try {
                var requestUri = new Uri(httpClient.BaseAddress, restUrl);
                var response = await httpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<T>(json);

                return new ApiResponse<T> {
                    Error = result == null,
                    Message = result == null ? "Error while deserializing JSON" : "",
                    Data = result == null ? default : result
                };
            } catch (Exception ex) {
                throw new ApplicationException($"Error while trying to retrieve the data. Error: {ex.Message}");
            }
        }
    }
}
