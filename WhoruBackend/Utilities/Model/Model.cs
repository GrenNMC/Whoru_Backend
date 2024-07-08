using System;
using System.IO;
using System.Linq;
using Tensorflow;
using NumSharp;
using static Tensorflow.Binding;
using static Tensorflow.KerasApi;
using SkiaSharp;
using System.Drawing;


namespace WhoruBackend.Utilities.Model
{
    public class Model
    {
        //public string ClassifyImage(IFormFile imageFile)
        //{
        //    // Đường dẫn tới mô hình .h5
        //    string modelPath = "path_to_model.h5";
        //    //string weightsPath = "";
        //    // Tạo mô hình từ file .pb
        //    var model = LoadModel(modelPath);

        //    // Tiền xử lý ảnh từ IFormFile
        //    var image = LoadImageFromFormFile(imageFile);

        //    // Thực hiện dự đoán
        //    var prediction = Predict(model, image);

        //    // Ánh xạ kết quả dự đoán thành nhãn
        //    string label = MappingToLabel(prediction);

        //    return label;
        //}
        //static Session LoadModel(string modelPath)
        //{
        //    var graph = new Graph().as_default();
        //    var session = new Session(graph);

        //    // Load the model
        //    var metaGraphDef = tf.train.import_meta_graph(Path.Combine(modelPath, "saved_model.pb"));
        //    tf.train.Saver().restore(session, Path.Combine(modelPath, "variables/variables"));

        //    return session;
        //}

        //static NDArray Predict(Session session, NDArray image)
        //{
        //    // Assuming the input tensor name is "input" and output tensor name is "output"
        //    var inputTensor = session.graph.OperationByName("input").output;
        //    var outputTensor = session.graph.OperationByName("output").output;

        //    var runner = session.GetRunner();
        //    runner.AddInput(inputTensor, image);
        //    runner.Fetch(outputTensor);

        //    var result = runner.Run();
        //    return result[0];
        //}
        //static string MappingToLabel(NDArray prediction)
        //{
        //    // Danh sách các nhãn
        //    string[] labels = { "drawings", "hentai", "neutral", "porn", "sexy" };

        //    // Tìm chỉ số của giá trị lớn nhất trong mảng dự đoán
        //    int maxIndex = np.argmax(prediction);

        //    // Trả về nhãn tương ứng với chỉ số lớn nhất
        //    return labels[maxIndex];
        //}
        //static NDArray LoadImageFromFormFile(IFormFile formFile)
        //{
        //    using (var stream = formFile.OpenReadStream())
        //    {
        //        var bitmap = new Bitmap(stream);
        //        var resized = new Bitmap(bitmap, new Size(224, 224));

        //        float[,,] imageData = new float[224, 224, 3];

        //        for (int y = 0; y < resized.Height; y++)
        //        {
        //            for (int x = 0; x < resized.Width; x++)
        //            {
        //                var color = resized.GetPixel(x, y);
        //                imageData[y, x, 0] = color.R / 255.0f;
        //                imageData[y, x, 1] = color.G / 255.0f;
        //                imageData[y, x, 2] = color.B / 255.0f;
        //            }
        //        }

        //        var npImage = np.array(imageData);
        //        npImage = np.expand_dims(npImage, axis: 0);
        //        return npImage;
        //    }
        //}
    }
}
