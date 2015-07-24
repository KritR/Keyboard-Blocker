using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;
using WindowsFormsApplication3;

namespace Keyboard_Disabler
{
    public partial class Form1 : Form
    {
        GlobalKeyboardHook gkh = new GlobalKeyboardHook();


        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);


        public Form1()
        {
            InitializeComponent();
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                gkh.HookedKeys.Add(key);
            }
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
            gkh.hook();
        }
        bool supress = false;
        string x = "";
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            supress = true;
            button1.Enabled = false;
            var timer = new Timer();                                                // Creates a New Timer
            timer.Tick += new EventHandler(waitSir);                               // Every time timer ticks, timer_Tick will be called
            timer.Interval = (1000 * Convert.ToInt16(numericUpDown1.Value));                                                    
            timer.Enabled = true;                                                   // Enable the timer
            timer.Start();
        }
        private void waitSir(Object sender, EventArgs e) {
            button1.Enabled = true;
            supress = false;
            ((Timer)sender).Stop();
        }
        void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            if (supress)
            {
                e.SuppressKeyPress = true;
            }
        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            if (supress)
            {
                e.SuppressKeyPress = true;
            }
            
        }
        private void toggleDevice(bool enabled)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
