using System;
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
      Console.Write("Digite o caminha completo do arquivo: ");
      string path = Console.ReadLine();

      try
      {
        using (StreamReader reader = File.OpenText(path))
        {
          string s = reader.ReadToEnd();
          List<Post> list = JsonConvert.DeserializeObject<List<Post>>(s);
          foreach (Post post in list)
          {
            Console.WriteLine(post);
          }
        }
      }
      catch (IOException err)
      {
        Console.WriteLine("Um erro ocorreu: ");
        Console.WriteLine(err.Message);
      }
      catch (JsonSerializationException err)
      {
        Console.WriteLine("An error occurred");
        Console.WriteLine(err.Message);
      }
    }
  }
}

