using System;

namespace GridAppWithoutTheNoise.DataModel
{
    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class SampleDataItem : SampleDataCommon
    {
        public SampleDataItem(String uniqueId, String title, String subtitle, String imagePath, String description, String content, SampleDataGroup group)
            : base(uniqueId, title, subtitle, imagePath, description)
        {
            this.content = content;
            this.group = group;
        }

        string content = string.Empty;
        public string Content
        {
            get { return content; }
            set { SetProperty(ref content, value); }
        }

        SampleDataGroup group;
        public SampleDataGroup Group
        {
            get { return group; }
            set { SetProperty(ref group, value); }
        }
    }
}