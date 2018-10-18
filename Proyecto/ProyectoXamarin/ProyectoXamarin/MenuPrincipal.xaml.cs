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
	public partial class MenuPrincipal : ContentPage
	{
		public MenuPrincipal ()
		{
			InitializeComponent ();

            btSalir.Clicked += ButtonSalir_Click;
            btOk.Clicked += ButtonOk_Click;

        }


        private async void ButtonSalir_Click(object sender, EventArgs arg)
        {
           
        }

        private async void ButtonOk_Click(object sender, EventArgs arg)
        {
            await Navigation.PushAsync(new PaginaGatos() { Title = "Gatos a Adoptar" });
              
        }

    }
}