

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TodoList_Q4_2024.Models;
using TodoList_Q4_2024.Services;
using TodoList_Q4_2024.Views;
using TodoList_Q4_2024.ViewModels;

namespace TodoList_Q4_2024.ViewModels
{
    public partial class ElimiarTareaViewModel:ObservableObject
    {

        [ObservableProperty] private ObservableCollection<Tarea> tareaCollection= new ObservableCollection<Tarea>();
        private readonly TareaService service;


             
        public ElimiarTareaViewModel()
        {
            service = new TareaService();
        }

        private void Alerta(string titulo, string mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(titulo, mensaje, "Aceptar"));
        }

        public void GetAll()
        {
            var getAll=service.GetAll();

            InicioAppViewModel.porHacerContador = 0;
            InicioAppViewModel.enProgresoContador = 0;
            InicioAppViewModel.finalizadaContador = 0;

            if (getAll.Count > 0)
            {
                
                TareaCollection.Clear();
                foreach(var tarea in getAll)
                {
                    /*Dejar solo la fecha quitando la hora*/
                    DateTime fecha = DateTime.Parse(tarea.FechaLimite);
                    DateOnly fechaAnterior = DateOnly.FromDateTime(fecha);

                    tarea.FechaLimite = fechaAnterior.ToString();

                    /*Validar que si el estado de la tarea estan en finalizada se activa el CheckBox de manera automatico*/
                    /*Si el estado de la tara no estas finalizada el checkBox esta desactivado*/

                    if (tarea.EstadoActual == "Finalizada" && tarea.TareaTerminada==false)
                    {
                        tarea.TareaTerminada = true;
                    }else if(tarea.EstadoActual != "Finalizada" && tarea.TareaTerminada == true)
                    {
                        tarea.TareaTerminada = false;
                    }

                    TareaCollection.Add(tarea);


                    if (tarea.EstadoActual == "Por hacer")
                    {
                        InicioAppViewModel.porHacerContador = InicioAppViewModel.porHacerContador + 1;
                    }

                    if (tarea.EstadoActual == "En Progreso")
                    {
                        InicioAppViewModel.enProgresoContador = InicioAppViewModel.enProgresoContador + 1;
                    }

                    if (tarea.EstadoActual == "Finalizada")
                    {
                        InicioAppViewModel.finalizadaContador = InicioAppViewModel.finalizadaContador + 1;
                    }

                }
            }
        }


        [RelayCommand]
        private async Task GotoInsertarModificarTareaView()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new InsertarModificarTareaView());
        }

        [RelayCommand]
        private async Task GotoEditInsertarModificarTareaView(Tarea tarea)
        {
        await App.Current!.MainPage!.Navigation.PushAsync(new InsertarModificarTareaView(tarea));
        }


        [RelayCommand]
        private async Task irInicioAppView()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new InicioAppView());
        }


        private async Task EliminarTarea(Tarea tarea)
        {
            try
            {
                bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR TAREA", "¿Desea eliminar tarea?", "Si", "No");
                if (respuesta) { 
                    int del =service.Delete(tarea);
                    if (del > 0) {
                        Alerta("ELIMINAR TAREA", "Tarea eliminada correctmente");
                        TareaCollection.Remove(tarea);
                    }
                }
            }catch(Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        [RelayCommand]
        private async Task SelectTarea(Tarea tarea)
        {
            try
            {
                const string ACTUALIZAR = "Actualizar";
                const string ELIMINAR = "Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR, ELIMINAR);

                if (res == ACTUALIZAR)
                {
                    await GotoEditInsertarModificarTareaView(tarea);
                }
                else if (res == ELIMINAR)
                {
                    await EliminarTarea(tarea);
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

    }
}
