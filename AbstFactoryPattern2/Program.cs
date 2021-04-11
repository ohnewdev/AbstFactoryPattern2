using System;

// 추상팩토리 
// 샘플2
// ref : https://www.youtube.com/watch?v=soV1C6j9kkg&list=PLsoscMhnRc7pPsRHmgN4M8tqUdWZzkpxY&index=11
namespace AbstFactoryPattern2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IGuiFac fac = new LinuxGuiFac();
            IButton btn = fac.createButton();
            btn.click();


            ITextarea ta = fac.createTextarea();
            Console.WriteLine(ta.getText());


            // Mac
            fac = new MacFac();
            btn = fac.createButton();
            btn.click();
            ta = fac.createTextarea();
            Console.WriteLine(ta.getText());

        }
    }

    public interface IGuiFac
    {
        public IButton createButton();
        public ITextarea createTextarea();
    }

    public interface IButton
    {
        public void click();
    }

    public interface ITextarea
    {
        public string getText();
    }

    public class LinuxGuiFac : IGuiFac
    {
        public IButton createButton()
        {
            return new LinuxButton();
        }

        public ITextarea createTextarea()
        {
            return new LinuxTextarea();
        }
    }

    public class LinuxButton : IButton
    {
        public void click()
        {
            Console.WriteLine("Linux button click!!");
        }
    }

    public class LinuxTextarea : ITextarea
    {
        public string getText()
        {
            return "Linux string on Textarea";
        }
    }

    // add new factory
    public class MacFac : IGuiFac
    {
        public IButton createButton()
        {
            return new MacButton();
        }

        public ITextarea createTextarea()
        {
            return new MacTextArea();
        }
    }

    internal class MacTextArea : ITextarea
    {
        public string getText()
        {
            return "Mac's string on TextArea";
        }
    }

    internal class MacButton : IButton
    {
        public void click()
        {
            Console.WriteLine("Mac button 클릭");
        }

    }
}
