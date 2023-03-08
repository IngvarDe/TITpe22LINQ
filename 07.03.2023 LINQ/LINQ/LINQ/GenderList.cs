namespace LINQ
{
    public class GenderList
    {
        public static readonly List<Gender> genderList = new List<Gender>
        {
            new Gender()
            {
                Id = Guid.Parse("81985602-b844-4bec-9066-7059f7169913"),
                Sex = "male"
            },
            new Gender()
            {
                Id = Guid.Parse("4c4209e5-7a1b-429d-91ed-bbe20844f29e"),
                Sex = "female"
            },
        };
    }
}
