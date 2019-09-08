using MadreDeDiosAdventure;
using MadreDeDiosAdventureFileManager;

namespace MadreDeDiosAdventureSimulator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = "inputFile.txt";
            string outputFileName = "outputFile.txt";

            WriteMapOnFile(
                outputFileName,
                GetSimulatedMap(
                    ReadMapFromFile(
                        inputFileName
                    )
                )
            );

            System.Console.WriteLine("Simulation finished, press any key to exit ...");

            System.Console.ReadKey();
        }

        private static void WriteMapOnFile(string outputFileName, Map map)
        {
            FileWriter fileWriter = new FileWriter(outputFileName);

            fileWriter.Write(map);
        }

        private static Map GetSimulatedMap(Map map)
        {
            System.Console.WriteLine($"Adventure simulation");
            Simulator simulator = new Simulator(map);
            simulator.Simulate();

            return simulator.Map;
        }

        private static Map ReadMapFromFile(string inputFileName)
        {
            System.Console.WriteLine($"Reading file ({ inputFileName })");
            FileReader fileReader = new FileReader(inputFileName);

            string fileContent = fileReader.Read();
            StringParser stringToMapParser = new StringParser();

            return stringToMapParser.Parse(fileContent);
        }
    }
}
