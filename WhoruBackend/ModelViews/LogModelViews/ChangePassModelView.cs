namespace WhoruBackend.ModelViews.LogModelViews
{
    public class ChangePassModelView
    {
        public string pass {  get; set; }
        public string prePass {  get; set; }

        public ChangePassModelView(string pass, string prePass)
        {
            this.pass = pass;
            this.prePass = prePass;
        }
    }
}
