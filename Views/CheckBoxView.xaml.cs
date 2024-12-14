namespace TodoList_Q4_2024.Views;

public partial class CheckBoxView : ContentPage
{
	public CheckBoxView()
	{
		InitializeComponent();
	}

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		CheckBox caja= sender as CheckBox;
		if (caja.IsChecked)
		{
			lblPrueba.Text = "Si este video te esta aportando a tu conocimiento suscribite o apoya el video con un like o compartelo el video con un like o compartelo";
			lblPrueba.FontAttributes= FontAttributes.Bold | FontAttributes.Italic;
			lblPrueba.FontSize = 18;
		}
		else
		{
			lblPrueba.FontAttributes=FontAttributes.None;
			lblPrueba.FontSize = 12;
		}
	}

}