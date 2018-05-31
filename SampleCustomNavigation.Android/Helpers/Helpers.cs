using System;
using Android.App;
using Android.Content;
using Android.Views.InputMethods;
using Android.Widget;

namespace SampleCustomNavigation.Droid.Helpers
{
    public class Helpers
    {
        public static void ShowKeyboard(EditText inputBox, Activity context)
        {
            inputBox.RequestFocus();

            inputBox.Focusable = true;

            InputMethodManager inputManager = (InputMethodManager)context.GetSystemService(Context.InputMethodService);
            inputManager.ToggleSoftInput(ShowFlags.Implicit, HideSoftInputFlags.None);
        }

        public static void HideKeyboard(EditText inputBox, Activity context)
        {
            if (inputBox.IsInputMethodTarget)
            {
                InputMethodManager inputManager = (InputMethodManager)context.GetSystemService(Context.InputMethodService);
                inputManager.HideSoftInputFromWindow(inputBox.ApplicationWindowToken, HideSoftInputFlags.None);
            }
        }
    }
}
