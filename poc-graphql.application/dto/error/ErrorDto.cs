namespace poc_graphql.application.dto.error
{
    public class ErrorDto
    {
        public int code { get; set; }
        public string? message { get; set; }
        public bool error { get; set; }
    }
}
