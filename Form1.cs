using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
namespace RS_232_SERIAL_COM_PORT_GUI
{
    public partial class RS232 : Form
    {

        // Create the serial port with basic settings
        public SerialPort port = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
        delegate void SetTextCallback(string text);

        string InputData = String.Empty;

        public RS232() 
        {
            InitializeComponent();

            Console.WriteLine("Incoming Data:");

            // Attach a method to be called when there
            // is data waiting in the port's buffer
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            
            try
            {
                // Begin communications
                port.Open();

            }catch(Exception)
            {
                // Enter an application loop to keep this thread alive
                Application.Run();
            }
        }

        private void SetText(string inputData)
        {
            // Show all the incoming data in the port's buffer
            Console.WriteLine("Data Received:" + inputData);
            TableLayoutPanel panel = tableLayoutPanel2;
            TableLayoutPanel panel2 = tableLayoutPanel1;
            TableLayoutPanel panel3 = tableLayoutPanel3;
            String[] seperatedData = inputData.Trim().Split();

            //if (seperatedData.Length == 2)
            //{
            String id = seperatedData[0];
            //Console.WriteLine(id);
            switch (id)
            {
                case "0x00":
                    try
                    {
                        double voltage = Convert.ToDouble(seperatedData[1]);
                        DateTime now = DateTime.Now;
                        RowStyle temp = panel.RowStyles[panel.RowCount - 1];

                        //increase panel rows count by one
                        panel.RowCount++;
                        //add a new RowStyle as a copy of the previous one
                        panel.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                        panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                        panel.Controls.Add(new Label() { Text = voltage.ToString() }, 0, panel.RowCount - 1);
                        panel.Controls.Add(new Label() { Text = now.ToString() }, 1, panel.RowCount - 1);
                    }
                    catch (System.FormatException)
                    {
                        Console.Error.WriteLine("Failed to read voltage(Not a number?)");
                    }
                    catch (NullReferenceException)
                    {
                        Console.Error.WriteLine("Tried to draw to the screen after you removed it.");
                    }
                    break;
                case "0x01":
                    try
                    {
                        double temperature = Convert.ToDouble(seperatedData[1]);
                        DateTime now = DateTime.Now;
                        RowStyle temp = panel2.RowStyles[panel2.RowCount - 1];

                        //increase panel rows count by one
                        panel2.RowCount++;
                        //add a new RowStyle as a copy of the previous one
                        panel2.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                        panel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                        panel2.Controls.Add(new Label() { Text = temperature.ToString() }, 0, panel2.RowCount - 1);
                        panel2.Controls.Add(new Label() { Text = now.ToString() }, 1, panel2.RowCount - 1);
                    }
                    catch (System.FormatException)
                    {
                        Console.Error.WriteLine("Failed to read voltage(Not a number?)");
                    }
                    catch (NullReferenceException)
                    {
                        Console.Error.WriteLine("Tried to draw to the screen after you removed it.");
                    }
                    break;
                case "0x02":
                    try
                    {
                        double current = Convert.ToDouble(seperatedData[1]);
                        DateTime now = DateTime.Now;
                        RowStyle temp = panel3.RowStyles[panel3.RowCount - 1];

                        //increase panel rows count by one
                        panel3.RowCount++;
                        //add a new RowStyle as a copy of the previous one
                        panel3.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                        panel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                        panel3.Controls.Add(new Label() { Text = current.ToString() }, 0, panel3.RowCount - 1);
                        panel3.Controls.Add(new Label() { Text = now.ToString() }, 1, panel3.RowCount - 1);
                    }
                    catch (System.FormatException)
                    {
                        Console.Error.WriteLine("Failed to read voltage(Not a number?)");
                    }
                    catch (NullReferenceException)
                    {
                        Console.Error.WriteLine("Tried to draw to the screen after you removed it.");
                    }
                    break;
            }
            //}
            //else
            //{
            //  Console.Error.WriteLine("Input length incorrect (Might happen if we start reading in the wrong spot. No big deal)");
            //}
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            InputData = port.ReadExisting();
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
            }

            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
