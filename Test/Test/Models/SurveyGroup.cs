using System.Collections.Generic;

namespace Test.Models
{
    class SurveyGroup
    {
        public string Title { get; set; }
        public List<Survey> Surveys { get; set; }
        public bool IsVisible { get; set; }
    }
}
