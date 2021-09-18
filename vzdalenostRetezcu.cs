// Editační vzálenost mezi dvěma znakovými řetězci je definována jako nejmenší počet znakových operací, které je třeba vykonat k převedení jednoho řetězce na druhý.
// Povolené znakové operace jsou:

// vložení znaku
// smazání znaku
// nahrazení jednoho znaku jiným znakem
// Spočítejte editační vzdálenost dvou zadaných řetězců.

// Vstup:
// Standardní vstup obsahuje dva řetězce, každý na jednom řádku.

// Výstup:
// Na standardní výstup vypište jedno celé číslo - editační vzdálenost zadaných řetězců.

// Příklad 1:
// Vstup:

// Hello World
// Hallo xWorld
// Výstup:

// 2
// Poznámka: Druhý řetězec získáme z prvního, jestliže znak 'e' nahradíme znakem 'a' a vložíme znak 'x'.

// Příklad 2:
// Vstup:

// pivo
// laska
// Výstup:

// 5
// Poznámka: Provedeme 4 operace nahrazení znaku a jedno vložení znaku.

using System;

class Program {
    static public void Main() {
        string s = Console.ReadLine();
        string p = Console.ReadLine();
        Console.WriteLine(Levenshtein(s, p));
    }

    public static int Levenshtein(string s, string p){
        var matrix = new int[s.Length + 1, p.Length + 1];
        if (s.Length == 0) return p.Length;
        if (p.Length == 0) return s.Length;
        for (var i = 0; i <= s.Length; i++) { matrix[i, 0] = i; }
        for (var j = 0; j <= p.Length; j++) { matrix[0, j] = j; }
        for (var i = 1; i <= s.Length; i++) {
            for (var j = 1; j <= p.Length; j++) {
                var cost = (p[j - 1] == s[i - 1]) ? 0 : 1;
                matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1), matrix[i - 1, j - 1] + cost);
            }
        }
        return matrix[s.Length, p.Length];
    }
}
