using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Data;
using System.Data.SqlClient;
using cource.Connection;
using System.Drawing;
using cource.Main;

namespace cource.Main
{
    class Animation
    {
        public static void CreateAnimCloseCol(List<UIElement> Panels, UIElement elem)
        {
            DoubleAnimation anim = new DoubleAnimation();

            foreach (var item in Panels)
            {
                if (item != elem)
                {
                    anim.From = item.Opacity;
                    anim.To = 0;
                    anim.Duration = TimeSpan.FromSeconds(0.5);
                    anim.EasingFunction = new QuarticEase();

                    item.BeginAnimation(UIElement.OpacityProperty, anim);

                    item.Visibility = Visibility.Hidden;
                }
            }
        }
        public static void CreateAnimClose(UIElement elem)
        {
            DoubleAnimation anim = new DoubleAnimation();

            anim.From = elem.Opacity;
            anim.To = 0;
            anim.Duration = TimeSpan.FromSeconds(0.5);
            anim.EasingFunction = new QuarticEase();

            elem.BeginAnimation(UIElement.OpacityProperty, anim);

            elem.Visibility = Visibility.Visible;
        }
        public static void CreateAnimOpen(UIElement elem)
        {
            DoubleAnimation anim = new DoubleAnimation();

            elem.Visibility = Visibility.Visible;

            anim.From = elem.Opacity;
            anim.To = 1;
            anim.Duration = TimeSpan.FromSeconds(0.5);
            anim.EasingFunction = new QuarticEase();

            elem.BeginAnimation(UIElement.OpacityProperty, anim);
        }
        public static void CreateWrap(List<WrapPanel> list)
        {
            foreach (var item in list)
            {
                item.Children.Clear();
            }
        }
        public static void CreateAnimOpenClose(UIElement OpenElem, UIElement CloseElem)
        {
            DoubleAnimation anim = new DoubleAnimation();

            anim.From = OpenElem.Opacity;
            anim.To = 0;
            anim.Duration = TimeSpan.FromSeconds(0.2);
            anim.EasingFunction = new QuarticEase();

            anim.Completed += (s, e) =>
            {
                DoubleAnimation anim1 = new DoubleAnimation();

                CloseElem.Visibility = Visibility.Visible;

                anim1.From = CloseElem.Opacity;
                anim1.To = 1;
                anim1.Duration = TimeSpan.FromSeconds(0.2);
                anim1.EasingFunction = new QuarticEase();

                CloseElem.BeginAnimation(UIElement.OpacityProperty, anim1);
            };

            OpenElem.BeginAnimation(UIElement.OpacityProperty, anim);

            OpenElem.Visibility = Visibility.Hidden;

            
        }

    }
}
