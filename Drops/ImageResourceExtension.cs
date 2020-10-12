using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Drops.Images
{
    // [ContentProperty (nameof(Source))]
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }
        

        // I need to grok the lingo for interfaces because even though I understand them i'm concerned I would bomb an interview questin on them    
        // this property is what implements the interface
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if(Source == null)
            {
                return null;
            }

            // var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
            var imageSource = ImageSource.FromResource(Source);

            return imageSource; 
        }
    }
}
