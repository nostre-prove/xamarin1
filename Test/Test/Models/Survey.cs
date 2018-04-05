using System.Collections.Generic;

namespace AuditPlus.Models
{
    public class Survey
    {
        public int SiteId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public int TypeId { get; set; }
        public SurveyLookup TypeLookup { get; set; }
        public List<string> TypeOptions { get; set; }
        public string TypeDescriptionText { get; set; }
        public int TypeDescriptionDigit { get; set; }
        public bool IsVisible { get; set; }
    }
}
