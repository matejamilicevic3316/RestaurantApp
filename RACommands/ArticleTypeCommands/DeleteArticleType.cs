using DataAccess;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsArticleType;

namespace RACommands.ArticleTypeCommands
{
    public class DeleteArticleType : BaseCommand, IDeleteArticleType
    {
        public DeleteArticleType(RestaurantContext context) : base(context)
        {

        }
        public void Execute(int req)
        {
            var delete = this.context.Article_types.Find(req);
            if (delete == null)
            {
                throw new ObjectDoesntExistException("ArticleType");
            }
            else
            {
                delete.IsDelete = true;
                this.context.SaveChanges();
            }
        }
    }
}
