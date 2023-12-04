using Microsoft.JSInterop;
using ProjectDiaries.Shared;
using System;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

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

    public async Task DeleteDiary(int id)
    {
		await _http.DeleteAsync($"api/Diaries/{id}");
    }

    public async Task EditDiary(Diary request)
    {
        await _http.PutAsJsonAsync($"api/Diaries/{request.Id}", request);
    }

	public async Task<List<Diary>> GetDiaries()
	{

		return await _http.GetFromJsonAsync<List<Diary>>("api/Diaries");
	}

	public async Task<Diary> GetDiaryById(int id)
	{

		return await _http.GetFromJsonAsync<Diary>($"api/Diaries/{id}");

	}




}
