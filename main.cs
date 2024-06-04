using System; 
using System.Collections.Generic;

public class Program {
  public static string password;
  public static int currentLength = 1;
  public static bool isFound = false;
  public static DateTime startTime;

  public static void BroadcastFound(string password) {
    isFound = true;
    DateTime currentTime = DateTime.Now;
    Console.WriteLine("Password found!\nThe password you entered is " + password + "\nThis program took " + (currentTime - startTime).ToString() + " to finish.");
  }
  
  public static void GeneratePasswords(List<string> letters, string sequence) {
    foreach (string letter in letters) {
      string newSequence = sequence + letter;

      if (newSequence == password) {
        BroadcastFound(newSequence);
        break;
      } else if (newSequence.Length < currentLength) {
        GeneratePasswords(letters, newSequence);
      }
    }
  }
  
  public static void Loop(List<string> letters) {
    while (!isFound) {
      foreach (string letter in letters) {
        GeneratePasswords(letters, letter);
      }
      if (!isFound) {
        currentLength++;
        Console.WriteLine("Password not found. Length: " + currentLength.ToString());
      }
    }
  }
  
  public static void Main(string[] args) {
    Console.WriteLine("Password Guesser\nDirections:\nThe password must be lowercase and must only contain letters in the range of A-Z. The password will then be guessed through the use of algorithms.\n--------------------------------");
    Console.WriteLine("Write a password below:");
    password = Console.ReadLine().ToLower();
    startTime = DateTime.Now;
    Console.WriteLine("Attempting to crack password.. Please wait, this may take some time!");
    
    Loop(new List<string> {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"});
  }
}
