using System.Collections.ObjectModel;

namespace NeuralNetwork.Domain
{
    public class Layer : ILayer
    {
        private readonly List<INeuron> _neurons = new();
        private readonly Dictionary<INeuron, IReadOnlyCollection<ISynapse>> _synapses = new();

        public byte Index { get; init; }

        public ILayer? PreviousLayer { get; init; }

        public IReadOnlyCollection<INeuron> Neurons { get; init; }

        public IReadOnlyDictionary<INeuron, IReadOnlyCollection<ISynapse>> Synapses { get; init; }

        public Layer(ILayer previousLayer)
        {
            PreviousLayer = previousLayer;
            Index = (byte)(previousLayer.Index + 1);
            Neurons = new ReadOnlyCollection<INeuron>(_neurons);
            Synapses = new Dictionary<INeuron, IReadOnlyCollection<ISynapse>>(_synapses);
        }

        public void AddNeuron(INeuron neuron)
        {
            _neurons.Add(neuron);
        }

        public IDictionary<INeuron, ICollection<ISynapse>> Connect(ILayer previousLayer, IDictionary<INeuron, ICollection<double>> weights)
        {
            IDictionary<INeuron, ICollection<ISynapse>> result = new Dictionary<INeuron, ICollection<ISynapse>>();

            foreach(INeuron neuron in _neurons)
            {
                List<ISynapse> neuronSynapses = new List<ISynapse>();

                foreach(INeuron previousLayerNeuron in previousLayer.Neurons)
                {
                    ISynapse synapse = neuron.Connect(previousLayerNeuron, weights[i, j]);
                    neuronSynapses.Add(synapse);
                }

                _synapses.Add(neuron, new ReadOnlyCollection<ISynapse>(neuronSynapses));
                result.Add(neuron, neuronSynapses);
            }

            return result;
        }

        public void UpdateBiases(IDictionary<INeuron, double> biases)
        {
            if (biases.Count != _neurons.Count)
                throw new ArgumentException("The number of biases must match the number of neurons in the layer.", nameof(biases));

            foreach(INeuron neuron in biases.Keys)
            {
                if(!_neurons.Contains(neuron))
                    throw new ArgumentException("The neuron must be in the layer.", nameof(neuron));

                _neurons.ElementAt(_neurons.IndexOf(neuron)).Bias = biases[neuron];
            }
        }

        public void UpdateWeights(IDictionary<INeuron, ICollection<double>> weights)
        {
            if (weights.Count != _neurons.Count)
                throw new ArgumentException("The number of collection of weights must match the number of neurons in the layer.", nameof(weights));

            foreach(INeuron neuron in Synapses.Keys)
            {
                if(!_neurons.Contains(neuron))
                    throw new ArgumentException("The neuron must be in the layer.", nameof(neuron));

                if (weights[neuron].Count != _synapses[neuron].Count)
                    throw new ArgumentException("The number of weights for a neuron must match the number of synapses in the neuron.", nameof(weights));

                for(int i = 0; i < _synapses[neuron].Count; i++)
                {
                    ISynapse synapse = Synapses[neuron].ElementAt(i);
                    synapse.Weight = weights[neuron].ElementAt(i);
                }
            }
        }
    }
}
