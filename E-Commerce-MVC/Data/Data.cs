using System.Globalization;

namespace E_Commerce_MVC.Data
{
    public static class Data
    {
        // this is to get the whole countries list
        static public List<string> GetCountryList()
        {
            List<string> cultureList = new List<string>();

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {

                RegionInfo region = new RegionInfo(culture.Name);

                if (!(cultureList.Contains(region.EnglishName)))
                {
                    cultureList.Add(region.EnglishName);
                }
            }
            cultureList.Sort();

            return cultureList;
        }
    }
}