using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Drops
{
    public partial class GeneralDevicesStyle : ResourceDictionary
    {
        public static GeneralDevicesStyle SharedInstance { get; } = new GeneralDevicesStyle();

        public GeneralDevicesStyle()
        {
            InitializeComponent();
        }
    }
}
