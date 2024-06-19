namespace WhoruBackend.ModelViews.UserModelViews
{
    public class EmbeddingModelView
    {
        public List<double> Embedded {  get; set; }

        public EmbeddingModelView(List<double> embedded)
        {
            Embedded = embedded;
        }
    }
}
