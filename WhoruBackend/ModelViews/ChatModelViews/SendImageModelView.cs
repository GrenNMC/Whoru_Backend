namespace WhoruBackend.ModelViews.ChatModelViews
{
    public class SendImageModelView
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public IFormFile File { get; set; }

        public SendImageModelView(int sender, int receiver, IFormFile file)
        {
            Sender = sender;
            Receiver = receiver;
            File = file;
        }

        public SendImageModelView()
        {
        }
    }
}
