namespace SCV.Web.ViewModels.Administration.StoreVM.ProductsVM
{
    using SCV.GlCommon.Enums;
    using System.ComponentModel.DataAnnotations;

    using static SCV.GlCommon.ModelConstants.EntityConstantsProduct;
    using static SCV.GlCommon.ValidationMessages.Product;
    public class ProductAddViewModel
    {
        [Required(ErrorMessage = TitleRequired)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = TitleLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = ProductCategoryRequired)]
        public ProductCategory ProductCategory { get; set; }

        [Required(ErrorMessage = QuantityRequired)]
        [Range(QuantityMinValue, QuantityMaxValue, ErrorMessage = QuantityRange)]
        public int Quantity { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionLength)]
        public string? Description { get; set; }

        [Required(ErrorMessage = PriceRequired)]
        [Range((double)PriceMinValue, (double)PriceMaxValue, ErrorMessage = PriceRange)]
        public decimal Price { get; set; }

        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength, ErrorMessage = ImageUrlInvalid)]
        public string? ImageUrl { get; set; }
    }
}
