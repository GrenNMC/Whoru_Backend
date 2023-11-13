namespace WhoruBackend.ModelViews
{
    public class ResponseView
    {
        public string? Message { get; set; }
        //code 
        public ResponseView() { }

        public ResponseView(string? message)
        {
            Message = message;
        }
    }
}
