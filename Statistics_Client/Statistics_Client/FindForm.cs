using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Statistics_Client
{
    public partial class FindForm : Form
    {
        // DataGridView 컬럼 배열
        string[] basicColumnArr = new string[10] { "갱신날짜", "카스", "필라이트", "아사히", "초코송이", "새우깡", "썬칩", "참깨라면", "신라면", "짜파게티" };
        // DB에서 특정 날짜만 저장하기위한 변수
        string firstDate, lastDate;
        // Chart, DataGridView에서 특정 종류의 데이터만 보기위해 설정한 변수
        Dictionary<string, int> typeStartNum = new Dictionary<string, int>() { { "맥주", 0 }, { "과자", 3 }, { "라면", 6 } };

        public FindForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 조회 Form이 켜지면 실행되는 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindForm_Load(object sender, EventArgs e)
        {
            // 메인 Form에서 입력한 날짜를 받기
            Form1 form = this.Owner as Form1;

            firstDate = form.firstDate_Form;
            lastDate = form.lastDate_Form;

            // Handler 연결
            DAO dao = new DAO();
            dao.UpdateSpecialProdPrice += new DAO.UpdateSpecialProdPriceHandler(UpdateSpecialProdPrice);
            dao.UpdateSpecialChart += new DAO.UpdateSpecialChartHandler(UpdateSpecialChart);

            // DB에서 받아온 데이터 DataGridView, Chart에 뿌려주기
            SetupDataGridView();
            dao.GetSpecialProdPrice(firstDate, lastDate);
        }

        /// <summary>
        /// DataGridView에 데이터 넣어주는 메서드
        /// </summary>
        /// <param name="updateDate"></param>
        /// <param name="prodArr"> Row 값 (각 물품들 가격)들의 배열 </param>
        private void UpdateSpecialProdPrice(DateTime updateDate, long[] prodArr)
        {
            // 가격들에 대한 Row + updateDate Row
            string[] rowData = new string[prodArr.Length + 1];
            rowData[0] = string.Format("{0:yyyy-MM-dd}", updateDate);

            for (int i = 0; i < prodArr.Length; i++)
            {
                rowData[i + 1] = prodArr[i].ToString();
            }

            // DataGridView에 데이터값 넣기
            prodPriceDataGridView.Rows.Add(rowData);
        }

        /// <summary>
        /// Chart 그려주는 메서드
        /// </summary>
        /// <param name="updateDate"></param>
        /// <param name="prodArr"></param>
        private void UpdateSpecialChart (DateTime updateDate, long[] prodArr)
        {
            for (int i = 0; i < prodArr.Length; i++)
            {
                priceChart.Series[i].Points.AddXY(updateDate, prodArr[i]);
            }
        }

        #region CheckBox 변동사항에 대한 메서드
        private void beerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChangeTableChart(beerCheckBox.Text, beerCheckBox.Checked);
        }

        private void snackCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChangeTableChart(snackCheckBox.Text, snackCheckBox.Checked);
        }

        private void ramenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChangeTableChart(ramenCheckBox.Text, ramenCheckBox.Checked);
        }

        /// <summary>
        /// CheckBox 변경 유무에 따라 DataGridView, Chart 보여주는 형식 변경
        /// </summary>
        /// <param name="type"></param>
        /// <param name="flag"></param>
        private void ChangeTableChart (string type, bool flag)
        {
            // flag : true => 체크박스 선택한거
            // flag : false => 체크박스 선택 안한거
            if (flag)
            {
                for (int i = typeStartNum[type]; i < typeStartNum[type] + 3; i++)
                {
                    priceChart.Series[i].Enabled = true;
                    prodPriceDataGridView.Columns[i + 1].Visible = true;
                }
            }
            else
            {
                for (int i = typeStartNum[type]; i < typeStartNum[type] + 3; i++)
                {
                    priceChart.Series[i].Enabled = false;
                    prodPriceDataGridView.Columns[i + 1].Visible = false;
                }
            }
        }
        #endregion

        /// <summary>
        /// DataGridView 컬럼 설정해주는 메서드
        /// </summary>
        private void SetupDataGridView()
        {
            prodPriceDataGridView.ColumnCount = basicColumnArr.Length;

            for (int i = 0; i < basicColumnArr.Length; i++)
            {
                prodPriceDataGridView.Columns[i].Name = basicColumnArr[i];
            }
        }
    }
}
