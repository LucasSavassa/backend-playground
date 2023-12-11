namespace NeuralNetwork.Domain
{
    internal class NeuralConnection : INeuralConnection
    {
        public double Weight { get; init; }
        public INeuron Input { get; init; }
        public INeuron Output { get; init; }

        public NeuralConnection(INeuron input, INeuron output, double weight)
        {
            Input = input;
            Output = output;
            Weight = weight;
        }
    }
}
