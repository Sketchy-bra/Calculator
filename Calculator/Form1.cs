using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }
        // Event handler for when a number button is clicked
        private void button_click(object sender, EventArgs e)
        {
            // If the result text box is currently displaying "0" or if an operation has been performed, clear the text box
            if ((textBox_Result.Text == "0") && (sender as Button).Text != "0" || (isOperationPerformed))
                textBox_Result.Clear();

            // Set the isOperationPerformed flag to false
            isOperationPerformed = false;

            // Get the button that was clicked
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;
            }
            // Otherwise, append the text of the button to the text box
            else
                textBox_Result.Text = textBox_Result.Text + button.Text;
        }
        // Event handler for when an operation button is clicked
        private void operator_click(object sender, EventArgs e)
        {
            // Get the button that was clicked
            Button button = (Button)sender;

            // If the result value is not equal to 0
            if (resultValue != 0)
            {
                // Perform the operation on the result value and the text box value, store the result in the result value variable, and update the label to show the current operation
                button16.PerformClick();
                operationPerformed = button.Text;

                // Otherwise, set the result value to the text box value, set the operation performed to the text of the button, and update the label to show the current operation
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }
        // Event handler for when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {    // Set the text of the result text box to "0" and set the result value to 0

            textBox_Result.Text = "0";
            resultValue = 0;
        }
        // Event handler for when the clear button is clicked

        private void button5_Click(object sender, EventArgs e)
        {    // Set the text of the result text box to "0"

            textBox_Result.Text = "0";
        }
        // Event handler for when the clear all button is clicked

        private void button6_Click(object sender, EventArgs e)
        {    // Set the text of the result text box to "0" and set the result value to 0

            textBox_Result.Text = "0";
            resultValue = 0;
            labelCurrentOperation.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (resultValue != 0)
            {
                switch (operationPerformed)
                {
                    case "+":
                        textBox_Result.Text = (resultValue + Double.Parse(textBox_Result.Text)).ToString(); break;
                    case "-":
                        textBox_Result.Text = (resultValue - Double.Parse(textBox_Result.Text)).ToString(); break;
                    case "*":
                        textBox_Result.Text = (resultValue * Double.Parse(textBox_Result.Text)).ToString(); break;
                    case "/":
                        textBox_Result.Text = (resultValue / Double.Parse(textBox_Result.Text)).ToString(); break;
                    default:
                        break;
                }
                resultValue = Double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = "";
            }
        }
    }
}