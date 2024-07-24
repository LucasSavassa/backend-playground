namespace NeuralNetwork.Domain
{
    public interface INeuron
    {
        event EventHandler? NeuronFired;
        IReadOnlyCollection<ISynapse> Synapses { get; }
        double Value { get; }
        double Bias { get; set; }
        ISynapse Connect(INeuron input, double weight);
    }
}