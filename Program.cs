namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstObj1 = new FirstClass("Первый объект первого класса");
            var firstObj2 = new FirstClass("Второй объект первого класса");
            var secondObj = new SecondClass { Name = "Объект второго класса" };

            firstObj1.EventGenerated += secondObj.HandleEvent;
            firstObj2.EventGenerated += secondObj.HandleEvent;

            firstObj1.GenerateEvent();
            firstObj2.GenerateEvent();
        }
    }
    class FirstClass
    {
        public string Name { get; set; }

        public delegate void EventHandler(string eventName);
        public event EventHandler EventGenerated;

        public FirstClass(string name)
        {
            Name = name;
        }

        public void GenerateEvent()
        {
            EventGenerated?.Invoke(Name);
        }
    }


    class SecondClass
    {
        public string Name { get; set; }

        public void HandleEvent(string eventName)
        {
            Console.WriteLine($"{Name} обработал событие, сгенерированное {eventName}");
        }
    }
}