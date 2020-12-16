namespace Statistics_Client
{
    partial class FindForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.prodPriceDataGridView = new System.Windows.Forms.DataGridView();
            this.priceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.beerCheckBox = new System.Windows.Forms.CheckBox();
            this.snackCheckBox = new System.Windows.Forms.CheckBox();
            this.ramenCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.prodPriceDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceChart)).BeginInit();
            this.SuspendLayout();
            // 
            // prodPriceDataGridView
            // 
            this.prodPriceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prodPriceDataGridView.Location = new System.Drawing.Point(12, 499);
            this.prodPriceDataGridView.Name = "prodPriceDataGridView";
            this.prodPriceDataGridView.RowTemplate.Height = 23;
            this.prodPriceDataGridView.Size = new System.Drawing.Size(1111, 426);
            this.prodPriceDataGridView.TabIndex = 0;
            // 
            // priceChart
            // 
            chartArea2.Name = "ChartArea1";
            this.priceChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.priceChart.Legends.Add(legend2);
            this.priceChart.Location = new System.Drawing.Point(12, 12);
            this.priceChart.Name = "priceChart";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.LabelForeColor = System.Drawing.Color.Red;
            series10.Legend = "Legend1";
            series10.LegendText = "카스";
            series10.Name = "A1";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend1";
            series11.LegendText = "필라이트";
            series11.Name = "A2";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Legend = "Legend1";
            series12.LegendText = "아사히";
            series12.Name = "A3";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Legend = "Legend1";
            series13.LegendText = "초코송이";
            series13.Name = "B1";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.Legend = "Legend1";
            series14.LegendText = "새우깡";
            series14.Name = "B2";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.Legend = "Legend1";
            series15.LegendText = "썬칩";
            series15.Name = "B3";
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series16.Legend = "Legend1";
            series16.LegendText = "참깨라면";
            series16.Name = "C1";
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series17.Legend = "Legend1";
            series17.LegendText = "신라면";
            series17.Name = "C2";
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series18.Legend = "Legend1";
            series18.LegendText = "짜파게티";
            series18.Name = "C3";
            this.priceChart.Series.Add(series10);
            this.priceChart.Series.Add(series11);
            this.priceChart.Series.Add(series12);
            this.priceChart.Series.Add(series13);
            this.priceChart.Series.Add(series14);
            this.priceChart.Series.Add(series15);
            this.priceChart.Series.Add(series16);
            this.priceChart.Series.Add(series17);
            this.priceChart.Series.Add(series18);
            this.priceChart.Size = new System.Drawing.Size(1111, 481);
            this.priceChart.TabIndex = 2;
            this.priceChart.Text = "priceChart";
            // 
            // beerCheckBox
            // 
            this.beerCheckBox.AutoSize = true;
            this.beerCheckBox.Checked = true;
            this.beerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.beerCheckBox.Location = new System.Drawing.Point(1016, 212);
            this.beerCheckBox.Name = "beerCheckBox";
            this.beerCheckBox.Size = new System.Drawing.Size(48, 16);
            this.beerCheckBox.TabIndex = 3;
            this.beerCheckBox.Text = "맥주";
            this.beerCheckBox.UseVisualStyleBackColor = true;
            this.beerCheckBox.CheckedChanged += new System.EventHandler(this.beerCheckBox_CheckedChanged);
            // 
            // snackCheckBox
            // 
            this.snackCheckBox.AutoSize = true;
            this.snackCheckBox.Checked = true;
            this.snackCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.snackCheckBox.Location = new System.Drawing.Point(1016, 234);
            this.snackCheckBox.Name = "snackCheckBox";
            this.snackCheckBox.Size = new System.Drawing.Size(48, 16);
            this.snackCheckBox.TabIndex = 3;
            this.snackCheckBox.Text = "과자";
            this.snackCheckBox.UseVisualStyleBackColor = true;
            this.snackCheckBox.CheckedChanged += new System.EventHandler(this.snackCheckBox_CheckedChanged);
            // 
            // ramenCheckBox
            // 
            this.ramenCheckBox.AutoSize = true;
            this.ramenCheckBox.Checked = true;
            this.ramenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ramenCheckBox.Location = new System.Drawing.Point(1016, 256);
            this.ramenCheckBox.Name = "ramenCheckBox";
            this.ramenCheckBox.Size = new System.Drawing.Size(48, 16);
            this.ramenCheckBox.TabIndex = 3;
            this.ramenCheckBox.Text = "라면";
            this.ramenCheckBox.UseVisualStyleBackColor = true;
            this.ramenCheckBox.CheckedChanged += new System.EventHandler(this.ramenCheckBox_CheckedChanged);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 937);
            this.Controls.Add(this.ramenCheckBox);
            this.Controls.Add(this.snackCheckBox);
            this.Controls.Add(this.beerCheckBox);
            this.Controls.Add(this.priceChart);
            this.Controls.Add(this.prodPriceDataGridView);
            this.Name = "FindForm";
            this.Text = "FindForm";
            this.Load += new System.EventHandler(this.FindForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prodPriceDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView prodPriceDataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart priceChart;
        private System.Windows.Forms.CheckBox beerCheckBox;
        private System.Windows.Forms.CheckBox snackCheckBox;
        private System.Windows.Forms.CheckBox ramenCheckBox;
    }
}