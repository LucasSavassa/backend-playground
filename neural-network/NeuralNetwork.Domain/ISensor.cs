namespace NeuralNetwork.Domain
{
    public interface ISensor : INeuron
    {
        void Set(double value);
    }
}
