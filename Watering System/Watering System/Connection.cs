using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector; // your sap connector

namespace Watering_System
{
    public class ECCDestinationConfig : IDestinationConfiguration
    {

        public bool ChangeEventsSupported()
        {
            return false;
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public RfcConfigParameters GetParameters(string destinationName)
        {

            RfcConfigParameters parms = new RfcConfigParameters();

            if (destinationName.Equals("mySAPdestination"))
            {
                parms.Add(RfcConfigParameters.AppServerHost, "");
                parms.Add(RfcConfigParameters.SystemNumber, "00");
                parms.Add(RfcConfigParameters.SystemID, "");
                parms.Add(RfcConfigParameters.User, "USER");
                parms.Add(RfcConfigParameters.Password, "NoPassword");
                parms.Add(RfcConfigParameters.Client, "120");
                parms.Add(RfcConfigParameters.Language, "EN");
                parms.Add(RfcConfigParameters.PoolSize, "5");
            }
            return parms;

        }
    }
}