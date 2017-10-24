using Xamarin.Forms;

namespace ParentsAndKids.Controls {
    public class EntryEx : Entry {

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(propertyName: "BorderColor",
                                                                                              returnType: typeof(Color),
                                                                                              declaringType: typeof(EntryEx),
                                                                                              defaultValue: Color.Transparent);
        public Color BorderColor {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(propertyName: "BorderWidth",
                                                                                              returnType: typeof(float),
                                                                                              declaringType: typeof(EntryEx),
                                                                                              defaultValue: default(float));
        public float BorderWidth {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public static readonly BindableProperty BorderRadiusProperty = BindableProperty.Create(propertyName: "BorderRadius",
                                                                                               returnType: typeof(float),
                                                                                               declaringType: typeof(EntryEx),
                                                                                               defaultValue: default(float));
        public float BorderRadius {
            get { return (float)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }


        public static readonly BindableProperty LeftPaddingProperty = BindableProperty.Create(propertyName: "LeftPadding",
                                                                                              returnType: typeof(int),
                                                                                              declaringType: typeof(EntryEx),
                                                                                              defaultValue: 5);
        public int LeftPadding {
            get { return (int)GetValue(LeftPaddingProperty); }
            set { SetValue(LeftPaddingProperty, value); }
        }

        public static BindableProperty RightPaddingProperty = BindableProperty.Create(propertyName: "RightPadding",
                                                                                      returnType: typeof(int),
                                                                                      declaringType: typeof(EntryEx),
                                                                                      defaultValue: 5);
        public int RightPadding {
            get { return (int)GetValue(RightPaddingProperty); }
            set { SetValue(RightPaddingProperty, value); }
        }
    }
}
