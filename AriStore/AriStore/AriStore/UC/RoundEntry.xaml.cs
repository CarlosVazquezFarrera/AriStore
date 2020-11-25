using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AriStore.UC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoundEntry : ContentView
    {
        public RoundEntry()
        {
            InitializeComponent();
            this.Entry.TextChanged += (s, e) =>
            {
                this.Text = this.Entry.Text;
            };
        }
        /// <summary>
        /// PlaceHolder del entry
        /// </summary>
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(RoundEntry), default(string),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (RoundEntry)bindable;
            entry.Entry.Placeholder = (string)newValue;
        });

        /// <summary>
        /// El texto que se introduce en el Entry
        /// </summary>

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(RoundEntry), default(string), defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (RoundEntry)bindable;
            entry.Entry.Text = (string)newValue;
        });

        /// <summary>
        /// Define el tipo de teclado del control
        /// </summary>
        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }
        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(RoundEntry), default(Keyboard),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (RoundEntry)bindable;
            entry.Entry.Keyboard = (Keyboard)newValue;
        });

    }
}