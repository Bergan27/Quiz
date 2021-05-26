using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz
{
    /// <summary>
    ///  Ett enkelt gissningsspel där man ska gissa vad det är för tillverka som skapat båten på bilden
    ///  Man spelar genom att trycka på den knappa med rätt tillverkar för respektive båt
    ///  Alternativen kommer flera gånger och antal rätt sparas och kan ses fram till drag 13
    /// </summary>
    public partial class MainWindow : Window
    {   // En klass som sammankopplar svarsalternativen från en annan klass(i en annan fil) till denna 
        // AnswerAlternatives hämtar items från sin externa lista 
        // MainWindow är en klass över allt som ryms i det synliga fältet (xaml)
        //questonNumbers är en lista som innehåller tal från 1-13 för att sedan väljas randomiserat
        //Det fördefineras även intar som qNum vilket ökar efter att den fråga ställts
        // Int score kollas av i en annan funktion om man svarat rätt och ökar isf med 1
        AnswerAlternatives answerAlternatives = new AnswerAlternatives();
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        int qNum = 0;
        int i;
        int score;
        public MainWindow()
        {  
            InitializeComponent();
            StartGame();
            NextQuestion();
        } //checkAnswer är en funktion som tar in ett fördefinerat värde på 1 ifall svarsalternativet är rätt
          // Button senderButton hämtar inputen från svarsalternativet vilket än kodat i frågan att vara 1 eller ingenting
          // Senderbutton är en variabel som kan öka med 1 ifall man svarat rätt och ökar då score med 1
          //inten qNum ökar med 1 för att visa nästa fråga
        private void checkAnswer(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            if (senderButton.Tag.ToString() == "1")
            {
                score++;
            }
            if (qNum < 0)
            {
                qNum = 0;
            }
            else
            {
                qNum++;
            }
            scoretext.Content = "Answered Correctly" + score + "/" + questionNumbers.Count;
            NextQuestion();
        }// En funktion som startar om spelet och återställer score, i, och qnum
         //qnum är satt som -1 för att man ska kunna starta om spelet efter att man svarat på alla 13 frågor
         //qnum får alltså spelet att ta in en exta input innan det startar igen då den vill vara på 0 för att starta om
        private void RestartGame()
        {
            score = 0;
            qNum = -1;
            i = 0;
            StartGame();
        }// Denna metod gör så att spelet fortsätter tills dess att alla frågor är besvarade.
         // Den startar om hela spelet automatiskt
         // den startar om spelet när qNum är större än questionnumbers.qount 
         // detta sker genom att den tar in ett extra svar efter att man svarat på alla frågor
         // om man svarat på alla frågor och svarar på ytterligare en startar spelet om
         //switch casen tar in ett värde från listan questionnumbers och tar då en fråga med 4 svarsalternativ
         //ans.tag är det som bestämmer vilket värde som är rätt då den ger värdet 1 
         //Bitmapimage hämtar in en bild från en länkad fil med olika bilder (png)
        private void NextQuestion()
        {
            if (qNum < questionNumbers.Count)
            {
                i = questionNumbers[qNum];
            }
            else
            {
                RestartGame();
            }
            foreach (var x in myCanvas.Children.OfType<Button>())
            {
                x.Tag = "0";
                x.Background = Brushes.DarkCyan;
            }
            switch (i)
            {
                case 1:
                    txtquestion.Text = "Question 1";
                    ans1.Content = answerAlternatives.item1;
                    ans2.Content = answerAlternatives.item6;
                    ans3.Content = answerAlternatives.item2;
                    ans4.Content = answerAlternatives.item5;
                    ans1.Tag = "1";
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/img1.jpg"));
                    break;
                case 2:
                    txtquestion.Text = "Question 2";
                    ans1.Content = answerAlternatives.item12;
                    ans2.Content = answerAlternatives.item5;
                    ans3.Content = answerAlternatives.item11;
                    ans4.Content = answerAlternatives.item2;
                    ans4.Tag = "1";
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/img2.jpg"));
                    break;
                case 3:
                    txtquestion.Text = "Question 3";
                    ans1.Content = answerAlternatives.item1;
                    ans2.Content = answerAlternatives.item6;
                    ans3.Content = answerAlternatives.item12;
                    ans4.Content = answerAlternatives.item2;
                    ans3.Tag = "1";
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/img3.jpg"));
                    break;
                case 4:
                    txtquestion.Text = "Question 4";
                    ans1.Content = answerAlternatives.item4;
                    ans2.Content = answerAlternatives.item5;
                    ans3.Content = answerAlternatives.item11;
                    ans4.Content = answerAlternatives.item9;
                    ans2.Tag = "1";
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/img4.jpg"));
                    break;
                case 5:
                    txtquestion.Text = "Question 5";
                    ans1.Content = answerAlternatives.item7;
                    ans2.Content = answerAlternatives.item6;
                    ans3.Content = answerAlternatives.item13;
                    ans4.Content = answerAlternatives.item11;
                    ans4.Tag = "1";
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/img5.jpg"));
                    break;
                case 6:
                    txtquestion.Text = "Question 6";
                    ans1.Content = answerAlternatives.item4;
                    ans2.Content = answerAlternatives.item8;
                    ans3.Content = answerAlternatives.item3;
                    ans4.Content = answerAlternatives.item11;
                    ans1.Tag = "1";
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/img6.jpg"));
                    break;
                case 7:
                    txtquestion.Text = "Question 7";
                    ans1.Content = answerAlternatives.item1;
                    ans2.Content = answerAlternatives.item7;
                    ans3.Content = answerAlternatives.item13;
                    ans4.Content = answerAlternatives.item10;
                    ans2.Tag = "1";
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/img7.jpg"));
                    break;
                case 8:
                    txtquestion.Text = "Question 8";
                    ans1.Content = answerAlternatives.item5;
                    ans2.Content = answerAlternatives.item13;
                    ans3.Content = answerAlternatives.item7;
                    ans4.Content = answerAlternatives.item3;
                    ans2.Tag = "1";
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/img8.jpg"));
                    break;
                case 9:
                    txtquestion.Text = "Question 9";
                    ans1.Content = answerAlternatives.item5;
                    ans2.Content = answerAlternatives.item8;
                    ans3.Content = answerAlternatives.item9;
                    ans4.Content = answerAlternatives.item11;
                    ans3.Tag = "1";
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/img9.jpg"));
                    break;
                case 10:
                    txtquestion.Text = "Question 10";
                    ans1.Content = answerAlternatives.item4;
                    ans2.Content = answerAlternatives.item10;
                    ans3.Content = answerAlternatives.item12;
                    ans4.Content = answerAlternatives.item3;
                    ans2.Tag = "1";
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/img10.jpg"));
                    break;
                case 11:
                    txtquestion.Text = "Question 11";
                    ans1.Content = answerAlternatives.item4;
                    ans2.Content = answerAlternatives.item8;
                    ans3.Content = answerAlternatives.item6;
                    ans4.Content = answerAlternatives.item11;
                    ans3.Tag = "1";
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/img11.jpg"));
                    break;
                case 12:
                    txtquestion.Text = "Question 12";
                    ans1.Content = answerAlternatives.item7;
                    ans2.Content = answerAlternatives.item4;
                    ans3.Content = answerAlternatives.item12;
                    ans4.Content = answerAlternatives.item3;
                    ans4.Tag = "1";
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/img12.jpg"));
                    break;
                case 13:
                    txtquestion.Text = "Question 13";
                    ans1.Content = answerAlternatives.item1;
                    ans2.Content = answerAlternatives.item6;
                    ans3.Content = answerAlternatives.item8;
                    ans4.Content = answerAlternatives.item12;
                    ans3.Tag = "1";
                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/img13.jpg"));
                    break;
            }
        }// En funktion som startar spelet 
        // den definerar questionNumbers som en randomiserad lista detta gör så att frågorna inte kommer i ordning 
        private void StartGame()
        {
            var randomList = questionNumbers.OrderBy(a => Guid.NewGuid()).ToList();
            questionNumbers = randomList;
            questionOrder.Content = null;
            for (int i = 0; i < questionNumbers.Count; i++)
            {
                questionOrder.Content += " " + questionNumbers[i].ToString();
            }
        }
    }
}
