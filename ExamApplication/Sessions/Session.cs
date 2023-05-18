namespace ExamApplication.Sessions
{
    public class Session
    {
        public const string SessionKeyEnrollId = "_EnrollId";
        const string SessionKeyTime = "_Time";
        public string? SessionInfo_SessionTime { get; set; }
        private readonly ILogger<Session> _logger;
        private readonly HttpContext _httpContext;
        public Session(ILogger<Session> logger, HttpContext httpContext)
        {
            _logger = logger;
            _httpContext = httpContext;
        }
        public void OnGet(int EnrollId)
        {
            if (SessionKeyEnrollId != null)
            {
                _httpContext.Session.SetInt32(SessionKeyEnrollId, EnrollId);
            }
            var enrollId = _httpContext.Session.GetInt32(SessionKeyEnrollId);
            _logger.LogInformation("Session Name: {enrollId}", enrollId);
        }
    }
}
