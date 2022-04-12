using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Project_Tracker.MVM.Model
{
    internal class CardInfoButton : Button
    {
        public int sectionID { get; set; }
        public int CardID { get; set; }


        //public static readonly DependencyProperty CardIDProperty =
        //    DependencyProperty.RegisterAttached(
        //       "CardID",
        //       typeof(int),
        //       typeof(CardInfoButton),
        //       new FrameworkPropertyMetadata(defaultValue: false)
        //        );

        //public static int GetCardID(UIElement target) =>
        //    (int)target.GetValue(CardIDProperty);

        //public static void SetCardID(UIElement target, int value) =>
        //    target.SetValue(CardIDProperty, value);
    }
}
