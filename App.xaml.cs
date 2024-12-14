using TodoList_Q4_2024.ViewModels;
using TodoList_Q4_2024.Views;

namespace TodoList_Q4_2024
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage( new InsertarModificarTareaView()));
        }
    }
}