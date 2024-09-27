namespace Clase8.ejercicios
{
    class Lists
    {
        static Dictionary<Char, String> morse = new Dictionary<char, string>{
            {'A', ".-"},{'B', "-.."},{'C', "-.-."},{'D', "-.."},
            {'E', "."},{'F', "..-."},{'G', "--."},{'H', "...."},
            {'I', ".."},{'J', ".---"},{'K', "-.-"},{'L', ".-.."},
            {'M', "--"},{'N', "-."},{'O', "---"},{'P', ".--."},
            {'Q', "--.-"},{'R', ".-."},{'S', "..."},{'T', "-"},
            {'U', "..-"},{'V', "...-"},{'W', ".--"},{'X', "-..-"},
            {'Y', "-.--"},{'Z', "--.."},
        };

        public void AddFlavor(Dictionary<String, List<String>> person_flavors, String person, String flavor)
        {
            if (!person_flavors.ContainsKey(person))
            {
                person_flavors[person] = [flavor];
            }

            if (!person_flavors[person].Contains(flavor))
            {
                person_flavors[person].Add(flavor);
            }
        }

        public void MorseCode(String word)
        {
            String morseCode = "";

            foreach (Char c in word)
            {
                morseCode += morse[Char.ToUpper(c)] + " ";
            }

            Console.WriteLine(morseCode);
        }

        public void MorseToAlphabet(String morseCode)
        {
            List<String> codes = morseCode.Split(" ").ToList();
            String word = "";

            foreach (String code in codes)
            {
                foreach (Char key in morse.Keys)
                {
                    if (morse[key] == code)
                    {
                        word += key;
                        break;
                    }
                }
            }

            Console.WriteLine(word);
        }
    }
}