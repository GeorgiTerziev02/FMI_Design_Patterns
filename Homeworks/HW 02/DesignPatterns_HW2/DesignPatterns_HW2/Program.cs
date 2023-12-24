using DesignPatterns_HW2.LabelDecorators;
using DesignPatterns_HW2.Labels;
using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2
{

    public class Program
    {
        
        public static void Main(string[] args)
        {
            ILabel label = new Label("hello world!");
            label = new TextTransformationDecorator(label, new CapitalizeTransformation());
            label = new TextTransformationDecorator(label, new CensorTransformation("world"));
            label = new TextTransformationDecorator(label, new DecorateTransformation());
            
            var decoratorToRemove = new TextTransformationDecorator(null, new DecorateTransformation());
            label = BaseLabelDecorator.RemoveDecoratorFrom(label, decoratorToRemove);
            Console.WriteLine(label.GetText());
        }
    }
}