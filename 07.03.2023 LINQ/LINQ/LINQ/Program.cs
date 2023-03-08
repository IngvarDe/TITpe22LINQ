using System;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ");

            //kutsume WhereLINQ meetodi välja
            WhereLINQ();
            ThenByLINQ();
            ThenByDescendingLINQ();
            ToLookUpLINQ();
            JoinLINQ();
            GroupJoinLINQ();
            SelectLINQ();
            AllAndAnyLINQ();
            ContainsLINQ();
            AggregateLINQ();
            AvarageLINQ();
        }

        public static void WhereLINQ()
        {
            var peopleAge = PeopleList.peoples
                .Where(x => x.Age > 20 && x.Age < 23);

            foreach (var item in peopleAge)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void ThenByLINQ()
        {
            Console.WriteLine("ThenBy järgi reastamine");

            var thenByResult = PeopleList.peoples
                //järjestab nimede järgi ja siis vanuse järgi
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Age);

            foreach (var people in thenByResult)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }

        public static void ThenByDescendingLINQ()
        {
            Console.WriteLine("ThenByDescending");

            var thenByDescending = PeopleList.peoples
                .OrderBy(x => x.Name)
                .ThenByDescending(x => x.Age);

            foreach (var people in thenByDescending)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }

        public static void ToLookUpLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Green;

            Console.WriteLine("ToLookUp järgi reastamine");

            var toLookUp = PeopleList.peoples
                .ToLookup(x => x.Age);

            foreach (var people in toLookUp)
            {
                Console.WriteLine("Age group " + people.Key);

                foreach (People p in people)
                {
                    Console.WriteLine("Person name " + p.Name);
                }
            }
        }

        public static void JoinLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("InnerJoin in LINQ");

            var innerJoin = PeopleList.peoples
                .Join(GenderList.genderList,
                humans => humans.GenderId,
                gender => gender.Id,
                (humans, gender) => new
                {
                    Name = humans.Name,
                    Sex = gender.Sex
                });

            foreach (var people in innerJoin)
            {
                Console.WriteLine(people.Name + " " + people.Sex);
            }
        }

        public static void GroupJoinLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            var groupJoin = GenderList.genderList
                .GroupJoin(PeopleList.peoples,
                p => p.Id,
                g => g.GenderId,
                (p, peopleGroup) => new
                {
                    Humans = peopleGroup,
                    GenderFullName = p.Sex
                });

            foreach (var people in groupJoin)
            {
                Console.WriteLine(people.GenderFullName);

                foreach (var name in people.Humans)
                {
                    Console.WriteLine(name.Name);
                }
            }
        }

        public static void SelectLINQ()
        {
            Console.WriteLine("Select in LINQ");
            //teha iseseisvalt LINQ Select
            //otsida Internetist vastuseid
            //lõpus kasutada foreachi

            var selectLINQ = PeopleList.peoples
                .Select(p =>  new
                {
                    name = p.Name,
                    age = p.Age
                });

            foreach (var peopleName in selectLINQ)
            {
                Console.WriteLine(peopleName.name + " " + peopleName.age);
            }
        }

        public static void AllAndAnyLINQ()
        {
            Console.WriteLine("All LINQ");

            bool areAllPeopleTeenagers = PeopleList.peoples
                .All(x => x.Age > 18);
            //k]ik PeopleList-i all olevad isikud peavad olema alla 18 a vanused

            Console.WriteLine(areAllPeopleTeenagers);

            Console.WriteLine("Any LINQ");
            bool isAnyPersonTeenager = PeopleList.peoples
                .Any(x => x.Age > 18);
            //kasvõi üks  andmerida vastab tingimustele, siis tuelb vastus
            Console.WriteLine(isAnyPersonTeenager);
        }

        public static void ContainsLINQ()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Contains LINQ");

            //pärib, kas number 10 on numbrite seas
            //niimoodi saab iga numbriga teha
            // kui paneme nr 5, siis tuleb vastuseks true
            bool result = NumberList.numberList.Contains(5);

            Console.WriteLine(result);
        }

        public static void AggregateLINQ()
        {
            string commaSeparatedPersonNames = PeopleList.peoples
                .Aggregate<People, string>(
                "People names: ",
                (str, x) => str += x.Name + ", "
                );

            Console.WriteLine(commaSeparatedPersonNames);
        }

        public static void AvarageLINQ()
        {
            Console.WriteLine("Avarage LINQ");
            //teha Avarage LINQ
            //PeopleList Age kohta teha
            var avarageResult = PeopleList.peoples
                .Average(x => x.Age);

            Console.WriteLine(avarageResult);
        }
    }
}