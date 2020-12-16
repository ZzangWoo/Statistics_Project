namespace Statistics_Client
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.uspshowProdPriceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prodPriceDataGridView = new System.Windows.Forms.DataGridView();
            this.priceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.autoButton = new System.Windows.Forms.Button();
            this.beerCheckBox = new System.Windows.Forms.CheckBox();
            this.snackCheckBox = new System.Windows.Forms.CheckBox();
            this.ramenCheckBox = new System.Windows.Forms.CheckBox();
            this.firstDateTextBox = new System.Windows.Forms.TextBox();
            this.insertFirstDateTextBox = new System.Windows.Forms.TextBox();
            this.lastDateTextBox = new System.Windows.Forms.TextBox();
            this.insertLastDateTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.findButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uspshowProdPriceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodPriceDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceChart)).BeginInit();
            this.SuspendLayout();
            // 
            // prodPriceDataGridView
            // 
            this.prodPriceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prodPriceDataGridView.Location = new System.Drawing.Point(13, 557);
            this.prodPriceDataGridView.Name = "prodPriceDataGridView";
            this.prodPriceDataGridView.RowTemplate.Height = 23;
            this.prodPriceDataGridView.Size = new System.Drawing.Size(1059, 322);
            this.prodPriceDataGridView.TabIndex = 0;
            // 
            // priceChart
            // 
            chartArea3.Name = "ChartArea1";
            this.priceChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.priceChart.Legends.Add(legend3);
            this.priceChart.Location = new System.Drawing.Point(13, 13);
            this.priceChart.Name = "priceChart";
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series19.LabelForeColor = System.Drawing.Color.Red;
            series19.Legend = "Legend1";
            series19.LegendText = "카스";
            series19.Name = "A1";
            series20.ChartArea = "ChartArea1";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series20.Legend = "Legend1";
            series20.LegendText = "필라이트";
            series20.Name = "A2";
            series21.ChartArea = "ChartArea1";
            series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series21.Legend = "Legend1";
            series21.LegendText = "아사히";
            series21.Name = "A3";
            series22.ChartArea = "ChartArea1";
            series22.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series22.Legend = "Legend1";
            series22.LegendText = "초코송이";
            series22.Name = "B1";
            series23.ChartArea = "ChartArea1";
            series23.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series23.Legend = "Legend1";
            series23.LegendText = "새우깡";
            series23.Name = "B2";
            series24.ChartArea = "ChartArea1";
            series24.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series24.Legend = "Legend1";
            series24.LegendText = "썬칩";
            series24.Name = "B3";
            series25.ChartArea = "ChartArea1";
            series25.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series25.Legend = "Legend1";
            series25.LegendText = "참깨라면";
            series25.Name = "C1";
            series26.ChartArea = "ChartArea1";
            series26.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series26.Legend = "Legend1";
            series26.LegendText = "신라면";
            series26.Name = "C2";
            series27.ChartArea = "ChartArea1";
            series27.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series27.Legend = "Legend1";
            series27.LegendText = "짜파게티";
            series27.Name = "C3";
            this.priceChart.Series.Add(series19);
            this.priceChart.Series.Add(series20);
            this.priceChart.Series.Add(series21);
            this.priceChart.Series.Add(series22);
            this.priceChart.Series.Add(series23);
            this.priceChart.Series.Add(series24);
            this.priceChart.Series.Add(series25);
            this.priceChart.Series.Add(series26);
            this.priceChart.Series.Add(series27);
            this.priceChart.Size = new System.Drawing.Size(1058, 428);
            this.priceChart.TabIndex = 1;
            this.priceChart.Text = "priceChart";
            // 
            // autoButton
            // 
            this.autoButton.Location = new System.Drawing.Point(960, 509);
            this.autoButton.Name = "autoButton";
            this.autoButton.Size = new System.Drawing.Size(111, 42);
            this.autoButton.TabIndex = 2;
            this.autoButton.Text = "자동 새로고침";
            this.autoButton.UseVisualStyleBackColor = true;
            this.autoButton.Click += new System.EventHandler(this.autoButton_Click);
            // 
            // beerCheckBox
            // 
            this.beerCheckBox.AutoSize = true;
            this.beerCheckBox.Checked = true;
            this.beerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.beerCheckBox.Location = new System.Drawing.Point(960, 192);
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
            this.snackCheckBox.Location = new System.Drawing.Point(960, 214);
            this.snackCheckBox.Name = "snackCheckBox";
            this.snackCheckBox.Size = new System.Drawing.Size(48, 16);
            this.snackCheckBox.TabIndex = 4;
            this.snackCheckBox.Text = "과자";
            this.snackCheckBox.UseVisualStyleBackColor = true;
            this.snackCheckBox.CheckedChanged += new System.EventHandler(this.snackCheckBox_CheckedChanged);
            // 
            // ramenCheckBox
            // 
            this.ramenCheckBox.AutoSize = true;
            this.ramenCheckBox.Checked = true;
            this.ramenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ramenCheckBox.Location = new System.Drawing.Point(960, 236);
            this.ramenCheckBox.Name = "ramenCheckBox";
            this.ramenCheckBox.Size = new System.Drawing.Size(48, 16);
            this.ramenCheckBox.TabIndex = 5;
            this.ramenCheckBox.Text = "라면";
            this.ramenCheckBox.UseVisualStyleBackColor = true;
            this.ramenCheckBox.CheckedChanged += new System.EventHandler(this.ramenCheckBox_CheckedChanged);
            // 
            // firstDateTextBox
            // 
            this.firstDateTextBox.Location = new System.Drawing.Point(13, 496);
            this.firstDateTextBox.Name = "firstDateTextBox";
            this.firstDateTextBox.ReadOnly = true;
            this.firstDateTextBox.Size = new System.Drawing.Size(178, 21);
            this.firstDateTextBox.TabIndex = 6;
            // 
            // insertFirstDateTextBox
            // 
            this.insertFirstDateTextBox.Location = new System.Drawing.Point(12, 523);
            this.insertFirstDateTextBox.Name = "insertFirstDateTextBox";
            this.insertFirstDateTextBox.Size = new System.Drawing.Size(178, 21);
            this.insertFirstDateTextBox.TabIndex = 6;
            // 
            // lastDateTextBox
            // 
            this.lastDateTextBox.Location = new System.Drawing.Point(268, 496);
            this.lastDateTextBox.Name = "lastDateTextBox";
            this.lastDateTextBox.ReadOnly = true;
            this.lastDateTextBox.Size = new System.Drawing.Size(179, 21);
            this.lastDateTextBox.TabIndex = 6;
            // 
            // insertLastDateTextBox
            // 
            this.insertLastDateTextBox.Location = new System.Drawing.Point(267, 523);
            this.insertLastDateTextBox.Name = "insertLastDateTextBox";
            this.insertLastDateTextBox.Size = new System.Drawing.Size(179, 21);
            this.insertLastDateTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 478);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "시작날짜";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 478);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "마지막날짜";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 457);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "*** 날짜 입력시 \'2020-01-07\' 형태로 입력해주세요 ***";
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(468, 496);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(80, 48);
            this.findButton.TabIndex = 9;
            this.findButton.Text = "조회";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 891);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.insertLastDateTextBox);
            this.Controls.Add(this.insertFirstDateTextBox);
            this.Controls.Add(this.lastDateTextBox);
            this.Controls.Add(this.firstDateTextBox);
            this.Controls.Add(this.ramenCheckBox);
            this.Controls.Add(this.snackCheckBox);
            this.Controls.Add(this.beerCheckBox);
            this.Controls.Add(this.autoButton);
            this.Controls.Add(this.priceChart);
            this.Controls.Add(this.prodPriceDataGridView);
            this.Name = "Form1";
            this.Text = "편의점 물품 가격 실시간 조회";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uspshowProdPriceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodPriceDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource uspshowProdPriceBindingSource;
        private System.Windows.Forms.DataGridView prodPriceDataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart priceChart;
        private System.Windows.Forms.Button autoButton;
        private System.Windows.Forms.CheckBox beerCheckBox;
        private System.Windows.Forms.CheckBox snackCheckBox;
        private System.Windows.Forms.CheckBox ramenCheckBox;
        private System.Windows.Forms.TextBox firstDateTextBox;
        private System.Windows.Forms.TextBox insertFirstDateTextBox;
        private System.Windows.Forms.TextBox lastDateTextBox;
        private System.Windows.Forms.TextBox insertLastDateTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button findButton;
    }
}

