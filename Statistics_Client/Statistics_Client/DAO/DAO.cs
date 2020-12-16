using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Statistics_Client
{
    class DAO
    {
        #region Form1에 있는 컨트롤에 접근하기 위한 Delegate
        // DataGridView에 날짜별 물품 가격 업데이트
        public delegate void UpdateProdPriceHandler(DateTime updatedDate, long[] prodArr);
        public event UpdateProdPriceHandler UpdateProdPrice;

        // Chart에 날짜별 물품 가격 업데이트
        public delegate void UpdateChartHandler(DateTime updatedDate, long A1, long A2, long A3, long B1, long B2, long B3,
            long C1, long C2, long C3);
        public event UpdateChartHandler UpdateChart;

        // DataGridView 초기화
        public delegate void RowClearHandler();
        public event RowClearHandler RowChartClear;

        // 특정 날짜에 해당하는 데이터 -> DataGridView로
        public delegate void UpdateSpecialProdPriceHandler(DateTime updateDate, long[] prodArr);
        public event UpdateSpecialProdPriceHandler UpdateSpecialProdPrice;

        // 특정 날짜에 해당하는 데이터 -> Char로
        public delegate void UpdateSpecialChartHandler(DateTime updateDate, long[] prodArr);
        public event UpdateSpecialChartHandler UpdateSpecialChart;
        #endregion

        // DAO 클래스에 대한 싱글톤
        private static DAO instance = null;
        public static DAO Get()
        {
            if (instance == null)
                instance = new DAO();
            
            return instance;
        }

        /// <summary>
        /// DB에서 갱신날짜 별 물품들의 가격을 불러오기 위한 메서드
        /// </summary>
        public void GetProdPrice (Dictionary<string, bool> isType)
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["StatisticsDB"].ConnectionString;
            SqlDataReader reader;

            // 선택된 CheckBox만 검색할 수 있게
            // 물품 Type명 typeName 배열에 집어넣기
            string[] typeName = new string[3];
            int count = 0;

            foreach (var data in isType)
            {
                if (data.Value)
                    typeName[count] = data.Key;
                else
                    typeName[count] = "없음";
                count++;
            }

            using (SqlConnection sqlCon = new SqlConnection())
            {
                sqlCon.ConnectionString = connectionString;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("usp_showProdPrice", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = cmd.Parameters.Add("@beer", SqlDbType.NVarChar, 2);
                param.Value = typeName[0];

                param = cmd.Parameters.Add("@snack", SqlDbType.NVarChar, 2);
                param.Value = typeName[1];

                param = cmd.Parameters.Add("@ramen", SqlDbType.NVarChar, 2);
                param.Value = typeName[2];

                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    // 물품 컬럼수에 따른 배열 동적할당 (updateDate 개수는 생략)
                    long[] prodArr = new long[reader.FieldCount - 1]; 
                    for (int i = 0; i < prodArr.Length; i++)
                    {
                        prodArr[i] = reader.GetInt64(i+1);
                    }

                    // DAO 클래스에서는 폼에 있는 컨트롤에 접근할 수 없기 때문에 메서드 불러오기
                    UpdateProdPrice(reader.GetDateTime(0), prodArr);

                    // Chart 업데이트
                    UpdateChart(reader.GetDateTime(0), reader.GetInt64(1), reader.GetInt64(2),
                        reader.GetInt64(3), reader.GetInt64(4), reader.GetInt64(5), reader.GetInt64(6), reader.GetInt64(7),
                        reader.GetInt64(8), reader.GetInt64(9));
                }
                
            }

        }

        /// <summary>
        /// 조회 가능 날짜를 받아오는 메서드
        /// </summary>
        /// <returns></returns>
        public string[] GetDates ()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["StatisticsDB"].ConnectionString;
            // index = 0 : 시작날짜
            // index = 1 : 마지막날짜
            string[] dateArr = new string[2];

            using (SqlConnection sqlCon = new SqlConnection())
            {
                sqlCon.ConnectionString = connectionString;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("usp_getDate", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = cmd.Parameters.Add("@firstDate", SqlDbType.Date);
                param.Direction = ParameterDirection.Output;

                param = cmd.Parameters.Add("@lastDate", SqlDbType.Date);
                param.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                dateArr[0] = string.Format("{0:yyyy-MM-dd}", cmd.Parameters["@firstDate"].Value);
                dateArr[1] = string.Format("{0:yyyy-MM-dd}", cmd.Parameters["@lastDate"].Value);
            }

            return dateArr;

        }

        /// <summary>
        /// 특정날짜에 대한 물품 가격 데이터를 DB에서 가져오게 하는 메서드
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="lastDate"></param>
        public void GetSpecialProdPrice (string firstDate, string lastDate)
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["StatisticsDB"].ConnectionString;
            SqlDataReader reader;

            using (SqlConnection sqlCon = new SqlConnection())
            {
                sqlCon.ConnectionString = connectionString;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("usp_getSpecialProdPrice", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = cmd.Parameters.Add("@firstDate", SqlDbType.NVarChar, 20);
                param.Value = firstDate;

                param = cmd.Parameters.Add("@lastDate", SqlDbType.NVarChar, 20);
                param.Value = lastDate;

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // 물품 컬럼수에 따른 배열 동적할당 (updateDate 개수는 생략)
                    long[] prodArr = new long[reader.FieldCount - 1];
                    for (int i = 0; i < prodArr.Length; i++)
                    {
                        prodArr[i] = reader.GetInt64(i + 1);
                    }

                    // DAO 클래스에서는 폼에 있는 컨트롤에 접근할 수 없기 때문에 메서드 불러오기
                    UpdateSpecialProdPrice(reader.GetDateTime(0), prodArr);
                    UpdateSpecialChart(reader.GetDateTime(0), prodArr);
                }
            }
        }
    }
}
