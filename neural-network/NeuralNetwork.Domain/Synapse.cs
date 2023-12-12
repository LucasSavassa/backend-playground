namespace NeuralNetwork.Domain
{
    internal class Synapse : ISynapse
    {
        public double Weight { get; set; }
        public INeuron Input { get; init; }
        public INeuron Output { get; init; }

        public Synapse(INeuron input, INeuron output, double weight)
        {
            Input = input;
            Output = output;
            Weight = weight;
        }
    }
}
