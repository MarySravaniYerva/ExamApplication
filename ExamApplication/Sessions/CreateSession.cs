namespace ExamApplication.Sessions
{
    public class CreateSession
    {
        public static IHttpContextAccessor _context;
        public CreateSession(IHttpContextAccessor httpContext)
        {
            _context = httpContext;
        }
        public void SetSession(object obj, string newSession)
        {
            SessionExtension.Set(_context.HttpContext.Session, newSession, obj);
        }
    }
}
