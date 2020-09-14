using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LinelistSVC
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IService1"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IService1
    {
        
        [ServiceKnownType(typeof(DBNull))]
        [OperationContract]
        bool Put_data_into_DB(object[] arr, int row, int col, string userName, string date, string comment);

        [OperationContract]
        List<string> Load_setNumbers();

        [OperationContract]
        string[][] Load_data_from_DB(string selected_setNumber);

        [OperationContract]
        List<string> Load_DB_Record();

        [OperationContract]
        List<string> Load_column_name();
        [OperationContract]
        List<string> Record();

    }

}
