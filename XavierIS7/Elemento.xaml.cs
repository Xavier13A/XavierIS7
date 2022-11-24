using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XavierIS7.Models;
using static Android.Resource;

namespace XavierIS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSet;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> borrar;
        IEnumerable<Estudiante> actualizar;

        public Elemento(int id)
        {
            InitializeComponent();
            idSet = id;
            con = DependencyService.Get<Database>().GetConnection();
        }
        public static IEnumerable<Estudiante> borrar1(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("Delete FROM Estudiante where Id = ?", id);
        }
        
        public static IEnumerable<Estudiante> Actualiza1 (SQLiteConnection db, int id, string nombre, string usuario, string contrasena) {
          
           return db.Query<Estudiante>( "UPDATE Estudiante set Nombre =  ?, Usuario =?,Contrasena=? where Id=?" ,nombre,usuario,contrasena,id);
        }
        
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
        try
        {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                actualizar = Actualiza1 (db,idSet,txtNombre.Text,txtUsuario.Text,txtContrasena.Text );
                DisplayAlert("Alerta", "Seactualizo correctamente", "ok");
        }
        catch (Exception)
        {

            throw;
        }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(databasePath);
            borrar = borrar1 (db, idSet);
            DisplayAlert("Eliminar", "Eliminado correctamente", "ok");

        }
    }
}