using System.Collections.Generic;

namespace AuditPlus.Models
{
    class LoginResponse
    {
        public List<string> data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public string currentDateTime { get; set; }
    }
}
