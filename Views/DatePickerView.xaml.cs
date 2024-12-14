namespace TodoList_Q4_2024.Views;

public partial class DatePickerView : ContentPage
{
	public DatePickerView()
	{
		InitializeComponent();
	}

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        lblDatePicker.Text = "Ha Seleccionado una fecha (SUSCRIBETE)";
        lblDatePicker.TextColor=Colors.Purple;
    }
}