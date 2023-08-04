namespace Decisions.TruCap.Api;

public class LoginResponse {
        public bool isSuccess { get; set; }
        public string token { get; set; }
        public string message { get; set; }
        public string sid { get; set; }
        public string ValidationUrl { get; set; }
}