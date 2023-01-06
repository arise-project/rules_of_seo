namespace rules_of_seo.Config
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SlugAttribute : Attribute
    {
        public string Slug { get; set; }

        public double Version { get; set; }

        public SlugAttribute(string slug)
        {
            Slug = slug;
            Version = 1.0;
        }
    }
}
