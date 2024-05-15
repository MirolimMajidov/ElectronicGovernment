using EGovernment.Web.Abstractions;
using ElectronicGovernment.DTO;
using System.Net.Http.Json;
using Blazored.LocalStorage;


namespace EGovernment.Web.Services
{
	public class DepService : IDepService
	{
		protected HttpClient _httpClient;
		protected ILocalStorageService _localStorage;
		public DepService(HttpClient httpClient, ILocalStorageService localStorage)
		{
			_httpClient = httpClient;
			_localStorage = localStorage;
		}
		public async Task<List<DepartmentInfo>> GetAllDeps()
		{
			var accessToken = await _localStorage.GetItemAsync<string>("token");
			_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
			Console.WriteLine("Foo1", accessToken);
			var response = await _httpClient.GetFromJsonAsync<List<DepartmentInfo>>("department/all");
			return response ?? [];
		}

		public async Task<List<DocumentTemplateInfo>> GetAllDocs(Guid id)
		{
			var accessToken = await _localStorage.GetItemAsync<string>("token");
			_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
			Console.WriteLine("Foo", accessToken);
			var response = await _httpClient.GetFromJsonAsync<List<DocumentTemplateInfo>>($"DocumentTemplate/AllTemplates?departmentId={id}");
			return response ?? [];
		}
	}
}
