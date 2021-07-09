using Sitecore.Data.Items;
using Sitecore.Events;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.Tenant.Pipeline
{
    public class UpdateWorkflowState
    {
        /// <summary>
        /// Update workflow state on feature template item save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnItemSaved(object sender, EventArgs args)
        {
            var eventArgs = args as SitecoreEventArgs;

            var item = eventArgs?.Parameters[0] as Item;

            if (item != null && item.TemplateID == Constants.BookDetailsTemplate) 
            {

                using (new SecurityDisabler())
                {
                    try
                    {
                        item.Editing.BeginEdit();
                        item.Fields["__Workflow state"].Value = Constants.AwaitingApproval.ToString(); // Awaiting approval of Sample workflow
                        item.Editing.EndEdit(true);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}