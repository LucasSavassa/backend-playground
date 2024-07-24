namespace NeuralNetwork.Domain
{
    public interface ISensorLayer : ILayer
    {
        void Fire(IDictionary<ISensor, double> values);
    }
}
