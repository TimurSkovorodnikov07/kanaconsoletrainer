public static class Program
{
    private static readonly Dictionary<string, string> _hiraganaDictionary = new Dictionary<string, string>
    {
        { "あ", "a" }, { "い", "i" }, { "う", "u" }, { "え", "e" }, { "お", "o" },
        { "か", "ka" }, { "き", "ki" }, { "く", "ku" }, { "け", "ke" }, { "こ", "ko" },
        { "さ", "sa" }, { "し", "shi" }, { "す", "su" }, { "せ", "se" }, { "そ", "so" },
        { "た", "ta" }, { "ち", "chi" }, { "つ", "tsu" }, { "て", "te" }, { "と", "to" },
        { "な", "na" }, { "に", "ni" }, { "ぬ", "nu" }, { "ね", "ne" }, { "の", "no" },
        { "は", "ha" }, { "ひ", "hi" }, { "ふ", "fu" }, { "へ", "he" }, { "ほ", "ho" },
        { "ま", "ma" }, { "み", "mi" }, { "む", "mu" }, { "め", "me" }, { "も", "mo" },
        { "や", "ya" }, { "ゆ", "yu" }, { "よ", "yo" },
        { "ら", "ra" }, { "り", "ri" }, { "る", "ru" }, { "れ", "re" }, { "ろ", "ro" },
        { "わ", "wa" }, { "を", "wo" }, { "ん", "n" },
        { "が", "ga" }, { "ぎ", "gi" }, { "ぐ", "gu" }, { "げ", "ge" }, { "ご", "go" },
        { "ざ", "za" }, { "じ", "ji" }, { "ず", "zu" }, { "ぜ", "ze" }, { "ぞ", "zo" },
        { "だ", "da" }, { "ぢ", "ji" }, { "づ", "dzu" }, { "で", "de" }, { "ど", "do" },
        { "ば", "ba" }, { "び", "bi" }, { "ぶ", "bu" }, { "べ", "be" }, { "ぼ", "bo" },
        { "ぱ", "pa" }, { "ぴ", "pi" }, { "ぷ", "pu" }, { "ぺ", "pe" }, { "ぽ", "po" }
    };

    private static readonly Dictionary<string, string> _katakanaDictionary = new Dictionary<string, string>
    {
        { "ア", "a" }, { "イ", "i" }, { "ウ", "u" }, { "エ", "e" }, { "オ", "o" },
        { "カ", "ka" }, { "キ", "ki" }, { "ク", "ku" }, { "ケ", "ke" }, { "コ", "ko" },
        { "サ", "sa" }, { "シ", "shi" }, { "ス", "su" }, { "セ", "se" }, { "ソ", "so" },
        { "タ", "ta" }, { "チ", "chi" }, { "ツ", "tsu" }, { "テ", "te" }, { "ト", "to" },
        { "ナ", "na" }, { "ニ", "ni" }, { "ヌ", "nu" }, { "ネ", "ne" }, { "ノ", "no" },
        { "ハ", "ha" }, { "ヒ", "hi" }, { "フ", "fu" }, { "ヘ", "he" }, { "ホ", "ho" },
        { "マ", "ma" }, { "ミ", "mi" }, { "ム", "mu" }, { "メ", "me" }, { "モ", "mo" },
        { "ヤ", "ya" }, { "ユ", "yu" }, { "ヨ", "yo" },
        { "ラ", "ra" }, { "リ", "ri" }, { "ル", "ru" }, { "レ", "re" }, { "ロ", "ro" },
        { "ワ", "wa" }, { "ヲ", "wo" }, { "ン", "n" },
        { "ガ", "ga" }, { "ギ", "gi" }, { "グ", "gu" }, { "ゲ", "ge" }, { "ゴ", "go" },
        { "ザ", "za" }, { "ジ", "ji" }, { "ズ", "zu" }, { "ゼ", "ze" }, { "ゾ", "zo" },
        { "ダ", "da" }, { "ヂ", "ji" }, { "ヅ", "dzu" }, { "デ", "de" }, { "ド", "do" },
        { "バ", "ba" }, { "ビ", "bi" }, { "ブ", "bu" }, { "ベ", "be" }, { "ボ", "bo" },
        { "パ", "pa" }, { "ピ", "pi" }, { "プ", "pu" }, { "ペ", "pe" }, { "ポ", "po" }
    };

    private enum Alphabet
    {
        None,
        Hiragana,
        Katakana
    }

    private static Alphabet _currentAlphabet = Alphabet.None;

    public static void Main(string[] args)
    {
        Write("仮名 console  trainer");
        Write("To change the alphabet use the command: 'change'");
        Thread.Sleep(3000);
        Console.Clear();
        ChooseAlphabet();
        Console.Clear();

        while (true)
        {
            var randomLetter = GetRangomLetter();
            Write($"{randomLetter.Key}\n", ConsoleColor.Cyan);

            var letter = Console.ReadLine();

            if (letter == randomLetter.Value)
                Write("GREAT!!!", ConsoleColor.Green, true);
            else if (letter == "change")
                ChooseAlphabet();
            else if (letter == "clear")
                Console.Clear();
            else
                Write($"WRONG!!! The right answer: {randomLetter.Key}({randomLetter.Value})", ConsoleColor.Red, true);

            WriteDashesLine();
        }
    }

    private static KeyValuePair<string, string> GetRangomLetter()
    {
        if (_currentAlphabet == Alphabet.Hiragana)
        {
            var randomIndex = new Random().Next(0, _hiraganaDictionary.Count);
            return _hiraganaDictionary.ElementAt(randomIndex);
        }

        var randomIndexFromKatakana = new Random().Next(0, _katakanaDictionary.Count);
        return _katakanaDictionary.ElementAt(randomIndexFromKatakana);
    }

    private static void ChooseAlphabet()
    {
        _currentAlphabet = Alphabet.None;

        while (_currentAlphabet == Alphabet.None)
        {
            Write("Choose alphabet: ", ConsoleColor.Green);
            Thread.Sleep(1000);
            Console.WriteLine("Hiragana: 1 or h");
            Console.WriteLine("Katakana: 2 or k");

            var keyChar = Console.ReadKey().KeyChar;

            _currentAlphabet =
                (keyChar == 'h' || keyChar == '1') ? Alphabet.Hiragana :
                (keyChar == 'k' || keyChar == '2') ? Alphabet.Katakana :
                Alphabet.None;
        }
    }

    private static void Write(string text, ConsoleColor color = ConsoleColor.White, bool withEnterAfter = false)
    {
        int consoleWidth = Console.WindowWidth;
        int textStartPosition = (consoleWidth - text.Length) / 2;
        string spaces = textStartPosition > 0 ? new string(' ', textStartPosition) : "";


        var defColor = Console.ForegroundColor;

        Console.ForegroundColor = color;
        Console.WriteLine(spaces + text);

        Console.ForegroundColor = defColor;

        if (withEnterAfter) Console.WriteLine("\n");
    }
    
    private static void WriteDashesLine(ConsoleColor color = ConsoleColor.White)
    {
        int consoleWidth = Console.WindowWidth;
        string dashes = consoleWidth > 2 ? new string('-', consoleWidth - 2) : null;

        if (dashes != null)
            Write(dashes, color);
    }
}
