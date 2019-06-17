using DataAccess;
using Domain;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsArticleType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.ArticleTypeCommands
{
    public class AddArticleType : BaseCommand, IAddArticleType
    {
        IGetArticleType getArticleType;
        public AddArticleType(RestaurantContext context,IGetArticleType getArticleType) : base(context)
        {
            this.getArticleType = getArticleType;
        }
        public ArticleTypeDTO Execute(ArticleTypeDTO req)
        {
            if (context.Article_types.Any(p => p.Name == req.Name && p.IsDelete==false))
            {
                throw new ObjectAlreadyExistsException("Article");
            }
            else
            {
                var obj = new Article_type
                {
                    Name = req.Name
                };
                this.context.Article_types.Add(obj);
                context.SaveChanges();
                return getArticleType.Execute(obj.Id);
            }      
        }
       
    }
}
