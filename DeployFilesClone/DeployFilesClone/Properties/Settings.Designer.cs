﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeployFilesClone.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string BatchDirPath {
            get {
                return ((string)(this["BatchDirPath"]));
            }
            set {
                this["BatchDirPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0,1,2,3,4,5,6,7,8,9,10")]
        public string BatchIdArray {
            get {
                return ((string)(this["BatchIdArray"]));
            }
            set {
                this["BatchIdArray"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("*.exe,*.exe.config,*.pdb")]
        public string BatchRenameFileExtensionName {
            get {
                return ((string)(this["BatchRenameFileExtensionName"]));
            }
            set {
                this["BatchRenameFileExtensionName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<setting name=\"hogehogeId\" serializeAs=\"String\">")]
        public string ReplaceBeforeBatchIdString {
            get {
                return ((string)(this["ReplaceBeforeBatchIdString"]));
            }
            set {
                this["ReplaceBeforeBatchIdString"] = value;
            }
        }
    }
}
