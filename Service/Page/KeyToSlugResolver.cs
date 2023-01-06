using rules_of_seo.Service.Interface;

namespace rules_of_seo.Service
{
    public class KeyToSlugResolver : IKeyToSlugResolver
    {
        public string? Resolve(string key)
        {
            var d = key.Count(c => c == '.');
            var l = key.Split('.').Last();

            switch(d)
            {
                case 1:
                    switch(key)
                    {
                        case "h1Text":
                        return "app-title";
                        case "h2Text":
                        return "app-sub-title";
                        case "metaTitle":
                        return "app-header-title";
                        case "mainTitle":
                        return "app-about-title";
                        case "mainText":
                        return "app-about-description";
                        case "metaDescription":
                        return "app-header-description";
                        case "howtoTitle":
                        return "app-howto-title";
                        case "faqTitle":
                        return "app-faq-title";
                    }
                break;
                case 2:
                switch(key)
                    {
                        case "h1Text":
                        return "format-title";
                        case "h2Text":
                        return "format-sub-title";
                        case "mainTitle":
                        return "format-about-title";
                        case "mainText":
                        return "format-about-description";
                        case "howtoTitle":
                        return "format-howto-title";
                        case "faqTitle":
                        return "format-faq-title";
                    }
                break;
                case 3:
                	break;
            }

            return null;
        }
    }
}
