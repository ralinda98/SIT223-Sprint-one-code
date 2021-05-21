using System;
using System.Collections.Generic;

namespace Task_4._2._1C
{
    class TeamUpWithMe
    {

        static int ChooseTeam()
        {
            Console.WriteLine("\nChoose a team number and press enter\n");
            Console.WriteLine("[1] Team 1");
            Console.WriteLine("[2] Team 2");
            Console.WriteLine("[3] Team 3");
            Console.Write(">> ");
            int teamNumber = Convert.ToInt32(Console.ReadLine());

            return teamNumber;
        }

        // Returns task taken from user's input
        static int WriteMember()
        {
            Console.WriteLine("\nEnter the number of the student and press enter\n");
            Console.WriteLine("|Student Name | Unit     |  Target Grade  |               Availability             |");
            Console.WriteLine("|__________________________________________________________________________________|");
            Console.WriteLine("| [1] Steve:   | SIT111  |      D         |   MON - FRI           08:00am-12:00pm  |");
            Console.WriteLine("| [2] John:    | SIT223  |      HD        |   WED & THU           09:30am-2:00pm   |");
            Console.WriteLine("| [3] Casper:  | SIT210  |      C         |   TUE - THU           11:00am-3:30pm   |");
            Console.WriteLine("| [4] Tony:    | SIT111  |      D         |   TUE, WED, THU - FRI 10:30am-1:00pm   |");

            Console.Write(">> ");
            int student = Convert.ToInt32(Console.ReadLine());

            return student;
        }

        static void AddMember(int teamNumber, List<string> team1, List<string> team2, List<string> team3)
        {
            int studentNumber = WriteMember();
            string student = "";

            if (studentNumber == 1)
                student = "Steve";
            else if (studentNumber == 2)
                student = "John";
            else if (studentNumber == 3)
                student = "Casper";
            else if (studentNumber == 4)
                student = "Tony";

            if (teamNumber == 1)
                team1.Add(student);
            else if (teamNumber == 2)
                team2.Add(student);
            else if (teamNumber == 3)
                team3.Add(student);
        }

        static void CreateTeamMember(List<string> team1, List<string> team2, List<string> team3)
        {
            int teamNumber = ChooseTeam();
            AddMember(teamNumber, team1, team2, team3);
        }
        static void JoinTeam(List<string> joinedTeams)
        {
            Console.WriteLine("\nPlease enter the number of a team to send a request to join: \n");
            Console.WriteLine("|  Team Name    |  Target Grade  |            Availability               |");
            Console.WriteLine("|_____________________________________________________________________|");
            Console.WriteLine("|[1] SEJ101 T10 |      D         |  TUE - THU           08:00am-12:00pm  |");
            Console.WriteLine("|[2] SIT223 T5  |      HD        |  WED & THU           09:30am-2:00pm   |");
            Console.WriteLine("|[3] SIT210 T4  |      C         |  WED - FRI           11:00am-3:30pm   |");
            Console.WriteLine("|[4] SIT111 T1  |      D         |  MON, TUE, FRI       10:30am-1:00pm   |\n");
            Console.Write(">>");

            int teamNumber = Convert.ToInt32(Console.ReadLine());
            string team = "";

            if (teamNumber == 1)
                team = "SEJ101 T10";
            else if (teamNumber == 2)
                team = "SIT223 T5";
            else if (teamNumber == 3)
                team = "SIT210 T4";
            else if (teamNumber == 4)
                team = "SIT111 T1";

            joinedTeams.Add(team);
        }

        static void ChooseOption(List<string> team1, List<string> team2, List<string> team3, List<string> joinedTeams)
        {
            Console.WriteLine("\nChoose an option number and press enter\n");
            Console.WriteLine("[1] Recruit team members");
            Console.WriteLine("[2] Join a team");
            Console.Write(">> ");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
                CreateTeamMember(team1, team2, team3);
            else if (option == 2)
                JoinTeam(joinedTeams);
        }

        static int FindMax(List<string> team1, List<string> team2, List<string> team3)
        {
            int max = team1.Count > team2.Count ? team1.Count : team2.Count;
            max = max > team3.Count ? max : team3.Count;

            return max;
        }

        static void PrintTable(List<string> myTeam1, List<string> myTeam2, List<string> myTeam3, List<string>joinedTeams)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string(' ', 12) + "Your Teams");
            Console.WriteLine(new string(' ', 10) + new string('-', 94));
            Console.WriteLine("{0,10}|{1,30}|{2,30}|{3,30}|", "Student #", "Team 1", "Team 2", "Team 3");
            Console.WriteLine(new string(' ', 10) + new string('-', 94));
            for (int i = 0; i < FindMax(myTeam1, myTeam2, myTeam3); i++)
            {
                Console.Write("{0,10}|", i);

                if (myTeam1.Count > i)
                {
                    Console.Write("{0,30}|", myTeam1[i]);
                }
                else
                {
                    Console.Write("{0,30}|", "N/A");
                }

                if (myTeam2.Count > i)
                {
                    Console.Write("{0,30}|", myTeam2[i]);
                }
                else
                {
                    Console.Write("{0,30}|", "N/A");
                }

                if (myTeam3.Count > i)
                {
                    Console.Write("{0,30}|", myTeam3[i]);
                }
                else
                {
                    Console.Write("{0,30}|", "N/A");
                }
                Console.WriteLine();
            }
            //
            //
            //
            //
            //
            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(new string(' ', 12) + "Joined Teams");
            Console.WriteLine(new string(' ', 10) + new string('-', 30));
            for(int i = 0; i < joinedTeams.Count; i++)
            {
                Console.WriteLine(new string(' ', 10) + "[" +(i+1)+"] "+joinedTeams[i]);
                Console.WriteLine(new string(' ', 10) + new string('-', 30));
            }
            //
            //
            //
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            List<string> myTeam1 = new List<string>(), myTeam2 = new List<string>(), myTeam3 = new List<string>();
            List<string> joinedTeams = new List<string>();

            while (true)
            {
                PrintTable(myTeam1, myTeam2, myTeam3, joinedTeams);
                ChooseOption(myTeam1, myTeam2, myTeam3, joinedTeams);
            }
        }
    }
}