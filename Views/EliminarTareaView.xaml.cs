using TodoList_Q4_2024.ViewModels;
namespace TodoList_Q4_2024.Views;

public partial class EliminarTareaView : ContentPage
{
	private ElimiarTareaViewModel ViewModel;
	public EliminarTareaView()
	{
		InitializeComponent();
		ViewModel = new ElimiarTareaViewModel();
		BindingContext = ViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		ViewModel.GetAll();
    }
}