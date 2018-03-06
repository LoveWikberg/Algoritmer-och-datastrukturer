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
            var members = GenerateMemberArray();
            PrintMembers(members);
            while (true)
            {
                int menuSelection = menu.PrintMenu(new string[]
                {
                    "Shuffle list"
                ,"Sort all members by age"
                , "Sort all members by lastname"
                , "Show all members that haven't payed"
                ,  "Search by social security number"
                ,"Search by lastname"
                , "Sort list of 10 000 integers"
                ,"Sort list of 20 000 integers"
                , "Sort list of 40 000 integers"
                , "Reset members"
                });

                switch (menuSelection)
                {
                    case 0:
                        Console.Clear();
                        members.Shuffle();
                        PrintMembers(members);
                        break;
                    case 1:
                        Console.Clear();
                        members.BubbleSort((m => m.SocialSecurityNumber));
                        PrintMembers(members);
                        break;
                    case 2:
                        Console.Clear();
                        members.QuickSort((m => m.Lastname));
                        PrintMembers(members);
                        break;
                    case 3:
                        // Show members that haven't payed
                        break;
                    case 4:
                        // Search by social security number
                        break;
                    case 5:
                        //Search by lastname
                        Console.WriteLine();
                        Console.Write("Please enter a lastname: ");
                        string search = Console.ReadLine();
                        Console.Clear();
                        PrintMembers(members);
                        break;
                    case 6:
                        //Search by lastname
                        break;
                    case 7:
                        //Search by lastname
                        break;
                    case 8:
                        //Search by lastname
                        break;
                    case 9:
                        Console.Clear();
                        members = GenerateMemberArray();
                        PrintMembers(members);
                        break;
                }
            }
        }

        //Member[] GetMembers(Member[] members, string search, Func<bool> condition)
        //{
        //    for (int i = 0; i < members.Length; i++)
        //    {
        //        if(condition() == true)
        //    }
        //}

        void PrintMembers(Member[] members)
        {
            int right = 0;
            foreach (var member in members)
            {
                Console.SetCursorPosition(50, right);
                right++;
                Console.WriteLine($"{right}. { member.Firstname} | {member.Lastname} | {member.SocialSecurityNumber} | {member.IsMembershipPayed}");
            }
            Console.SetCursorPosition(0, 0);
        }
        void PrintMarkedMembers(Member[] members, string nameSearch)
        {

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
