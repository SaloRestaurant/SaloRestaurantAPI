using FluentValidation;

namespace SaloAPI.Domain.Entities;

public sealed class ImageEntity
{
    public ImageEntity()
    {
    }

    public ImageEntity(
        string filename,
        Guid? productId)
    {
        Id = Guid.NewGuid();

        FileName = filename;
        ProductId = productId;

        new ImageEntityValidator().ValidateAndThrow(this);
    }

    public Guid Id { get; set; }

    public string FileName { get; set; }

    public Guid? ProductId { get; set; }

    public ProductEntity ProductEntity { get; set; }

    public static ImageEntity Create(
        string filename,
        Guid? productId)
    {
        var newImage = new ImageEntity(filename, productId);

        return newImage;
    }
}