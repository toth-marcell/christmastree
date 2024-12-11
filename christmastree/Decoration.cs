namespace christmastree
{
    public class Decoration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public Decoration(string name, int price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
}
