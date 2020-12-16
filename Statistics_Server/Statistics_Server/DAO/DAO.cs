using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Statistics_Server
{
    class DAO
    {
        private static DAO instance = null;
        public static DAO Get()
        {
            if (instance == null)
                instance = new DAO();

            return instance;
        }

        /// <summary>
        /// 테이블에 있는 값들을 모두 지워주는 메서드
        /// </summary>
        public void ResetTables ()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["StatisticsDB"].ConnectionString;

            using (SqlConnection sqlCon = new SqlConnection())
            {
                sqlCon.ConnectionString = connectionString;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("usp_deleteAll", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 처음 Form이 실행될 때 DB에 물품값 업데이트 (1000원으로)
        /// </summary>
        /// <param name="prodID"></param>
        /// <param name="prodName"></param>
        /// <param name="prodType"></param>
        /// <param name="prodPrcie"></param>
        /// <param name="currentTime"></param>
        public void FirstConnection (string prodID, string prodName, string prodType, int prodPrcie, DateTime currentTime)
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["StatisticsDB"].ConnectionString;

            using (SqlConnection sqlCon = new SqlConnection())
            {
                sqlCon.ConnectionString = connectionString;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("usp_firstConnection", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = cmd.Parameters.Add("@prodID", SqlDbType.NVarChar, 2);
                param.Value = prodID;

                param = cmd.Parameters.Add("@prodName", SqlDbType.NVarChar, 10);
                param.Value = prodName;

                param = cmd.Parameters.Add("@prodType", SqlDbType.NVarChar, 5);
                param.Value = prodType;

                param = cmd.Parameters.Add("@prodPrice", SqlDbType.BigInt);
                param.Value = prodPrcie;

                param = cmd.Parameters.Add("@updatedDate", SqlDbType.DateTime);
                param.Value = currentTime;

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 랜덤 변동값을 DB에 적용시켜주는 메서드
        /// </summary>
        /// <param name="prodID"></param>
        /// <param name="prodName"></param>
        /// <param name="prodType"></param>
        /// <param name="prodChange"></param>
        /// <param name="currentTime"></param>
        public void UpdatePrice (string prodID, string prodName, string prodType, int prodChange, DateTime currentTime)
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["StatisticsDB"].ConnectionString;

            using (SqlConnection sqlCon = new SqlConnection())
            {
                sqlCon.ConnectionString = connectionString;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("usp_updatePrice", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = cmd.Parameters.Add("@prodID", SqlDbType.NVarChar, 2);
                param.Value = prodID;

                param = cmd.Parameters.Add("@prodName", SqlDbType.NVarChar, 10);
                param.Value = prodName;

                param = cmd.Parameters.Add("@prodType", SqlDbType.NVarChar, 5);
                param.Value = prodType;

                param = cmd.Parameters.Add("@prodChange", SqlDbType.Int);
                param.Value = prodChange;

                param = cmd.Parameters.Add("@updatedDate", SqlDbType.DateTime);
                param.Value = currentTime;

                cmd.ExecuteNonQuery();
            }
        }
    }
}
