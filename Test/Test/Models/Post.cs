using SQLite;

namespace AuditPlus.Models
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int AppId { get; set; }
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public long Timestamp { get; set; }
    }
}
