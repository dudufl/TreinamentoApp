using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Core;

namespace PhoneWord
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

            EditText phoneNumberText = (EditText)FindViewById(Resource.Id.PhoneNumberText);
            TextView translatedPhoneWord = (TextView)FindViewById(Resource.Id.TranslatePhoneWord);
            Button translateButton = (Button)FindViewById(Resource.Id.TranslateButton);

            translateButton.Click += (sender, e) =>
            {
                string translatedNumber = PhoneWordTranslator.ToNumber(phoneNumberText.Text);

                if (string.IsNullOrWhiteSpace(translatedNumber))
                    translatedPhoneWord.Text = string.Empty;
                else
                    translatedPhoneWord.Text = translatedNumber;
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}