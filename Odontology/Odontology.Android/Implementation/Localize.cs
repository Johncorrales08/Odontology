[assembly: Xamarin.Forms.Dependency(typeof(Odontology.Droid.Implementations.Localize))]

namespace Odontology.Droid.Implementations
{ 

using System.Globalization;
using System.Threading;
using Helpers;
using Interfaces;

public class Localize : ILocalize
{
    public CultureInfo GetCurrentCultureInfo()


    {
        var netLanguage = "en";
        var androidLocale = Java.Util.Locale.Default;
        netLanguage = AndroidToDotnetLanguage(androidLocale.ToString().Replace("_", "-"));
        //thisgetscalled  a  lot  -  try/catchcanbeexpensivesoconsidercachingorsomething
        System.Globalization.CultureInfo ci = null;
        try
        {
            ci = new System.Globalization.CultureInfo(netLanguage);
        }
        catch (CultureNotFoundException e1)
        {
            //iOSlocalenotvalid.NETculture(eg."en-ES"  :  EnglishinSpain)
            //fallbacktofirstcharacters,inthiscase"en"
            try
            {
                var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                ci = new System.Globalization.CultureInfo(fallback);
            } catch (CultureNotFoundExceptione2)
            {
                //iOSlanguagenotvalid.NETculture,fallingbacktoEnglish
                ci = new System.Globalization.CultureInfo("en");
            }
        }
        return ci;
    }
    public void SetLocale(CultureInfo ci)

    {
        Thread.CurrentThread.CurrentCulture = ci;
        Thread.CurrentThread.CurrentUICulture = ci;
    }
    string AndroidToDotnetLanguage(string androidLanguage)
    {
        var netLanguage = androidLanguage;
        //certainlanguagesneedtobeconvertedtoCultureInfoequivalentswitch(androidLanguage)  
        switch (androidLanguage)
        {
            case "ms-BN":      //"Malaysian(Brunei)"notsupported.NETculture
            case "ms-MY":      //"Malaysian(Malaysia)"notsupported.NETculture
            case "ms-SG":      //"Malaysian(Singapore)"notsupported.NETculture
                netLanguage = "ms";  //closestsupported
                break;
            case "in-ID":    //"Indonesian(Indonesia)"hasdifferentcodein.NET
                netLanguage = "id-ID";  //correctcodefor.NET
                break;
            case "gsw-CH":    //"Schwiizertüütsch(SwissGerman)"notsupported.NETculture
                netLanguage = "de-CH";  //closestsupported
                break;
                //addmoreapplication-specificcaseshere(ifrequired)
                //ONLYuseculturesthathavebeentestedandknowntowork                        
        }
        returnnetLanguage;
    }
    string ToDotnetFallbackLanguage(PlatformCulture platCulture)
    {
        var netLanguage = platCulture.LanguageCode;//usethefirstpartoftheidentifier(twochars,usually);
        switch (platCulture.LanguageCode)
        {
            case "gsw":
                netLanguage = "de-CH";  //equivalent to German(Switzerland) forthisapp
                break;
                //addmoreapplication-specificcaseshere(ifrequired)
                //ONLYuseculturesthathavebeentestedandknowntowork
        }
         return netLanguage;
        }
    }
}