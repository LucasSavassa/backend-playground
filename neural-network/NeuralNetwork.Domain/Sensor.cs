namespace NeuralNetwork.Domain
{
    public class Sensor : ISensor
    {
        public event EventHandler? NeuronFired;
        public IReadOnlyCollection<ISynapse> Synapses { get; } = new List<ISynapse>();
        public double Value { get; private set; }
        public double Bias { get { return 0; } set { throw new InvalidOperationException("Input neurons cannot have a bias."); } }

        public ISynapse Connect(INeuron input, double weight)
        {
            throw new InvalidOperationException("Input neurons cannot be connected to other neurons.");
        }

        public void Fire(double value)
        {
            Value = value;

            OnNeuronFired();
        }

        private void OnNeuronFired()
        {
            NeuronFired?.Invoke(this, EventArgs.Empty);
        }
    }
}
