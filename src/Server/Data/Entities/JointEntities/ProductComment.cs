using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Server.Data.Entities.JointEntities;

public sealed class ProductComment
{
    public ProductComment(Guid productId, Guid commentId)
    {
        ProductId = productId;
        CommentId = commentId;
    }
    
    [Required] public Guid ProductId { get; set; }

    [Required] public Guid CommentId { get; set; }
}