namespace Services
{
    public class DroidService : IDroidService
    {
        public Droid GetDroid()
        {
            return new Droid
            {
                Id = 2,
                Name = "R2D2"
            };
        }
    }
}
