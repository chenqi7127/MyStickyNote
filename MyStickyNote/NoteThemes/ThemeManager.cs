using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyStickyNote.NoteThemes
{
    public class ThemeManager
    {
        public static ThemeManager Instance;
        private ResourceDictionary _currentTheme;
        static ThemeManager()
        {
            Instance = new ThemeManager();
        }

        public ThemeManager()
        {
            _currentTheme = GetThemeResourceDictionary();
        }

        private ResourceDictionary GetThemeResourceDictionary()
        {
            return Application.Current.Resources.MergedDictionaries.FirstOrDefault(p => p.Contains("TitleBackgroundColor"));
        }

        public void SetThemeResource(Uri uri)
        {
            var dictionaries = Application.Current.Resources.MergedDictionaries;
            dictionaries.Add(new ResourceDictionary
            {
                Source = uri
            });
            if (_currentTheme != null)
            {
                dictionaries.Remove(_currentTheme);
            }
        }
    }
}
