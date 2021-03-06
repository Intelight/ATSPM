﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPM.LinkPivotServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AdjustmentObject", Namespace="http://schemas.datacontract.org/2004/07/MOEWcfServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class AdjustmentObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double AOGDownstreamBeforeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double AOGDownstreamPredictedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double AOGUpstreamBeforeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double AOGUpstreamPredictedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AdjustmentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double AogTotalBeforeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double AogTotalPredictedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DeltaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DownSignalIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DownstreamApproachDirectionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DownstreamLocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double DownstreamVolumeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LinkNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PAOGDownstreamBeforeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PAOGDownstreamPredictedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PAOGUpstreamBeforeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PAOGUpstreamPredictedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PAogTotalBeforeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PAogTotalPredictedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResultChartLocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SignalIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UpstreamApproachDirectionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double UpstreamVolumeField;
        
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
        public double AOGDownstreamBefore {
            get {
                return this.AOGDownstreamBeforeField;
            }
            set {
                if ((this.AOGDownstreamBeforeField.Equals(value) != true)) {
                    this.AOGDownstreamBeforeField = value;
                    this.RaisePropertyChanged("AOGDownstreamBefore");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AOGDownstreamPredicted {
            get {
                return this.AOGDownstreamPredictedField;
            }
            set {
                if ((this.AOGDownstreamPredictedField.Equals(value) != true)) {
                    this.AOGDownstreamPredictedField = value;
                    this.RaisePropertyChanged("AOGDownstreamPredicted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AOGUpstreamBefore {
            get {
                return this.AOGUpstreamBeforeField;
            }
            set {
                if ((this.AOGUpstreamBeforeField.Equals(value) != true)) {
                    this.AOGUpstreamBeforeField = value;
                    this.RaisePropertyChanged("AOGUpstreamBefore");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AOGUpstreamPredicted {
            get {
                return this.AOGUpstreamPredictedField;
            }
            set {
                if ((this.AOGUpstreamPredictedField.Equals(value) != true)) {
                    this.AOGUpstreamPredictedField = value;
                    this.RaisePropertyChanged("AOGUpstreamPredicted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Adjustment {
            get {
                return this.AdjustmentField;
            }
            set {
                if ((this.AdjustmentField.Equals(value) != true)) {
                    this.AdjustmentField = value;
                    this.RaisePropertyChanged("Adjustment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AogTotalBefore {
            get {
                return this.AogTotalBeforeField;
            }
            set {
                if ((this.AogTotalBeforeField.Equals(value) != true)) {
                    this.AogTotalBeforeField = value;
                    this.RaisePropertyChanged("AogTotalBefore");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AogTotalPredicted {
            get {
                return this.AogTotalPredictedField;
            }
            set {
                if ((this.AogTotalPredictedField.Equals(value) != true)) {
                    this.AogTotalPredictedField = value;
                    this.RaisePropertyChanged("AogTotalPredicted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Delta {
            get {
                return this.DeltaField;
            }
            set {
                if ((this.DeltaField.Equals(value) != true)) {
                    this.DeltaField = value;
                    this.RaisePropertyChanged("Delta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DownSignalId {
            get {
                return this.DownSignalIdField;
            }
            set {
                if ((object.ReferenceEquals(this.DownSignalIdField, value) != true)) {
                    this.DownSignalIdField = value;
                    this.RaisePropertyChanged("DownSignalId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DownstreamApproachDirection {
            get {
                return this.DownstreamApproachDirectionField;
            }
            set {
                if ((object.ReferenceEquals(this.DownstreamApproachDirectionField, value) != true)) {
                    this.DownstreamApproachDirectionField = value;
                    this.RaisePropertyChanged("DownstreamApproachDirection");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DownstreamLocation {
            get {
                return this.DownstreamLocationField;
            }
            set {
                if ((object.ReferenceEquals(this.DownstreamLocationField, value) != true)) {
                    this.DownstreamLocationField = value;
                    this.RaisePropertyChanged("DownstreamLocation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double DownstreamVolume {
            get {
                return this.DownstreamVolumeField;
            }
            set {
                if ((this.DownstreamVolumeField.Equals(value) != true)) {
                    this.DownstreamVolumeField = value;
                    this.RaisePropertyChanged("DownstreamVolume");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LinkNumber {
            get {
                return this.LinkNumberField;
            }
            set {
                if ((this.LinkNumberField.Equals(value) != true)) {
                    this.LinkNumberField = value;
                    this.RaisePropertyChanged("LinkNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Location {
            get {
                return this.LocationField;
            }
            set {
                if ((object.ReferenceEquals(this.LocationField, value) != true)) {
                    this.LocationField = value;
                    this.RaisePropertyChanged("Location");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PAOGDownstreamBefore {
            get {
                return this.PAOGDownstreamBeforeField;
            }
            set {
                if ((this.PAOGDownstreamBeforeField.Equals(value) != true)) {
                    this.PAOGDownstreamBeforeField = value;
                    this.RaisePropertyChanged("PAOGDownstreamBefore");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PAOGDownstreamPredicted {
            get {
                return this.PAOGDownstreamPredictedField;
            }
            set {
                if ((this.PAOGDownstreamPredictedField.Equals(value) != true)) {
                    this.PAOGDownstreamPredictedField = value;
                    this.RaisePropertyChanged("PAOGDownstreamPredicted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PAOGUpstreamBefore {
            get {
                return this.PAOGUpstreamBeforeField;
            }
            set {
                if ((this.PAOGUpstreamBeforeField.Equals(value) != true)) {
                    this.PAOGUpstreamBeforeField = value;
                    this.RaisePropertyChanged("PAOGUpstreamBefore");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PAOGUpstreamPredicted {
            get {
                return this.PAOGUpstreamPredictedField;
            }
            set {
                if ((this.PAOGUpstreamPredictedField.Equals(value) != true)) {
                    this.PAOGUpstreamPredictedField = value;
                    this.RaisePropertyChanged("PAOGUpstreamPredicted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PAogTotalBefore {
            get {
                return this.PAogTotalBeforeField;
            }
            set {
                if ((this.PAogTotalBeforeField.Equals(value) != true)) {
                    this.PAogTotalBeforeField = value;
                    this.RaisePropertyChanged("PAogTotalBefore");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PAogTotalPredicted {
            get {
                return this.PAogTotalPredictedField;
            }
            set {
                if ((this.PAogTotalPredictedField.Equals(value) != true)) {
                    this.PAogTotalPredictedField = value;
                    this.RaisePropertyChanged("PAogTotalPredicted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ResultChartLocation {
            get {
                return this.ResultChartLocationField;
            }
            set {
                if ((object.ReferenceEquals(this.ResultChartLocationField, value) != true)) {
                    this.ResultChartLocationField = value;
                    this.RaisePropertyChanged("ResultChartLocation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SignalId {
            get {
                return this.SignalIdField;
            }
            set {
                if ((object.ReferenceEquals(this.SignalIdField, value) != true)) {
                    this.SignalIdField = value;
                    this.RaisePropertyChanged("SignalId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UpstreamApproachDirection {
            get {
                return this.UpstreamApproachDirectionField;
            }
            set {
                if ((object.ReferenceEquals(this.UpstreamApproachDirectionField, value) != true)) {
                    this.UpstreamApproachDirectionField = value;
                    this.RaisePropertyChanged("UpstreamApproachDirection");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double UpstreamVolume {
            get {
                return this.UpstreamVolumeField;
            }
            set {
                if ((this.UpstreamVolumeField.Equals(value) != true)) {
                    this.UpstreamVolumeField = value;
                    this.RaisePropertyChanged("UpstreamVolume");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DisplayObject", Namespace="http://schemas.datacontract.org/2004/07/MOEWcfServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class DisplayObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DownstreamAfterPCDPathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DownstreamAfterTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DownstreamBeforePCDPathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DownstreamBeforeTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ExistingAOGField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ExistingPAOGField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PredictedAOGField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PredictedPAOGField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UpstreamAfterPCDPathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UpstreamAfterTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UpstreamBeforePCDPathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UpstreamBeforeTitleField;
        
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
        public string DownstreamAfterPCDPath {
            get {
                return this.DownstreamAfterPCDPathField;
            }
            set {
                if ((object.ReferenceEquals(this.DownstreamAfterPCDPathField, value) != true)) {
                    this.DownstreamAfterPCDPathField = value;
                    this.RaisePropertyChanged("DownstreamAfterPCDPath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DownstreamAfterTitle {
            get {
                return this.DownstreamAfterTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.DownstreamAfterTitleField, value) != true)) {
                    this.DownstreamAfterTitleField = value;
                    this.RaisePropertyChanged("DownstreamAfterTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DownstreamBeforePCDPath {
            get {
                return this.DownstreamBeforePCDPathField;
            }
            set {
                if ((object.ReferenceEquals(this.DownstreamBeforePCDPathField, value) != true)) {
                    this.DownstreamBeforePCDPathField = value;
                    this.RaisePropertyChanged("DownstreamBeforePCDPath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DownstreamBeforeTitle {
            get {
                return this.DownstreamBeforeTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.DownstreamBeforeTitleField, value) != true)) {
                    this.DownstreamBeforeTitleField = value;
                    this.RaisePropertyChanged("DownstreamBeforeTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double ExistingAOG {
            get {
                return this.ExistingAOGField;
            }
            set {
                if ((this.ExistingAOGField.Equals(value) != true)) {
                    this.ExistingAOGField = value;
                    this.RaisePropertyChanged("ExistingAOG");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double ExistingPAOG {
            get {
                return this.ExistingPAOGField;
            }
            set {
                if ((this.ExistingPAOGField.Equals(value) != true)) {
                    this.ExistingPAOGField = value;
                    this.RaisePropertyChanged("ExistingPAOG");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PredictedAOG {
            get {
                return this.PredictedAOGField;
            }
            set {
                if ((this.PredictedAOGField.Equals(value) != true)) {
                    this.PredictedAOGField = value;
                    this.RaisePropertyChanged("PredictedAOG");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PredictedPAOG {
            get {
                return this.PredictedPAOGField;
            }
            set {
                if ((this.PredictedPAOGField.Equals(value) != true)) {
                    this.PredictedPAOGField = value;
                    this.RaisePropertyChanged("PredictedPAOG");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UpstreamAfterPCDPath {
            get {
                return this.UpstreamAfterPCDPathField;
            }
            set {
                if ((object.ReferenceEquals(this.UpstreamAfterPCDPathField, value) != true)) {
                    this.UpstreamAfterPCDPathField = value;
                    this.RaisePropertyChanged("UpstreamAfterPCDPath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UpstreamAfterTitle {
            get {
                return this.UpstreamAfterTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.UpstreamAfterTitleField, value) != true)) {
                    this.UpstreamAfterTitleField = value;
                    this.RaisePropertyChanged("UpstreamAfterTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UpstreamBeforePCDPath {
            get {
                return this.UpstreamBeforePCDPathField;
            }
            set {
                if ((object.ReferenceEquals(this.UpstreamBeforePCDPathField, value) != true)) {
                    this.UpstreamBeforePCDPathField = value;
                    this.RaisePropertyChanged("UpstreamBeforePCDPath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UpstreamBeforeTitle {
            get {
                return this.UpstreamBeforeTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.UpstreamBeforeTitleField, value) != true)) {
                    this.UpstreamBeforeTitleField = value;
                    this.RaisePropertyChanged("UpstreamBeforeTitle");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LinkPivotServiceReference.ILinkPivotService")]
    public interface ILinkPivotService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILinkPivotService/GetLinkPivot", ReplyAction="http://tempuri.org/ILinkPivotService/GetLinkPivotResponse")]
        SPM.LinkPivotServiceReference.AdjustmentObject[] GetLinkPivot(int routeId, System.DateTime startDate, System.DateTime endDate, int cycleTime, string direction, double bias, string biasDirection, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILinkPivotService/GetLinkPivot", ReplyAction="http://tempuri.org/ILinkPivotService/GetLinkPivotResponse")]
        System.Threading.Tasks.Task<SPM.LinkPivotServiceReference.AdjustmentObject[]> GetLinkPivotAsync(int routeId, System.DateTime startDate, System.DateTime endDate, int cycleTime, string direction, double bias, string biasDirection, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILinkPivotService/DisplayLinkPivotPCD", ReplyAction="http://tempuri.org/ILinkPivotService/DisplayLinkPivotPCDResponse")]
        SPM.LinkPivotServiceReference.DisplayObject DisplayLinkPivotPCD(string upstreamSignalID, string upstreamDirection, string downstreamSignalID, string downstreamDirection, int delta, System.DateTime startDate, System.DateTime endDate, int maxYAxis);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILinkPivotService/DisplayLinkPivotPCD", ReplyAction="http://tempuri.org/ILinkPivotService/DisplayLinkPivotPCDResponse")]
        System.Threading.Tasks.Task<SPM.LinkPivotServiceReference.DisplayObject> DisplayLinkPivotPCDAsync(string upstreamSignalID, string upstreamDirection, string downstreamSignalID, string downstreamDirection, int delta, System.DateTime startDate, System.DateTime endDate, int maxYAxis);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILinkPivotService/Test", ReplyAction="http://tempuri.org/ILinkPivotService/TestResponse")]
        int Test();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILinkPivotService/Test", ReplyAction="http://tempuri.org/ILinkPivotService/TestResponse")]
        System.Threading.Tasks.Task<int> TestAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILinkPivotServiceChannel : SPM.LinkPivotServiceReference.ILinkPivotService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LinkPivotServiceClient : System.ServiceModel.ClientBase<SPM.LinkPivotServiceReference.ILinkPivotService>, SPM.LinkPivotServiceReference.ILinkPivotService {
        
        public LinkPivotServiceClient() {
        }
        
        public LinkPivotServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LinkPivotServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LinkPivotServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LinkPivotServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SPM.LinkPivotServiceReference.AdjustmentObject[] GetLinkPivot(int routeId, System.DateTime startDate, System.DateTime endDate, int cycleTime, string direction, double bias, string biasDirection, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday) {
            return base.Channel.GetLinkPivot(routeId, startDate, endDate, cycleTime, direction, bias, biasDirection, monday, tuesday, wednesday, thursday, friday, saturday, sunday);
        }
        
        public System.Threading.Tasks.Task<SPM.LinkPivotServiceReference.AdjustmentObject[]> GetLinkPivotAsync(int routeId, System.DateTime startDate, System.DateTime endDate, int cycleTime, string direction, double bias, string biasDirection, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday) {
            return base.Channel.GetLinkPivotAsync(routeId, startDate, endDate, cycleTime, direction, bias, biasDirection, monday, tuesday, wednesday, thursday, friday, saturday, sunday);
        }
        
        public SPM.LinkPivotServiceReference.DisplayObject DisplayLinkPivotPCD(string upstreamSignalID, string upstreamDirection, string downstreamSignalID, string downstreamDirection, int delta, System.DateTime startDate, System.DateTime endDate, int maxYAxis) {
            return base.Channel.DisplayLinkPivotPCD(upstreamSignalID, upstreamDirection, downstreamSignalID, downstreamDirection, delta, startDate, endDate, maxYAxis);
        }
        
        public System.Threading.Tasks.Task<SPM.LinkPivotServiceReference.DisplayObject> DisplayLinkPivotPCDAsync(string upstreamSignalID, string upstreamDirection, string downstreamSignalID, string downstreamDirection, int delta, System.DateTime startDate, System.DateTime endDate, int maxYAxis) {
            return base.Channel.DisplayLinkPivotPCDAsync(upstreamSignalID, upstreamDirection, downstreamSignalID, downstreamDirection, delta, startDate, endDate, maxYAxis);
        }
        
        public int Test() {
            return base.Channel.Test();
        }
        
        public System.Threading.Tasks.Task<int> TestAsync() {
            return base.Channel.TestAsync();
        }
    }
}
