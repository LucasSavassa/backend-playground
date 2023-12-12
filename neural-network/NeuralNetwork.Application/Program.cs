using NeuralNetwork.Domain;

namespace NeuralNetwork.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ISensor inputNeuron1 = new InputNeuron();
            ISensor inputNeuron2 = new InputNeuron();
            
            INeuron neuron1 = new SigmoidNeuron(bias: 0.0);
            INeuron neuron2 = new SigmoidNeuron(bias: 0.0);
            
            neuron1.Connect(inputNeuron1, weight: 1.0);
            neuron1.Connect(inputNeuron2, weight: 1.0);
            neuron2.Connect(inputNeuron1, weight: -1.0);
            neuron2.Connect(inputNeuron2, weight: -1.0);

            inputNeuron1.Fire(2.0);
            inputNeuron2.Fire(1.0);
            
            Console.WriteLine($"Neuron 1 value: {neuron1.Value}");
            Console.WriteLine($"Neuron 2 value: {neuron2.Value}");
        }
    }
}