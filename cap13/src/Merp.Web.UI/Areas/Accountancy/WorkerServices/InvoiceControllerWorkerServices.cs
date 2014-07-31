﻿using Merp.Accountancy.CommandStack.Commands;
using Merp.Infrastructure;
using Merp.Web.UI.Areas.Accountancy.Models.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merp.Web.UI.Areas.Accountancy.WorkerServices
{
    public class InvoiceControllerWorkerServices
    {
        public IBus Bus { get; private set; }

        public InvoiceControllerWorkerServices(IBus bus)
        {
            if(bus==null)
            {
                throw new ArgumentNullException("bus");
            }
            this.Bus = bus;
        }
        public IssueViewModel GetIssueViewModel()
        {
            var model = new IssueViewModel();
            model.Date = DateTime.Now;
            return model;
        }
        public void Issue(IssueViewModel model)
        {
            var command = new IssueInvoiceCommand(
                model.Date,
                model.Amount,
                model.Taxes,
                model.TotalPrice,
                model.Description,
                model.PaymentTerms,
                model.PurchaseOrderNumber,
                model.Customer.OriginalId,
                model.Customer.Name,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty
                );
            Bus.Send(command);
        }
    }
}