using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballMatch
{
    public class Commentator : Human
    {
        Team team1;
        Team team2;

        List<string> phrases;
        Random rand;

        public Commentator (string name, Team team1, Team team2)
	    {
            this.team1 = team1;
            this.team2 = team2;
            phrases = new List<string>();
            rand = new Random(DateTime.Now.Millisecond);

            AddPhrases();
	    }

        private void AddPhrases()
        {
            phrases.Add(String.Format("{0} предлагает себя очень активно.", team1[rand.Next() % 11]));
            phrases.Add(String.Format("Тренер {0} очень активно ведёт себя у бровки поля: кричит, жестикулирует, пьёт, а иногда и курит...", team2));
            phrases.Add(String.Format("Защитник {0} поднял ногу, и... атака {1} захлебнулась!", team1, team2));
            phrases.Add(String.Format("{0} сегодня не в ударе - сгорбленная походка, потухший взгляд, всё валится из рук, из ног...", team1[rand.Next()%11]));
            phrases.Add(String.Format("Пенсионным бегом {0} побежал подавать угловой.", team1[rand.Next() % 11]));
            phrases.Add(String.Format("Это - {0}! Вы наверняка узнали его кучерявые ноги...", team1[rand.Next() % 11]));
            phrases.Add(String.Format("{0} pазминается yже 45 минyт. Hе пеpегpелся бы.", team1[rand.Next() % 11]));
            phrases.Add(String.Format("Сyдья так пpистально посмотpел в глаза игроку {0}, что чyть не пpожег дыpкy в его спине.", team2));
            phrases.Add("Это футболист с повадками страуса.");
            phrases.Add("Играешь заднего защитника - так играй, нечего бегать!");
            phrases.Add("Все грязные, потные, страшные - вот что такое футбол.");
            phrases.Add("Пенальти аккypатно pеализовал не менее аккypатно пpичесанный фyтболист.");
            phrases.Add("Ай-яй-яй-яй-яй! Вы со мной согласны?");
            phrases.Add("Удаp был очень сильным. Мяч попал в головy защитника. Если есть мозги, возможно, бyдет сотpясение.");
            phrases.Add("Нескольких сантиметров не хватило до счастья...");
            phrases.Add("Как говоpят, стоит, стоит фyтболист, потом pаз - и гол забил.");
            phrases.Add("Парень подал мяч дальше, чем я езжу на выходные!");
            phrases.Add("Солнце позолотило лысую голову вратаря.");
            phrases.Add("В первом тайме соперники только принюхивались друг к другу.");
        }

        public void SayComment(object sender, EventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(phrases[rand.Next() % phrases.Count]);
            Console.ResetColor();
        }
    }
}
