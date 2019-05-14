using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyStickyNote.MyControls
{
    public class ControlAttachProperty
    {


        public static string GetTextContent(DependencyObject obj)
        {
            return (string)obj.GetValue(TextContentProperty);
        }

        public static void SetTextContent(DependencyObject obj, string value)
        {
            obj.SetValue(TextContentProperty, value);
        }

        // Using a DependencyProperty as the backing store for TextContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextContentProperty =
            DependencyProperty.RegisterAttached("TextContent", typeof(string), typeof(ControlAttachProperty), new PropertyMetadata("123123"));


    }
}
