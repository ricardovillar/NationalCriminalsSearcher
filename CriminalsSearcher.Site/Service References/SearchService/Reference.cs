﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CriminalsSearcher.Site.SearchService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SearchParameters", Namespace="http://schemas.datacontract.org/2004/07/CriminalsSearcher.Services")]
    [System.SerializableAttribute()]
    public partial class SearchParameters : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DriverLicenseNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FatherNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> MaximumAgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> MaximumHeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> MaximumWeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> MinimumAgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> MinimumHeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> MinimumWeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MotherNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NationalityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PassportNumberField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DriverLicenseNumber {
            get {
                return this.DriverLicenseNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.DriverLicenseNumberField, value) != true)) {
                    this.DriverLicenseNumberField = value;
                    this.RaisePropertyChanged("DriverLicenseNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FatherName {
            get {
                return this.FatherNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FatherNameField, value) != true)) {
                    this.FatherNameField = value;
                    this.RaisePropertyChanged("FatherName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Gender {
            get {
                return this.GenderField;
            }
            set {
                if ((object.ReferenceEquals(this.GenderField, value) != true)) {
                    this.GenderField = value;
                    this.RaisePropertyChanged("Gender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> MaximumAge {
            get {
                return this.MaximumAgeField;
            }
            set {
                if ((this.MaximumAgeField.Equals(value) != true)) {
                    this.MaximumAgeField = value;
                    this.RaisePropertyChanged("MaximumAge");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> MaximumHeight {
            get {
                return this.MaximumHeightField;
            }
            set {
                if ((this.MaximumHeightField.Equals(value) != true)) {
                    this.MaximumHeightField = value;
                    this.RaisePropertyChanged("MaximumHeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> MaximumWeight {
            get {
                return this.MaximumWeightField;
            }
            set {
                if ((this.MaximumWeightField.Equals(value) != true)) {
                    this.MaximumWeightField = value;
                    this.RaisePropertyChanged("MaximumWeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> MinimumAge {
            get {
                return this.MinimumAgeField;
            }
            set {
                if ((this.MinimumAgeField.Equals(value) != true)) {
                    this.MinimumAgeField = value;
                    this.RaisePropertyChanged("MinimumAge");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> MinimumHeight {
            get {
                return this.MinimumHeightField;
            }
            set {
                if ((this.MinimumHeightField.Equals(value) != true)) {
                    this.MinimumHeightField = value;
                    this.RaisePropertyChanged("MinimumHeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> MinimumWeight {
            get {
                return this.MinimumWeightField;
            }
            set {
                if ((this.MinimumWeightField.Equals(value) != true)) {
                    this.MinimumWeightField = value;
                    this.RaisePropertyChanged("MinimumWeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MotherName {
            get {
                return this.MotherNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MotherNameField, value) != true)) {
                    this.MotherNameField = value;
                    this.RaisePropertyChanged("MotherName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nationality {
            get {
                return this.NationalityField;
            }
            set {
                if ((object.ReferenceEquals(this.NationalityField, value) != true)) {
                    this.NationalityField = value;
                    this.RaisePropertyChanged("Nationality");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PassportNumber {
            get {
                return this.PassportNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.PassportNumberField, value) != true)) {
                    this.PassportNumberField = value;
                    this.RaisePropertyChanged("PassportNumber");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SearchService.ISearchService")]
    public interface ISearchService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISearchService/Search", ReplyAction="http://tempuri.org/ISearchService/SearchResponse")]
        bool Search(CriminalsSearcher.Site.SearchService.SearchParameters searchParameters, string mailTo, int maxResults);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISearchService/Search", ReplyAction="http://tempuri.org/ISearchService/SearchResponse")]
        System.Threading.Tasks.Task<bool> SearchAsync(CriminalsSearcher.Site.SearchService.SearchParameters searchParameters, string mailTo, int maxResults);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISearchServiceChannel : CriminalsSearcher.Site.SearchService.ISearchService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SearchServiceClient : System.ServiceModel.ClientBase<CriminalsSearcher.Site.SearchService.ISearchService>, CriminalsSearcher.Site.SearchService.ISearchService {
        
        public SearchServiceClient() {
        }
        
        public SearchServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SearchServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SearchServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SearchServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Search(CriminalsSearcher.Site.SearchService.SearchParameters searchParameters, string mailTo, int maxResults) {
            return base.Channel.Search(searchParameters, mailTo, maxResults);
        }
        
        public System.Threading.Tasks.Task<bool> SearchAsync(CriminalsSearcher.Site.SearchService.SearchParameters searchParameters, string mailTo, int maxResults) {
            return base.Channel.SearchAsync(searchParameters, mailTo, maxResults);
        }
    }
}
