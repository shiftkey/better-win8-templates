using System.Collections.ObjectModel;
using GridAppWithoutTheNoise.Common;
using GridAppWithoutTheNoise.DataModel;

namespace GridAppWithoutTheNoise.Modules.Home
{
    public class ItemViewModel : BindableBase
    {
#if DEBUG
        // TODO: do not like this hack but it takes away the nasty syntax from the XAML side
        public ItemViewModel()
        {
            var source = new SampleDataSource();
            var sampleData = source.AllGroups[0];
            Group = sampleData;
            Items = sampleData.Items;
        }
#endif

        SampleDataItem selectedItem;
        public SampleDataItem SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
        }

        SampleDataGroup group;
        public SampleDataGroup Group
        {
            get { return group; }
            set { SetProperty(ref group, value); }
        }

        ObservableCollection<SampleDataItem> items;
        public ObservableCollection<SampleDataItem> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }
    }
}
