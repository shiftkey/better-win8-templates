using System.Collections.ObjectModel;
using GridAppWithoutTheNoise.Common;
using GridAppWithoutTheNoise.DataModel;

namespace GridAppWithoutTheNoise.Modules.Home
{
    public class HomeViewModel : BindableBase
    {
#if DEBUG
        // TODO: do not like this hack but it takes away the nasty syntax from the XAML side
        public HomeViewModel()
        {
            var source = new SampleDataSource();
            Groups = source.AllGroups;
        }
#endif

        ObservableCollection<SampleDataGroup> groups;
        public ObservableCollection<SampleDataGroup> Groups
        {
            get { return groups; }
            set { SetProperty(ref groups, value); }
        }
    }
}
