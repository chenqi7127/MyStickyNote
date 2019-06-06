using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyStickyNote.NoteThemes
{
    public enum ThemeType
    {
        DarkBlue,
        Black,
        Gray,
        Green
    }
    public class ThemeManager
    {
        public static ThemeManager Instance;
        private ResourceDictionary _currentTheme;
        private Dictionary<ThemeType, ResourceDictionary> _themeDic;
        static ThemeManager()
        {
            Instance = new ThemeManager();
        }

        public ThemeManager()
        {
            _currentTheme = GetThemeResourceDictionary();
            InitThemeDic();
            
            
        }

        private void InitThemeDic()
        {
            _themeDic = new Dictionary<ThemeType, ResourceDictionary>();
            _themeDic.Add(ThemeType.DarkBlue,new ResourceDictionary{Source = new Uri(@"pack://application:,,,/NoteThemes/Theme.DarkBlue.xaml") });
            _themeDic.Add(ThemeType.Black, new ResourceDictionary { Source = new Uri(@"pack://application:,,,/NoteThemes/Theme.Black.xaml") });
            _themeDic.Add(ThemeType.Gray, new ResourceDictionary { Source = new Uri(@"pack://application:,,,/NoteThemes/Theme.Gray.xaml") });
            _themeDic.Add(ThemeType.Green, new ResourceDictionary { Source = new Uri(@"pack://application:,,,/NoteThemes/Theme.Green.xaml") });
        }

        private ResourceDictionary GetThemeResourceDictionary()
        {
            return Application.Current.Resources.MergedDictionaries.FirstOrDefault(p => p.Contains("TitleBackgroundColor"));
        }

        public void SetThemeResource(ThemeType type)
        {
            var dictionaries = Application.Current.Resources.MergedDictionaries;
            dictionaries.Add(_themeDic[type]);
            if (_currentTheme != null)
            {
                dictionaries.Remove(_currentTheme);
            }
            _currentTheme = _themeDic[type];
        }
    }
}
