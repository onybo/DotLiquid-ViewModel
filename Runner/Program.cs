using DotLiquid;
using DotLiquid.ViewModel;
using ViewModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var show = GetTvShow();

            LiquidFunctions.RegisterViewModel(typeof(Show));

            var template = Template.Parse(
                                new StreamReader("EmailTemplate.html")
                                                .ReadToEnd());
            var result = template.RenderViewModel(show);
        }

        private static Show GetTvShow()
        {
            return new Show
            {
                Name = "Fear the walking dead",
                Cast = new List<Actor>{
                    new Actor
                    {
                        FirstName = "Mercedes",
                        LastName = "Mason",
                        Born = new DateTime(1982, 3, 3)
                    },
                    new Actor
                    {
                        FirstName = "Rubén",
                        LastName = "Blades",
                        Born = new DateTime(1948, 7, 16)
                    }
                }
            };
        }
    }
}
