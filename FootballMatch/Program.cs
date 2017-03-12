using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FootballMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Команда 1
            Trainer trainer1 = new Trainer("Жозе Моуринью");
            Team team1 = new Team("Манчестер Юнайтед", trainer1, 1);

            // Команда 2
            Trainer trainer2 = new Trainer("Дэвид Мойес");
            Team team2 = new Team("Сандерленд", trainer2, 2);

            Refery refery = new Refery("Говард Уэбб");

            //!!!
            //Рефери может люить какую-то команду и не обращать внимания на нарушения
            refery.MakePreferences(team1);
            //

            // Рефери наблюдает за действиями команд
            team1.MakeGoal += refery.AddPoint;
            team2.MakeGoal += refery.AddPoint;
            team1.MakeFoul += refery.MakeWarning;
            team2.MakeFoul += refery.MakeWarning;

            Game game = new Game(team1, team2, refery);

            // Всё, что говорит рефери, влияет на исход игры
            refery.ChangeGameScore += game.AddPoint;
            //Когда матч закончится, будет выведен счёт
            GameTimer.PrintScore += game.GetScoreResult;

            Commentator commentator = new Commentator("Владимир Стогниенко", team1, team2);

            //Чтобы не скучно, будут кидаться комментики
            GameTimer.SayComment += commentator.SayComment;

            // Помощь пользователю
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Для управления используйте следующие клавиши:\n\t1 - гол забит игроком 1-й команды\n\t2 - нарушение правил игроком 1-й команды");
            Console.WriteLine("\tq(Q) - гол забит игроком 2-й команды\n\tw(W) - нарушение правил игроком 2-й команды");
            Console.WriteLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Матч начался! Сегодня играют\nКоманда 1: {0}\nКоманда 2: {1}\n", team1, team2);
            Console.ResetColor();

            Console.WriteLine();
            // Начать матч
            GameTimer.StartGame();

            SimulationPanel.SimulateGoal += team1.MakeNewGoal;
            SimulationPanel.SimulateGoal += team2.MakeNewGoal;
            SimulationPanel.SimulateFoul += team1.MakeNewFoul;
            SimulationPanel.SimulateFoul += team2.MakeNewFoul;

            // Отслеживаем действия пользователя
            do
            {
                SimulationPanel.KeeboardMonitoring();
            }
            while (GameTimer.currentTime < GameTimer.TIME);
            SimulationPanel.SimulateGoal = null;
            SimulationPanel.SimulateFoul = null;

        }
    }
}
