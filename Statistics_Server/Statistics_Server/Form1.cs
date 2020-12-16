using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Statistics_Server
{
    public partial class Form1 : Form
    {
        DateTime currentTime;
        // 물품 ID 배열
        string[,] prodIDArr = new string [3, 3] { { "A1", "B1", "C1" },
                                                  { "A2", "B2", "C2" },
                                                  { "A3", "B3", "C3" } };
        // 물품 이름 배열
        string[,] prodNameArr = new string [3, 3] { { "카스", "초코송이", "참깨라면" },
                                                    { "필라이트", "새우깡", "신라면" },
                                                    { "아사히", "썬칩", "짜파게티" } };
        // 물품 타입 배열
        string[] prodTypeArr = new string [3] { "맥주", "과자", "라면" };

        // 랜덤 가격 변동을 위한 변수
        Random randomPriceChange = new Random();
                                            

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form이 실행되면 모든 물건 가격을 1000원으로 초기화 (1000원부터 시작)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            DAO dao = new DAO();
            currentTime = DateTime.Now;

            // 서버를 시작하기전에 테이블에 있는 값들 모두 삭제
            dao.ResetTables();

            // 물품 타입 배열 인덱스에 사용할 변수
            int prodTypeCount = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dao.FirstConnection(prodIDArr[j, i], prodNameArr[j, i], prodTypeArr[prodTypeCount],
                        1000, currentTime);
                }
                prodTypeCount++;
            }
        }

        /// <summary>
        /// 자동 새로고침 버튼 누르면 타이머 시작 (자동으로 가격 DB로 업데이트)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;

            Timer timer = new Timer();
            timer.Interval = 5000; // 10초간격으로 타이머 실행
            timer.Tick += new EventHandler(UpdatePrice);
            timer.Start();
        }

        /// <summary>
        /// 자동 업데이트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdatePrice(object sender, EventArgs e)
        {
            DAO dao = new DAO();
            currentTime = currentTime.AddDays(1); // x초에 한 번씩 updatedDate는 하루 증가

            // 물품 타입 배열 인덱스에 사용할 변수
            int prodTypeCount = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // prodID | prodName | prodType | prodChange(랜덤값 -100~100) | updatedDate
                    dao.UpdatePrice(prodIDArr[j, i], prodNameArr[j, i], prodTypeArr[prodTypeCount],
                        randomPriceChange.Next(-100, 100), currentTime);
                }
                prodTypeCount++;
            }

            logListBox.Items.Add(string.Format("[ {0} ] : 가격변동 업데이트", currentTime));
        }
    }
}
