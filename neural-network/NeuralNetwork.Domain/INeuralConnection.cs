namespace NeuralNetwork.Domain
{
    public interface INeuralConnection
    {
        double Weight { get; }
        INeuron Input { get; }
        INeuron Output { get; }
    }
}