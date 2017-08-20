using System;

namespace Delegate20170709
{

    public class Looper
    {
        private int start;
        private int end;
        private IsNumberDele isNumberDele;

        public Looper(int start, int end, IsNumberDele isNumberDele)
        {
            this.start = start;
            this.end = end;
            this.isNumberDele = isNumberDele;
        }

        public void Display()
        {
            if (isNumberDele == null)
            {
                Console.WriteLine("isNumberDele is null !!");
                return;
            }

            for (int i = start; i <= end; i++)
            {
                if (isNumberDele(i))
                    Console.WriteLine(i);
            }
        }

    }
}