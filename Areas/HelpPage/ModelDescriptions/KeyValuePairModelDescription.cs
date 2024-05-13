namespace WildlifeAPI.Areas.HelpPage.ModelDescriptions
{
#pragma warning disable
    public class KeyValuePairModelDescription : ModelDescription
    {
        public ModelDescription KeyModelDescription { get; set; }

        public ModelDescription ValueModelDescription { get; set; }
    }
}