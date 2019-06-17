using DataAccess;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsArticleType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.ArticleTypeCommands
{
    public class UpdateArticleType : BaseCommand,IUpdateArticleType
    {
        public UpdateArticleType(RestaurantContext context) : base(context)
        {

        }
        public void Execute(ArticleTypeDTO req,int id)
        {
                     
                if (this.context.Article_types.Any(p=>p.Id==id))
                {
                    if (this.context.Article_types.Any(p => p.Name == req.Name))
                    {
                        throw new ObjectAlreadyExistsException("Article type");
                    }
                    else {
                        var update = this.context.Article_types.Find(id);
                        update.Name = req.Name;
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new ObjectDoesntExistException("Article Type");
                }
           
        }
    }
}
