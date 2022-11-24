using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XavierIS7.Models;

namespace XavierIS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tableEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            con= DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            Datos ();
        }
        public async void Datos ()
        {
            var Resultado = await con.Table<Estudiante>().ToListAsync();
            tableEstudiante = new ObservableCollection<Estudiante>(Resultado);
            ListarEstudiantes.ItemsSource = tableEstudiante;
           
        }
        private void ListarEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ListarEstudiantes_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item= obj.Id.ToString();
            int idSeleccionado =Convert.ToInt32 (item);

            try
            {
                //Navigation.PushAsync(new Element(id Seleccionado));
            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}