using System.Collections.ObjectModel;

namespace NeuralNetwork.Domain
{
    public class SensorLayer : ISensorLayer
    {
        private readonly List<INeuron> _neurons = new();
        private readonly Dictionary<INeuron, IReadOnlyCollection<ISynapse>> _synapses = new();

        public byte Index => 0;
        public ILayer? PreviousLayer => null;
        public IReadOnlyCollection<INeuron> Neurons { get; init; }
        public IReadOnlyDictionary<INeuron, IReadOnlyCollection<ISynapse>> Synapses { get; init; }

        public SensorLayer()
        {
            Neurons = new ReadOnlyCollection<INeuron>(_neurons);
            Synapses = new ReadOnlyDictionary<INeuron, IReadOnlyCollection<ISynapse>>(_synapses);
        }

        public void AddNeuron(INeuron neuron)
        {
            if (neuron is not ISensor)
                throw new ArgumentException("Neurons in an Sensor Layer must implement ISensor.", nameof(neuron));

            _neurons.Add(neuron);
        }

        public IDictionary<INeuron, ICollection<ISynapse>> Connect(ILayer previousLayer, double[,] weights)
        {
            throw new InvalidOperationException("Cannot connect an Input Layer to a previous layer.");
        }

        public void UpdateBiases(IDictionary<INeuron, double> biases)
        {
            throw new InvalidOperationException("Cannot update biases in an Input Layer.");
        }

        public void UpdateWeights(IDictionary<INeuron, ICollection<double>> weights)
        {
            throw new InvalidOperationException("Cannot update weights in an Input Layer.");
        }

        public void Fire(IDictionary<ISensor, double> values)
        {
            if (values.Count != _neurons.Count)
                throw new ArgumentException("The number of values must match the number of sensors in the Input Layer.", nameof(values));

            foreach (ISensor neuron in _neurons)
            {
                if (!_neurons.Contains(neuron))
                    throw new ArgumentException("Cannot update a sensor not contained in the Sensor Layer.", nameof(neuron));

                neuron.Fire(values[neuron]);
            }
        }
    }
}
