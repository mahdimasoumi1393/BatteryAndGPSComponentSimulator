using System.IO.Ports;
using Microsoft.Extensions.Configuration;

namespace VehicleComController
{
    public static class ComController

    {
        static void Main(string[] args)
        {
            // Bygg konfigurationen från appsettings.json
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Läs in portnamnet från konfigurationen
            string portName = config["SerialPort:PortName"];

            // Test if input arguments were suplied.
            if (string.IsNullOrEmpty(portName))
            {
                Console.WriteLine("PortName is not configured.");
                return;
            }

            // Set up the serial port to read from
            SerialPort serialPortControlUnits = new()
            {
                PortName = portName, // COM port as an argument
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None
            };

            // Attach event handler for when data is received
            serialPortControlUnits.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            try
            {
                serialPortControlUnits.Open();
                Console.WriteLine("Controller is ready to receive data from Aux...");

                // Keep the application alive to continue receiving data
                Console.WriteLine("Press  any key to close the application.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                if (serialPortControlUnits.IsOpen)
                    serialPortControlUnits.Close();
            }
        }

        // Event handler for when data is received from the serial port
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;

                // Read the incoming data
                string data = sp.ReadExisting();
                Console.WriteLine($"Received: {data}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving data: {ex.Message}");
            }
        }
    }
}