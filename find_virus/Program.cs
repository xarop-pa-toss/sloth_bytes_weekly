// Scalable solution that uses LINQ to find and remove specific filenames, while ignoring filenames which include excluded charsets
using System;

string RemoveVirus(string filesIn)
{
    string files = filesIn.Replace("PC Files: ", "");
    if (files == null || files.Equals(filesIn))
    {
        throw new ArgumentException("File list does not start with 'PC Files: '");
    }

    List<string> wordsToDelete = ["virus", "malware"];
    List<string> excludedWords = ["anti", "not"];

    string newFiles = string.Join(", ",
        files
        .Split(", ")
        .Where(filename =>
            !(
                wordsToDelete.Any(w => filename.Contains(w, StringComparison.OrdinalIgnoreCase)) &&
                !excludedWords.Any(w => filename.Contains(w, StringComparison.OrdinalIgnoreCase))
            )
        )
    );

    return "PC Files: " +  newFiles;
}


Console.WriteLine(RemoveVirus("PC Files: spotifysetup.exe, virus.exe, dog.jpg"));
Console.WriteLine(RemoveVirus("PC Files: antivirus.exe, cat.pdf, lethalmalware.exe, dangerousvirus.exe "));
Console.WriteLine(RemoveVirus("PC Files: notvirus.exe, funnycat.gif"));