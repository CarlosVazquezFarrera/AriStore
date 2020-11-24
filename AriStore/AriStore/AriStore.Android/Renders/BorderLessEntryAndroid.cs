using Android.Content;
using Android.Graphics.Drawables;
using AriStore.Droid.OS;
using AriStore.UC;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderLessEntry), typeof(BorderLessEntryAndroid))]
namespace AriStore.Droid.OS
{
    public class BorderLessEntryAndroid : EntryRenderer
    {
        public BorderLessEntryAndroid(Context context) : base(context)
        {
            AutoPackage = false;
        }
        /// <summary>
        /// Se elimina la línea inferior del cuadro de texto de un entry en android
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                GradientDrawable gradiente = new GradientDrawable();
                gradiente.SetColor(Android.Graphics.Color.Transparent);
                Control.SetBackground(gradiente);
                Control.SetRawInputType(Android.Text.InputTypes.TextFlagNoSuggestions);
                Control.SetPadding(0, 0, 0, 0);
            }
        } 
    }
}