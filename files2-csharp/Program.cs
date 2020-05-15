using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

using course.Entities;

namespace course
{
  class Program
  {
    static void Main(string[] args)
    {
      DateTime moment1 = DateTime.ParseExact("21/06/2019 13:05:44", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
      string title1 = "Viajando com a familia";
      string content1 = "Indo viajar com essa família linda";

      Comment comment1 = new Comment("Familia Linda!");
      Comment comment2 = new Comment("Que delícia, aproveitem por nós!");

      Post post1 = new Post(moment1, title1, content1, 23);
      post1.AddComments(comment1, comment2);

      DateTime moment2 = DateTime.ParseExact("25/04/2020 14:35:12", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
      string title2 = "Medo do Coronga";
      string content2 = "Morrendo de medo do corona vírus #FiqueEmCasa!";

      Comment comment3 = new Comment("Ta complicado essa situação...");
      Comment comment4 = new Comment("Se deus quiser as coisas vão melhorar!");

      Post post2 = new Post(moment2, title2, content2, 30);
      post2.AddComments(comment3, comment4);

      List<Post> posts = new List<Post>() { post1, post2 };

      Console.Write("Escreva o caminho completo do arquivo: ");
      string path = Console.ReadLine();

      try
      {
        using (StreamWriter writer = File.CreateText(path))
        {
          string s = JsonConvert.SerializeObject(posts, Formatting.Indented);
          writer.WriteLine(s);
          Console.WriteLine("Finalizado!");
        }
      }
      catch (IOException err)
      {
        Console.Write("Um erro ocorreu: ");
        Console.WriteLine(err.Message);
      }
    }
  }
}

