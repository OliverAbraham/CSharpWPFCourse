using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _16_Layout_with_4_sections
{
	class PopupManager
    {
        public delegate List<object> OnOpenPopupEventHandlerType(string tag);
        public event OnOpenPopupEventHandlerType OnOpen;

        public delegate void OnClosePopupEventHandlerType(object selectedItem);
        public event OnClosePopupEventHandlerType OnClose;

        private ListBox _MyPopup = null;
        private Grid _PopupParent = null;

        public void ShowPopup(object sender, MouseButtonEventArgs e)
        {
            var Cogwheel = (sender as Image);
            string Tag = Cogwheel.Tag as string;

            if (_PopupParent != null)
                _PopupParent.Children.Remove(_MyPopup);

            _MyPopup = new ListBox();
            _MyPopup.HorizontalAlignment = HorizontalAlignment.Right;
            _MyPopup.VerticalAlignment = VerticalAlignment.Top;
            _MyPopup.Margin = new Thickness(0, Cogwheel.Margin.Top + 20,20,0);
            _MyPopup.Width = 100;
            
            var Items = OnOpen(Tag);
            foreach (var item in Items)
                _MyPopup.Items.Add(item);
            _MyPopup.Height = _MyPopup.Items.Count * 25;
            
            var NextParent = Cogwheel.Parent as Grid;
            _PopupParent = NextParent.Parent as Grid;
            _PopupParent.Children.Add(_MyPopup);
            

            _MyPopup.SelectionChanged += delegate(object sender2, SelectionChangedEventArgs e2)
            {
                OnClose(_MyPopup.SelectedItem);
                _PopupParent.Children.Remove(_MyPopup);
                _MyPopup = null;
                _PopupParent = null;
            };
        }
    }
}
