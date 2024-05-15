using Blazored.LocalStorage;
using EGovernment.Web.Abstractions;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace EGovernment.Web.Services;

public class AuthenticationService : IAuthenticationService
{
	private readonly AuthenticationStateProvider _authenticationStateProvider;
	private readonly ILocalStorageService _localStorageService;
	private readonly INavigationService _navigationService;
	private HttpClient _httpClient;


	public AuthenticationService(AuthenticationStateProvider authenticationStateProvider,
		ILocalStorageService localStorageService, INavigationService navigationService, HttpClient httpClient)
	{
		_authenticationStateProvider = authenticationStateProvider;
		_localStorageService = localStorageService;
		_navigationService = navigationService;
		_httpClient = httpClient;
	}

	public async Task SignIn(string username, string password)
	{

		var result = await _httpClient.PostAsync($"Auth/Token?username={username}&password={password}", null);

		if (result.IsSuccessStatusCode)
		{
			var responseContent = await result.Content.ReadAsStringAsync();
			var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseContent);
			await _localStorageService.SetItemAsync("token", tokenResponse?.accessToken);
            await Console.Out.WriteLineAsync(tokenResponse.accessToken);
            await _authenticationStateProvider.GetAuthenticationStateAsync();
		}
		_navigationService.NavigateTo("/");
	}
	public class TokenResponse
	{
		public string accessToken { get; set; }
		public string refreshToken { get; set; }
	}
}