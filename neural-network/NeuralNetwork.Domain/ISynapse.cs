namespace NeuralNetwork.Domain
{
    public interface ISynapse
    {
        double Weight { get; set; }
        INeuron Input { get; }
        INeuron Output { get; }
    }
}