using KoD_Library_HCI_Core6.Views.Menu;
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

namespace KoD_Library_HCI_Core6.Views.UserControls
{
    /// <summary>
    /// Interaction logic for TemplateChange.xaml
    /// </summary>
    public partial class TemplateChange : UserControl
    {
        private List<UserControl> _userControls = new List<UserControl>();
        public TemplateChange()
        {
            InitializeComponent();
            //var _window = (ZaposleniMenu)Window.GetWindow(this);
            //var childrenControlsList = LogicalTreeHelper.GetChildren(_window);
            //foreach (var child in childrenControlsList)
            //{
            //    if (child is UserControl)
            //    {
            //        // child.GetType().GetProperty()
            //        _userControls.Add((UserControl)child);
            //        //((UserControl)child).Style = Application.GetResourceStream()
            //        //((UserControl)child).Style = new Style(UserControl uc, { })
            //        //((UserControl)child).Style = Application.GetResourceStream()
            //    }
            //}
        }

        private void btnTemplate1_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
            {
                Button btn = (Button)sender;
            }

            var _window = ((ZaposleniMenu)Window.GetWindow(this));
            var uc1 = (NavSideBarEmployeeUC)_window.FindName("NavSideBarEmployee");
            var uc2 = (NavSideBarUserUC)_window.FindName("NavSideBarUser");

            // LogicalTreeHelper.FindLogicalNode(UserControl, "NavSideBarEmployee");

            uc1.SetResourceReference(UserControl.StyleProperty, "ucTemplateStyle1");
            uc2.SetResourceReference(UserControl.StyleProperty, "ucTemplateStyle2");
            //var childrenControlsList = LogicalTreeHelper.GetChildren(_window);
            //foreach(var childControl in childrenControlsList)
            //{
            //    if (childControl is UserControl)
            //    {
            //        UserControl _userControl = (UserControl)childControl;
            //        _userControl.SetResourceReference(UserControl.StyleProperty, "ucTemplateStyle1");
            //    }
            //}
            

            // this.SetResourceReference(Control.StyleProperty, "ucTemplateStyle1");
            //var _window = (ZaposleniMenu)Window.GetWindow(this);
            //var childrenControlsList = LogicalTreeHelper.GetChildren(_window);
            //var childrenControlsList = LogicalTreeHelper.GetChildren(Window.GetWindow(this));
            //var childrenControlsList = LogicalTreeHelper.GetChildren(Window.GetWindow(this));
            //foreach (var child in childrenControlsList)
            //{
            //    if (child is UserControl)
            //    {
            //        child.GetType().GetProperty()
            //        _userControls.Add((UserControl)child);
            //        ((UserControl)child).Style = Application.GetResourceStream()
            //        ((UserControl)child).Style = new Style(UserControl uc, { })
            //        ((UserControl)child).Style = Application.GetResourceStream()
            //    }
            //}
        }

        private void btnTemplate2_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
            }
            this.SetResourceReference(Control.StyleProperty, "ucTemplateStyle2");
            //this.Background = btnTemplate1.Background;
            ucTemplateChange.Background = btnTemplate1.Foreground;
            
            //ucTemplateChange.Background = btnTemplate1.Background;
            //Window.GetWindow(this).Background = btnTemplate2.Background;
            //var _window = (ZaposleniMenu)(Window.GetWindow(this));
            //_window.
        }

        private void btnTemplate3_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
            }
            this.SetResourceReference(Control.StyleProperty, "ucTemplateStyle3");
            //this.Background = btnTemplate1.Background;
            //ucTemplateChange.Background = btnTemplate1.Foreground;
            //ucTemplateChange.Background = btnTemplate1.Background;
            //Window.GetWindow(this).Background = btnTemplate3.Background;
        }
    }
}
