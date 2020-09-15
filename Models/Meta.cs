using System.Collections.Generic;

namespace SearchProject.Models
{
    public class Meta
    {
        public object producer { get; set; }
        public string perl_module { get; set; }
        public string id { get; set; }
        public SrcOptions src_options { get; set; }
        public int Unsafe { get; set; }
        public string repo { get; set; }
        public object created_date { get; set; }
        public string signal_from { get; set; }
        public object src_url { get; set; }
        public IList<string> topic { get; set; }
        public object designer { get; set; }
        public object live_date { get; set; }
        public int src_id { get; set; }
        public IList<Developer> developer { get; set; }
        public string example_query { get; set; }
        public string description { get; set; }
        public string dev_milestone { get; set; }
        public object attribution { get; set; }
        public object dev_date { get; set; }
        public string name { get; set; }
        public object blockgroup { get; set; }
        public string production_state { get; set; }
        public string src_domain { get; set; }
        public object is_stackexchange { get; set; }
        public Maintainer maintainer { get; set; }
        public string src_name { get; set; }
        public string status { get; set; }
        public string js_callback_name { get; set; }
        public string tab { get; set; }
    }
}
