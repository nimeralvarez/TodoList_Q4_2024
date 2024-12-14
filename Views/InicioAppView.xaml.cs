using TodoList_Q4_2024.ViewModels;
namespace TodoList_Q4_2024.Views;

public partial class InicioAppView : ContentPage
{

    private InicioAppViewModel viewModel=new InicioAppViewModel();
	public InicioAppView()
	{

        InitializeComponent();

        viewModel=new InicioAppViewModel();
        BindingContext = viewModel;
    }
}