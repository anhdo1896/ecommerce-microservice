namespace Ecommerce.Service.ProductAPI.Specification
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 20;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public double? PriceMax{ get; set; }
        public double? PriceMin{ get; set; }
        public int? RatingNumber { get; set; }
        public string? Sort { get; set; }
        private string? _search { get; set; }
        public string? Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
