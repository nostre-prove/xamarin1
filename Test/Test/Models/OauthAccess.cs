using System;
using System.Collections.Generic;
using System.Text;

namespace AuditPlus.Models
{
    class OauthAccess
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
        public string user_info { get; set; }
        public string identity { get; set; }
        public long ts_created { get; set; }
        public string jti { get; set; }
    }
}
