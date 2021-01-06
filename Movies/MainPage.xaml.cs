using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



namespace MoviesDataLayer.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //List<Blog> Blogs;
        //List<Post> Posts;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //using (var db = new MoviesContext())
            //{
            //    //AllPosts = db.Posts.ToList();
            //    Blogs = db.Blogs.ToList();
            //    BlogsList.ItemsSource = Blogs;
            //    Posts = db.Posts.ToList();
            //}
        }

        private void AddBlog_Click(object sender, RoutedEventArgs e)
        {
            //using (var db = new MoviesContext())
            //{
            //    var blog = new Blog { Url = NewBlogUrl.Text };
            //    db.Blogs.Add(blog);
            //    db.SaveChanges();

            //    //AllPosts = db.Posts.ToList();
            //    Blogs = db.Blogs.ToList();
            //    BlogsList.ItemsSource = Blogs;
            //}
        }


        private void BlogButton_Click(object sender, RoutedEventArgs e)
        {
            //Blog CurrentBlog;

            //string content = (sender is Button) ? (string)((Button)sender).Content : "";
            //if (content == "")
            //    return;
            //CurrentBlog = (Blog)BlogsList.SelectedItem;
            
            //switch (content)
            //{
            //    case "Update Selected Blog":
            //        CurrentBlog.Url = NewBlogUrl.Text;
            //        using (var db = new MoviesContext())
            //        {                       
            //            var res = db.Blogs.Update(CurrentBlog);

            //            int i = db.SaveChanges();

            //            Blogs = db.Blogs.ToList();
            //            BlogsList.ItemsSource = Blogs;
            //        }
            //        break;
            //    case "Delete Selected Blog":
            //        using (var db = new MoviesContext())
            //        {
            //            var res = db.Blogs.Remove(CurrentBlog);

            //            int i = db.SaveChanges();

            //            Blogs = db.Blogs.ToList();
            //            BlogsList.ItemsSource = Blogs;

            //            PostId.Text = "";
            //            NewPostTitle.Text = "";
            //            NewPostContent.Text = "";
            //            NewPostBlog.Text = "";
            //        }
            //        break;
            //}
        }

        private void AddPost_Click(object sender, RoutedEventArgs e)
        {
            //Blog CurrentBlog;
            //if (BlogsList.SelectedIndex != -1)
            //{
            //    CurrentBlog = (Blog)BlogsList.SelectedItem;
            //    using (var db = new MoviesContext())
            //    {
            //        var post = new Post
            //        {
            //            BlogId = CurrentBlog.BlogId,
            //            Title = NewPostTitle.Text,
            //            Content = NewPostContent.Text
            //        };

            //        var res = db.Posts.Add(post);
            //        if (res.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            //        {
            //            post = res.Entity;
            //        }

            //        int i = db.SaveChanges();

                    
            //        Posts = db.Posts.ToList();

            //        PostId.Text = post.PostId.ToString();

            //        //The next query is required so that FK Post reference works in subsequent line.
            //        Blogs = db.Blogs.ToList();
            //        NewPostBlog.Text = post.Blog.Url;
            //    }

            //}
        }

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            //string idStr = PostId.Text;
            //int id;

            //Post CurrentPost;

            //string content = (sender is Button) ? (string)((Button)sender).Content : "";
            //if (content == "")
            //    return;
            //switch (content)
            //{
            //    case "Prev Post":
            //        if (int.TryParse(idStr, out id))
            //        {
            //            id--;

            //            if (id > 0)
            //            {
            //                PostId.Text = id.ToString();

            //                using (var db = new MoviesContext())
            //                {
            //                    //Hint: Don't do next line ,otherwise need ** below is needed
            //                    //Posts = db.Posts.ToList();
            //                    CurrentPost = (from p in Posts where p.PostId == id select p).FirstOrDefault();
            //                    if (CurrentPost != null)
            //                    {
            //                        NewPostTitle.Text = CurrentPost.Title;
            //                        NewPostContent.Text = CurrentPost.Content;

            //                        // ** The next query is required so that FK Post reference works in subsequent line.
            //                        // ** Blogs = db.Blogs.ToList();
            //                        NewPostBlog.Text = CurrentPost.Blog.Url;
            //                    }
            //                    else
            //                    {
            //                        NewPostTitle.Text = "No Post";
            //                        NewPostContent.Text = "";
            //                        NewPostBlog.Text = "";
            //                    }
            //                }
            //            }
            //        }
            //        break;
            //    case "Next Post":
            //        if (int.TryParse(idStr, out id))
            //        {
            //            id++;
            //            PostId.Text = id.ToString();
            //            using (var db = new MoviesContext())
            //            {
            //                //Hint: Don't do next line ,otherwise need ** below is needed
            //                //Posts = db.Posts.ToList();
            //                CurrentPost = (from p in Posts where p.PostId == id select p).FirstOrDefault();
            //                if (CurrentPost != null)
            //                {
            //                    NewPostTitle.Text = CurrentPost.Title;
            //                    NewPostContent.Text = CurrentPost.Content;

            //                    // ** The next query is required so that FK Post reference works in subsequent line.
            //                    // ** Blogs = db.Blogs.ToList();
            //                    NewPostBlog.Text = CurrentPost.Blog.Url;
            //                }
            //                else
            //                {
            //                    NewPostTitle.Text = "No Post";
            //                    NewPostContent.Text = "";
            //                    NewPostBlog.Text = "";
            //                }
            //            }
            //        }
            //        break;
            //    case "Update Current Post":
            //        if (int.TryParse(idStr, out id))
            //        {
            //            if (id > 0)
            //                using (var db = new MoviesContext())
            //                {
            //                    CurrentPost = (from p in Posts where p.PostId == id select p).FirstOrDefault();
            //                    if (CurrentPost != null)
            //                    {
            //                        CurrentPost.Title = NewPostTitle.Text;
            //                        CurrentPost.Content = NewPostContent.Text;
            //                        var res = db.Posts.Update(CurrentPost);

            //                        int i = db.SaveChanges();

            //                        Posts = db.Posts.ToList();
            //                    }
            //                }

            //        }
            //        break;
            //    case "Delete Current Post":
            //        if (int.TryParse(idStr, out id))
            //        {

            //            if (id > 0)
            //                using (var db = new MoviesContext())
            //                {
            //                    CurrentPost = (from p in Posts where p.PostId == id select p).FirstOrDefault();
            //                    if (CurrentPost != null)
            //                    {

            //                        var res = db.Posts.Remove(CurrentPost);

            //                        int i = db.SaveChanges();

            //                        Blogs = db.Blogs.ToList();
            //                        BlogsList.ItemsSource = Blogs;

            //                        Posts = db.Posts.ToList();

            //                        PostId.Text = "";
            //                        NewPostTitle.Text = "";
            //                        NewPostContent.Text = "";
            //                        NewPostBlog.Text = "";
            //                    }
            //                }

            //        }
            //        break;
            //}
        }

        private void Blogs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (BlogsList.SelectedIndex != -1)
            //{

            //    using (var db = new MoviesContext())
            //    {
            //        Blog CurrentBlog = (Blog)BlogsList.SelectedItem;
            //        if (CurrentBlog != null)
            //        {
            //            if (CurrentBlog.Posts != null)
            //                if (CurrentBlog.Posts.Count != 0)
            //                {
            //                    Post Post = CurrentBlog.Posts.First();
            //                    PostId.Text = Post.PostId.ToString();
            //                    NewPostTitle.Text = Post.Title;
            //                    NewPostContent.Text = Post.Content;
            //                    NewPostBlog.Text = Post.Blog.Url;
            //                }
            //        }
            //    }
            //}
        }
    }
}