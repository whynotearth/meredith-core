using System;
using WhyNotEarth.Meredith.Public;

namespace WhyNotEarth.Meredith.Volkswagen
{
    public class Article
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int CategoryId { get; set; }

        public ArticleCategory Category { get; set; } = null!;

        public string Headline { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Excerpt { get; set; }

        public DateTime? EventDate { get; set; }

        public int? ImageId { get; set; }

        public ArticleImage? Image { get; set; }

        public int? Order { get; set; }
    }

    public class ArticleImage : Image
    {
    }

    public class ArticleCategory : Category
    {
        public string Color { get; set; } = null!;

        public int Priority { get; set; }
    }
}