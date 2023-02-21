using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Profile.Utilities.Recommendation
{
    internal class DefaultEndProcessingRecommendationService : IEndProcessingRecommendationService
    {
        /// <inheritdoc/>
        public override void Handle(AzurePSCmdlet azurePSCmdlet, InvocationInfo myInvocation, AzurePSQoSEvent qoSEvent)
        {
            if (myInvocation.InvocationName == "New-AzVM")
            {
                if (myInvocation.BoundParameters["location"] as string == "locationA")
                {
                    azurePSCmdlet.WriteInformation(new HostInformationMessage() { Message = "please use recommended locationB" }, new string[] { "PSHOST" });
                    qoSEvent.DisplayRegionIdentified = true;
                }
            }
            base.Handle(azurePSCmdlet, myInvocation, qoSEvent);
        }
    }
}
