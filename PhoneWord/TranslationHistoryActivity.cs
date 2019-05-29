using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Linq;

namespace PhoneWord
{
    [Activity(Label = "@string/TranslationHistory")]
    public class TranslationHistoryActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0];
            this.ListAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, phoneNumbers.ToList());
        }
    }
}