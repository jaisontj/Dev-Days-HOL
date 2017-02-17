using Android.App;
using Android.Widget;
using Android.OS;
using Phoneword;

namespace Phoneword.Droid
{
    [Activity(Label = "Phoneword.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

		EditText phoneNumberText;
		Button translateButton;
		Button callButton;
		string TranslatedNumber;

		protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

			phoneNumberText = FindViewById<EditText>(Resource.Id.PhonewordText);
			translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
			callButton = FindViewById<Button>(Resource.Id.CallButton);

			translateButton.Click += TranslateButton_Click;
			callButton.Click += CallButton_Click;
        }

		private void TranslateButton_Click(object sender, System.EventArgs e)
		{
			
			//TranslatedNumber = PhonewordTranslator.ToNumber(phoneNumberText.Text);
			if (string.IsNullOrWhiteSpace(TranslatedNumber))
			{
				callButton.Text = "Call";
				callButton.Enabled = false;
			}
			else
			{
				callButton.Text = "Call " + TranslatedNumber;
				callButton.Enabled = true;
			}
		}

		private void CallButton_Click(object sender, System.EventArgs e)
		{
			var callDialog = new AlertDialog.Builder(this);
			callDialog.SetMessage("Call " + TranslatedNumber + "?");
			callDialog.SetNeutralButton("Call", delegate
			{
				var callIntent = new Intent(Intent.ActionCall);
				callIntent.SetData(Android.Net.Uri.Parse("tel:" + TranslatedNumber));
				StartActivity(callIntent);
			});
			callDialog.SetNegativeButton("Cancel", delegate { });
			callDialog.Show();
		}
    }
}

