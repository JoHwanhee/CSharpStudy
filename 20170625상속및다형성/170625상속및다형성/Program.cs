using System;
using static System.Console;

namespace InheritanceAndPolymorphism170625
{

    abstract class P
    {
        // abstract, interfcae, 다형성, 캡슐화 
        private int x;

        /*
        void add()
        {
            x = 109;
        }
        */

        public abstract void add(int x);
    }

    class C : P
    {
        //  오버라이딩, 내가 직접 내용을 저으이 하겠다.
        public override void add(int x = 0)
        {
            WriteLine("C : Add()" + x);
        }

    }

    class Bird
    {
        private int 부리;
        private int 다리;
        private int 날개;

        public void set부리(int x)
        {
            부리 = x;
        }

        public int get부리()
        {
            return 부리;
        }

        //
        public int 부리2 { get; set; }
    }

    #region MyRegion

    interface ISort
    {
        void Sort();
    }

    // 

    class Bubble : ISort
    {
        private int x;

        public void Sort()
        {
            Console.WriteLine("버블");
        }

        public void add(int x)
        {
            this.x = x;
        }
    }

    class Quick : ISort
    {
        public void Sort()
        {
            Console.WriteLine("퀵");
        }
    }

    class Heap : ISort
    {
        public void Sort()
        {
            Console.WriteLine("힙");
        }
    }


    #endregion

    interface IBirds
    {
        // 선언만, 메소드랑 프로퍼티
        void Fly();
    }

    public class 참새 : IBirds
    {
        public void Fly()
        {
            WriteLine("참새가 날고 있어요!");
        }
    }

    public class 독수리 : IBirds
    {
        public void Fly()
        {
            WriteLine("독수리가 사냥감을 찾고 있어요");
        }
    }

    public class 비둘기 : IBirds
    {
        public void Fly()
        {
            WriteLine("비둘기가 괴롭히고 있어요");
        }
    }

    class BirdsFlyer
    {
        private IBirds birds;

        public void SetBird(IBirds birds)
        {
            this.birds = birds;
        }

        public IBirds GetBirds()
        {
            return birds;
        }

        public void Fly()
        {
            birds.Fly();
        }
    }

    class Program
    {
        static void Main()
        {
            BirdsFlyer birdsFlyer = new BirdsFlyer();
            birdsFlyer.SetBird(new 비둘기());
            IBirds 훈련된새 = birdsFlyer.GetBirds();

            훈련된새.Fly();

            MySort(new Bubble());
            MySort(new Heap());
            MySort(new Quick());

        }

        static void MySort(ISort isort)
        {
            isort.Sort();
        }
    }
}
