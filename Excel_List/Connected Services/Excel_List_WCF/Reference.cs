﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LineList.Linelist_WCF {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Linelist_WCF.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Put_data_into_DB", ReplyAction="http://tempuri.org/IService1/Put_data_into_DBResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.DBNull))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(string[][]))]
        bool Put_data_into_DB(object[] arr, int row, int col, string userName, string date, string comment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Put_data_into_DB", ReplyAction="http://tempuri.org/IService1/Put_data_into_DBResponse")]
        System.Threading.Tasks.Task<bool> Put_data_into_DBAsync(object[] arr, int row, int col, string userName, string date, string comment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Load_setNumbers", ReplyAction="http://tempuri.org/IService1/Load_setNumbersResponse")]
        string[] Load_setNumbers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Load_setNumbers", ReplyAction="http://tempuri.org/IService1/Load_setNumbersResponse")]
        System.Threading.Tasks.Task<string[]> Load_setNumbersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Load_data_from_DB", ReplyAction="http://tempuri.org/IService1/Load_data_from_DBResponse")]
        string[][] Load_data_from_DB(string selected_setNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Load_data_from_DB", ReplyAction="http://tempuri.org/IService1/Load_data_from_DBResponse")]
        System.Threading.Tasks.Task<string[][]> Load_data_from_DBAsync(string selected_setNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Load_DB_Record", ReplyAction="http://tempuri.org/IService1/Load_DB_RecordResponse")]
        string[] Load_DB_Record();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Load_DB_Record", ReplyAction="http://tempuri.org/IService1/Load_DB_RecordResponse")]
        System.Threading.Tasks.Task<string[]> Load_DB_RecordAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Load_column_name", ReplyAction="http://tempuri.org/IService1/Load_column_nameResponse")]
        string[] Load_column_name();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Load_column_name", ReplyAction="http://tempuri.org/IService1/Load_column_nameResponse")]
        System.Threading.Tasks.Task<string[]> Load_column_nameAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Record", ReplyAction="http://tempuri.org/IService1/RecordResponse")]
        string[] Record();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Record", ReplyAction="http://tempuri.org/IService1/RecordResponse")]
        System.Threading.Tasks.Task<string[]> RecordAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : LineList.Linelist_WCF.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<LineList.Linelist_WCF.IService1>, LineList.Linelist_WCF.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Put_data_into_DB(object[] arr, int row, int col, string userName, string date, string comment) {
            return base.Channel.Put_data_into_DB(arr, row, col, userName, date, comment);
        }
        
        public System.Threading.Tasks.Task<bool> Put_data_into_DBAsync(object[] arr, int row, int col, string userName, string date, string comment) {
            return base.Channel.Put_data_into_DBAsync(arr, row, col, userName, date, comment);
        }
        
        public string[] Load_setNumbers() {
            return base.Channel.Load_setNumbers();
        }
        
        public System.Threading.Tasks.Task<string[]> Load_setNumbersAsync() {
            return base.Channel.Load_setNumbersAsync();
        }
        
        public string[][] Load_data_from_DB(string selected_setNumber) {
            return base.Channel.Load_data_from_DB(selected_setNumber);
        }
        
        public System.Threading.Tasks.Task<string[][]> Load_data_from_DBAsync(string selected_setNumber) {
            return base.Channel.Load_data_from_DBAsync(selected_setNumber);
        }
        
        public string[] Load_DB_Record() {
            return base.Channel.Load_DB_Record();
        }
        
        public System.Threading.Tasks.Task<string[]> Load_DB_RecordAsync() {
            return base.Channel.Load_DB_RecordAsync();
        }
        
        public string[] Load_column_name() {
            return base.Channel.Load_column_name();
        }
        
        public System.Threading.Tasks.Task<string[]> Load_column_nameAsync() {
            return base.Channel.Load_column_nameAsync();
        }
        
        public string[] Record() {
            return base.Channel.Record();
        }
        
        public System.Threading.Tasks.Task<string[]> RecordAsync() {
            return base.Channel.RecordAsync();
        }
    }
}