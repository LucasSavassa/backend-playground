using System.Collections.ObjectModel;

namespace NeuralNetwork.Domain
{
    public class SigmoidNeuron : INeuron
    {
        private readonly List<ISynapse> _synapses = new();

        public event EventHandler? NeuronFired;
        public IReadOnlyCollection<ISynapse> Synapses { get; init; }
        public double Value { get; private set; }
        public double Bias { get; private set; }

        public SigmoidNeuron(double bias)
        {
            Bias = bias;
            Synapses = new ReadOnlyCollection<ISynapse>(_synapses);
        }

        public ISynapse Connect(INeuron input, double weight)
        {
            input.NeuronFired += HandleNeuronFired;

            Synapse synapse = new(input, this, weight);
            _synapses.Add(synapse);
            
            return synapse;
        }

        private void HandleNeuronFired(object? sender, EventArgs e)
        {
            Fire();
        }

        private void Fire()
        {
            double sum = 0;

            foreach (ISynapse connection in Synapses)
            {
                sum += connection.Input.Value * connection.Weight;
            }

            Value = Sigmoid(sum + Bias);

            OnNeuronFired();
        }

        private static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        private void OnNeuronFired()
        {
            NeuronFired?.Invoke(this, EventArgs.Empty);
        }
    }
}