﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CallCenterDB.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute(@"
        <?xml version=""1.0"" encoding=""utf-16""?>
        <SerializableConnectionString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
        <ConnectionString>Data Source=184.107.55.171;Initial Catalog=Galenia_Loyalty_Program;Persist Security Info=True;User ID=usr_galenia_lp</ConnectionString>
        <ProviderName>System.Data.SqlClient</ProviderName>
        </SerializableConnectionString>
      ")]
        public string GaleniaTestConnectionString {
            get {
                return ((string)(this["GaleniaTestConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://rewards.com.mx/wsrms/wsRewards_Service_2.php")]
        public string CallCenterDB_mx_com_rewards_wsRewards_Service_2 {
            get {
                return ((string)(this["CallCenterDB_mx_com_rewards_wsRewards_Service_2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=204.71.233.8;Initial Catalog=vipclubla;Persist Security Info=True;Use" +
            "r ID=w_vipclubla_dbo")]
        public string vipclublaConnectionString {
            get {
                return ((string)(this["vipclublaConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=184.106.188.43;Initial Catalog=VipClubDB_stg;User ID=sa")]
        public string VipClubDB_stgConnectionString1 {
            get {
                return ((string)(this["VipClubDB_stgConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=184.107.55.171;Initial Catalog=LMS_Loyalty_Points;Persist Security In" +
            "fo=True;User ID=usr_loyalty_world;Password=loyworld@2014")]
        public string Loyalty_TestConnectionString {
            get {
                return ((string)(this["Loyalty_TestConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=184.107.55.171;Initial Catalog=Galenia_Loyalty_Program;User ID=usr_ga" +
            "lenia_lp;Password=galenialp@2015")]
        public string GaleniaTestConnectionString1 {
            get {
                return ((string)(this["GaleniaTestConnectionString1"]));
            }
        }
    }
}
