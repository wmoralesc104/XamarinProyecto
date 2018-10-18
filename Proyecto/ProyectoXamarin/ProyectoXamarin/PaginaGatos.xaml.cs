using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ComponentModel;

namespace ProyectoXamarin
{
	public partial class PaginaGatos : ContentPage, INotifyPropertyChanged
    {
        private string idGatoActual;
        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }
            set
            {
                this.isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        public PaginaGatos()
        {
            InitializeComponent();

            IsLoading = false;
            BindingContext = this;

            buttonSiguiente.Clicked += ButtonCambiar_Click;
            buttonAdoptar.Clicked += ButtonAdoptar_Click;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await CargarGato();
        }

        private async void ButtonAdoptar_Click(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new ContratoAdopcion(idGatoActual) { Title="Contrato Adopcion Gatos" });
        }

        private async void ButtonCambiar_Click(object sender, EventArgs arg)
        {
            await CargarGato();
        }

        private async Task CargarGato()
        {
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Advertencia", "No hay internet", "Cerrar");
                return;
            }
            IsLoading = true;
            
            var gatos = await CargarProductos();

            var UriCat = new Uri(gatos[0].url);
            
            gatoId.Text = "ID: " + gatos[0].id;
            idGatoActual = gatos[0].id;

            await CargarFoto(UriCat);

            IsLoading = false;
            
        }

        private async Task<Gato[]> CargarProductos()
        {
            try
            {
                var cliente = new HttpClient();

                cliente.BaseAddress = new Uri(App.WebServiceUrl);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-api-key", "ace7551a-2f54-4ede-bae3-5eb39a5e2179");
                var json = await cliente.GetStringAsync("");

                Console.WriteLine(json);

                var resultado = JsonConvert.DeserializeObject<Gato[]>(json);

                return resultado;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Gato[0];
            }
        }


        private async Task CargarFoto(Uri uriGato)
        {
       
            IsLoading = true;
              
            gatoImage.Source = FileImageSource.FromUri(uriGato);
            
            IsLoading = false;

            
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


    }

     
}
