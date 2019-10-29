using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Common
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        
        const string ResourceId = "Common.Resx.AppResources";
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return null;

            /// <summary>
            /// The resource manager will select the appropriate resource file, depending on the language used on the device. 
            /// The text value to be translated will be provided by the XAML view.
            /// </summary>
            

            ResourceManager resourceManager = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);

            return resourceManager.GetString(Text, CultureInfo.CurrentCulture);
        }

    }
}

