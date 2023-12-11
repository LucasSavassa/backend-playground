namespace NeuralNetwork.Domain
{
    public interface INeuron
    {
        event EventHandler? RaiseNeuronFiredEvent;
        ICollection<INeuralConnection> Connections { get; }
        double Value { get; }
        double Bias { get; }
        void Connect(INeuron input, double weight);
        void Fire();
    }
}