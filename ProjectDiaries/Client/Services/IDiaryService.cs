using ProjectDiaries.Shared;

namespace ProjectDiaries.Client.Services;

public interface IDiaryService
{
	Task<List<Diary>> GetDiaries();
	Task<Diary> GetDiaryById(int id);
	Task<Diary> CreateDiary(Diary request);
	Task EditDiary(Diary request);
	Task DeleteDiary(int id);
}
