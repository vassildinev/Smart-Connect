namespace SmartConnect.Services.Sanitizers
{
    using Contracts;
    using Ganss.XSS;

    public class SanitizerService : ISanitizerService
    {
        private IHtmlSanitizer sanitizer = new HtmlSanitizer();

        public SanitizerService()
        {
            // because reasons
            this.sanitizer = new HtmlSanitizer();
        }

        public string Sanitize(string html)
        {
            return this.sanitizer.Sanitize(html);
        }
    }
}
