using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebNumeric.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Result()
        {
            return View();
        }
        public ActionResult Review()
        {
            return View();
        }
        public ActionResult Matrix()
        {
            return View();
        }
        public ActionResult Study()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Matrix(DateTime? Date)
        {
            if (Date != null)
            {
                try
                {
                    var nr8 = Calculation.Calculate.GetRow1(Date);
                    string s = nr8.n1.ToString() + nr8.n2.ToString() + nr8.n3.ToString() + nr8.n4.ToString() + nr8.n5.ToString() + nr8.n6.ToString() + nr8.n7.ToString() + nr8.n8.ToString();

                    int numOfFate= Calculation.Calculate.GetSum(Convert.ToInt32(s)); ;
                    while (numOfFate>14)
                    {
                        if (numOfFate==22 || numOfFate==33)
                        {
                            break;
                        }
                        numOfFate = Calculation.Calculate.GetSum(Convert.ToInt32(numOfFate.ToString()));
                    }
                    
                    //ViewBag.Error = numOfFate.ToString();
                    //return View("~/Views/Home/MatrixError.cshtml");
                    int LC = Calculation.Calculate.GetLC1(Date);
                    int firstNum = nr8.n1 + nr8.n2 + nr8.n3 + nr8.n4 + nr8.n5 + nr8.n6 + nr8.n7 + nr8.n8;
                    int secondNum = Calculation.Calculate.GetSum(firstNum);
                    int cnt;
                    if (nr8.n1 != 0)
                        cnt = 2 * nr8.n1;
                    else
                        cnt = 2 * nr8.n2;
                    int thirdNum = firstNum - cnt;
                    thirdNum = thirdNum < 0 ? 0 : thirdNum;
                    int fourthNum = Calculation.Calculate.GetSum(thirdNum);
                    int addingNum;
                    if (Date.Value.Year > 1999)
                    {
                        addingNum = Date.Value.Year - Date.Value.Day - Date.Value.Month - firstNum - secondNum - thirdNum - fourthNum;
                    }
                    else
                        addingNum = 0;

                    addingNum = 0;
                    var d = Calculation.Calculate.GetSequenceForm(Convert.ToInt32(s), firstNum, secondNum, thirdNum, fourthNum, addingNum);
                    var d2 = Calculation.Calculate.GetSequencecalc(Convert.ToInt32(s), firstNum, secondNum, thirdNum, fourthNum, addingNum);

                    string SecSkill1 = Calculation.Calculate.GetNumSecSkill(d2[3], d2[5], d2[7]);
                    string SecSkill2 = Calculation.Calculate.GetNumSecSkill(d2[1], d2[4], d2[7]);
                    string SecSkill3 = Calculation.Calculate.GetNumSecSkill(d2[2], d2[5], d2[8]);
                    string SecSkill4 = Calculation.Calculate.GetNumSecSkill(d2[3], d2[6], d2[9]);
                    string SecSkill5 = Calculation.Calculate.GetNumSecSkill(d2[1], d2[2], d2[3]);
                    string SecSkill6 = Calculation.Calculate.GetNumSecSkill(d2[4], d2[5], d2[6]);
                    string SecSkill7 = Calculation.Calculate.GetNumSecSkill(d2[7], d2[8], d2[9]);
                    string SecSkill8 = Calculation.Calculate.GetNumSecSkill(d2[1], d2[5], d2[9]);

                    #region Формирование сумки на форму
                    ViewBag.date = Date.Value.ToShortDateString();
                    ViewBag.fateNum = numOfFate;
                    ViewBag.lifeCode = LC;

                    ViewBag.firstNum = firstNum;
                    ViewBag.secondNum = secondNum;
                    ViewBag.thirdNum = thirdNum;
                    ViewBag.fourthNum = fourthNum;

                    ViewBag.in1Ch = d[1] == "" ? "Нет" : d[1];
                    ViewBag.in2En = d[2] == "" ? "Нет" : d[2];
                    ViewBag.in3In = d[3] == "" ? "Нет" : d[3];
                    ViewBag.in4Zd = d[4] == "" ? "Нет" : d[4];
                    ViewBag.in5Lo = d[5] == "" ? "Нет" : d[5];
                    ViewBag.in6Tr = d[6] == "" ? "Нет" : d[6];
                    ViewBag.in7Ud = d[7] == "" ? "Нет" : d[7];
                    ViewBag.in8Do = d[8] == "" ? "Нет" : d[8];
                    ViewBag.in9Pa = d[9] == "" ? "Нет" : d[9];

                    ViewBag.ex1Te = SecSkill1;
                    ViewBag.ex2Ce = SecSkill2;
                    ViewBag.ex3Se = SecSkill3;
                    ViewBag.ex4St = SecSkill4;
                    ViewBag.ex5Sa = SecSkill5;
                    ViewBag.ex6Bi = SecSkill6;
                    ViewBag.ex7Ta = SecSkill7;
                    ViewBag.ex8Du = SecSkill8;

                    string st = "";

                    if (SecSkill3 == "нет")
                        SecSkill3 = "0";

                    switch (Convert.ToInt32(SecSkill3))
                    {
                        case int n when (n < 3):
                            st = "У вас низкая инициативность, вы ждете, что ситуация решится сама собой и ждете действий от окружения или партнера, это очень снижает ваши денежные потоки, для исправления данной ситуации, запишитесь на консультацию ";
                            break;
                        case int n when (n == 3):
                            st = "Вы отталкиваете от себя гармоничные отношения, пытаясь их всячески разорвать. Сомнения и подозрения по любому поводу, ревность, желание оттолкнуть партнёра, для исправления данной ситуации, запишитесь на консультацию";
                            break;
                        case int n when (n == 4):
                            st = " У вас программа «создания отношений», стремление находиться в группе/семье/обществе, за более подробной информацией, запишитесь на консультацию";
                            break;
                        case int n when (n > 4):
                            st = "У вас сильно высокие требования к семье и своему партнеру, перфекционизм во всем, придирчивость и требовательность, для исправления данной ситуации, запишитесь на консультацию";
                            break;
                    }

                    ViewBag.st = st;

                    #endregion

                    return View("~/Views/Home/MatrixResult.cshtml");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View("~/Views/Home/MatrixError.cshtml");
                }
            }
            else
            {
                return View("~/Views/Home/MatrixError.cshtml");
            }



        }
        public ActionResult MatrixResult()
        {
            return View();
        }

    }
}