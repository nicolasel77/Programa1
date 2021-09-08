using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Programa1.DB;
using System.Collections.Generic;
using System.Data;

namespace Sistema_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            TipoProductos tipoProductos = new TipoProductos();
            DataTable dt = tipoProductos.Datos();

            ListView lstProds = FindViewById<ListView>(Resource.Id.lstProductos);

            List<string> items;
            ArrayAdapter<string> adapter;

            items = new List<string>(new[] { "Nombre" });
            foreach (DataRow dr in dt.Rows)
            {
                items = new List<string>(new[] { dr["Nombre"].ToString() });
                
            }
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            lstProds.Adapter = adapter;
        }
    }
}