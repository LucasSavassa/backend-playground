namespace NeuralNetwork.Domain
{
    public interface ILayer
    {
        byte Index { get; }
        ILayer? PreviousLayer { get; }
        IReadOnlyCollection<INeuron> Neurons { get; }
        IReadOnlyDictionary<INeuron, IReadOnlyCollection<ISynapse>> Synapses { get; }
        void AddNeuron(INeuron neuron);
        IDictionary<INeuron, ICollection<ISynapse>> Connect(ILayer previousLayer, IDictionary<INeuron, ICollection<double>> weights);
        void UpdateBiases(IDictionary<INeuron, double> biases);
        void UpdateWeights(IDictionary<INeuron, ICollection<double>> weights);
    }
}