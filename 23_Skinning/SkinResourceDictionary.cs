using System;
using System.Windows;

namespace _23_Skinning
{
	public class SkinResourceDictionary : ResourceDictionary
    {
        private Uri _LightThemeSource;
        private Uri _DarkThemeSource;

        public Uri LightThemeSource
        {
            get { return _LightThemeSource; }
            set { _LightThemeSource = value; UpdateSource(); }
        }

        public Uri DarkThemeSource
        {
            get { return _DarkThemeSource; }
            set { _DarkThemeSource = value; UpdateSource(); }
        }

        public void UpdateSource()
        {
            var val = App.Skin == Skin.Light ? LightThemeSource : DarkThemeSource;
            if (val != null && base.Source != val)
                base.Source = val;
        }
    }
}