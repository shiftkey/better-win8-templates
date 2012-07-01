using System;
using System.Collections.Generic;
using GridAppWithoutTheNoise.DataModel;
using Windows.UI.Xaml.Controls;

namespace GridAppWithoutTheNoise
{
    public sealed partial class GroupDetailPage
    {
        public GroupDetailPage()
        {
            InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            var group = SampleDataSource.GetGroup((String)navigationParameter);
            DefaultViewModel["Group"] = group;
            DefaultViewModel["Items"] = group.Items;
        }

        void ItemViewItemClick(object sender, ItemClickEventArgs e)
        {
            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
            Frame.Navigate(typeof(ItemDetailPage), itemId);
        }
    }
}
