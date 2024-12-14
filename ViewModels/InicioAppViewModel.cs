
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TodoList_Q4_2024.Models;
using TodoList_Q4_2024.Services;
using TodoList_Q4_2024.Views;

namespace TodoList_Q4_2024.ViewModels
{
    public partial class InicioAppViewModel: ObservableObject
    {

        public static int porHacerContador = 0;
        public static int enProgresoContador = 0;
        public static int finalizadaContador = 0;

        [ObservableProperty] private int porHacer;
        [ObservableProperty] private int enProgreso;
        [ObservableProperty] private int finalizada;

        public InicioAppViewModel()
        {
            PorHacer = porHacerContador;
            EnProgreso = enProgresoContador;
            Finalizada = finalizadaContador;

        }



    }
}
