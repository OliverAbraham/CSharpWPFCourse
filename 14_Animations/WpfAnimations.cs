using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace _14_Animations
{
	internal class WpfAnimations
	{
		public static void FadeOut(Control control, DependencyProperty property)
		{
			control.Opacity = 1.0;
			control.Visibility = System.Windows.Visibility.Visible;

			Create_and_start_animation(control, 1.0, 0.0, property,
				delegate { control.Visibility = System.Windows.Visibility.Hidden; });
		}

		public static void FadeIn(Control control, DependencyProperty property)
		{
			control.Opacity = 0.0;
			control.Visibility = System.Windows.Visibility.Visible;

			Create_and_start_animation(control, 0.0, 1.0, property,
				delegate { control.Visibility = System.Windows.Visibility.Visible; });
		}

		public static void Create_and_start_animation(Control control, double from, double to, DependencyProperty property, EventHandler completedAction)
		{
			var a = new DoubleAnimation
			{
				From = from,
				To = to,
				FillBehavior = FillBehavior.HoldEnd,
				BeginTime = TimeSpan.FromSeconds(0),
				Duration = new Duration(TimeSpan.FromSeconds(1.0))
			};
			var storyboard = new Storyboard();

			storyboard.Children.Add(a);
			Storyboard.SetTarget(a, control);
			Storyboard.SetTargetProperty(a, new PropertyPath(property));
			storyboard.Completed += completedAction;
			storyboard.Begin();
		}
	}
}
