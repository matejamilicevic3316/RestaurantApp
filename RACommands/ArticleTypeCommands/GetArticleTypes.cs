using DataAccess;
using RAApplication.DTO;
using RAApplication.ICommands.ICommandsArticleType;
using RAApplication.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RACommands.ArticleTypeCommands
{
    public class GetArticleTypes : BaseCommand, IGetArticleTypes
    {
        public GetArticleTypes(RestaurantContext context) : base(context)
        {

        }
        public IEnumerable<ArticleTypeDTO> Execute(ArticleTypeSearch req)
        {
                var Types = this.context.Article_types.AsQueryable().Where(p=>p.IsDelete==false);
            
                if (req.Name != null)
                {
                    Types = Types.Where(p => p.Name.ToLower().Contains(req.Name.ToLower()));
                }
                return Types.Select(p => new ArticleTypeDTO
                {
                    Id=p.Id,
                    Name=p.Name
                });
          
        }
    }
}
