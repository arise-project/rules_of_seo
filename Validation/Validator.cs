using rules_of_seo.Model;
namespace rules_of_seo.Validation
{
    public interface IValidator
    {
        List<RuleMessage> Validate();
    }
}
