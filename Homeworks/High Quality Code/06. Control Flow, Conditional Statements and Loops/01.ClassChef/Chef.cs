namespace Kitchen
{
    public class Chef
    {
        public void Cook()
        {
            Potato potato = GetPotato();
            Carrot carrot = GetCarrot();
            Peel(potato);
            Peel(carrot);
            Cut(potato);
            Cut(carrot);
            Bowl bowl = GetBowl();            
            bowl.Add(carrot);
            bowl.Add(potato);
        }
        private Potato GetPotato()
        {
            return new Potato();
        }
        private Carrot GetCarrot()
        {
            return new Carrot();
        }
        private static void Peel(Vegetable vegatable)
        {
            System.Console.WriteLine("Peeling");
        }
        private void Cut(Vegetable vegetable)
        {
        }
        private Bowl GetBowl()
        {
            return new Bowl();
        }
    }
}
