using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Drops
{
    public partial class SmallDevicesStyle : ResourceDictionary
    {
        public static SmallDevicesStyle SharedInstance { get; } = new SmallDevicesStyle();
       
        public SmallDevicesStyle()
        {
            InitializeComponent();
        }
    }
}
