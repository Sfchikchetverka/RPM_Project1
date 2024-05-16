namespace RPM_Project1
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal Cost { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Characteristics { get; set; }
        public string Photo { get; set; }
        public Car() { }

        public Car(string Model, decimal Cost, int Year, string Description, string Characteristics, string Photo)
        {

            this.Model=Model;
            this.Cost=Cost;
            this.Year=Year;
            this.Description=Description;
            this.Characteristics=Characteristics;
            this.Photo=Photo;
        }
    }
}
