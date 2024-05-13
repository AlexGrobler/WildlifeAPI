using System.Collections.ObjectModel;

namespace WildlifeAPI.Areas.HelpPage.ModelDescriptions
{
#pragma warning disable
    public class ComplexTypeModelDescription : ModelDescription
    {
        public ComplexTypeModelDescription()
        {
            Properties = new Collection<ParameterDescription>();
        }

        public Collection<ParameterDescription> Properties { get; private set; }
    }
}