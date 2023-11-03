using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ProjectDiaries.Client.Services;

namespace ProjectDiaries.Client.Pages;

public class CreateDiaryBase : ComponentBase
{
	[Inject]
	public IDiaryService DiaryService { get; set; }

	[Inject]
	public NavigationManager NavigationManager { get; set; }

	protected ProjectDiaries.Shared.Diary newDiary = new ProjectDiaries.Shared.Diary();

	protected async Task HandleSubmit()
	{
		await DiaryService.CreateDiary(newDiary);
		NavigationManager.NavigateTo("/");
	}

	protected async Task OnFileChange(InputFileChangeEventArgs e)
	{
		var format = "image/.png";
		var resizedImage = await e.File.RequestImageFileAsync(format, 1060, 1060);
		var buffer = new byte[resizedImage.Size];
		await resizedImage.OpenReadStream().ReadAsync(buffer);
		var imageData = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
		newDiary.Image = imageData;
	}
}
