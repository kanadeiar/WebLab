using Microsoft.ML;

Console.WriteLine("Тестирование ML");

var context = new MLContext();
var reader = context.Data.CreateTextLoader<IrisData>(separatorChar: ',', hasHeader: true);
var dataView = reader.Load("iris.data.txt");

var pipeline = context.Transforms.Conversion.MapValueToKey(outputColumnName: "Label")
    .Append(context.Transforms.Concatenate("Features", "SepalLength", "SepalWidth", "PetalLength", "PetalWidth"))
    .Append(context.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
    .Append(context.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

var trainedModel = pipeline.Fit(dataView);

var engine = context.Model.CreatePredictionEngine<IrisData, IrisPrediction>(trainedModel);

var test = new IrisData()
{
    SepalLength = 3.3f,
    SepalWidth = 1.6f,
    PetalLength = 0.2f,
    PetalWidth = 5.1f,
};

var prediction = engine.Predict(test);

Console.WriteLine($"Тип цветка: {prediction.PredictedLabel}");

Console.WriteLine("Нажмите любую кнопку ...");
Console.ReadKey();


