using FileForensiq.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileForensiq.UI
{
    public partial class ChartForm : Form
    {

        private List<CacheModel> data;

        public ChartForm()
        {
            InitializeComponent();
        }

        public ChartForm(List<CacheModel> recievedData)
        {
            InitializeComponent();
            data = recievedData;
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            DisplayDataInChart();
        }

        public void DisplayDataInChart()
        {
            try
            {
                chart.Titles.Add("Number of files by extension:");
                chart.Series["NumberOfFiles"].IsVisibleInLegend = false;
                foreach (string extension in data.Select(x => x.Extension).Distinct())
                {
                    var result = data.Where(x => x.Extension == extension).Count();

                    chart.Series["NumberOfFiles"].Points.AddXY(extension, result);
                }
            }
            catch (Exception)
            { 
            }
        }
    }
}
