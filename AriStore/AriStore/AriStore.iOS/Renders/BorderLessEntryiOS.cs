using AriStore.iOS.OS;
using AriStore.UC;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(BorderLessEntry), typeof(BorderLessEntryiOS))]
namespace AriStore.iOS.OS
{
    public class BorderLessEntryiOS: EntryRenderer
    {
        /// <summary>
        /// Elimina la línea inferior de los Entry en Ios
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.Layer.CornerRadius = 10;
                Control.TextColor = UIColor.White;
            }
        }
    }
}