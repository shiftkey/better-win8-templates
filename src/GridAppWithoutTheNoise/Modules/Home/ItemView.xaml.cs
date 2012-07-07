using System;
using System.Collections.Generic;
using GridAppWithoutTheNoise.DataModel;

namespace GridAppWithoutTheNoise.Modules.Home
{
    public sealed partial class ItemView
    {
        public ItemView()
        {
            InitializeComponent();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // Allow saved page state to override the initial item to display
            if (pageState != null && pageState.ContainsKey("SelectedItem"))
            {
                navigationParameter = pageState["SelectedItem"];
            }

            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var item = SampleDataSource.GetItem((String)navigationParameter);
            // TODO: simplify this viewmodel
            var viewModel = new ItemViewModel
                {
                    SelectedItem = item,
                    Group = item.Group,
                    Items = item.Group.Items
                };
            DataContext = viewModel;
            flipView.SelectedItem = item;
        }

        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            var selectedItem = (SampleDataItem)flipView.SelectedItem;
            pageState["SelectedItem"] = selectedItem.UniqueId;
        }
    }
}
