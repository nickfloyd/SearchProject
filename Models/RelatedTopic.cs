using System.Collections.Generic;

namespace SearchProject.Models
{
    public class RelatedTopic
    {
        public string FirstURL { get; set; }
        public Icon Icon { get; set; }
        public string Result { get; set; }
        public string Text { get; set; }
        public IList<Topic> Topics { get; set; }
        public string Name { get; set; }
    }
}
