using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Statistics_Client
{
    public partial class Form1 : Form
    {
        // 조회 Form에서 DB에 조건으로 넣을 날짜
        public string firstDate_Form;
        public string lastDate_Form;

        // Column에 사용할 배열
        string[] basicColumnArr = new string[10] { "갱신날짜", "카스", "필라이트", "아사히", "초코송이", "새우깡", "썬칩", "참깨라면", "신라면", "짜파게티" };
        bool[] boolColumnArr = new bool[10];

        // CheckBox 선택 여부 담아줄 변수
        Dictionary<string, bool> isType = new Dictionary<string, bool>();

        // 자동 업데이트하게 만들어주는 타이머
        Timer timer = new Timer();

        // 시작날짜, 마지막날짜 변수
        string firstDate, lastDate;

        // 현재 보고있는 Row Index 담아주는 변수
        int currentRowIndex;

        // 현재 보고있는 Row의 UpdateDate 담아주는 변수
        string currentRowUpdateDate;

        public Form1()
        {
            InitializeComponent();

            SaveTypeStatement();

            // 초기에 CheckBox가 모두 체크된 상태이기 때문에 true로 초기화
            for (int i = 0; i < boolColumnArr.Length; i++)
            {
                boolColumnArr[i] = true;
            }
        }

        /// <summary>
        /// 처음 시작시 CheckBox 체크여부 Dictionary에 저장해주는 메서드
        /// </summary>
        private void SaveTypeStatement()
        {
            // CheckBox 선택 여부 설정
            isType.Add("맥주", beerCheckBox.Checked);
            isType.Add("과자", snackCheckBox.Checked);
            isType.Add("라면", ramenCheckBox.Checked);
        }

        /// <summary>
        /// Form이 처음 켜졌을 때의 EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Column 초기화 메서드 호출
            SetupDataGridView();

            // 핸들러 묶어주기
            DAO dao = new DAO();
            dao.UpdateProdPrice += new DAO.UpdateProdPriceHandler(UpdateProdPrice);
            dao.RowChartClear += new DAO.RowClearHandler(RowChartClear);
            dao.UpdateChart += new DAO.UpdateChartHandler(UpdateChart);
            
            RowChartClear();
            dao.GetProdPrice(isType);

            // 날짜 업데이트
            string[] dateArr = dao.GetDates();
            firstDate = dateArr[0];
            lastDate = dateArr[1];

            UpdateDate(firstDate, lastDate);

            // 초기 DataGridView 위치 저장
            currentRowIndex = 0;
            currentRowUpdateDate = prodPriceDataGridView[0, currentRowIndex].Value.ToString();

            // DataGridView 스크롤 핸들러
            prodPriceDataGridView.Scroll += new ScrollEventHandler(GridScroll);
        }

        /// <summary>
        /// 스크롤바가 움직이면 발생하는 EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridScroll(object sender, ScrollEventArgs e)
        {
            // 다음 변수에 현재 보고있는 데이터들 중 맨위에 있는 데이터의 Index와 해당 Index의 갱신날짜 값을 입력
            currentRowIndex = prodPriceDataGridView.FirstDisplayedCell.RowIndex;
            currentRowUpdateDate = prodPriceDataGridView[0, currentRowIndex].Value.ToString();
        }

        /// <summary>
        /// 조회할 날짜 업데이트 해주는 메서드
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="lastDate"></param>
        private void UpdateDate(string firstDate, string lastDate)
        {
            firstDateTextBox.Text = firstDate + " 부터 입력가능";
            lastDateTextBox.Text = lastDate + " 까지 입력가능";
        }

        /// <summary>
        /// DataGridView 레코드 값 업데이트 해주는 메서드
        /// DataGridView에 접근하기 위해서 DAO와 Delegate로 묶어주었다
        /// </summary>
        private void UpdateProdPrice(DateTime updatedDate, long[] prodArr)
        {
            // 컬럼명과 물품 가격을 동적으로 업데이트해주기위한 for문
            // prodArr (물품 가격)에 0값이 있으면 List에 저장해주지 않는다
            List<string> prodPriceList = new List<string>();
            for (int i = 0; i < prodArr.Length; i++)
            {
                if (prodArr[i] != 0)
                    prodPriceList.Add(prodArr[i].ToString());
            }

            // DataGridView의 Row에 값 집어넣기 위한 string 배열 생성
            string[] rowData = new string[prodPriceList.Count + 1];
            rowData[0] = string.Format("{0:yyyy-MM-dd}", updatedDate);
            
            for (int i = 0; i < prodPriceList.Count; i++)
            {
                rowData[i + 1] = prodPriceList[i];
            }

            SetupDataGridView(); // 컬럼 값 업데이트
            prodPriceDataGridView.Rows.Add(rowData);
        }

        /// <summary>
        /// 그래프 그려주는 메서드
        /// </summary>
        /// <param name="updatedDate"></param>
        /// <param name="A1"></param>
        /// <param name="A2"></param>
        /// <param name="A3"></param>
        /// <param name="B1"></param>
        /// <param name="B2"></param>
        /// <param name="B3"></param>
        /// <param name="C1"></param>
        /// <param name="C2"></param>
        /// <param name="C3"></param>
        private void UpdateChart(DateTime updatedDate, long A1, long A2, long A3, long B1, long B2, long B3,
            long C1, long C2, long C3)
        {
            long[] priceArr = new long[9] { A1, A2, A3, B1, B2, B3, C1, C2, C3 };

            for (int i = 0; i < 9; i++)
            {
                priceChart.Series[i].Points.AddXY(updatedDate, priceArr[i]);
            }
        }

            /// <summary>
            /// DataGridView Column 명 초기화해주는 메서드
            /// </summary>
            private void SetupDataGridView()
        {
            // columnList에 DataGridView에서 보여줄 컬럼값들만 입력
            List<string> columnList = new List<string>();
            for (int i = 0; i < basicColumnArr.Length; i++)
            {
                if (boolColumnArr[i])
                    columnList.Add(basicColumnArr[i]);
            }

            prodPriceDataGridView.ColumnCount = columnList.Count;

            // 컬럼 업데이트
            for (int i = 0; i < prodPriceDataGridView.ColumnCount; i++)
            {
                prodPriceDataGridView.Columns[i].Name = columnList[i];
            }
            
        }

        /// <summary>
        /// 자동 새로고침 버튼 메서드
        /// 누르면 Timer가 작동하면서 자동으로 DB에서 값을 받을 수 있게 해준다
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoButton_Click(object sender, EventArgs e)
        {
            if (autoButton.Text == "자동 새로고침")
            {
                autoButton.Text = "중지";

                timer.Interval = 5000;
                timer.Tick += new EventHandler(autoUpdate);
                timer.Start();
            }
            else if (autoButton.Text == "중지")
            {
                autoButton.Text = "자동 새로고침";

                timer.Stop();
            }
        }

        /// <summary>
        /// 맥주 CheckBox가 눌렸을 때 EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isType["맥주"] = beerCheckBox.Checked;

            if (beerCheckBox.Checked)
            {
                priceChart.Series[0].Enabled = true;
                priceChart.Series[1].Enabled = true;
                priceChart.Series[2].Enabled = true;

                boolColumnArr[1] = true;
                boolColumnArr[2] = true;
                boolColumnArr[3] = true;
            }
            else
            {
                priceChart.Series[0].Enabled = false;
                priceChart.Series[1].Enabled = false;
                priceChart.Series[2].Enabled = false;

                boolColumnArr[1] = false;
                boolColumnArr[2] = false;
                boolColumnArr[3] = false;
            }
            
        }

        /// <summary>
        /// 과자 CheckBox가 눌렸을 때 EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void snackCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isType["과자"] = snackCheckBox.Checked;

            
            if (snackCheckBox.Checked)
            {
                priceChart.Series[3].Enabled = true;
                priceChart.Series[4].Enabled = true;
                priceChart.Series[5].Enabled = true;

                boolColumnArr[4] = true;
                boolColumnArr[5] = true;
                boolColumnArr[6] = true;
            }
            else
            {
                priceChart.Series[3].Enabled = false;
                priceChart.Series[4].Enabled = false;
                priceChart.Series[5].Enabled = false;

                boolColumnArr[4] = false;
                boolColumnArr[5] = false;
                boolColumnArr[6] = false;
            }
            
        }

        /// <summary>
        /// 라면 CheckBox가 눌렸을 때 EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ramenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isType["라면"] = ramenCheckBox.Checked;

            
            if (ramenCheckBox.Checked)
            {
                priceChart.Series[6].Enabled = true;
                priceChart.Series[7].Enabled = true;
                priceChart.Series[8].Enabled = true;

                boolColumnArr[7] = true;
                boolColumnArr[8] = true;
                boolColumnArr[9] = true;
            }
            else
            {
                priceChart.Series[6].Enabled = false;
                priceChart.Series[7].Enabled = false;
                priceChart.Series[8].Enabled = false;

                boolColumnArr[7] = false;
                boolColumnArr[8] = false;
                boolColumnArr[9] = false;
            }
            
        }

        /// <summary>
        /// Timer에서 사용할 메서드
        /// 핸들러 연결해주고 DB에서 데이터를 받아올 수 있게 DAO를 호출한다
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoUpdate(object sender, EventArgs e)
        {
            DAO dao = new DAO();
            dao.UpdateProdPrice += new DAO.UpdateProdPriceHandler(UpdateProdPrice);
            dao.RowChartClear += new DAO.RowClearHandler(RowChartClear);
            dao.UpdateChart += new DAO.UpdateChartHandler(UpdateChart);

            RowChartClear();
            dao.GetProdPrice(isType);

            string[] dateArr = dao.GetDates();
            firstDate = dateArr[0];
            lastDate = dateArr[1];

            UpdateDate(firstDate, lastDate);

            // 해당 Cell 위치로 이동시키기 위한 변수
            int goIndex = 0;

            // 현재 보고 있는 데이터들의 제일 위의 값을 DataGridView 안의 데이터들과 비교
            for (int i = 0; i < prodPriceDataGridView.RowCount; i++)
            {
                if (prodPriceDataGridView[0, i].Value.Equals(currentRowUpdateDate))
                {
                    goIndex = i;
                    break;
                }
            }

            // 스크롤을 내리지 않은 상태라면 최신 데이터가 맨위로
            if (currentRowIndex == 0)
                prodPriceDataGridView.FirstDisplayedCell = prodPriceDataGridView.Rows[0].Cells[0];
            // 스크롤을 내린 상태라면 지금 보고 있는 데이터중 제일 위의 데이터가 보이게
            else
                prodPriceDataGridView.FirstDisplayedCell = prodPriceDataGridView.Rows[goIndex].Cells[0];
        }

        /// <summary>
        /// 조회버튼 눌렀을 때의 EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(insertFirstDateTextBox.Text))
            {
                MessageBox.Show("시작날짜를 입력해주세요");
            }
            else if (string.IsNullOrEmpty(insertLastDateTextBox.Text))
            {
                MessageBox.Show("마지막날짜를 입력해주세요");
            }
            // yyyy-MM-dd에 대한 날짜 정규식
            else if (!Regex.IsMatch(insertFirstDateTextBox.Text, @"^(20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[0-1])$"))
            {
                MessageBox.Show("시작날짜 형식을 맞춰주세요");
            }
            else if (!Regex.IsMatch(insertLastDateTextBox.Text, @"^(20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[0-1])$"))
            {
                MessageBox.Show("마지막날짜 형식을 맞춰주세요");
            }
            else
            {
                firstDate_Form = insertFirstDateTextBox.Text;
                lastDate_Form = insertLastDateTextBox.Text;

                FindForm findForm = new FindForm();
                findForm.Text = firstDate_Form + " ~ " + lastDate_Form + " 까지의 가격 변동 데이터 조회";
                findForm.Show(this);
            }
        }

        /// <summary>
        /// Chart, DataGridView 초기화해주는 메서드
        /// </summary>
        private void RowChartClear()
        {
            // DataGridView가 비어있지 않으면 Clear
            if (prodPriceDataGridView.Rows.Count != 0)
            {
                prodPriceDataGridView.Columns.Clear();
                prodPriceDataGridView.Rows.Clear();
                prodPriceDataGridView.Refresh();
            }

            for (int i = 0; i < 9; i++)
            {
                priceChart.Series[i].Points.Clear();
            }
        }
    }
}
