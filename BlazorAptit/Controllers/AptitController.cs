using BlazorAptit.Data;
using BlazorAptit.Models;
using BlazorAptit.Models.Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace BlazorAptit.Controllers
{
    public class AptitController : Controller
    {
        private readonly SchoolContext _context;

        private  IAptitRepository _repository { get;set;}

        public AptitController(SchoolContext context, IAptitRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult Result()
        {
            return View();
        }

        public IActionResult MainLogin()
        {
            return View();
        }

        public ActionResult StartPage(string Group_ID , string Group_Name, string Group_City)
        {
            ViewBag.Group_ID = Group_ID;
            ViewBag.Group_Name = Group_Name;
            ViewBag.Group_City = Group_City;
            return View();
        }

        public ActionResult StartPage2(string Group_ID, string Group_Name, string Group_City)
        {
            ViewBag.Group_ID = Group_ID;
            ViewBag.Group_Name = Group_Name;
            ViewBag.Group_City = Group_City;
            return View();
        }

        [HttpPost, ActionName("MainLogin")]
        [ValidateAntiForgeryToken]  
        public ActionResult MainLogin(AptitGroupView objUser)   
        {  
            if (ModelState.IsValid)   
            {  
                var obj = _context.AptitGroups.Where(a => a.Group_ID.Equals(objUser.Group_ID) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                if (obj != null)
                {
                    DateTime T1 = new DateTime();
                    T1 = DateTime.Now;

                    DateTime T2 = new DateTime();
                    T2 = Convert.ToDateTime(obj.StartDate);

                    DateTime T3 = new DateTime();
                    T3 = Convert.ToDateTime(obj.EndDate);

                    DateTime DT1 = DateTime.Parse(T1.ToShortDateString());
                    DateTime START_DT= DateTime.Parse(T2.ToShortDateString());
                    DateTime END_DT= DateTime.Parse(T3.ToShortDateString());


                    int result = DateTime.Compare(DT1,END_DT);

                    int result2 = DateTime.Compare(DT1,START_DT);

                    if(result > 0 )
                    {
                         ViewBag.Message = "계약기간이 만료되었습니다.";
                         return View(objUser); 
                    }
                    if( result2 < 0 )
                    {
                         ViewBag.Message = "계약일이 아닙니다.";
                         return View(objUser); 
                    }
                    //Session["GroupID"] = obj.Group_ID.ToString();
                    HttpContext.Session.SetString("AptitGroupID_KEY",  obj.Group_ID.ToString());
                    HttpContext.Session.SetString("AptitGroupName_KEY", obj.Group_Name.ToString());
                    HttpContext.Session.SetString("AptitGroupCity_KEY", obj.Group_City.ToString());
                    //return RedirectToAction("UserDashBoard");
                    //return RedirectToAction("StartPage", "Aptit", new { Group_ID = obj.Group_ID ,Group_Name = obj.Group_Name, Group_City = obj.Group_City  });
                    return RedirectToAction("StartPage2", "Aptit", new { Group_ID = obj.Group_ID, Group_Name = obj.Group_Name, Group_City = obj.Group_City });
                }
            }  
            ViewBag.Message = "아이디 또는 비밀번호를 확인해주세요.";
            return View(objUser);  
        }  

        public ActionResult Create(string Group_ID, string Group_Name, string Group_City)
        {
            ViewBag.Group_ID = HttpContext.Session.GetString("AptitGroupID_KEY");
            ViewBag.Group_Name = HttpContext.Session.GetString("AptitGroupName_KEY");
            ViewBag.Group_City = HttpContext.Session.GetString("AptitGroupCity_KEY");
            return View();
        }

        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] AptitUserView model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var aptitanswer = _context.AptitAnswers.FirstOrDefault(m => m.AptitUsers.User_Email == model.User_Email && m.AptitUsers.User_Password == model.User_Password);

                if (aptitanswer == null)
                {
                    return BadRequest();
                }
                //var uri = Url.Link("LoginUser",aptitanswer);
                //var uri = Url.Link((nameof(Pages2), new { ID = aptitanswer.Stage });
                //return Created(uri, aptitanswer); // 201 Created
                //return Ok(aptitanswer);

                HttpContext.Session.SetInt32("AptitUserID_KEY", aptitanswer.AptitUserID);
                return CreatedAtAction(nameof(Pages2), new { id = aptitanswer.Stage }, aptitanswer);

            }
            catch (Exception ex)
            {
                //_logger.LogError(e.Message);
                return BadRequest();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AptitUser model)
        {
            if (ModelState.IsValid)
            {
                model.AptitAnswers.Add(new AptitAnswer()
                {
                    AptitUserID = model.ID,
                    Stage = 1
                });
                
                string Group_ID = HttpContext.Session.GetString("AptitGroupID_KEY");
                var group =  _context.AptitGroups.FirstOrDefault(x => x.Group_ID == Group_ID );

               
                if(group != null)
                {
                    if (group.CompletCount == group.RegCount )
                    {
                        ViewBag.Message = "신청인원이 마감되었습니다.";
                        return View(model);
                    }

                     group.CompletCount  = group.CompletCount + 1;
                     _context.AptitGroups.Update(group);

                    try
                    {
                        var useremail = _context.AptitUsers.FirstOrDefault(x => x.User_Email == model.User_Email);

                        if(useremail != null)
                        {
                            ViewBag.Message = "이미 등록된 이메일주소입니다.";
                            return View(model);
                            
                        }

                        model.Created = DateTime.Now;
                        _context.AptitUsers.Add(model);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        ViewBag.Message = "이미 등록된 이메일주소입니다.";
                        return View(model);
                    }

                    HttpContext.Session.SetInt32("AptitUserID_KEY", model.ID);
                    return RedirectToAction(nameof(Pages2));
                }
                else
                {
                    return View(model);
                }

            }

            return View(model);
        }

       

        public async Task<IActionResult> Pages2(AptitAnswer model)
        {
            model.AptitUserID = (int)HttpContext.Session.GetInt32("AptitUserID_KEY");
            var aptitanswer = await _context.AptitAnswers.AsNoTracking().FirstOrDefaultAsync(m => m.AptitUserID == model.AptitUserID);

            QuestionSetting(aptitanswer.Stage == 0 ? 1 : aptitanswer.Stage);
            AnswerSetting(aptitanswer.Stage);
            decimal maxData =15;
            ViewBag.Image= "/img/"+aptitanswer.Stage+"/";
            ViewBag.Percent = Convert.ToInt32( aptitanswer.Stage  / maxData * 100 );
            if(aptitanswer.Stage > 15 )
                return RedirectToAction(nameof(Result));

            return View(aptitanswer);
        }

        public async Task<IActionResult> Pages()
        {
            var questions = await _context.AptitQuestions.Where(m => m.ID == 1).ToListAsync();

            //var IEnumerable<aptitgr>
            //QuestionSetting();
            

            if (questions == null)
            {
                return NotFound();
            }
            var aptitanswer = await _context.AptitAnswers.AsNoTracking().FirstOrDefaultAsync(m => m.AptitUserID == 25);
            return View(aptitanswer);
        }

        private void AnswerSetting(int stage)
        {
            AptitQuestion aptitQuestion = new AptitQuestion();

            List<QuizItem> aptitQuestions = quizs;


            ViewData["answer"] = aptitQuestions;
            ViewData["answer2"] = quizs2;

            if(stage == 1 || stage == 2  )
            {
                ViewData["answer3"] = 문항1_2_19답;
                ViewData["answer4"] = 문항1_2_20답;
            }
            if(stage == 3 )
            {
                ViewData["answer3"] = 문항3_19답;
                ViewData["answer4"] = 문항3_20답;
            }
            if(stage == 4 || stage == 5 || stage == 6 || stage == 7  || stage == 8 )
            {
                ViewData["answer3"] = 문항4_19답;
                ViewData["answer4"] = 문항4_20답;
            }
            if(stage == 9  || stage == 11  )
            {
                //매우중요하다
                ViewData["answer3"] = 문항9_19답;
                ViewData["answer4"] = 문항9_20답;
            }
             if(stage == 10 )
            {
                ViewData["answer3"] = 문항10_19답;
                ViewData["answer4"] = 문항10_20답;
            }
            if(stage == 12 )
            {
                ViewData["answer3"] = 문항12_19답;
                ViewData["answer4"] = 문항12_20답;
            }
            if(stage == 13 )
            {
                ViewData["answer3"] = 문항13_19답;
                ViewData["answer4"] = 문항13_20답;
            }
              if(stage == 14 )
            {
                ViewData["answer3"] = 문항14_19답;
                ViewData["answer4"] = 문항14_20답;
            }

                  if(stage == 15 )
            {
                ViewData["answer3"] = 문항15_19답;
                ViewData["answer4"] = 문항15_20답;
            }


            
            
        }

        public List<QuizItem> quizs = new List<QuizItem> {
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 그렇다", "그렇다", "약간 그렇다", "별로 그렇지 않다", "그렇지 않다", "매우 그렇지 않다" },
                    AnswerIndex = 1,
                    Score = 3
                },
           
        };

        public List<QuizItem> quizs2 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 좋다", "좋다", "약간 좋다", "약간 싫다", "싫다", "매우 싫다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };
        public List<QuizItem> 문항1_2_19답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 좋아했다", "좋아했다", "약간 좋아했다", "약간 싫어했다", "싫어했다", "매우 싫어했다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };
        public List<QuizItem> 문항1_2_20답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 좋을 것이다", "좋을 것이다", "약간 좋을 것이다", "약간 싫을 것이다", "싫을 것이다", "매우 싫을 것이다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };


         public List<QuizItem> 문항3_19답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 화가난다", "화가난다", "약간 화가난다", "별로 화가 나지 않는다", "화가 나지 않는다", "전혀 화가 나지 않는다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };
        public List<QuizItem> 문항3_20답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 좋을 것이다", "좋을 것이다", "약간 좋을 것이다", "약간 싫을 것이다", "싫을 것이다", "매우 싫을 것이다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };

        public List<QuizItem> 문항4_19답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 동의한다", "동의한다", "약간 동의한다", "별로 동의하지 않는다", "동의하지 않는다", "전혀 동의하지 않는다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };
        public List<QuizItem> 문항4_20답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 좋을 것이다", "좋을 것이다", "약간 좋을 것이다", "약간 싫을 것이다", "싫을 것이다", "매우 싫을 것이다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };


        public List<QuizItem> 문항9_19답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 중요하다", "중요하다", "약간 중요하다", "별로 중요하지 않다", "중요하지 않다", "전혀 중요하지 않다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };
        public List<QuizItem> 문항9_20답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 좋을 것이다", "좋을 것이다", "약간 좋을 것이다", "약간 싫을 것이다", "싫을 것이다", "매우 싫을 것이다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };


        public List<QuizItem> 문항12_19답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 편하다", "편하다", "약간 편하다", "약간 불편하다", "불편하다", "매우 불편하다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };
        public List<QuizItem> 문항12_20답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 좋을 것이다", "좋을 것이다", "약간 좋을 것이다", "약간 싫을 것이다", "싫을 것이다", "매우 싫을 것이다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };

        public List<QuizItem> 문항10_19답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 잘 견딘다", "잘 견딘다", "약간 견딘다", "별로 견디지 못한다", "견디지 못한다", "매우 견디지 못한다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };
        public List<QuizItem> 문항10_20답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 좋을 것이다", "좋을 것이다", "약간 좋을 것이다", "약간 싫을 것이다", "싫을 것이다", "매우 싫을 것이다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };

         public List<QuizItem> 문항14_19답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 좋다", "좋다", "약간 좋다", "별로 좋지 않다", "좋지 않다", "매우 좋지 않다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };
         public List<QuizItem> 문항14_20답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 좋을 것이다", "좋을 것이다", "약간 좋을 것이다", "약간 싫을 것이다", "싫을 것이다", "매우 싫을 것이다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };


        public List<QuizItem> 문항13_19답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "가장 추구한다", "추구한다", "약간 추구한다", "별로 추구하지 않는다", "추구하지 않는다", "전혀 추구하지 않는다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };
        public List<QuizItem> 문항13_20답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 좋을 것이다", "좋을 것이다", "약간 좋을 것이다", "약간 싫을 것이다", "싫을 것이다", "매우 싫을 것이다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };


           public List<QuizItem> 문항15_19답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 많다", "많다", "약간 많다", "별로 없다", "없다", "전혀 없다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };
        public List<QuizItem> 문항15_20답 = new List<QuizItem> {
            
            new QuizItem
                {
                    Question = "Which of the following is the name of a Leonardo da Vinci's masterpiece?",
                    Choices = new List<string> { "매우 좋을 것이다", "좋을 것이다", "약간 좋을 것이다", "약간 싫을 것이다", "싫을 것이다", "매우 싫을 것이다" },
                    AnswerIndex = 1,
                    Score = 3
                }
        };



        private void QuestionSetting(int stage )
        {
            List<AptitQuestion> quest = (from d in _context.AptitQuestions where d.ID == stage  
                                         orderby d.ID
                                              select new AptitQuestion()
                                              {
                                                  ID = d.ID,
                                                  QUE_1 = d.QUE_1,
                                                  QUE_2 = d.QUE_2,
                                                  QUE_3 = d.QUE_3,
                                                  QUE_4 = d.QUE_4,
                                                  QUE_5 = d.QUE_5,
                                                  QUE_6 = d.QUE_6,
                                                  QUE_7 = d.QUE_7,
                                                  QUE_8 = d.QUE_8,
                                                  QUE_9 = d.QUE_9,
                                                  QUE_10 = d.QUE_10,
                                                  QUE_11 = d.QUE_11,
                                                  QUE_12 = d.QUE_12,
                                                  QUE_13 = d.QUE_13,
                                                  QUE_14 = d.QUE_14,
                                                  QUE_15 = d.QUE_15,
                                                  QUE_16 = d.QUE_16,
                                                  QUE_17 = d.QUE_17,
                                                  QUE_18 = d.QUE_18,
                                                  QUE_19 = d.QUE_19,
                                                  QUE_20 = d.QUE_20
                                              }).ToList();

            ViewBag.quest = quest;
        }

        #region 
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AptitAnswer model)
        {
            
            int score = 0;
            foreach (PropertyInfo pinfo in model.GetType().GetProperties())
            {
                if (pinfo.Name.Contains("AQ"))
                {
                    object value = pinfo.GetValue(model, null);
                    score += (int)value;
                }
                
            }



            
                AptitUserQue aptituserque = new AptitUserQue();
                aptituserque.AptitUserID = model.AptitUserID;
                aptituserque.AptitQuestionID = model.Stage;
                aptituserque.AQ_1 = model.AQ_1;
                aptituserque.AQ_2 = model.AQ_2;
                aptituserque.AQ_3 = model.AQ_3;
                aptituserque.AQ_4 = model.AQ_4;
                aptituserque.AQ_5 = model.AQ_5;
                aptituserque.AQ_6 = model.AQ_6;
                aptituserque.AQ_7 = model.AQ_7;
                aptituserque.AQ_8 = model.AQ_8;
                aptituserque.AQ_9 = model.AQ_9;
                aptituserque.AQ_10 = model.AQ_10;
                aptituserque.AQ_11 = model.AQ_11;
                aptituserque.AQ_12 = model.AQ_12;
                aptituserque.AQ_13 = model.AQ_13;
                aptituserque.AQ_14 = model.AQ_14;
                aptituserque.AQ_15 = model.AQ_15;
                aptituserque.AQ_16 = model.AQ_16;
                aptituserque.AQ_17 = model.AQ_17;
                aptituserque.AQ_18 = model.AQ_18;
                aptituserque.AQ_19 = model.AQ_19;
                aptituserque.AQ_20 = model.AQ_20;
                aptituserque.Stage_Score = score;
                aptituserque.Created = DateTime.Now;
                _context.AptitUserQue.Add(aptituserque);
                await _context.SaveChangesAsync();

            

            PropertyInfo fieldPropertyInfo = model.GetType().GetProperties()
        .FirstOrDefault(f => f.Name.ToUpper() == $"AQ_{model.Stage}");
            fieldPropertyInfo.SetValue(model, score, null);

            var aptitAnswer = await _context.AptitAnswers.FirstOrDefaultAsync(m => m.AptitUserID == model.AptitUserID);

            switch (model.Stage)
            {
                case 1:
                    
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_1 );
                    aptitAnswer.AQ_1 = score;
                    break;
                case 2:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_2);
                    aptitAnswer.AQ_2 = score;
                    break;
                case 3:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_3);
                    aptitAnswer.AQ_3 = score;
                    break;
                case 4:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_4);
                    aptitAnswer.AQ_4 = score;
                    break;
                case 5:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_5);
                    aptitAnswer.AQ_5 = score;
                    break;
                case 6:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_6);
                    aptitAnswer.AQ_6 = score;
                    break;
                case 7:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_7);
                    aptitAnswer.AQ_7 = score;
                    break;
                case 8:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_8);
                    aptitAnswer.AQ_8 = score;
                    break;
                case 9:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_9);
                    aptitAnswer.AQ_9 = score;
                    break;
                case 10:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_10);
                    aptitAnswer.AQ_10 = score;
                    break;
                 case 11:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_11);
                    aptitAnswer.AQ_11 = score;
                    break;
                case 12:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_12);
                    aptitAnswer.AQ_12 = score;
                    break;
                case 13:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_13);
                    aptitAnswer.AQ_13 = score;
                    break;
                case 14:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_14);
                    aptitAnswer.AQ_14 = score;
                    break;
                case 15:
                    await TryUpdateModelAsync<AptitAnswer>(aptitAnswer, "", s => s.AQ_15);
                    aptitAnswer.AQ_15 = score;
                    break;
                
            }

            if (ModelState.IsValid)
            {
                aptitAnswer.Stage = aptitAnswer.Stage + 1;
                aptitAnswer.Created = DateTime.Now;
                aptitAnswer.Updated = DateTime.Now;
                //_context.Update(model);
                await _context.SaveChangesAsync();
                if(aptitAnswer.Stage == 16)
                    _repository.SetUserRankInsert(model.AptitUserID);

                return RedirectToAction(nameof(Pages2));
            }

            return View(model);
        }
        #endregion



    }
}
