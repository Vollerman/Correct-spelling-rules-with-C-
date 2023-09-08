using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string input = "bu       bir test metnidir.yürü, gez toz."; 
        string result = FormatSentence(input);
        Console.WriteLine(result);
        Console.ReadLine();
    }

    static string FormatSentence(string input)
    {
        StringBuilder formattedSentence = new StringBuilder(); 
        bool capitalizeNext = true;
        bool lastCharWasSpace = false; 

        foreach (char character in input)
        {
            if (char.IsLetterOrDigit(character)) 
            {
                if (lastCharWasSpace) // Eğer bir önceki karakter bir boşluk ise
                {
                    formattedSentence.Append(' '); 
                    lastCharWasSpace = false; 
                }

                formattedSentence.Append(capitalizeNext ? char.ToUpper(character) : character); // Karakteri büyük harfle ekle veya aynen bırak
                capitalizeNext = false; 
            }
            else if (char.IsPunctuation(character)) 
            {
                formattedSentence.Append(character); 

                if (character == '.' || character == '!' || character == '?') // Eğer nokta, ünlem veya soru işareti ise
                {
                    capitalizeNext = true; // Bir sonraki karakter büyük harfle başlayacak
                    lastCharWasSpace = true; // Noktalama işaretinden sonra otomatik olarak boşluk bırakılacak
                }
                else
                {
                    lastCharWasSpace = false; 
                }
            }
            else if (char.IsWhiteSpace(character)) // karakter bir boşluk ise
            {
                lastCharWasSpace = true; 
            }
            else // Karakter harf, rakam, noktalama veya boşluk değilse
            {
                formattedSentence.Append(character); 
            }
        }

        return formattedSentence.ToString(); 
    }
}
