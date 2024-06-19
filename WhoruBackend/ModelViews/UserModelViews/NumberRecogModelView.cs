namespace WhoruBackend.ModelViews.UserModelViews
{
    public class NumberRecogModelView
    {
        public int UserId { get; set; }
        public List<double> Embedding { get; set; }

        public NumberRecogModelView(int userId, List<double> embedding)
        {
            UserId = userId;
            Embedding = embedding;
        }

        public NumberRecogModelView()
        {
        }
    }
}
