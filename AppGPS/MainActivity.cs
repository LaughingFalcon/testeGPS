using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Plugin.Geolocator;

namespace AppGPS
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
        }



        private void botaoTestes(object enviador, EventArgs evento) {
            if (!CrossGeolocator.Current.IsGeolocationAvailable) {
                Toast.MakeText(this, 'NaN Pos', ToastLength.Long).Show();
            }
            if (!CrossGeolocator.IsSupported){
                Toast.MakeText(this, 'API insurportável', ToastLength.Long).Show();
            }

        }
        private async void botaoPosicao(object enviador, EventArgs evento) {
            var localizacao = CrossGeolocator.Current;
            localizacao.DesiredAccuracy = 50;

            var posicao = await localizacao.GetPositionAsync(TimeSpan.FromSeconds(10));

            lblLatitude.Text = posicao.Latitude.ToString();
            lblLongitude.Text = posicao.Longitude.ToString();
        }
    }
}