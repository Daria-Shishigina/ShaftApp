using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kompas6API5;
using ShaftApp;

namespace ShaftAppForm
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            _kompasConnector = new KompasConnector();
        }

        private DetailBuilder _detailBuilder;
        private KompasConnector _kompasConnector;
        private Parameters _parameters;

        private void buildButton_Click(object sender, EventArgs e)
        {
          _kompasConnector.Connector();
                


            Parameters parameters = new Parameters(Convert.ToDouble(diamBracingTextBox.Text), 
                Convert.ToDouble(diamHeadTextBox.Text),
                Convert.ToDouble(diamLegTextBox.Text),
                Convert.ToDouble(lengthBracingTextBox.Text),
                Convert.ToDouble(lengthBracingTextBox.Text), 
                Convert.ToDouble(lengthBracingTextBox.Text));

            DetailBuilder detailBuilder = new DetailBuilder(_kompasConnector);
            detailBuilder.BuildDetail(parameters);

        }


        private void Validate()
        {


            //////////////////////////////////////////////


        }

    }
}
