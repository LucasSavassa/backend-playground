namespace NeuralNetwork.Domain
{
    public class SigmoidNeuron : INeuron
    {
        public event EventHandler? RaiseNeuronFiredEvent;
        public ICollection<INeuralConnection> Connections { get; private set; } = new List<INeuralConnection>();
        public double Value { get; private set; }
        public double Bias { get; private set; }

        public SigmoidNeuron(double bias)
        {
            Bias = bias;
        }

        public void Connect(INeuron input, double weight)
        {
            NeuralConnection neuralConnection = new(input, this, weight);
            Connections.Add(neuralConnection);
            input.RaiseNeuronFiredEvent += HandleNeuronFiredEvent;
        }

        public void Fire()
        {
            double sum = 0;

            foreach (INeuralConnection connection in Connections)
            {
                sum += connection.Input.Value * connection.Weight;
            }

            Value = Sigmoid(sum + Bias);

            OnRaiseNeuronFiredEvent();
        }

        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        private void OnRaiseNeuronFiredEvent()
        {
            RaiseNeuronFiredEvent?.Invoke(this, EventArgs.Empty);
        }

        private void HandleNeuronFiredEvent(object? sender, EventArgs e)
        {
            Fire();
        }
    }
}