using System.IO;
using System.Xml.Linq;

namespace IntroToFunctionalProgrammingInCS
{
    internal class Demo6PointfreePipeAndComposition
    {
        public static void Run()
        {
            // =>"Terje Albert Kolderup"
            //Console.WriteLine(NameCaseImperative("tErjE AlbErt kOldErUp"));
            Console.WriteLine(NameCaseLinq("tErjE AlbErt kOldErUp"));
        }

        // v1 imperative 
        static string NameCaseImperative(string name)
        {
            var parts = name.Split(' ');
            var newName = "";
            foreach (var part in parts)
            {
                if (newName.Length > 0) newName += ' ';
                newName += char.ToUpper(part[0]) + part.Substring(1).ToLower();
            }
            return newName;
        }

        // v2 litt mer funksjonell
        static string NameCaseLinq(string name)
        {
            var newParts = name
                .Split(' ')
                .Select(part => {
                    var lower = part.ToLower();
                    return char.ToUpper(lower[0]) + lower.Substring(1);
                });
            return string.Join(' ', newParts);
        }

    //// v3 funksjonell
    //static string NameCase = 

        // point free and curried string functions
        static Func<char, Func<string,string[]>> Split = separator => text => text.Split(separator);
        static Func<string, string> FirstToUpper = s => char.ToUpper(s[0]) + s.Substring(1);
        static Func<string, string> ToLower = s => s.ToLower();


    }
}
