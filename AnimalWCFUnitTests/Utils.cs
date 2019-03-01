using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AnimalWCFUnitTests
{
    internal class Utils
    {
        public static void CloseProxy(ICommunicationObject proxy)
        {
            if (proxy != null && proxy.State != System.ServiceModel.CommunicationState.Closed && proxy.State != System.ServiceModel.CommunicationState.Faulted)
            {
                proxy.Close();
            }
            if (proxy != null && proxy.State != CommunicationState.Closed)
            {
                proxy.Abort();
            }
        }
    }
}
