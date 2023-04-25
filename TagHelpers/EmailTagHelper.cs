using Microsoft.AspNetCore.Razor.TagHelpers;

namespace VendaLanches.TagHelpers
{
    public class EmailTagHelper: TagHelper
    {
        public string Endereco { get; set; }
        public string Conteudo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; // Replaces <email> with <a> tag
            output.Attributes.SetAttribute("href", "mailto:" + Endereco);
            output.Content.SetContent(Conteudo);
        }
    }
}
