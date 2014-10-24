﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34209
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.33440.
// 
namespace Vitasoft.DocMaker.Core {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Doc : object, System.ComponentModel.INotifyPropertyChanged {
        
        private DocParam[] paramsField;
        
        private DocOutput_Dataset output_DatasetField;
        
        private string docNameField;
        
        private string docSectionField;
        
        private string sortSectionField;
        
        private string summaryField;
        
        private string basedOnObjectsField;
        
        private string functionResultCommentField;
        
        public Doc() {
            this.docNameField = "";
            this.sortSectionField = "";
            this.summaryField = "";
            this.basedOnObjectsField = "";
            this.functionResultCommentField = "";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Param", IsNullable=false)]
        public DocParam[] Params {
            get {
                return this.paramsField;
            }
            set {
                this.paramsField = value;
                this.RaisePropertyChanged("Params");
            }
        }
        
        /// <remarks/>
        public DocOutput_Dataset Output_Dataset {
            get {
                return this.output_DatasetField;
            }
            set {
                this.output_DatasetField = value;
                this.RaisePropertyChanged("Output_Dataset");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string DocName {
            get {
                return this.docNameField;
            }
            set {
                this.docNameField = value;
                this.RaisePropertyChanged("DocName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DocSection {
            get {
                return this.docSectionField;
            }
            set {
                this.docSectionField = value;
                this.RaisePropertyChanged("DocSection");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string SortSection {
            get {
                return this.sortSectionField;
            }
            set {
                this.sortSectionField = value;
                this.RaisePropertyChanged("SortSection");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Summary {
            get {
                return this.summaryField;
            }
            set {
                this.summaryField = value;
                this.RaisePropertyChanged("Summary");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string BasedOnObjects {
            get {
                return this.basedOnObjectsField;
            }
            set {
                this.basedOnObjectsField = value;
                this.RaisePropertyChanged("BasedOnObjects");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string FunctionResultComment {
            get {
                return this.functionResultCommentField;
            }
            set {
                this.functionResultCommentField = value;
                this.RaisePropertyChanged("FunctionResultComment");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DocParam : object, System.ComponentModel.INotifyPropertyChanged {
        
        private DocParamValue valueField;
        
        private string nameField;
        
        private string dataTypeNameField;
        
        private string commentField;
        
        public DocParam() {
            this.dataTypeNameField = "";
        }
        
        /// <remarks/>
        public DocParamValue Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string DataTypeName {
            get {
                return this.dataTypeNameField;
            }
            set {
                this.dataTypeNameField = value;
                this.RaisePropertyChanged("DataTypeName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Comment {
            get {
                return this.commentField;
            }
            set {
                this.commentField = value;
                this.RaisePropertyChanged("Comment");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DocParamValue : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool isScriptField;
        
        private string valueField;
        
        public DocParamValue() {
            this.isScriptField = false;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool IsScript {
            get {
                return this.isScriptField;
            }
            set {
                this.isScriptField = value;
                this.RaisePropertyChanged("IsScript");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DocOutput_Dataset : object, System.ComponentModel.INotifyPropertyChanged {
        
        private DocOutput_DatasetField[] fieldsField;
        
        private SearchAreaEnum searchAreaField;
        
        public DocOutput_Dataset() {
            this.searchAreaField = SearchAreaEnum.AUTO;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Field", IsNullable=false)]
        public DocOutput_DatasetField[] Fields {
            get {
                return this.fieldsField;
            }
            set {
                this.fieldsField = value;
                this.RaisePropertyChanged("Fields");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(SearchAreaEnum.AUTO)]
        public SearchAreaEnum SearchArea {
            get {
                return this.searchAreaField;
            }
            set {
                this.searchAreaField = value;
                this.RaisePropertyChanged("SearchArea");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class DocOutput_DatasetField : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nameField;
        
        private string dataTypeNameField;
        
        private string commentField;
        
        public DocOutput_DatasetField() {
            this.dataTypeNameField = "";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string DataTypeName {
            get {
                return this.dataTypeNameField;
            }
            set {
                this.dataTypeNameField = value;
                this.RaisePropertyChanged("DataTypeName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Comment {
            get {
                return this.commentField;
            }
            set {
                this.commentField = value;
                this.RaisePropertyChanged("Comment");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    public enum SearchAreaEnum {
        
        /// <remarks/>
        NONE,
        
        /// <remarks/>
        DOCONLY,
        
        /// <remarks/>
        AUTO,
    }
}
