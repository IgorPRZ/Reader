using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reader.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarCodePrincipalPage : ContentPage
    {

        private string resultScanText;

        public string ResultScanText
        {
            get { return resultScanText; }
            set { 
                resultScanText = value;
                OnPropertyChanged();
            }
        }

        private bool _buttonVisible;

        public bool ButtonVisible
        {
            get { return _buttonVisible; }
            set 
            {
                _buttonVisible = value;
                OnPropertyChanged();
            }
        }

        public Command OpenURL { get; set; }


        public BarCodePrincipalPage()
        {
            InitializeComponent();
            BindingContext = this;
            ButtonVisible = false;
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (result.Text.Contains("http") || result.Text.Contains("https") || result.Text.Contains(".com"))
                {
                    ResultScanText = String.Format("{0}", result.Text);
                    ButtonVisible = true;
                }
                else 
                {
                    ResultScanText = String.Format("{0}", result.Text);
                    ButtonVisible = false;
                }
   
            });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool pergunta = await DisplayAlert("Você tem certeza ?", "Esse link irá redimensionar você para uma pagína desconhecida, o aplicativo não se responsabiliza pelas ações do site acessado. \n \n Você mesmo assim deseja prosseguir ? ", "Prosseguir", "Voltar");

                if (pergunta)
                {
                    await Browser.OpenAsync(resultScanText, BrowserLaunchMode.SystemPreferred);
                }
                else 
                {
                    //DoNothing
                }
       
            }
            catch (Exception)
            {

            }

        }
    }
}