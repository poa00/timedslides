﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PetjeOp
{
    //De MasterController wordt altijd meegegeven, gebruik is bijv. alsvolgt:
    //Question q = masterController.DB.GetQuestion(id);
    public class Database
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public void Query()
        {
            Console.WriteLine(GetQuestion(0).Description);
        }

        public MultipleChoiceQuestion GetQuestion(int id)
        {
            tblQuestion query = db.tblQuestions.SingleOrDefault(q => q.id == id);

            if (query!=null){                
                MultipleChoiceQuestion question = new MultipleChoiceQuestion(query.description);
                return question;
            }
            return null;          
        }

        /*public Questionnaire GetQuestionnaire(int id)
        {           
            tblQuestionnaire query = db.tblQuestionnaires.SingleOrDefault(q => q.id == id);

            if (query!=null){
                Questionnaire questionnaire = new Questionnaire(query.description);
                foreach(tblLinkQuestion question in query.tblLinkQuestions.ToList())
                {
                    questionnaire.addQuestion(new MultipleChoiceQuestion(question.tblQuestion.question));
                }
                return questionnaire;
            }
            return null;     
        }*/

        public void UpdateQuestionnaire(Questionnaire questionnaire)
        {
            tblQuestionnaire updateQuestionnaire = db.tblQuestionnaires.SingleOrDefault(q => q.id == questionnaire.ID);         // Haalt questionnaire op uit DB
            updateQuestionnaire.description = questionnaire.Name;                                                                      // Wijzigt naam van questionnaire in DB

            /*foreach (tblLinkQuestion dbQuestion in updateQuestionnaire.tblLinkQuestions.ToList())                                            // Doorloopt lijst van bijbehorende questions uit DB
            {
                MultipleChoiceQuestion question = (MultipleChoiceQuestion)questionnaire.Questions.Select(q => q.ID == dbQuestion.questionnr);// Haalt Question op uit Questionnaire                 
                dbQuestion.tblQuestion.question = question.Description;                                                                      // Wijzigt de vraag in DB
                
                foreach(tblLinkAnswer dbLinkAnwser in dbQuestion.tblQuestion.tblLinkAnswers.ToList())                                        // Doorloopt lijst van bijbehorende answers uit DB
                {                                                                       
                    Answer answer = (Answer)question.AnswerOptions.Select(a => a.ID == dbLinkAnwser.answernr);                               // Haalt Answer op uit Question
                    dbLinkAnwser.tblAnswer.answer = answer.Description;                                                                      // Wijzigt het antwoord in DB
                }
                dbQuestion.tblQuestion.correctanswernr = question.CorrectAnswer.ID;                                                          // Wijzigt het correcte antwoord in DB
            }*/
            db.SubmitChanges();                                                                                                              // Waar alle Magic happens, alle bovenstaande wijzigingen worden doorgevoerd in de DB            
        }

        public Student GetStudent(String code)
        {
            Student person = (from tblStudent in db.tblStudents
                               where tblStudent.nr == code
                               select new Student
                               {
                                   StudentNr = tblStudent.nr,
                                   FirstName = tblStudent.firstname,
                                   SurName = tblStudent.surname,
                                   GroupNr = tblStudent.@class

                               }).FirstOrDefault();

            if (person!=null){
                return person; // Returnt, uit database opgehaalde, Student.
            }
            return null;  
        }
        public Teacher GetTeacher(String code) // Returnt een Teacher als deze bestaat, anders NULL.
        {
            Teacher person = (from tblTeacher in db.tblTeachers
                              where tblTeacher.nr == code
                              select new Teacher
                              {
                                  TeacherNr = tblTeacher.nr,
                                  FirstName = tblTeacher.firstname,
                                  SurName = tblTeacher.surname

                              }).FirstOrDefault();

            if (person != null)
            {
                return person; // Returnt, uit database opgehaalde, Teacher.
            }
            return null;
        }

        public bool QuestionnaireExists(string name) {
            tblQuestionnaire foundQuestionnaire = (from questionnaire in db.tblQuestionnaires
                                                    where questionnaire.description.ToString().Equals(name)
                                                    select questionnaire).FirstOrDefault();

            if(foundQuestionnaire != null) {
                return true;
            }
            return false;
        }

        public Questionnaire AddQuestionnaire(Questionnaire questionnaire) { 
            tblQuestionnaire tblQuestionnaire = new tblQuestionnaire();
            tblQuestionnaire.author = "eltjo1";
            tblQuestionnaire.description = questionnaire.Name;
            tblQuestionnaire.subject = 1; // test data
            db.tblQuestionnaires.InsertOnSubmit(tblQuestionnaire);
            db.SubmitChanges();

            questionnaire.ID = tblQuestionnaire.id;

            //Loop door alle vragen heen
            foreach (MultipleChoiceQuestion q in questionnaire.Questions) {
                //Loop door alle antwoorden heen
                foreach (Answer answer in q.AnswerOptions) {
                    Answer ans = GetAnswer(answer.Description);
                    if (ans == null) {
                        ans = AddAnswer(answer.Description.ToString());
                    }

                    if (q.CorrectAnswer == answer) {
                        q.CorrectAnswer = ans;
                    }

                    // Synchroniseer onze offline answer met primary key van DB
                    answer.ID = ans.ID;
                }

                MultipleChoiceQuestion dbQuestion = AddMultipleChoiceQuestion(q, questionnaire.ID);
                // Synchroniseer onze offline dbQuestion met primary key van DB
                q.ID = dbQuestion.ID;

                // Nu kunnen we er door heen loopen aangezien we nu een ID hebben van Question
                foreach (Answer answer in q.AnswerOptions) {
                    LinkAnswerToQuestion(q, answer);
                }
            }

            return questionnaire;
        }

        public Answer GetAnswer(string answer) {
            tblAnswer foundAnswer =   (from answers in db.tblAnswers
                                where answers.description.ToString().Equals(answer)
                                select answers).FirstOrDefault();

            if(foundAnswer != null) {
                Console.WriteLine("Found answer: " + foundAnswer.description.ToString());

                Answer retrievedAnswer = new Answer(foundAnswer.description);
                retrievedAnswer.ID = foundAnswer.id;

                return retrievedAnswer;
            }
            return null;
        }

        public Answer AddAnswer(string receivedAnswer) {
            tblAnswer answer = new tblAnswer();
            //answer.id = new Random().Next(100, 1000); // AI maken!!
            answer.description = receivedAnswer;

            db.tblAnswers.InsertOnSubmit(answer);
            db.SubmitChanges();

            return new Answer(answer.description) {
                ID = answer.id
            };
        }

        public void DeleteMultipleChoiceQuestion(MultipleChoiceQuestion question) {
            // Eerst moeten we de link verwijderen om referentiele integriteit te behouden
            List<tblAnsweroption> referencedAnswerOption = (from ao in db.tblAnsweroptions
                                                            where ao.question == question.ID
                                                            select ao).ToList();

            foreach(tblAnsweroption answerOption in referencedAnswerOption) {
                Console.WriteLine("Removing AnswerOption ID: " + answerOption.question);
                DeleteLinkAnswerToQuestion(answerOption.question);
            }

            Console.WriteLine("Question ID: " + question.ID);
            tblQuestion selectedQuestion = (from q in db.tblQuestions
                                            where q.id == question.ID
                                            select q).FirstOrDefault();

            if(selectedQuestion != null) {
                db.tblQuestions.DeleteOnSubmit(selectedQuestion);
                db.SubmitChanges();
            }
            else {
                Console.WriteLine("wtf, null record?");
            }
        }

        public MultipleChoiceQuestion AddMultipleChoiceQuestion(MultipleChoiceQuestion createdQuestion, int questionnaireId) {
            tblQuestion question = new tblQuestion();
            //question.id = new Random().Next(100, 1000); // AI maken!!
            question.description = createdQuestion.Description;
            question.correctanswer = createdQuestion.CorrectAnswer.ID;
            question.questionnaire = questionnaireId;
            question.questionindex = createdQuestion.QuestionIndex;

            if (createdQuestion.TimeRestriction != TimeSpan.Zero)
            {
                question.timerestriction = createdQuestion.TimeRestriction.Ticks;
            }

            db.tblQuestions.InsertOnSubmit(question);
            db.SubmitChanges();

            return new MultipleChoiceQuestion(question.description) {
                ID = question.id,
                Description = question.description,
                CorrectAnswer = createdQuestion.CorrectAnswer,
                AnswerOptions = createdQuestion.AnswerOptions,
                QuestionIndex = createdQuestion.QuestionIndex,
                TimeRestriction = createdQuestion.TimeRestriction
            };
        }

        public void LinkAnswerToQuestion(MultipleChoiceQuestion refQuestion, Answer refAnswer) {
            // Dit moet zo, omdat we geen PI hebben in answeroption, LINQ vindt dat niet leuk
            db.ExecuteCommand("INSERT INTO [answeroption] (question, answer) VALUES ({0}, {1})", refQuestion.ID, refAnswer.ID);
        }

        private void DeleteLinkAnswerToQuestion(int questionId) {
            // Dit moet zo, omdat we geen PI hebben in answeroption, LINQ vindt dat niet leuk
            db.ExecuteCommand("DELETE FROM [answeroption] WHERE question = {0}", questionId);
        }

        public List<Questionnaire> GetAllQuestionnaires() {
            List<Questionnaire> questionnaires = new List<Questionnaire>();

            // Loop door alle questionnaires
            foreach(tblQuestionnaire tblQuestionnaire in db.tblQuestionnaires) {
                Questionnaire questionnaire = new Questionnaire(tblQuestionnaire.description);
                questionnaire.ID = tblQuestionnaire.id;

                // Loop door alle questions binnen die questionnaire
                foreach(tblQuestion tblQuestion in tblQuestionnaire.tblQuestions) {
                    MultipleChoiceQuestion question = new MultipleChoiceQuestion(tblQuestion.description);

                    // Maak een nieuwe answer object aan voor onze correct answer
                    Answer correctAnswer = new Answer(tblQuestion.tblAnswer.description);
                    correctAnswer.ID = tblQuestion.tblAnswer.id;

                    question.CorrectAnswer = correctAnswer;
                    question.ID = tblQuestion.id;
                    question.QuestionIndex = tblQuestion.questionindex;

                    // Haal alle answeroptions op die bij deze vraag horen
                    List<tblAnsweroption> tblAnswerOption = (from answer in db.tblAnsweroptions
                                               where answer.question == question.ID
                                               select answer).ToList();

                    List<Answer> answerOptions = new List<Answer>();

                    foreach(tblAnsweroption answerOption in tblAnswerOption) {
                        // Doordat we data hebben van onze answeroption, kunnen we nu ook de gehele vraag halen
                        tblAnswer tblAnswer = (from foundAnswer in db.tblAnswers
                                               where foundAnswer.id == answerOption.answer
                                               select foundAnswer).FirstOrDefault();

                        Answer answer = new Answer(tblAnswer.description);
                        answer.ID = tblAnswer.id;
                        answerOptions.Add(answer);
                    }

                    // Voeg answeroptions (die desalniettemin volledige Answer objecten zijn) toe
                    question.AnswerOptions = answerOptions;

                    // Voeg vragen toe aan onze questionnaire
                    questionnaire.Questions.Add(question);
                }
                // Voeg questionnaire toe aan onze lijst met questionnaire
                questionnaires.Add(questionnaire);
            }

            return questionnaires;
        }

        public List<Exam> GetExams()
        {
            List<Exam> exams = new List<Exam>();

            foreach(tblExam tblExam in db.tblExams)
            {
                Exam exam = new Exam();
                exam.Examnr = tblExam.id;

                exams.Add(exam);
                Console.WriteLine(exams);
                }
                return exams;
            
        }
    }
}
