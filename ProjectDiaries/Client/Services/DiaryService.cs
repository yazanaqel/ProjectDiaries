using ProjectDiaries.Shared;
using System;
using System.Net.Http.Json;

namespace ProjectDiaries.Client.Services;

public class DiaryService : IDiaryService
{
	private readonly HttpClient _http;

	public DiaryService(HttpClient http)
	{
		_http = http;
	}

	public async Task<Diary> CreateDiary(Diary request)
	{
		var result = await _http.PostAsJsonAsync("api/Diaries", request);
		return await result.Content.ReadFromJsonAsync<Diary>();
	}

	public async Task<List<Diary>> GetDiaries()
	{

		return await _http.GetFromJsonAsync<List<Diary>>("api/Diaries");
	}

	public async Task<Diary> GetDiaryById(int id)
	{

		var result = await _http.GetAsync($"api/Diaries/{id}");
		if (result.StatusCode != System.Net.HttpStatusCode.OK)
		{
			var message = await result.Content.ReadAsStringAsync();
			Console.WriteLine(message);
			return new Diary { Title = message };
		}
		else
		{
			return await result.Content.ReadFromJsonAsync<Diary>();
		}
	}




}
