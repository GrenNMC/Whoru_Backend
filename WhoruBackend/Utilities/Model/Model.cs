using HeyRed.Mime;
using ImageMagick;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.ML;
using Tensorflow;
using System.Web;
namespace WhoruBackend.Utilities.Model
{
    public class Model
    {
        private static ITransformer _model;

        public Model()
        {
            if (_model == null)
            {
                var modelPath = Path.Combine(AppContext.BaseDirectory, "Model.zip");
                var mlContext = new MLContext();
                _model = mlContext.Model.Load(modelPath, out var modelInputSchema);
            }

        }
        public NsfwSpyResult ClassifyImage(IFormFile imageFile)
        {
            var imageData = ConvertFormFileToByteArray(imageFile);
            var fileType = MimeGuesser.GuessFileType(imageData);
            if (fileType.Extension == "webp")
            {
                using (MagickImage image = new MagickImage(imageData))
                {
                    imageData = image.ToByteArray(MagickFormat.Png);
                }
            }

            var modelInput = new ModelInput(imageData);
            var mlContext = new MLContext();
            var predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(_model);
            var modelOutput = predictionEngine.Predict(modelInput);
            return new NsfwSpyResult(modelOutput);
        }
        private byte[] ConvertFormFileToByteArray(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return fileBytes;
            }
        }


    }
}
