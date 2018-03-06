using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inlämningsuppgift3
{
    class Runtime
    {
        private readonly Menu menu;

        public Runtime(Menu menu)
        {
            this.menu = menu;
        }

        public void Start()
        {
            string[] menuOptions = new string[]
            {
                 "Shuffle list"
                ,"Bubble sort all members by age"
                ,"Quicksort all members by age"
                , "Bubble sort all members by lastname"
                , "Quicksort all members by lastname"
                , "Show all members that haven't payed"
                ,  "Search by social security number"
                ,"Search by lastname"
                , "Sort list of 10 000 integers"
                ,"Sort list of 20 000 integers"
                , "Sort list of 40 000 integers"
                , "Reset members"
            };
            var members = GenerateMemberArray();
            PrintMembers(members);
            PrintUI(members, menuOptions);
        }


        void PrintUI(Member[] members, string[] menuOptions)
        {
            while (true)
            {
                int menuSelection = menu.PrintMenu(menuOptions);

                switch (menuSelection)
                {
                    case 0:
                        members.Shuffle();
                        break;
                    case 1:
                        members.BubbleSort((m => m.SocialSecurityNumber));
                        break;
                    case 2:
                        members.QuickSort((m => m.SocialSecurityNumber));
                        break;
                    case 3:
                        members.BubbleSort((m => m.Lastname));
                        break;
                    case 4:
                        members.QuickSort((m => m.Lastname));
                        break;
                    case 5:
                        members = members.CustomWhere(m => m.IsMembershipPayed);
                        break;
                    case 6:
                        SocialSecurityNumberSearchUI(ref members);
                        break;
                    case 7:
                        LastNameSearchUI(ref members);
                        break;
                    case 8:
                        //Search by lastname
                        break;
                    case 9:
                        //Search by lastname
                        break;
                    case 10:
                        //Search by lastname
                        break;
                    case 11:
                        members = GenerateMemberArray();
                        break;
                }
                Console.Clear();
                PrintMembers(members);
            }
        }

        void SocialSecurityNumberSearchUI(ref Member[] members)
        {
            bool result = false;
            do
            {
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("SSN can only contains digits");
                Console.WriteLine("Please enter a social security");
                Console.Write("number: ");
                string searchNumber = Console.ReadLine();
                result = float.TryParse(searchNumber, out float number);
                if (result)
                    members = members.CustomWhere(m => m.SocialSecurityNumber == number);
                else
                    Console.WriteLine("Invalid input");
            }
            while (!result);
            Console.SetCursorPosition(0, 0);
        }
        void LastNameSearchUI(ref Member[] members)
        {
            Console.WriteLine();
            Console.Write("Please enter a lastname: ");
            string search = Console.ReadLine();
            members = members.CustomWhere(m => m.Lastname.ToLower() == search.ToLower());
        }
        void PrintMembers(Member[] members)
        {
            int top = 0;
            foreach (var member in members)
            {
                string SSL = member.SocialSecurityNumber.ToString();
                SSL = $"{SSL[0]}{SSL[1]}{SSL[2]}{SSL[3]}{SSL[4]}{SSL[5]}{SSL[6]}{SSL[7]}-{SSL[8]}{SSL[9]}{SSL[10]}{SSL[11]}";
                Console.SetCursorPosition(50, top);
                top++;
                Console.WriteLine($"{top}. { member.Firstname} | {member.Lastname} | {SSL} | {member.IsMembershipPayed}");
            }
            Console.SetCursorPosition(0, 0);
        }
        Member[] GenerateMemberArray()
        {
            Member[] members = new Member[]
            {
                new Member {Firstname = "Anna", Lastname = "Wiik", IsMembershipPayed = false},
                new Member {Firstname = "Kristian",Lastname = "Kristoffersson", IsMembershipPayed = false},
                new Member {Firstname = "Klara",Lastname = "Wiking", IsMembershipPayed = true},
                new Member {Firstname = "Fredrik",Lastname = "Palm", IsMembershipPayed = false},
                new Member {Firstname = "Klara",Lastname = "Wikstrom", IsMembershipPayed = true},
                new Member {Firstname = "Pernilla",Lastname = "Wiik", IsMembershipPayed = true},
                new Member {Firstname = "Gustav",Lastname = "Svensson", IsMembershipPayed = false},
                new Member {Firstname = "Gabriella",Lastname = "Ulvenfeldt", IsMembershipPayed = true},
                new Member {Firstname = "Stefan",Lastname = "Karlstrom", IsMembershipPayed = false},
                new Member {Firstname = "Anna-Lena",Lastname = "Tapper", IsMembershipPayed = false},
                new Member {Firstname = "Ake",Lastname = "Halvarsson", IsMembershipPayed = true},
                new Member {Firstname = "Robert",Lastname = "Berg", IsMembershipPayed = true},
                new Member {Firstname = "Wilma",Lastname = "Forsberg", IsMembershipPayed = true},
                new Member {Firstname = "Johan",Lastname = "Stenkramp", IsMembershipPayed = false},
                new Member {Firstname = "Arvid",Lastname = "Juppaniemi", IsMembershipPayed = false},
                new Member {Firstname = "Jessica",Lastname = "Ivarsson", IsMembershipPayed = true},
                new Member {Firstname = "Emelie",Lastname = "Myrstrom", IsMembershipPayed = false},
                new Member {Firstname = "Karl-Jan",Lastname = "Granqvist", IsMembershipPayed = true},
                new Member {Firstname = "Roy",Lastname = "Wiik", IsMembershipPayed = true},
                new Member {Firstname = "Anna",Lastname = "Karlstrom", IsMembershipPayed = false}
            };

            for (int i = 0; i < members.Length; i++)
            {
                members[i].SocialSecurityNumber = GenerateSocialSecurityNumber();
            }
            return members;
        }
        long GenerateSocialSecurityNumber()
        {
            string year, month, day, lastFour;
            Random random = new Random();

            year = random.Next(1943, 2011).ToString();
            month = random.Next(1, 12).ToString();
            if (int.Parse(month) < 10)
                month = $"0{month}";
            day = random.Next(1, 30).ToString();
            if (int.Parse(day) < 10)
                day = $"0{day}";
            lastFour = random.Next(1000, 9999).ToString();

            return long.Parse($"{year}{month}{day}{lastFour}");

        }
    }
}
