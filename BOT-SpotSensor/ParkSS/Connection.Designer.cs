﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkSS {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Connection : global::System.Configuration.ApplicationSettingsBase {
        
        private static Connection defaultInstance = ((Connection)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Connection())));
        
        public static Connection Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\T1819\\IS\\Practica\\Campus " +
            "Park\\campusPark\\BOT-SpotSensor\\ParkSS\\ParkingSpots.mdf\";Integrated Security=True" +
            "")]
        public string connStr {
            get {
                return ((string)(this["connStr"]));
            }
        }
    }
}