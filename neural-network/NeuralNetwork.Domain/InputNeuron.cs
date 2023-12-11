namespace NeuralNetwork.Domain
{
    public class InputNeuron : ISensor
    {
        public event EventHandler? RaiseNeuronFiredEvent;
        public ICollection<INeuralConnection> Connections { get; } = new List<INeuralConnection>();
        public double Value { get; private set; }
        public double Bias => 0;

        public void Connect(INeuron input, double weight)
        {
            return;
        }

        public void Fire()
        {
            OnRaiseNeuronFiredEvent();
        }

        private void OnRaiseNeuronFiredEvent()
        {
            RaiseNeuronFiredEvent?.Invoke(this, EventArgs.Empty);
        }

        public void Set(double value)
        {
            Value = value;
        }
    }
}
