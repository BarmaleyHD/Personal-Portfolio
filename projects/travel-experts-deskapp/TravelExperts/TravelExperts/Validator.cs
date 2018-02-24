using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExperts
{
    /// <summary>
    /// Author: Team4
    /// </summary>
    public static class Validator
    {
        private static string title = "Entry Error";

        /// <summary>
        /// The title that will appear in dialog boxes.
        /// </summary>
        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        
        // Checks whether the user entered data into a text box.
        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag + " is a required field.", "Entry Error");
                    comboBox.Focus();
                    return false;
                }
            }
            return true;
        }

        public static bool IsPresent(Control control, string message)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(message, title);
                    textBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(message, title);
                    comboBox.Focus();
                    return false;
                }
            }
            return true;
        }
        
        // Checks whether the user entered a decimal value into a text box.
        public static bool IsDecimal(TextBox textBox, string text)
        {
            bool result = false;
            decimal i;
            //Convert.ToDecimal(textBox.Text);
            if(decimal.TryParse(textBox.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat,  out  i))
            {
                result = true;
            }
            else
            {
                MessageBox.Show(text + " must be a decimal number.", Title);
                textBox.Focus();
            }
            return result;
        }
        
        // Checks whether the user entered an int value into a text box.
        public static bool IsInt32(TextBox textBox, string text)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(text + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsDate(TextBox textBox, string text)
        {
            try
            {
                Convert.ToDateTime(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(text + " must be an Date in correct format. " + CultureInfo.CurrentCulture.DateTimeFormat, Title);
                textBox.Focus();
                return false;
            }
        }

        // Checks whether the user entered a value within a specified range into a text box.
        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min
                    + " and " + max + ".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        // Checks whether the user input in one TextBox is less that in another
        public static bool IsLessThan(TextBox txtBigger, TextBox txtSmaller, string biggerName, string smallerName)
        {
            bool result = true;
            if (IsDecimal(txtBigger, biggerName) && IsDecimal(txtSmaller, smallerName))
            {
                decimal smaller = decimal.Parse(txtSmaller.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat);
                decimal bigger = decimal.Parse(txtBigger.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat);
                if (smaller > bigger)
                {
                    MessageBox.Show(smallerName + " should be less than " + biggerName);
                    result = false;
                }
            }
            return result;
        }

        //Checks whether the user input in one TextBox is earlier that in another
        public static bool IsEarlierThan(TextBox txtBigger, TextBox txtSmaller, string biggerName, string smallerName)
        {
            bool result = true;
            if (IsDate(txtBigger, biggerName) && IsDate(txtSmaller, smallerName))
            {
                DateTime smaller = Convert.ToDateTime(txtSmaller.Text);
                DateTime bigger = Convert.ToDateTime(txtBigger.Text);
                if (smaller > bigger)
                {
                    MessageBox.Show(smallerName + " should be less than " + biggerName);
                    result = false;
                }
            }
            return result;
        }

        // Check if textbox has non-negative double value
        public static bool IsNonNegativeDouble(TextBox tb, string name)
        {
            bool valid = true;
            double value;

            if (!Double.TryParse(tb.Text, out value)) 
            {
                valid = false;
                MessageBox.Show(name + " must be a number");
                tb.SelectAll();
                tb.Focus();
            }
            else if (value < 0)
            {
                valid = false;
                MessageBox.Show(name + " must be a equal to or greater than zero");
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }
    }
}