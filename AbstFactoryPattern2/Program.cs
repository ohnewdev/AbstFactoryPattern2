using System;

/// <summary>
/// 
///
/// 추상팩토리 
/// 샘플2
/// 
/// 요구사항
/// 
///
/// ref : https://www.youtube.com/watch?v=soV1C6j9kkg&list=PLsoscMhnRc7pPsRHmgN4M8tqUdWZzkpxY&index=11
/// </summary>
namespace AbstFactoryPattern2
{
    class Program
    {
        static void Main(string[] args)
        {



            //Console.WriteLine("Hello World!");
            //IGuiFac fac = new LinuxGuiFac();
            //IButton btn = fac.createButton();
            //btn.click();


            //ITextarea ta = fac.createTextarea();
            //Console.WriteLine(ta.getText());


            //// Mac
            //fac = new MacGuiFac();
            //btn = fac.createButton();
            //btn.click();
            //ta = fac.createTextarea();
            //Console.WriteLine(ta.getText());


            IGuiFac fac = FactoryInstance.getGuiFac();
            IButton btn = fac.createButton();
            btn.click();
            ITextarea ta = fac.createTextarea();
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
    public class MacGuiFac : IGuiFac
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

    // add new fac
    public class WindowGuiFac : IGuiFac
    {
        public IButton createButton()
        {
            return new WindowButton();
        }

        public ITextarea createTextarea()
        {
            return new WindowTextarea();
        }
    }



    public class WindowButton : IButton
    {
        public void click()
        {
            Console.WriteLine("Window button click!!");
        }
    }

    public class WindowTextarea : ITextarea
    {
        public string getText()
        {
            return "Window string on Textarea";
        }
    }


    public class FactoryInstance
    {
        public static IGuiFac getGuiFac()
        {
            int l_typeOs = getTypeOfOs();
            switch (l_typeOs)
            {
                case 0:
                    return new WindowGuiFac();
                case 1:
                    return new MacGuiFac();
                case 2:
                    return new LinuxGuiFac();

                default:
                    return null;

            }

        }

        private static int getTypeOfOs()
        {

            // Microsoft Windows
            Console.WriteLine(Environment.OSVersion.ToString());
            if (Environment.OSVersion.ToString().Contains("Windows"))
            {
                return 0;

            }
            else if (Environment.OSVersion.ToString().Contains("Mac"))
            {
                return 1;
            }
            else if (Environment.OSVersion.ToString().Contains("Linux"))
            {
                return 2;
            }
            else return -1;

        }
    }
}
