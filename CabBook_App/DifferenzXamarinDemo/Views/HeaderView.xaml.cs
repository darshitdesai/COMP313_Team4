using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CabBook
{
    /// <summary>
    /// HeaderView - Top Bar which will contain screen title and buttons
    /// </summary>
    public partial class HeaderView : ContentView
    {
        public HeaderView()
        {
            InitializeComponent();
            TapGestureRecognizer RightClickTGR = new TapGestureRecognizer();
            RightClickTGR.Tapped += (object sender, EventArgs e) =>
            {
                if (RightCommand != null)
                {
                    RightCommand.Execute(this);
                }
            };
            RightButtontext.GestureRecognizers.Add(RightClickTGR);


            TapGestureRecognizer LeftClickTGR = new TapGestureRecognizer();
            LeftClickTGR.Tapped += (object sender, EventArgs e) =>
            {
                if (LeftCommand != null)
                {
                    LeftCommand.Execute(this);
                }
            };
            LeftButtontext.GestureRecognizers.Add(LeftClickTGR);

        }

        public static BindableProperty RightCommandProperty = BindableProperty.Create(nameof(RightCommand), typeof(Command), typeof(HeaderView), default(Command), BindingMode.TwoWay, propertyChanged: OnRightCommandChanged);
        private static void OnRightCommandChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as HeaderView;
            picker.RightCommand = (Xamarin.Forms.Command)newvalue;
        }

        public Command RightCommand
        {
            get
            {
                return (Command)this.GetValue(RightCommandProperty);
            }
            set
            {
                this.SetValue(RightCommandProperty, value);
            }
        }

        public static BindableProperty LeftCommandProperty =
            BindableProperty.Create(nameof(LeftCommand), typeof(Command), typeof(HeaderView), default(Command), BindingMode.TwoWay, propertyChanged: OnLeftCommandChanged);
        private static void OnLeftCommandChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as HeaderView;
            picker.LeftCommand = (Xamarin.Forms.Command)newvalue;
        }

        public Command LeftCommand
        {
            get
            {
                return (Command)this.GetValue(LeftCommandProperty);
            }
            set
            {
                this.SetValue(LeftCommandProperty, value);
            }
        }

        public static BindableProperty HeaderTextProperty = BindableProperty.Create(nameof(HeaderText), typeof(string), typeof(HeaderView), default(string), BindingMode.TwoWay, propertyChanged: OnHeaderTextChanged);
        private static void OnHeaderTextChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as HeaderView;
            picker.HeaderText = (string)newvalue;
            picker.headertext.Text = (string)newvalue;
        }

        public string HeaderText
        {
            get
            {
                return (string)this.GetValue(HeaderTextProperty);
            }
            set
            {
                this.SetValue(HeaderTextProperty, value);
            }
        }

        public static BindableProperty LeftTextProperty = BindableProperty.Create(nameof(LeftText), typeof(string), typeof(HeaderView), default(string), BindingMode.TwoWay, propertyChanged: OnLeftTextChanged);
        private static void OnLeftTextChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as HeaderView;
            picker.LeftText = (string)newvalue;
            picker.LeftButtontext.Text = (string)newvalue;
        }

        public string LeftText
        {
            get
            {
                return (string)this.GetValue(LeftTextProperty);
            }
            set
            {
                this.SetValue(LeftTextProperty, value);
            }
        }

        public static BindableProperty RightTextProperty = BindableProperty.Create(nameof(RightText), typeof(string), typeof(HeaderView), default(string), BindingMode.TwoWay, propertyChanged: OnRightTextChanged);
        private static void OnRightTextChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as HeaderView;
            picker.RightText = (string)newvalue;
            picker.RightButtontext.Text = (string)newvalue;
        }

        public string RightText
        {
            get
            {
                return (string)this.GetValue(RightTextProperty);
            }
            set
            {
                this.SetValue(RightTextProperty, value);
            }
        }
    }
}
