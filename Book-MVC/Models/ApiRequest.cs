using static Book_MVC.StaticDetails;

namespace Book_MVC.Models
{
    public class ApiRequest
    {
        public ApiType apiType {  get; set; }
        public Object Data { get; set; }
        public string Url {  get; set; }
        public string AccessToken { get; set; }

    }
}
