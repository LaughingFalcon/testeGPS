using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Plugin.Geolocator;
using System;

namespace AppGPS
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            FindViewById<Button>(Resource.Id.testarGps).Click += TestarGpsUsavel;
            FindViewById<Button>(Resource.Id.obterPosicao).Click += BuscarDadosPosicao;
        }

        private void TestarGpsUsavel(object enviador, EventArgs evento) {
            //if (!CrossGeolocator.Current.IsGeolocationAvailable) {
            //    Toast.MakeText(this, 'NaN Pos', ToastLength.Long).Show();
            //}
            //if (!CrossGeolocator.IsSupported){
            //    Toast.MakeText(this, 'API insurportável', ToastLength.Long).Show();
            //}
        }
        private async void BuscarDadosPosicao(object enviador, EventArgs evento) {

            var localizacao = CrossGeolocator.Current;
            var latitude = FindViewById<TextView>(Resource.Id.latitude);
            var longitude = FindViewById<TextView>(Resource.Id.longitude);

            localizacao.DesiredAccuracy = 50;

            var posicao = await localizacao.GetPositionAsync(TimeSpan.FromSeconds(10));

            latitude.Text = posicao.Latitude.ToString();
            longitude.Text = posicao.Longitude.ToString();

        }
    }
}