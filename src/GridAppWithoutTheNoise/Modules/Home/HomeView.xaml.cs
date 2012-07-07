using System;
using System.Collections.Generic;
using GridAppWithoutTheNoise.DataModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GridAppWithoutTheNoise.Modules.Home
{
    public sealed partial class HomeView
    {
        public HomeView()
        {
            InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var sampleDataGroups = SampleDataSource.GetGroups((String)navigationParameter);
            DefaultViewModel["Groups"] = sampleDataGroups;
        }

        void HeaderClick(object sender, RoutedEventArgs e)
        {
            // Determine what group the Button instance represents
            var group = (sender as FrameworkElement).DataContext;

            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            Frame.Navigate(typeof(GroupView), ((SampleDataGroup)group).UniqueId);
        }

        /// <summary>
        /// Invoked when an item within a group is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemViewItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
            Frame.Navigate(typeof(ItemView), itemId);
        }
    }
}
