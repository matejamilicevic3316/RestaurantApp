using DataAccess;
using Domain;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsWaiter;
using RAApplication.Interfaces;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.WaiterCommands
{
    public class AddWaiter : BaseCommand,IAddWaiter
    {
        private IGetWaiter getWaiter;
        private IEmailSender emailSender;
        public AddWaiter(IGetWaiter getWaiter,RestaurantContext ctx,IEmailSender emailSender) : base(ctx)
        {
            this.getWaiter = getWaiter;
            this.emailSender = emailSender;
        }

        public WaiterDTO Execute(WaiterRequest req)
        {
            if (context.Roles.Any(p => p.Id == req.IdRole))
            {
                if (context.Waiters.Any(p => p.Email == req.Email))
                {
                    throw new ObjectAlreadyExistsException("Email");
                }
                else
                {
                    var waiter = new Waiter
                    {
                        FirstName = req.FirstName,
                        LastName = req.LastName,
                        IdRole = req.IdRole,
                        Email = req.Email,
                        Password = req.Password
                    };
                    this.context.Waiters.Add(waiter);
                    this.context.SaveChanges();
                    emailSender.Subject = "Job";
                    emailSender.Subject = req.FirstName + " " + req.LastName + ", you got a job!";
                    emailSender.ToEmail = req.Email;
                    emailSender.Send();
                    return getWaiter.Execute(waiter.Id);
                }
            }
            else
            {
                throw new ObjectDoesntExistException("Role");
            }
        }
    }
}
