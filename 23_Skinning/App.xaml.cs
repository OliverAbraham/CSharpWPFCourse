using System.Windows;

namespace _23_Skinning
{
	public enum Skin { Light, Dark }

	public partial class App : Application
	{
        public static Skin Skin { get; set; } = Skin.Dark;
 
        public void ChangeSkin(Skin newSkin)
        {
            Skin = newSkin;
 
            foreach (ResourceDictionary dict in Resources.MergedDictionaries)
            {
                 if (dict is SkinResourceDictionary skinDict)
                    skinDict.UpdateSource();
                else
                    dict.Source = dict.Source;
            }
        }
    }
}
