using TodoList_Q4_2024.ViewModels;
using TodoList_Q4_2024.Models;
namespace TodoList_Q4_2024.Views;

public partial class InsertarModificarTareaView : ContentPage
{
    InsertarModificarTareaViewModel viewModel= new InsertarModificarTareaViewModel();
    public InsertarModificarTareaView()
	{
		InitializeComponent();
		viewModel=new InsertarModificarTareaViewModel();
		BindingContext=viewModel;
	}

    public InsertarModificarTareaView(Tarea tarea)
	{
		InitializeComponent();
		viewModel=new InsertarModificarTareaViewModel(tarea);
		BindingContext=viewModel;
	}


}