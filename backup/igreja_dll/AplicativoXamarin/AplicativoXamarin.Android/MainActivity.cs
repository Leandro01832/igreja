using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AplicativoXamarin.models.Interface;
using Android.Provider;
using Android.Content;
using Xamarin.Forms;
using Java.IO;
using AplicativoXamarin.Droid;
using Android;
using Plugin.Media;
using Android.Graphics;
using System.IO;
using System.Threading.Tasks;
using Plugin.CurrentActivity;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace AplicativoXamarin.Droid
{
    [Activity(Label = "Igreja em Cataguases", Icon = "@drawable/icone_igreja", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        readonly string[] permissionGroup =
        {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera,
            Manifest.Permission.AccessFineLocation,
            Manifest.Permission.AccessCoarseLocation
        };        

        protected override void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar; //esta linha 
            ToolbarResource = Resource.Layout.Toolbar; //esta linha 

            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder(); //esta linha 
            StrictMode.SetVmPolicy(builder.Build());//esta linha

            RequestPermissions(permissionGroup, 0);

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState);
            LoadApplication(new App());
        }        

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}