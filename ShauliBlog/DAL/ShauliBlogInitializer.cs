using ShauliBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ShauliBlog.DAL
{
    public class ShauliBlogInitializer : DropCreateDatabaseIfModelChanges<ShauliBlogContext>
    {
        protected override void Seed(ShauliBlogContext context)
        {
            var managers = new List<Manager>
            {
                new Manager {UserName="Dor" , Password="123"}
            };
            managers.ForEach(s => context.Managers.Add(s));
            context.SaveChanges();

            var fans = new List<Fan>
            {
            new Fan{FirstName="Carson",LastName="Alexander",BirthDate=DateTime.Parse("2005-09-01"), Seniority=1, SexType=Sex.Male},
            new Fan{FirstName="Meredith",LastName="Alonso",BirthDate=DateTime.Parse("2002-09-01"), Seniority=2, SexType=Sex.Female},
            new Fan{FirstName="Arturo",LastName="Anand",BirthDate=DateTime.Parse("2003-09-01"), Seniority=3, SexType=Sex.Male},
            new Fan{FirstName="Gytis",LastName="Barzdukas",BirthDate=DateTime.Parse("2002-09-01"), Seniority=4, SexType=Sex.Female},
            new Fan{FirstName="Yan",LastName="Li",BirthDate=DateTime.Parse("2002-09-01"), Seniority=3, SexType=Sex.Male},
            new Fan{FirstName="Peggy",LastName="Justice",BirthDate=DateTime.Parse("2001-09-01"), Seniority=2, SexType=Sex.Female},
            new Fan{FirstName="Laura",LastName="Norman",BirthDate=DateTime.Parse("2003-09-01"), Seniority=1, SexType=Sex.Female},
            new Fan{FirstName="Nino",LastName="Olivetto",BirthDate=DateTime.Parse("2005-09-01"), Seniority=10, SexType=Sex.Male}
            };
            fans.ForEach(s => context.Fans.Add(s));
            context.SaveChanges();

            var posts = new List<Post>
            {
                new Post{ID=1, Title="This is the title of a blog post",Author="Mads Kjaer" ,
                    Content="Lorem ipsum dolor sit amet, tellus eu orci lacus blandit. Cras enim nibh, sodales ultricies elementum vel, fermentum id tellus. Proin metus odio, ultricies eu pharetra dictum, laoreet id odio. Curabitur in odio augue. Morbi congue auctor interdum. Phasellus sit amet metus justo. Phasellus vitae tellus orci, at elementum ipsum. In in quam eget diam adipiscing condimentum. Maecenas gravida diam vitae nisi convallis vulputate quis sit amet nibh. Nullam ut velit tortor. Curabitur ut elit id nisl volutpat consectetur ac ac lorem. Quisque non elit et elit lacinia lobortis nec a velit. Sed ac nisl sed enim consequat porttitor",
                Image="~/Content/images/flower.png", Video="~/Content/images/shauli.m4v", Website="https://www.Mads-Kjaer.com", PostDate=new DateTime(2009,6,29)}
            };
            posts.ForEach(s => context.Posts.Add(s));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment{Title="George Washington Comment", Author = "George Washington",
                    PostID=1,Content="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut.",
                    Website="https://www.GeorgeWashington.com"},
                new Comment{Title="Benjamin Franklin Comment", Author = "Benjamin Franklin",
                    PostID=1,Content="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut.",
                    Website="https://www.BenjaminFranklin.com"},
                new Comment{Title="Barack Obama Comment", Author = "Barack Obama",
                    PostID=1,Content="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut.",
                    Website="https://www.BarackObama.com"}
            };
            comments.ForEach(s => context.Comments.Add(s));
            context.SaveChanges();
        }
    }
}