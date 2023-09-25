using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace demo_huomen.UI
{
    public partial class WaveForm : Form
    {
        public WaveForm()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void WaveForm_Load(object sender, EventArgs e)
        {
            // 创建一个新的图表区域
            ChartArea chartArea = new ChartArea("WaveformChartArea");
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 10; // X轴范围
            chartArea.AxisY.Minimum = -1;
            chartArea.AxisY.Maximum = 1; // Y轴范围
            chartArea.AxisX.Title = "时间";
            chartArea.AxisY.Title = "振幅";

            // 将图表区域添加到图表控件中
            chart1.ChartAreas.Add(chartArea);

            // 创建一个数据系列
            Series waveformSeries = new Series("波形");
            waveformSeries.ChartType = SeriesChartType.Line; // 使用折线图
            waveformSeries.Points.AddXY(0, 0);
            waveformSeries.Points.AddXY(1, 0.5);
            waveformSeries.Points.AddXY(2, 1);
            waveformSeries.Points.AddXY(3, 0.5);
            waveformSeries.Points.AddXY(4, 0);
            waveformSeries.Points.AddXY(5, -0.5);
            waveformSeries.Points.AddXY(6, -1);
            waveformSeries.Points.AddXY(7, -0.5);
            waveformSeries.Points.AddXY(8, 0);
            waveformSeries.Points.AddXY(9, 0.5);
            waveformSeries.Points.AddXY(10, 1);

            // 将数据系列添加到图表控件中
            chart1.Series.Add(waveformSeries);
        }
    }
}
