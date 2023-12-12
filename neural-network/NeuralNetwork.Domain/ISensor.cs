namespace NeuralNetwork.Domain
{
    public interface ISensor : INeuron
    {
        void Fire(double value);
    }
}
