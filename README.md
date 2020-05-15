# Trabalhando com Arquivos :file_cabinet:

Neste repositório se encontra alguns exercícios utilizados no aprendizado de como se trabalhar com arquivos na linguagem C#.

Durante o módulo foram aprendidos os conceitos de:

#### File, FileInfo e IOException

Essas 3 opções realizam operações com arquivos (create, copy, delete, move, open, etc) e ajuda na criação de objetos `FileStream`

- **File**
  Métodos estáticos para a criação, cópia, exclusão, deslocamento e abertura de um arquivo (simples, mas realiza verificação de segurança para cada operação)
    > https://docs.microsoft.com/en-us/dotnet/api/system.io.file?redirectedfrom=MSDN&view=netcore-3.1

- **FileInfo**
  Propriedades e métodos de instância para a criação, cópia, exclusão, deslocamento e abertura de arquivos
    > https://docs.microsoft.com/en-us/dotnet/api/system.io.fileinfo?redirectedfrom=MSDN&view=netcore-3.1

- **IOException**
  A exceção que é gerada quando ocorre um erro de E/S

  
  - System.IO.DirectoryNotFoundException
  - System.IO.DriveNotFoundException
  - System.IO.EndOfStreamException
  - System.IO.FileLoadException
  - System.IO.FileNotFoundException
  - System.IO.PathTooLongException
  - System.IO.PipeException

#### FileStream e StreamReader

- **FileStream**
  Fornece um Stream para um arquivo, dando suporte a operações de leitura e gravação síncronas e assíncronas.
<br>

- **StreamReader**
  Implementa um TextReader que lê caracteres de um fluxo de bytes em uma codificação específica (Ex. FileStream).

#### Bloco Using

Fornece uma sintaxe conveniente que garante o uso correto de objetos IDisposable, garantindo que eles serão fechados ao final da execução.

Objetos IDisposable **NÃO** são gerenciados pelo CLR. Eles precisam ser
manualmente fechados.
> Exemplos: Font, FileStream, StreamReader, StreamWriter

```csharp
// Demo 1
string path = @"c:\temp\file1.txt";

try {
  using (FileStream fs = new FileStream(path, FileMode.Open)) {
    using (StreamReader sr = new StreamReader(fs)) {
      string line = sr.ReadLine();
      Console.WriteLine(line);
    }
  }
}
catch (IOException e) {
  Console.WriteLine("An error occurred");
  Console.WriteLine(e.Message);
}
```
```csharp
// Demo 2
string path = @"c:\temp\file1.txt";

try {
  using (StreamReader sr = File.OpenText(path)) {
    while (!sr.EndOfStream) {
      string line = sr.ReadLine();
      Console.WriteLine(line);
    }
  }
}
catch (IOException e) {
  Console.WriteLine("An error occurred");
  Console.WriteLine(e.Message);
}
```

#### StreamWriter

É uma stream capaz de escrever caracteres a partir de uma stream binária (ex: FileStream).

Suporte a dados no formato de texto.

#### Directory e DirectoryInfo

- **Directory**
Expõe métodos estáticos para criar, mover e enumerar em diretórios e subdiretórios. Essa classe não pode ser herdada. (Faz uma verificação de segurança a cada operação)
<br>

- **DirectoryInfo**
Expõe métodos de instância para criar, mover e enumerar em diretórios e subdiretórios. Essa classe não pode ser herdada.

#### Path

Executa operações em instâncias de String que contêm informações de caminho de arquivo ou diretório.
<!-- - FileStream e StreamReader
- Bloco Using
- StreamWriter
- Directory e DirectoryInfo
- Path -->
