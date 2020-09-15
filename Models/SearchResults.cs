using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SearchProject.Models
{

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


