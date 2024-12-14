

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using TodoList_Q4_2024.Models;
using TodoList_Q4_2024.Services;

namespace TodoList_Q4_2024.ViewModels
{
    internal partial class InsertarModificarTareaViewModel : ObservableObject
    {
        [ObservableProperty] private int idTarea;
        [ObservableProperty] private string nombre;
        [ObservableProperty] private string fechaLimite;
        [ObservableProperty] private string estadoActual;
        [ObservableProperty] private bool tareaTerminada;

        private readonly TareaService service;

        /*Obtener la fecha Minima
         * DateTime maneja Fevha y Hora
         * DateOnly maneja Fecha
         * TimeOnly maneja Hora
         * DateOnly minFecha= DateOnly.FromDateTime(DateTime.Now);
         */

        [ObservableProperty] private DateTime minFecha= DateTime.Now.AddDays(-1);
        
        

        /*Crear las opciones de estados*/
        public ObservableCollection<string> listaEstado { get; set; }


        public InsertarModificarTareaViewModel()
        {
            service = new TareaService();
            listaEstado = new ObservableCollection<string>()
            {
                new string("Por hacer"),
                new string("En Progreso"),
                new string("Finalizada")
            };
        }

        public InsertarModificarTareaViewModel(Tarea tarea)
        {
            service = new TareaService();
            IdTarea = tarea.IdTarea;
            Nombre = tarea.Nombre;
            FechaLimite = tarea.FechaLimite;
            EstadoActual = tarea.EstadoActual;
            TareaTerminada = tarea.TareaTerminada;

            listaEstado = new ObservableCollection<string>()
            {
                new string("Por hacer"),
                new string("En Progreso"),
                new string("Finalizada")
            };
        }


        private void Alerta(string titulo, string mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(titulo, mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {

                Tarea tarea = new Tarea();
                tarea.IdTarea = IdTarea;
                tarea.Nombre = Nombre;
                tarea.FechaLimite = FechaLimite;
                tarea.EstadoActual = EstadoActual;
                tarea.TareaTerminada= TareaTerminada;

                if (Validar(tarea))
                {
                    if (IdTarea == 0)
                    {
                        service.Insert(tarea);
                    }
                    else
                    {
                        service.Update(tarea);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
           }
            catch (Exception ex)
           {
                Alerta("ERROR", ex.Message);
            }
        }


        private bool Validar(Tarea tarea)
        {
            
            

            if (tarea.Nombre == null || tarea.Nombre == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el nombre de la tarea.");
                return false;
            }else if(tarea.FechaLimite==null || tarea.FechaLimite== "")
            {
                Alerta("ADVERTENCIA", "Debe de asignar una fecha limite a la tarea.");
                return false;
            }
            else if (tarea.EstadoActual==null || tarea.EstadoActual == "")
            {
                Alerta("ADVERTENCIA", "Debe de asignar el estado actual a la tarea.");
                return false;
            }else
            {
                DateTime fecha = DateTime.Parse(tarea.FechaLimite);
                DateOnly fechaAnterior = DateOnly.FromDateTime(fecha);
                DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);

                if (fechaAnterior < fechaActual)
                {
                    Alerta("ADVERTENCIA", "Debe modificar la fecha limite a una fecha mayor o igual a la fecha actual.");
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            
        }

    }
}
