using System;
using Xamarin.Forms;


namespace Drops.SharedResources
{
    public static class PagesMeta
    {
        // I use this property to refer to the page a viewmodel is representing when invoking the InsertPageBefore method
        public static ContentPage ThisPage { get; set; }
    }
}
