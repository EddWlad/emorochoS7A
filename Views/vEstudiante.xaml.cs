using destradaS6A.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace destradaS6A.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://192.168.1.201:8080/uisarelws/post.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> students;
	public vEstudiante()
	{
		InitializeComponent();
		mostrar();
	}
	private async void mostrar()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Estudiante> mostrar = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		students = new ObservableCollection<Estudiante>(mostrar);
        lvEstudiantes.ItemsSource = students;
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vInsertar());

    }

    private void lvEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vActElim(objEstudiante));
    }
}