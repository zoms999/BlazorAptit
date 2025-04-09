#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Syncfusion.Pdf.Parsing;
using BlazorAptit.Models;
using System.Collections.Generic;
using System;
using SkiaSharp;

namespace BlazorDemos.Data.FileFormats.PDF
{ 
    public class RearrangePagesService
    {
        List<UserReplyView> AptitReplys = new List<UserReplyView>();

		private readonly IWebHostEnvironment _hostingEnvironment;
        public RearrangePagesService(IWebHostEnvironment hostingEnvironment, List<UserReplyView>  aptitReply)
        {
            _hostingEnvironment = hostingEnvironment;
            AptitReplys = aptitReply;
        }
		
        /// <summary>
        /// Create a simple PDF document
        /// </summary>
        /// <returns>Return the created PDF document as stream</returns>
        public MemoryStream CreatePdfDocument()
        {
            //Read the file
            FileStream file = new FileStream(ResolveApplicationPath("한국진로적성센터_NEW.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Load the input PDF document
            PdfLoadedDocument ldoc = new PdfLoadedDocument(file);
            //PdfLoadedPage lpage1 = ldoc.Pages[0] as PdfLoadedPage;
            //PdfLoadedPage lpage2 = ldoc.Pages[1] as PdfLoadedPage;
            //Rearrange the page by index
            int[] numbers;
            // 13 15 4개  14 6개
            var result1 = AptitReplys.Find(x => x.AptitReplyID == 13);
            var result2 = AptitReplys.Find(x => x.AptitReplyID == 15);
            var result3 = AptitReplys.Find(x => x.AptitReplyID == 14);
          
            int default_Page = 3;

            if(result1 != null && result2 != null && result3 != null)
                numbers = new int[( AptitReplys.Count * 5 )+ default_Page - 1 ];
            else if (result1 != null && result2 != null  )
                numbers = new int[(AptitReplys.Count * 5) + default_Page - 2];
            else if (result1 != null && result3 != null)
                numbers = new int[(AptitReplys.Count * 5) + default_Page  ];
            else if (result2 != null && result3 != null)
                numbers = new int[(AptitReplys.Count * 5) + default_Page  ];

            else if (  result3 != null)
                numbers = new int[(AptitReplys.Count * 5) + default_Page  + 1 ];
            else if (result1 != null || result2 != null)
                numbers = new int[(AptitReplys.Count * 5) + default_Page - 1];
            else
                numbers = new int[(AptitReplys.Count * 5 ) + default_Page ];

            int j= 0;
            for(int i= 0 ; i < AptitReplys.Count  ; i ++)
            {
                if(i == 0)
                {
                     numbers[i] = 0;
                     numbers[i + 1] = 1;
                     numbers[i + 2] = 2;
                     j = 3;
                }
                if (AptitReplys[i].AptitReplyID == 1 )
                {
                     numbers[i+ j]     = 3;
                     numbers[i + 1+ j] = 4;
                     numbers[i + 2+ j] = 5;
                     numbers[i + 3+ j] = 6;
                     numbers[i + 4+ j] = 7;
                    j += 4; 
                }
                else if(AptitReplys[i].AptitReplyID == 2 )
                {
                    numbers[i+ j]     = 8;
                    numbers[i + 1+ j] = 9;
                    numbers[i + 2+ j] = 10;
                    numbers[i + 3+ j] = 11;
                    numbers[i + 4 + j] = 12;
                    j += 4; 
                }
                else if(AptitReplys[i].AptitReplyID == 3 )
                {
                    numbers[i + j ]    = 13;
                    numbers[i + 1 + j] = 14;
                    numbers[i + 2 + j] = 15;
                    numbers[i + 3 + j] = 16;
                    numbers[i + 4 + j] = 17;
                    j += 4; 
                }

                else if(AptitReplys[i].AptitReplyID == 4 )
                {
                    numbers[i+ j]     = 18;
                    numbers[i + 1+ j] = 19;
                    numbers[i + 2+ j] = 20;
                    numbers[i + 3+ j] = 21;
                    numbers[i + 4 + j] = 22;
                    j += 4; 
                }

                else if(AptitReplys[i].AptitReplyID == 5 )
                {
                    numbers[i+ j]     = 23;
                    numbers[i + 1+ j] = 24;
                    numbers[i + 2+ j] = 25;
                    numbers[i + 3+ j] = 26;
                    numbers[i + 4 + j] = 27;
                    j += 4; 
                }

                else if(AptitReplys[i].AptitReplyID == 6 )
                {
                    numbers[i+ j]     = 28;
                    numbers[i + 1+ j] = 29;
                    numbers[i + 2+ j] = 30;
                    numbers[i + 3+ j] = 31;
                    numbers[i + 4 + j] = 32;
                    j += 4; 
                }

                else if(AptitReplys[i].AptitReplyID == 7 )
                {
                    numbers[i+ j]     = 33;
                    numbers[i + 1+ j] = 34;
                    numbers[i + 2+ j] = 35;
                    numbers[i + 3+ j] = 36;
                    numbers[i + 4 + j] = 37;
                    j += 4; 
                }

                else  if(AptitReplys[i].AptitReplyID == 8 )
                {
                    numbers[i+ j]     = 38;
                    numbers[i + 1+ j] = 39;
                    numbers[i + 2+ j] = 40;
                    numbers[i + 3+ j] = 41;
                    numbers[i + 4 + j] = 42;
                    j += 4; 
                }

                else if(AptitReplys[i].AptitReplyID == 9 )
                {
                    numbers[i+ j]     = 43;
                    numbers[i + 1+ j] = 44;
                    numbers[i + 2+ j] = 45;
                    numbers[i + 3+ j] = 46;
                    numbers[i + 4 + j] = 47;
                    j += 4; 
                }

                else if(AptitReplys[i].AptitReplyID == 10 )
                {
                    numbers[i+ j]     = 48;
                    numbers[i + 1+ j] = 49;
                    numbers[i + 2+ j] = 50;
                    numbers[i + 3+ j] = 51;
                    numbers[i + 4 + j] = 52;
                    j += 4; 
                }

                else if(AptitReplys[i].AptitReplyID == 11 )
                {
                    numbers[i+ j]     = 53;
                    numbers[i + 1+ j] = 54;
                    numbers[i + 2+ j] = 55;
                    numbers[i + 3+ j] = 56;
                    numbers[i + 4 + j] = 57;
                    j += 4; 
                }

                else if(AptitReplys[i].AptitReplyID == 12 )
                {
                    numbers[i+ j]     = 58;
                    numbers[i + 1+ j] = 59;
                    numbers[i + 2+ j] = 60;
                    numbers[i + 3+ j] = 61;
                    numbers[i + 4 + j] = 62;
                    j += 4; 
                }

                else if(AptitReplys[i].AptitReplyID == 13 )
                {
                    numbers[i+ j]     = 63;
                    numbers[i + 1+ j] = 64;
                    numbers[i + 2+ j] = 65;
                    numbers[i + 3+ j] = 66;
                    j += 3; 
                }

                else if(AptitReplys[i].AptitReplyID == 14 )
                {
                    numbers[i+ j]     = 67;
                    numbers[i + 1+ j] = 68;
                    numbers[i + 2+ j] = 69;
                    numbers[i + 3+ j] = 70;
                    numbers[i + 4 + j] = 71;
                    numbers[i + 5 + j] = 72;
                    j += 5; 
                }

                else if(AptitReplys[i].AptitReplyID == 15 )
                {
                     numbers[i+ j]     = 73;
                     numbers[i + 1+ j] = 74;
                     numbers[i + 2+ j] = 75;
                     numbers[i + 3+ j] = 76;
                    j += 3; 
                }
               
            }
            ldoc.Pages.ReArrange(numbers);
            //ldoc.Pages.ReArrange(new int[] { i, , 2 });
            //ldoc.Pages.Add(pages);
            
            PdfLoadedPage page = ldoc.Pages[0] as PdfLoadedPage;
            PdfGraphics graphics = page.Graphics;

           Stream fontStream = new MemoryStream(File.ReadAllBytes("wwwroot/Font/NanumBarunGothicBold.ttf"));
            //FileStream fontStream = new FileStream("Arial.ttf", FileMode.Open, FileAccess.Read);

            PdfFont font = new PdfTrueTypeFont(fontStream, 30);
             PdfFont font2 = new PdfTrueTypeFont(fontStream, 20);
            PdfFont font3 = new PdfTrueTypeFont(fontStream, 15);

            graphics.DrawString(AptitReplys[0].User_Name, font, PdfBrushes.Black, new PointF(260, 640));


            PdfLoadedPage page2 = ldoc.Pages[2] as PdfLoadedPage;
            PdfGraphics graphics2 = page2.Graphics;

            graphics2.DrawString(AptitReplys[2].User_Name, font2, PdfBrushes.Black, new PointF(270, 393));

            int rowHeight = 0;
            int rowHeight2 = 0;
            int rowHeight3 = 0;
            foreach ( var item in AptitReplys)
            {
                if(item.RankNo == 1)
                {
                    graphics2.DrawString(item.TITLE, font3, PdfBrushes.Black, new PointF(130, 485 + rowHeight ));
                    rowHeight = rowHeight+ 25;
                }
                else if(item.RankNo == 2)
                {
                    graphics2.DrawString(item.TITLE, font3, PdfBrushes.Black, new PointF(275, 485 + rowHeight2 ));
                    rowHeight2 = rowHeight2+ 25;
                }
                else if(item.RankNo == 3)
                {
                    graphics2.DrawString(item.TITLE, font3, PdfBrushes.Black, new PointF(420, 485 + rowHeight3 ));
                    rowHeight3 = rowHeight3+ 25;
                }
            }
        

                MemoryStream ms = new MemoryStream();

            try
            {

                ms.Flush();
                ms.Position = 0;
                ldoc.Save(ms);
            

                //Save the PDF to the MemoryStream


                //If the position is not set to '0' then the PDF will be empty.


                //Close the PDF document.
                ldoc.Close(true);


            } catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Oh no! Something went wrong");
                Console.WriteLine(ex);
            }

            return ms;

        }

        public static MemoryStream Demo(string str)
        {
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(str));
            return memoryStream;
        }



        public MemoryStream CreatePdfDocument_Subject()
        {
            //Read the file
            FileStream file = new FileStream(ResolveApplicationPath("지면검사결과분석지_교과목.pdf"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Load the input PDF document
            PdfLoadedDocument ldoc = new PdfLoadedDocument(file);
            //PdfLoadedPage lpage1 = ldoc.Pages[0] as PdfLoadedPage;
            //PdfLoadedPage lpage2 = ldoc.Pages[1] as PdfLoadedPage;
            //Rearrange the page by index
             var result =  AptitReplys.FindAll(n => n.RankNo == 1);

            int[] numbers = new int[result.Count * 4 ];
            int j = 0;
            for (int i = 0; i < result.Count; i++)
            {
                
                if (result[i].AptitReplyID == 1)
                {
                    numbers[i + j] = 0;
                    numbers[i + 1 + j] = 1;
                    numbers[i + 2 + j] = 2;
                    numbers[i + 3 + j] = 3;
                    j += 3;
                }
                else if (result[i].AptitReplyID == 2)
                {
                    numbers[i + j] = 4;
                    numbers[i + 1 + j] = 5;
                    numbers[i + 2 + j] = 6;
                    numbers[i + 3 + j] = 7;
                    j += 3;
                }
                else if (result[i].AptitReplyID == 3)
                {
                    numbers[i + j] = 8;
                    numbers[i + 1 + j] = 9;
                    numbers[i + 2 + j] = 10;
                    numbers[i + 3 + j] = 11;
                    j += 3;
                }

                else if (result[i].AptitReplyID == 4)
                {
                    numbers[i + j] = 12;
                    numbers[i + 1 + j] = 13;
                    numbers[i + 2 + j] = 14;
                    numbers[i + 3 + j] = 15;
                    j += 3;
                }

                else if (result[i].AptitReplyID == 5)
                {
                    numbers[i + j] = 16;
                    numbers[i + 1 + j] = 17;
                    numbers[i + 2 + j] = 18;
                    numbers[i + 3 + j] = 19;
                    j += 3;
                }

                else if (result[i].AptitReplyID == 6)
                {
                    numbers[i + j] = 20;
                    numbers[i + 1 + j] = 21;
                    numbers[i + 2 + j] = 22;
                    numbers[i + 3 + j] = 23;
                    j += 3;
                }

                else if (result[i].AptitReplyID == 7)
                {
                    numbers[i + j] = 24;
                    numbers[i + 1 + j] = 25;
                    numbers[i + 2 + j] = 26;
                    numbers[i + 3 + j] = 27;
                    j += 3;
                }

                else if (result[i].AptitReplyID == 8)
                {
                    numbers[i + j] = 28;
                    numbers[i + 1 + j] = 29;
                    numbers[i + 2 + j] = 30;
                    numbers[i + 3 + j] = 31;
                    j += 3;
                }

                else if (result[i].AptitReplyID == 9)
                {
                    numbers[i + j] = 32;
                    numbers[i + 1 + j] = 33;
                    numbers[i + 2 + j] = 34;
                    numbers[i + 3 + j] = 35;
                    j += 3;
                }

                else if (result[i].AptitReplyID == 10)
                {
                    numbers[i + j] = 36;
                    numbers[i + 1 + j] = 37;
                    numbers[i + 2 + j] = 38;
                    numbers[i + 3 + j] = 39;
                    j += 3;
                }

                else if (result[i].AptitReplyID == 11)
                {
                    numbers[i + j] = 40;
                    numbers[i + 1 + j] = 41;
                    numbers[i + 2 + j] = 42;
                    numbers[i + 3 + j] = 43;
                    j += 3;
                }

                else if (result[i].AptitReplyID == 12)
                {
                    numbers[i + j] = 44;
                    numbers[i + 1 + j] = 45;
                    numbers[i + 2 + j] = 46;
                    numbers[i + 3 + j] = 47;
                    j += 3;
                }

                else if (result[i].AptitReplyID == 13)
                {
                    numbers[i + j] = 48;
                    numbers[i + 1 + j] = 49;
                    numbers[i + 2 + j] = 50;
                    numbers[i + 3 + j] = 51;
                    j += 3;
                }

                else if (result[i].AptitReplyID == 14)
                {
                    numbers[i + j] = 52;
                    numbers[i + 1 + j] = 53;
                    numbers[i + 2 + j] = 54;
                    numbers[i + 3 + j] = 55;
                    j += 3;
                }

                else if (result[i].AptitReplyID == 15)
                {
                    numbers[i + j] = 56;
                    numbers[i + 1 + j] = 57;
                    numbers[i + 2 + j] = 58;
                    numbers[i + 3 + j] = 59;
                    j += 3;
                }

            }
            ldoc.Pages.ReArrange(numbers);
            //ldoc.Pages.ReArrange(new int[] { i, , 2 });
            //ldoc.Pages.Add(pages);

            PdfLoadedPage page = ldoc.Pages[0] as PdfLoadedPage;
            PdfGraphics graphics = page.Graphics;

            Stream fontStream = new MemoryStream(File.ReadAllBytes("wwwroot/Font/NanumBarunGothicBold.ttf"));
            //FileStream fontStream = new FileStream("Arial.ttf", FileMode.Open, FileAccess.Read);

            //PdfFont font = new PdfTrueTypeFont(fontStream, 30);
            //PdfFont font2 = new PdfTrueTypeFont(fontStream, 15);

            //graphics.DrawString(AptitReplys[0].User_Name, font, PdfBrushes.Black, new PointF(235, 320));

            //int rowHeight = 0;
            //int rowHeight2 = 0;
            //int rowHeight3 = 0;
            //foreach (var item in AptitReplys)
            //{
            //    if (item.RankNo == 1)
            //    {
            //        graphics.DrawString(item.TITLE, font2, PdfBrushes.Black, new PointF(105, 620 + rowHeight));
            //        rowHeight = rowHeight + 25;
            //    }
            //    if (item.RankNo == 2)
            //    {
            //        graphics.DrawString(item.TITLE, font2, PdfBrushes.Black, new PointF(250, 620 + rowHeight2));
            //        rowHeight2 = rowHeight2 + 25;
            //    }
            //    if (item.RankNo == 3)
            //    {
            //        graphics.DrawString(item.TITLE, font2, PdfBrushes.Black, new PointF(390, 620 + rowHeight3));
            //        rowHeight3 = rowHeight3 + 25;
            //    }
            //}


            //Save the PDF to the MemoryStream
            MemoryStream ms = new MemoryStream();

            ldoc.Save(ms);

            //If the position is not set to '0' then the PDF will be empty.
            ms.Position = 0;

            //Close the PDF document.
            ldoc.Close(true);

            return ms;

        }



        #region HelperMethod
        private string ResolveApplicationPath(string fileName)
        {
            return _hostingEnvironment.WebRootPath + "//data//" + fileName;
        }
        #endregion
    }
}
