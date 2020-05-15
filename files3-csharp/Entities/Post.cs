using System;
using System.Text;
using System.Collections.Generic;

namespace course.Entities
{
  public class Post
  {
    public DateTime Moment { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Likes { get; set; }
    public List<Comment> Comments { get; set; }

    public Post(DateTime moment, string title, string content, int likes)
    {
      Moment = moment;
      Title = title;
      Content = content;
      Likes = likes;
      Comments = new List<Comment>();
    }

    public void AddComments(params Comment[] comments)
    {
        foreach (Comment comment in comments)
        {
            Comments.Add(comment);
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine(Title);
        stringBuilder.AppendLine(Likes + " Likes - " + Moment);
        stringBuilder.AppendLine(Content);
        stringBuilder.AppendLine("Comments: ");
        foreach (Comment comment in Comments)
        {
            stringBuilder.AppendLine(comment.ToString());
        }

        return stringBuilder.ToString();
    }
  }
}