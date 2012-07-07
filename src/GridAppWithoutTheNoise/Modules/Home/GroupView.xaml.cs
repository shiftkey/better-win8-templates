using System;
using System.Collections.Generic;
using GridAppWithoutTheNoise.DataModel;
using Windows.UI.Xaml.Controls;

namespace GridAppWithoutTheNoise.Modules.Home
{
    public sealed partial class GroupView
    {
        public GroupView()
        {
            InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            var group = SampleDataSource.GetGroup((String)navigationParameter);
            var viewModel = new GroupViewModel
            {
                Group = group,
                Items = group.Items
            };
            DataContext = viewModel;
        }

        void ItemViewItemClick(object sender, ItemClickEventArgs e)
        {
            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
            Frame.Navigate(typeof(ItemView), itemId);
        }
    }
}
