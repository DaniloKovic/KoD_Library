using KoD_Library_HCI_Core6.Helper;
using KoD_Library_HCI_Core6.Models.Enums;
using KoD_Library_HCI_Core6.Repository;
using KoD_Library_HCI_Core6.Views.Pages;
using KoD_Library_HCI_Core6.Views.UserControls;
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
using System.Windows.Shapes;

namespace KoD_Library_HCI_Core6.Views.Menu
{
    /// <summary>
    /// Interaction logic for KorisnikMenu.xaml
    /// </summary>
    public partial class KorisnikMenu : Window
    {
        private Grid _windowGrid = new Grid();
        private List<DockPanel> _dockPanelList = new List<DockPanel>();
        public KorisnikMenu()
        {
            InitializeComponent();
            ApplyCustomStyle(LoggedUserHelper.currentUserTemplateID.ToString());
        }

        private void ApplyCustomStyle(string templateID)
        {
            var windowChildControls = LogicalTreeHelper.GetChildren(this);
            _windowGrid = windowChildControls.OfType<Grid>().ElementAt(0);
            foreach (var gridChild in _windowGrid.Children)
            {
                if (gridChild.GetType() == typeof(DockPanel))
                {
                    DockPanel dockPanel = (DockPanel)gridChild;
                    if (!dockPanel.Name.Equals("dpKorisnikFrame"))
                        _dockPanelList.Add(dockPanel);
                }
            }
            foreach (var dockPanel in _dockPanelList)
            {
                dockPanel.Style = (Style)Application.Current.FindResource($"dpTemplateStyle{templateID}");
            }
        }

        private void NavSideBarUserUC_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
