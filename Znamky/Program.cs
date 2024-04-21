namespace Znamky;

internal class Program {
    static void Main(string[] args) {
        /*Console.WriteLine("Vložte cestu k souboru .csv (Kopírovat jako cestu [Ctrl+Shift+C]:");
        string path = Console.ReadLine().Remove('"');*/
        string path = "D:\\Soutěžící\\Známky\\znamky.csv";

        // Cesta k souboru
        string[] fileContent = File.ReadAllLines(path);
        fileContent = fileContent.Skip(1).ToArray();

        List<string> nameList = new List<string>();
        List<string> subjectList = new List<string>();

        foreach (string line in fileContent) {
            string[] parts = line.Split(',');
            string name = parts[1];
            string subject = parts[2];


            if (!nameList.Contains(name))
                nameList.Add(name);

            if (!subjectList.Contains(subject))
                subjectList.Add(subject);
        }

        nameList.Sort();
        subjectList.Sort();

        // 2D pole pro známky - počet řádků je počet předmětů, počet sloupců je počet žáků
        float[,] grades = new float[subjectList.Count + 1, nameList.Count + 1];

        // Pole stejné velikosti jako grades, obsahuje počet známek - pro průměr
        int[,] gradesCount = new int[subjectList.Count, nameList.Count];

        // Nastavení všech hodnot na 0
        Array.Clear(grades, 0, grades.Length);

        // Přičtení známek
        foreach (string line in fileContent) {
            string[] parts = line.Split(',');
            string name = parts[1];
            string subject = parts[2];
            string grade = parts[3];

            grades[subjectList.IndexOf(subject), nameList.IndexOf(name)] += float.Parse(grade);
            gradesCount[subjectList.IndexOf(subject), nameList.IndexOf(name)] += 1;
        }

        // Zprůměrování známek podle počtu
        // i = řádek, j = sloupec
        for (int i = 0; i < grades.GetLength(0) - 2; i++) {
            for (int j = 0; j < grades.GetLength(1) - 2; j++) {
                grades[i, j] /= gradesCount[i, j];
                grades[i, j] = (float)Math.Round(grades[i, j], 2);
            }
        }

        // Průměry průměrů - studenti (řádky)
        for (int i = 0; i < grades.GetLength(0) - 2; i++) {
            float averageStudent = 0;
            for (int j = 0; j < grades.GetLength(1) - 2; j++) {
                averageStudent = grades[i, j];
            }
            averageStudent /= grades.GetLength(1) - 2;
            grades[i, grades.GetLength(1) - 1] = averageStudent;
        }

        // Průměry průměrů - předměty (sloupce)

        if (1==3) for (int i = 0; i < grades.GetLength(1) - 2; i++) {
            float averageSubject = 0;
            for (int j = 0; j < grades.GetLength(0) - 2; j++) {
                averageSubject = grades[i, j];
            }
            averageSubject /= grades.GetLength(0) - 2;
            grades[grades.GetLength(0) - 1, i] = averageSubject;
        }

        // Výpis do souboru
        using (StreamWriter sw = new StreamWriter($"{path.Split('.')[0]}-prumery{path.Split('.')[1]}"))
        {
            string line = "";

            // Vypsání hlavičky - předměty
            foreach (string subject in subjectList) {
                line += $",{subject}";
            }
            sw.WriteLine(line);

            for (int i = 0; i < grades.GetLength(1) - 1; i++) {
                line = $"{nameList[i]}";

                for (int j = 0; j < grades.GetLength(0) - 1; j++) {
                //    sw.WriteLine($",{grades[i, j]}");
                }

                sw.WriteLine(line);
            }

            sw.Close();
        }
    }
}
