using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace veriYapi
{
    
    public partial class Form1 : Form
    {
        string baglantiCumlesi = "Server=DESKTOP-7VKKIA1\\SQLEXPRESS;Database=veriYapi;Trusted_Connection=True;";


        private int maxQuestion;
        private int currentQuestion=0;
        private int currentStep = 1;      // O anki aşama (1-6 arasında)
        private int currentWordId = 1;    // Şu anki kelimenin ID'si
        private int userId = 1; 
        private string correctAnswer;
        private int currentIndex = 0;
        private int currentWordIndex = 0;
        private List<WordModel> wordsToAsk = new List<WordModel>();


        public Form1(int gelenUserID,int wordCount)
        {
            InitializeComponent();
            this.maxQuestion = wordCount;
            this.userId = gelenUserID;
            LoadWordsToAsk();
            ShowNextQuestion();
        }

       


        private void LoadWordsToAsk()
        {
            lblIpucu.Text = "";
            if (currentQuestion >= maxQuestion)
            {
                MessageBox.Show("Sınav tamamlandı!");
                return;
            }
            wordsToAsk = new List<WordModel>();
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();

                string sorgu = "SELECT TOP 50 w.WordID, w.English, w.Turkish, w.Sentence, w.ImagePath, " +
                    "CAST(ISNULL(wp.Step1, 0) AS INT) + CAST(ISNULL(wp.Step2, 0) AS INT) + " +
                    "CAST(ISNULL(wp.Step3, 0) AS INT) + CAST(ISNULL(wp.Step4, 0) AS INT) + " +
                    "CAST(ISNULL(wp.Step5, 0) AS INT) + CAST(ISNULL(wp.Step6, 0) AS INT) AS StepCount, " +
                    "wp.LastAnsweredDate " +
                    "FROM Words w LEFT JOIN WordProgress wp ON w.WordID = wp.WordID AND wp.UserID = @UserID" +
                    " where wp.IsKnown=0";

                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@UserID", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                DateTime now = DateTime.Now;

                while (reader.Read())
                {
                    int step = Convert.ToInt32(reader["StepCount"]);
                    DateTime? lastAnsweredDate = reader["LastAnsweredDate"] == DBNull.Value
                        ? null
                        : (DateTime?)Convert.ToDateTime(reader["LastAnsweredDate"]);

                    bool shouldAsk = false;
                    switch (step)
                    {
                        case 0: shouldAsk = true; break;
                        case 1: shouldAsk = (lastAnsweredDate == null || now >= lastAnsweredDate.Value.AddDays(1)); break;
                        case 2: shouldAsk = (lastAnsweredDate == null || now >= lastAnsweredDate.Value.AddDays(7)); break;
                        case 3: shouldAsk = (lastAnsweredDate == null || now >= lastAnsweredDate.Value.AddMonths(1)); break;
                        case 4: shouldAsk = (lastAnsweredDate == null || now >= lastAnsweredDate.Value.AddMonths(3)); break;
                        case 5: shouldAsk = (lastAnsweredDate == null || now >= lastAnsweredDate.Value.AddMonths(6)); break;
                        case 6: shouldAsk = (lastAnsweredDate == null || now >= lastAnsweredDate.Value.AddMonths(12)); break;
                    }

                    if (shouldAsk)
                    {
                        wordsToAsk.Add(new WordModel
                        {
                            WordID = Convert.ToInt32(reader["WordID"]),
                            English = reader["English"].ToString(),
                            Turkish = reader["Turkish"].ToString(),
                            Sentence = reader["Sentence"].ToString(),
                            ImagePath = reader["ImagePath"].ToString(),
                            Step = step,
                            LastAnsweredDate = lastAnsweredDate
                        });
                    }
                }
            }
            currentQuestion++;

        }

        private void ShowCurrentWord()
        {
            if (currentWordIndex < wordsToAsk.Count)
            {
                var word = wordsToAsk[currentWordIndex];
                lblEng.Text = word.English;
                var options = GetRandomOptions(word.Turkish);
                radioButton1.Text = options[0];
                radioButton2.Text = options[1];
                radioButton3.Text = options[2];
                radioButton4.Text = options[3];

                radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;
            }
            else
            {
                MessageBox.Show("Tüm sorular tamamlandı! ✅");
            }
        }

        private string GetSelectedOption()
        {
            if (radioButton1.Checked) return radioButton1.Text;
            else if (radioButton2.Checked) return radioButton2.Text;
            else if (radioButton3.Checked) return radioButton3.Text;
            else if (radioButton4.Checked) return radioButton4.Text;
            else
            {
                MessageBox.Show("Lütfen bir seçenek seçin!");
            }
            return null;
        }



        private void ShowNextQuestion()
        {
            lblIpucu.Text = "";
            lblSonuc.Text = "";

            if (currentIndex >= wordsToAsk.Count)
            {
                MessageBox.Show("Tüm sorular tamamlandı!");
                this.Close();
                return;
            }

            

            var word = wordsToAsk[currentIndex];
            currentWordId = word.WordID;
            lblEng.Text = word.English;
            currentStep = word.Step+1;

            correctAnswer = word.Turkish;

            var options = GetRandomOptions(correctAnswer);
            var shuffled = options.OrderBy(x => Guid.NewGuid()).ToList();

            radioButton1.Text = shuffled[0];
            radioButton2.Text = shuffled[1];
            radioButton3.Text = shuffled[2];
            radioButton4.Text = shuffled[3];

            
            lblSonuc.Text = "";
            lblAdımBilgisi.Text = $"Adım: {currentStep}";
        }

        private void UpdateWordProgress(int userId, int wordId, int step, bool isCorrect)
        {
            using (SqlConnection conn = new SqlConnection(baglantiCumlesi))
            {
                conn.Open();

                if (isCorrect)
                {
                    // Doğru cevap: sadece ilgili step'i true yap
                    string updateQuery = $@"
                IF EXISTS (SELECT 1 FROM WordProgress WHERE UserID=@UserID AND WordID=@WordID)
                    UPDATE WordProgress
                    SET Step{step} = 1,
                        {(step == 6 ? "IsKnown = 1," : "")}
                        LastAnsweredDate = GETDATE()
                    WHERE UserID=@UserID AND WordID=@WordID
                ELSE
                    INSERT INTO WordProgress 
                        (UserID, WordID, Step1, Step2, Step3, Step4, Step5, Step6, IsKnown, LastAnsweredDate)
                    VALUES 
                        (@UserID, @WordID, 
                         {(step == 1 ? "1" : "0")},  
                         {(step == 2 ? "1" : "0")},  
                         {(step == 3 ? "1" : "0")},  
                         {(step == 4 ? "1" : "0")},  
                         {(step == 5 ? "1" : "0")},  
                         {(step == 6 ? "1" : "0")},  
                         {(step == 6 ? "1" : "0")},  
                         GETDATE())";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@WordID", wordId);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // Yanlış cevap: tüm adımları sıfırla, başa döndür
                    string resetQuery = @"
                IF EXISTS (SELECT 1 FROM WordProgress WHERE UserID=@UserID AND WordID=@WordID)
                    UPDATE WordProgress
                    SET Step1=0, Step2=0, Step3=0, Step4=0, Step5=0, Step6=0,
                        LastAnsweredDate = GETDATE(),
                        IsKnown = 0  -- yanlışsa öğrenilmedi sayılır
                    WHERE UserID=@UserID AND WordID=@WordID
                ELSE
                    INSERT INTO WordProgress 
                        (UserID, WordID, Step1, Step2, Step3, Step4, Step5, Step6, LastAnsweredDate, IsKnown)
                    VALUES 
                        (@UserID, @WordID, 0, 0, 0, 0, 0, 0, GETDATE(), 0)";

                    SqlCommand cmd = new SqlCommand(resetQuery, conn);
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@WordID", wordId);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadWordsToAsk();
            ShowCurrentWord();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            string userAnswer = GetSelectedOption();


            bool isAnswerCorrect = false;
            if (userAnswer.Trim().ToLower() == correctAnswer.ToLower())
                isAnswerCorrect = true;

            UpdateWordProgress(userId, currentWordId, currentStep, isAnswerCorrect);
            lblSonuc.Text = isAnswerCorrect ? "✔ Doğru!" : "✘ Yanlış";

            btnSubmit.Enabled = false;
            btnNext.Enabled = true;

        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            currentIndex++;
            ShowNextQuestion();
            btnSubmit.Enabled = true;
            btnNext.Enabled = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

        }

        



        private List<string> GetRandomOptions(string correctAnswer)
        {
            List<string> options = new List<string> { correctAnswer };

            // Veritabanından rastgele 3 yanlış seçenek
            List<string> wrongOptions = GetRandomWrongAnswers(correctAnswer, 3);
            options.AddRange(wrongOptions);

            return options.OrderBy(x => Guid.NewGuid()).ToList(); // karıştır
        }

        private List<string> GetRandomWrongAnswers(string correctAnswer, int count)
        {
            List<string> wrongAnswers = new List<string>();

            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                string sorgu = "SELECT TOP (@Count) Turkish FROM Words WHERE Turkish != @CorrectAnswer ORDER BY NEWID()";

                using (SqlCommand cmd = new SqlCommand(sorgu, baglanti))
                {
                    cmd.Parameters.AddWithValue("@CorrectAnswer", correctAnswer);
                    cmd.Parameters.AddWithValue("@Count", count);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            wrongAnswers.Add(reader["Turkish"].ToString());
                        }
                    }
                }
            }

            return wrongAnswers;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void btnIpucu_Click(object sender, EventArgs e)
        {
            string sentences = "";
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                baglanti.Open();
                string sorgu = "SELECT Sentence FROM Words WHERE WordID = @WordID";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@WordID", currentWordId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sentences = reader["Sentence"].ToString();
                }
                baglanti.Close();
            }
            lblIpucu.Text = sentences != "" ? sentences : "Bu kelimw için örnek cümle bulunamadı.";
        }
    }
}
