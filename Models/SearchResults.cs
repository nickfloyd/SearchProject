using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SearchProject.Models
{

    public class Icon
    {
        public string Height { get; set; }
        public string URL { get; set; }
        public string Width { get; set; }
    }

    public class Topic
    {

        public Icon Icon { get; set; }
        public string FirstURL { get; set; }
        public string Text { get; set; }
        public string Result { get; set; }
    }

    public class RelatedTopic
    {
        public string FirstURL { get; set; }
        public Icon Icon { get; set; }
        public string Result { get; set; }
        public string Text { get; set; }
        public IList<Topic> Topics { get; set; }
        public string Name { get; set; }
    }

    public class SrcOptions
    {
        public string source_skip { get; set; }
        public int skip_icon { get; set; }
        public string skip_qr { get; set; }
        public int is_mediawiki { get; set; }
        public int is_wikipedia { get; set; }
        public string directory { get; set; }
        public int skip_image_name { get; set; }
        public string language { get; set; }
        public int skip_abstract_paren { get; set; }
        public int is_fanon { get; set; }
        public string src_info { get; set; }
        public int skip_abstract { get; set; }
        public string min_abstract_length { get; set; }
        public string skip_end { get; set; }
    }

    public class Developer
    {
        public string type { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Maintainer
    {
        public string github { get; set; }
    }

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

    public class SearchResults
    {
        public ObservableCollection<RelatedTopic> RelatedTopics { get; set; }
        public string Definition { get; set; }
        public string Redirect { get; set; }
        public int ImageIsLogo { get; set; }
        public string DefinitionSource { get; set; }
        public string Abstract { get; set; }
        public string AbstractSource { get; set; }
        public string AnswerType { get; set; }
        public int ImageHeight { get; set; }
        public IList<object> Results { get; set; }
        public string AbstractText { get; set; }
        public int ImageWidth { get; set; }
        public string Entity { get; set; }
        public string Heading { get; set; }
        public string DefinitionURL { get; set; }
        public string Answer { get; set; }
        public string AbstractURL { get; set; }
        public string Infobox { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public Meta meta { get; set; }

        public string Summary
        {
            get
            {
                return $"topics";
            }
        }
    }

    public class RelatedTopicsViewModel
    {
        private RelatedTopic defaultRelatedTopic = new RelatedTopic();
        public RelatedTopic DefaultRelatedTopic { get { return this.defaultRelatedTopic; } }

        private ObservableCollection<RelatedTopic> relatedTopics = new ObservableCollection<RelatedTopic>();
        public ObservableCollection<RelatedTopic> RelatedTopics { get { return this.relatedTopics; } }

        private Topic defaultTopic = new Topic();
        public Topic DefaultTopic { get { return this.defaultTopic; } }

        private ObservableCollection<Topic> topics = new ObservableCollection<Topic>();
        public ObservableCollection<Topic> Topics { get { return this.topics; } }

        public RelatedTopicsViewModel()
        {
            this.relatedTopics.Add(this.DefaultRelatedTopic);
            this.topics.Add(this.DefaultTopic);
        }

        public RelatedTopicsViewModel(SearchResults searchResults)
        {
            //this.relatedTopics = searchResults.RelatedTopics;

            if (searchResults != null && searchResults.RelatedTopics != null)
            {

                foreach (var rtItems in searchResults.RelatedTopics)
                {

                    if (rtItems.Topics != null)
                    {
                        foreach (var rItem in rtItems.Topics)
                        {
                            this.topics.Add(rItem);
                        }
                    }
                    else
                    {
                        this.relatedTopics.Add(rtItems);
                    }

                }
            }
        }
    }
}


