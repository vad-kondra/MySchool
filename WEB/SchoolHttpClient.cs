using System.Net.Http;

namespace WEB
{
    public class SchoolHttpClient : HttpClient
    {
        public string TeachersServiceHost { get; set; }
        public string SchoolClassesServiceHost { get; set; }
    }
}