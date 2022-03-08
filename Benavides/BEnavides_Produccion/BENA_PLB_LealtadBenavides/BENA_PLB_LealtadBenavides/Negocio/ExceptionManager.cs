using System;
using System.Diagnostics;
using System.Text;
using Microsoft.Win32;

namespace Negocio
{
    /// <summary>
    /// Clase que nos permite el Manejo de Excepciones.
    /// </summary>
    public class ExceptionManager
    {
        #region Methds

        /// <summary>
        /// Método que nos permite Crear el Registro LMS en el EventLog y escribir sus entradas.
        /// </summary>
        /// <param name="exception">Exception que se genero.</param>
        /// <param name="logEntryType">Tipo de Log a Escribir: 1)Error 2)Warning 3)Information 4)Failure Audit 5) Sucess Audit.</param>
        /// <param name="eventId">Id del Evento.</param>
        /// <param name="categoryId">Id de la Categoria.</param>
        public static void HandleException(Exception ex, int logEntryType, int eventId, short categoryId)
        {
            string eventLogName = "LMS";
            string sourceName = "LMS";
            EventLog hoksoftLog;
            hoksoftLog = new EventLog();
            hoksoftLog.Log = eventLogName;

            // set default event source (to be same as event log name) if not passed in
            if ((sourceName == null) || (sourceName.Trim().Length == 0))
            {
                sourceName = eventLogName;
            }

            hoksoftLog.Source = sourceName;

            // Extra Raw event data can be added (later) if needed
            byte[] rawEventData = Encoding.ASCII.GetBytes("");

            /// Check whether the Event Source exists. It is possible that this may
            /// raise a security exception if the current process account doesn't
            /// have permissions for all sub-keys under 
            /// HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\EventLog

            // Check whether registry key for source exists

            string keyName = @"SYSTEM\CurrentControlSet\Services\EventLog\" + eventLogName;

            RegistryKey rkEventSource = Registry.LocalMachine.OpenSubKey(keyName + @"\" + sourceName);

            // Check whether key exists
            if (rkEventSource == null)
            {
                /// Key does not exist. Create key which represents source
                Registry.LocalMachine.CreateSubKey(keyName + @"\" + sourceName);
                rkEventSource = Registry.LocalMachine.OpenSubKey(keyName + @"\" + sourceName);
            }

            /// Now validate that the .NET Event Message File, EventMessageFile.dll (which correctly
            /// formats the content in a Log Message) is set for the event source
            object eventMessageFile = rkEventSource.GetValue("EventMessageFile");

            /// If the event Source Message File is not set, then set the Event Source message file.
            if (eventMessageFile == null)
            {
                /// Source Event File Doesn't exist - determine .NET framework location,
                /// for Event Messages file.
                RegistryKey dotNetFrameworkSettings = Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\.NetFramework\");

                if (dotNetFrameworkSettings != null)
                {

                    object dotNetInstallRoot = dotNetFrameworkSettings.GetValue(
                        "InstallRoot",
                        null,
                        RegistryValueOptions.None);

                    if (dotNetInstallRoot != null)
                    {
                        string eventMessageFileLocation =
            dotNetInstallRoot.ToString() +
            "v" +
            System.Environment.Version.Major.ToString() + "." +
            System.Environment.Version.Minor.ToString() + "." +
            System.Environment.Version.Build.ToString() +
            @"\EventLogMessages.dll";

                        /// Validate File exists
                        if (System.IO.File.Exists(
            eventMessageFileLocation))
                        {
                            /// The Event Message File exists in the anticipated location on the
                            /// machine. Set this value for the new Event Source

                            // Re-open the key as writable
                            rkEventSource = Registry.LocalMachine.OpenSubKey(
                                keyName + @"\" + sourceName,
                                true);

                            // Set the "EventMessageFile" property
                            rkEventSource.SetValue(
                                "EventMessageFile",
                                eventMessageFileLocation,
                                RegistryValueKind.String);
                        }
                    }
                }
                dotNetFrameworkSettings.Close();
            }

            rkEventSource.Close();

            switch (logEntryType)
            {
                case 1:
                    hoksoftLog.WriteEntry(ex.ToString(), EventLogEntryType.Error, eventId, categoryId);
                    break;
                case 2:
                    hoksoftLog.WriteEntry(ex.ToString(), EventLogEntryType.Warning, eventId, categoryId);
                    break;
                case 3:
                    hoksoftLog.WriteEntry(ex.ToString(), EventLogEntryType.Information, eventId, categoryId);
                    break;
                case 4:
                    hoksoftLog.WriteEntry(ex.ToString(), EventLogEntryType.FailureAudit, eventId, categoryId);
                    break;
                case 5:
                    hoksoftLog.WriteEntry(ex.ToString(), EventLogEntryType.SuccessAudit, eventId, categoryId);
                    break;
            }
        }

        #endregion Methds
    }
}
