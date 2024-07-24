using NeuralNetwork.Domain;

namespace NeuralNetwork.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ISensorLayer sensorLayer = new SensorLayer();
            ICollection<ISensor> sensors = GetSensors();
            foreach(ISensor sensor in sensors)
            {
                sensorLayer.AddNeuron(sensor);
            }

            ILayer hiddenLayer = new Layer(sensorLayer);
            ICollection<INeuron> hiddenNeurons = GetNeurons();
            foreach(INeuron neuron in hiddenNeurons)
            {
                hiddenLayer.AddNeuron(neuron);
            }

            ILayer outputLayer = new Layer(hiddenLayer);
            ICollection<INeuron> outputNeurons = GetNeurons();
            foreach(INeuron neuron in outputNeurons)
            {
                outputLayer.AddNeuron(neuron);
            }

            IDictionary<INeuron, ICollection<double>> hiddenLayerWeights = GetLayerWeights(sensorLayer.Neurons, hiddenLayer.Neurons);
            hiddenLayer.Connect(sensorLayer, hiddenLayerWeights);
            IDictionary<INeuron, ICollection<double>> outputLayerWeights = GetLayerWeights(hiddenLayer.Neurons, sensorLayer.Neurons);
        }

        private static ICollection<ISensor> GetSensors()
        {
            return new List<ISensor>
            {
                new Sensor(),
                new Sensor(),
                new Sensor(),
                new Sensor(),
                new Sensor()
            };
        }

        private static ICollection<INeuron> GetNeurons()
        {
            return new List<INeuron>
            {
                new SigmoidNeuron(bias: 0.0),
                new SigmoidNeuron(bias: 0.0),
                new SigmoidNeuron(bias: 0.0),
                new SigmoidNeuron(bias: 0.0),
                new SigmoidNeuron(bias: 0.0)
            };
        }

        private static IDictionary<INeuron, ICollection<double>> GetLayerWeights(IReadOnlyCollection<INeuron> previousLayerNeurons, IReadOnlyCollection<INeuron> layerNeurons)
        {
            Random random = new Random();
            IDictionary<INeuron, ICollection<double>> result = new Dictionary<INeuron, ICollection<double>>();

            foreach(INeuron neuron in layerNeurons)
            {
                foreach(INeuron previousLayerNeuron in previousLayerNeurons)
                {
                    result[neuron].Add(random.Next(-10, 10));
                }
            }

            return result;
        }
    }
}