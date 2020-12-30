using System;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace Drops.SharedResources
{
    // There are some issues I need to resolve before all this logic can be migrated from App.Xaml.cs

    //// public static class DeviceMeta
    //{
    //    // FIELDS
    //    static int smallWightResolution = 768;

    //    static int smallHeightResolution = 1280;

    //    // METHODS
    //    public static void LoadStyles() // I should probably modularize the logic this methods bloated AF
    //    {
    //        // Optimizes for users RuntimePlatform
    //        GetRuntimePlatform();

    //        // Optimizes for users Display dimensions
    //        //GetDisplaySize();

    //        // Optimizes for users Device Idiom
    //        GetDeviceIdiom();
    //    }

    //    // Contains the logic that categorizes the users device by it's diplay dimensions, currently idiom agnostic
    //    //public static void GetDisplaySize()
    //    //{
    //    //    // Get Metrics
    //    //    var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

    //    //    // Width (in pixels)
    //    //    var width = mainDisplayInfo.Width;

    //    //    // Height (in pixels)
    //    //    var height = mainDisplayInfo.Height;

    //    //    //return (width <= smallWightResolution && height <= smallHeightResolution);
    //    //    bool isSmall = (width <= smallWightResolution && height <= smallHeightResolution);

    //    //    if (isSmall)
    //    //    {
    //    //        dictionary.MergedDictionaries.Add(SmallDevicesStyle.SharedInstance);

    //    //        System.Diagnostics.Debug.WriteLine("this is a small device");
    //    //    }
    //    //    else
    //    //    {
    //    //        dictionary.MergedDictionaries.Add(GeneralDevicesStyle.SharedInstance);

    //    //        System.Diagnostics.Debug.WriteLine("this is not a small device");
    //    //    }
    //    //}

    //    // Optimizes for users Device Idiom
    //    public static void GetDeviceIdiom()
    //    {
    //        switch (Device.Idiom)
    //        {
    //            case TargetIdiom.Desktop:

    //                System.Diagnostics.Debug.WriteLine("you're on desktop");

    //                break;
    //            case TargetIdiom.Phone:

    //                System.Diagnostics.Debug.WriteLine("you're on your phone");

    //                break;
    //            case TargetIdiom.Tablet:

    //                System.Diagnostics.Debug.WriteLine("you're on your tablet");

    //                break;
    //            case TargetIdiom.TV:

    //                System.Diagnostics.Debug.WriteLine("you're on a smart tv");

    //                break;
    //        }
    //    }

    //    // Optimizes for users runtime platform
    //    public static void GetRuntimePlatform()
    //    {
    //        switch (Device.RuntimePlatform)
    //        {
    //            case Device.iOS:

    //                System.Diagnostics.Debug.WriteLine("you're running iOS");

    //                // Let's add style selection logic

    //                break;

    //            case Device.Android:

    //                System.Diagnostics.Debug.WriteLine("you're running android");

    //                // let's add style selection logic
    //                break;

    //            default:

    //                System.Diagnostics.Debug.WriteLine("gee I don't know what you're running, maybe uwp?");

    //                break;
    //        }
    //    }
    //}
}
