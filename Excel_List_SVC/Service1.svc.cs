using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;

namespace LinelistSVC
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드, svc 및 config 파일에서 클래스 이름 "Service1"을 변경할 수 있습니다.
    // 참고: 이 서비스를 테스트하기 위해 WCF 테스트 클라이언트를 시작하려면 솔루션 탐색기에서Service1.svc나 Service1.svc.cs를 선택하고 디버깅을 시작하십시오.
    public class Service1 : IService1
    {
        private List<int> list = new List<int>();   // 값이 겹치는 행
        private OracleConnection oracleConn;
        private OracleCommand oracleCmd;
        int rowCounts;

        int setNumberInt = 0;

        public List<string> Load_column_name()
        {
            List<string> column_List = new List<string>();
            List<string> temp = new List<string>();

            bool success = false;
            success = ConnectionDB("192.168.219.108", "datalist", "jjm", "1234");   // DB 연결 성공/실패 여부 리턴
            if (success == false) { Debug.WriteLine("DB 연결 실패"); }

            string query = $@"select column_name from user_tab_columns where table_name = upper('ExcelLIST')";
            oracleCmd.CommandText = query;
            oracleCmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = oracleCmd.ExecuteReader();


            while (dr.Read())
            {
                temp.Add(dr["COLUMN_NAME"].ToString());
            }

            for (int i = 3; i < temp.Count; i++)
            {
                column_List.Add(temp[i]);
                if (i == temp.Count-1 )
                {
                    for (int j = 0; j < 3; j++)
                    {
                        column_List.Add(temp[j]);
                    }
                }
            }

            oracleConn.Close();
            return column_List;
        }
        //DB 저장 이력 가져오기
        public List<string> Load_DB_Record() {
            bool success = false;
            List<string> records = new List<string>();

            success = ConnectionDB("192.168.219.108", "datalist", "jjm", "1234");;   // DB 연결 성공/실패 여부 리턴
            if (success == false) { Debug.WriteLine("DB 연결 실패"); }
            string query = "SELECT SETNUMBER ,USERNAME, \"DATE\", \"COMMENT\" FROM SAVERECORD ORDER BY to_number(SETNUMBER) DESC";
            oracleCmd.CommandText = query;
            oracleCmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = oracleCmd.ExecuteReader();

            while (dr.Read())
            {
                records.Add(dr[0].ToString());
                records.Add(dr[1].ToString());
                records.Add(dr[2].ToString());
                records.Add(dr[3].ToString());
            }

            oracleConn.Close(); // DB 연결 해제

            return records;
        }

        public List<string> Record()
        {
            bool success = false;
            List<string> records = new List<string>();

            success = ConnectionDB("192.168.219.108", "datalist", "jjm", "1234");   // DB 연결 성공/실패 여부 리턴
            if (success == false) { Debug.WriteLine("DB 연결 실패"); }
            string query = "SELECT SETNUMBER ,USERNAME, \"DATE\", \"COMMENT\" FROM SAVERECORD ORDER BY to_number(SETNUMBER) DESC";
            oracleCmd.CommandText = query;
            oracleCmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = oracleCmd.ExecuteReader();

            while (dr.Read())
            {
                string temp = "";
                temp = dr[0].ToString() + "/" + dr[1].ToString() + "/" + dr[2].ToString() + "/" + dr[3].ToString();
                records.Add(temp);
            }

            oracleConn.Close(); // DB 연결 해제

            return records;
        }


        // set number 불러오기
        public List<string> Load_setNumbers() {
            bool success = false;
            List<string> setNumbers = new List<string>();

            success = ConnectionDB("192.168.219.108", "datalist", "jjm", "1234");   // DB 연결 성공/실패 여부 리턴
            if (success == false) { Debug.WriteLine("DB 연결 실패"); }

            string query = $@"SELECT SETNUMBER FROM SAVERECORD ORDER BY SETNUMBER DESC";
            oracleCmd.CommandText = query;
            oracleCmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = oracleCmd.ExecuteReader();

            while (dr.Read())
            {
                setNumbers.Add(dr[0].ToString());
            }

            oracleConn.Close(); // DB 연결 해제

            return setNumbers;
        }

        // DB에서 데이터 가져오기
        public string [][] Load_data_from_DB(string selected_setNumber) {
            bool success = false;

            success = ConnectionDB("192.168.219.108", "datalist", "jjm", "1234");  // DB 연결 성공/실패 여부 리턴
            if (success == false) { Debug.WriteLine("DB 연결 실패"); }           

            string query = $@"SELECT 
                                SETNUMBER,LINE_SIZE, UNIT, FLUID,SEQUENCE_NUMBER, PIPING_SPEC, INSULATION, INSULATION_THK,
                                HYDRO_TEST_MEDIUM, HYDRO_TEST_PRESS, PAINT_CODE, DESIGN__TEMP_OC, DESIGN_PRESS_BARG,
                                OPER_TEMP_OC, OPER_PRESS_BARG, RT_FIELD, RT_SHOP, PWHT, GAD_NO, PID_NO
                              FROM LINELIST WHERE SETNUMBER = '" + selected_setNumber + @"'";

            oracleCmd.CommandText = query;
            oracleCmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = oracleCmd.ExecuteReader();
            
            //List<string> data = new List<string>();
            int rcont = 0;
            while (dr.Read())
            {
                rcont++;
            }

            //long rCount = dr.RowSize;
            string[][] data = new string[rcont][];
            int i = 0;

            dr = oracleCmd.ExecuteReader();

            
            while (dr.Read())
            {
                // your logic here
                data[i] = new string[20];
                data[i][0] = dr[0].ToString();
                data[i][1] = dr[1].ToString();
                data[i][2] = dr[2].ToString();
                data[i][3] = dr[3].ToString();
                data[i][4] = dr[4].ToString();
                data[i][5] = dr[5].ToString();
                data[i][6] = dr[6].ToString();
                data[i][7] = dr[7].ToString();
                data[i][8] = dr[8].ToString();
                data[i][9] = dr[9].ToString();
                data[i][10] = dr[10].ToString();
                data[i][11] = dr[11].ToString();
                data[i][12] = dr[12].ToString();
                data[i][13] = dr[13].ToString();
                data[i][14] = dr[14].ToString();
                data[i][15] = dr[15].ToString();
                data[i][16] = dr[16].ToString();
                data[i][17] = dr[17].ToString();
                data[i][18] = dr[18].ToString();
                data[i][19] = dr[19].ToString();
                

                i++;
            }

            oracleConn.Close(); // DB 연결 해제

            //for (int i = 0; i < data.Count; i++) { Debug.WriteLine("data list[" + i + "] = " + data.ElementAt(i)); }

            return data;
        }
        
        // DB에 데이터 넣기
        public bool Put_data_into_DB(object[] arr, int row, int col, string userName, string date, string comment) {
            Debug.WriteLine("******************server 접속********************");
            bool success = false;

            object[,] data = new object[row, col];
            int index = 0;
            for (int r = 0; r < row; r++) {
                for (int c = 0; c < col; c++) {
                    data[r, c] = arr[index];
                    index++;
                    //Debug.WriteLine("data[" + r + ", " + c + "] = " + data[r, c]);
                }
            }

            rowCounts = data.GetLength(0);
            dataCheck(data);    // PK 중복 값 제거 하기 위한 값 체크

            //Oracle DB connect
            success = ConnectionDB("192.168.219.108", "datalist", "jjm", "1234");   // DB 연결 성공/실패 여부 리턴
            if (success == false) { Debug.WriteLine("DB 연결 실패"); return false; }
            Debug.WriteLine("DB 연결 성공");
            // DB에 값 넣기
            Insert_data_to_DB(data, userName, date, comment);
            
            return true;
        }

        // data 중복 값 체크
        private void dataCheck(object[,] data)
        {
            // string 1,2,3,4열 합침
            string[] dataStrings = new string[rowCounts];////////////////
            for (int r = 0; r < rowCounts; r++)
            {
                for (int c = 1; c < 5; c++)
                {
                    if (data[r, c] == null) { data[r, c] = ""; }
                    dataStrings[r] += data[r, c].ToString();
                    //Debug.WriteLine("dataStrings: " + dataStrings[r]);
                }
            }

            // 값 비교
            bool flag = false;
            for (int pick = 0; pick < rowCounts; pick++)
            {
                flag = false;
                for (int anotherPick = pick + 1; anotherPick < rowCounts; anotherPick++)
                {
                    // 값이 같다면
                    if (dataStrings[pick].Equals(dataStrings[anotherPick]))
                    {
                        flag = true; //값이 동일하다
                        list.Add(anotherPick);
                    }
                }
                if (flag)
                {
                    list.Add(pick);
                }
            }
            list.Sort();
        }

        // DB에 연결
        private bool ConnectionDB(string dbIp, string dbName, string dbId, string dbPw)
        {
            bool conn = false;

            try
            {
                oracleConn = new OracleConnection($"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={dbIp})(PORT=1521)))" +
                    $"(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={dbName})));User ID={dbId};Password={dbPw};Connection Timeout=30;");
                oracleConn.Open();
                oracleCmd = oracleConn.CreateCommand();
                //MessageBox.Show("Success DB connecion.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn = true;
            }
            catch (Exception e)
            {
                //MessageBox.Show($"DB connection fail.\n {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn = false;
            }
            return conn;
        }

        // DB에 data 넣기
        private void Insert_data_to_DB(object[,] data, string userName, string date, string comment)
        {

            // set number 값 정하기
            string query = $@"SELECT SETNUMBER FROM SAVERECORD ORDER BY to_number(SETNUMBER) DESC";
            oracleCmd.CommandText = query;
            oracleCmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr = oracleCmd.ExecuteReader();

            while (dr.Read())
            {
                setNumberInt = int.Parse(dr[0].ToString());
                break;
            }
            if (setNumberInt <= 0 || setNumberInt == null) { setNumberInt = 1; }
            else { setNumberInt++; }
            Debug.WriteLine("******set number: " + setNumberInt);


            string setNum = setNumberInt.ToString();
            query = $@"INSERT INTO SAVERECORD VALUES('" + setNum + "','"+ userName +"','"+ date +"','" + comment + "')";
            oracleCmd.CommandText = query;
            oracleCmd.ExecuteNonQuery();
            int listNum = 0;
            for (int r = 0; r < rowCounts; r++)////////////////
            {
                if (list.Count == 0 || r != list[listNum])  //중복 값이 없거나 중복 값과 같지 않을 때
                {
                    query = $@"INSERT INTO LINELIST VALUES('" + setNum + @"',";
                    for (int c = 0; c < 19; c++)
                    {
                        //Debug.WriteLine("data[" + r +"," + c + "] = " + data[r, c]);
                        if (c == 18)
                        {
                            if (data[r, c] == null)
                            {
                                data[r, c] = "";
                            }
                            query += @"'" + data[r, c].ToString() + @"'";
                        }
                        else
                        {
                            if (data[r, c] == null)
                            {
                                data[r, c] = "";
                            }
                            query += @"'" + data[r, c].ToString() + @"'" + ",";
                        }

                    }
                    query += @")";
                    oracleCmd.CommandText = query;
                    oracleCmd.ExecuteNonQuery();    // 쿼리 실행
                }
                else { listNum++; }
                if (listNum >= list.Count()) { listNum = list.Count - 1; }
            }
            oracleConn.Close(); // DB 연결 해제
        }

    }
}
