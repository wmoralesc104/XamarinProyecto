using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContratoAdopcion : ContentPage
	{
		public ContratoAdopcion (string idGato)
		{
			InitializeComponent ();
            gatoAdoptar.Text = "Id Gato:" + idGato;
            lbContrato.Text = "¿Usted acepta cuidar al felino, darle cariño, medicinas, un hogar, juguetes y hacerlo feliz?";

        }

        private async void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void ButtonOK_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Adopción", "Gracias por adoptar!!", "Ok");

            await Navigation.PopToRootAsync();
        }
    }
}