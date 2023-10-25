// Работа с файловой системой
using System.IO;
using System.Text;

// для работы с директориями
// создание директории
string path = "C:\\inetpub\\temp"; // экранирование слеша
path = @"C:\inetpub\temp"; // экранирование всех символов
// пути используются как абсолютные так и относительные
path = "temp\\123"; // относительно
string test = @"C:\Users\Student\source\repos\FileWork\FileWork\bin\Debug\net7.0";
//Environment.CurrentDirectory
Directory.CreateDirectory(path);

// проверка на существование директории
//if (Directory.Exists(path))
//    DoSmthg();
// удаление директории, второй аргумент это
// рекурсивное удаление - true, если в папке есть
// файлы и другие папки
//Directory.Delete(path, true);
// получить список директорий
var dirs = Directory.EnumerateDirectories(path);
// получить список файлов
var files = Directory.EnumerateFiles(path);
var filesArray = Directory.GetFiles(path);
// фильтрация файлов по заданному критерию
// SearchOption.AllDirectories поиск происходит
// во вложенных директориях
var search = Directory.GetFiles(Environment.CurrentDirectory, "*.*",
    SearchOption.AllDirectories);
/*
foreach (var file in search)
    Console.WriteLine(file);
*/
// класс с информацией о директории
var directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
Console.WriteLine(directoryInfo.Name);

// класс с информацией о файле
var fileInfo = new FileInfo("FileWork.dll");
// вывод длины в байтах
Console.WriteLine(fileInfo.Length);
Console.WriteLine(fileInfo.Name);// имя файла
Console.WriteLine(fileInfo.Extension);// расширение файла
Console.WriteLine(fileInfo.DirectoryName);// папка

// простые операции над файлом идут с помощью
// класса File
// перед такими операциями следует проверять 
// размер файла (и его существование)
byte[] file = File.ReadAllBytes("FileWork.dll");
if (File.Exists("file.txt"))// существует ли файл
{
    string[] lines = File.ReadAllLines("file.txt");
    string text = File.ReadAllText("file.txt");
}
File.WriteAllText("file.txt", "содержимое файла");
File.WriteAllLines("file2.txt", new string[] { 
"первая строка", "вторая строка"});
File.WriteAllBytes("file.bin", new byte[] { 1,2,3,4});

// операции с файлами с помощью стримов
// создание файла с получением дескриптора на файл
//FileStream fs = File.Create("file.bin");
// по окончанию работы дескриптор должен быть закрыт
//fs.Close(); // закрытие файла
//fs.Dispose(); // освобождение ресурсов

// вариант когда можно не писать Close и Dispose
/*using (FileStream fs = File.Create("file.bin"))
{ // блок тела using, по окончанию которого будут
  // автоматически вызваны методы Close и Dispose
  // для объекта fs
    fs.WriteByte(255); // запись числа 255
    string word = "шесть";
    var writeBytes = Encoding.UTF8.GetBytes(word);
    // записать в файл 10 байт
    fs.Write(writeBytes, 0, 10);
    // сдвиг текущего положения в файле на начало
    fs.Position = 0;
    fs.Seek(0, SeekOrigin.Begin);
    var byte1 = fs.ReadByte(); // прочесть один байт
    var bytes = new byte[10];
    // чтение 10 байт в массив bytes
    fs.Read(bytes, 0, bytes.Length);

    Console.WriteLine(byte1);
    foreach (var b in bytes)
        Console.WriteLine(b);
    Console.WriteLine(Encoding.UTF8.GetString(bytes));
}*/


using (FileStream fs = File.Create("file.bin"))
using (BinaryReader br = new BinaryReader(fs))
using (BinaryWriter bw = new BinaryWriter(fs))
{
    /*int i = 15000000;
    byte[] array = BitConverter.GetBytes(i);
    fs.Write(array, 0, array.Length);
    
    bw.Write(i);
    i = br.ReadInt32();
    */
    bw.Write((byte)200);
    bw.Write("пять");
    fs.Position = 0;
    Console.WriteLine(br.ReadByte());
    Console.WriteLine(br.ReadString());
}