using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PathVerifier {
    class Program {
        static void Main(string[] args) {
            string pathProvidedFiles = @"C:\Users\msbz\Desktop\Sharp_extracts\provided.txt";
            string pathMissedFiles = @"C:\Users\msbz\Desktop\Sharp_extracts\missed.txt";
            string pathResult = @"C:\Users\msbz\Desktop\Sharp_extracts\import_files_check.txt";

            List<string> fileLinesMissed = new List<string>();
            List<string> fileLinesProvided = new List<string>();
            List<string> fileNamesMissed = new List<string>();
            List<string> fileNamesProvided = new List<string>();

            fileLinesMissed = File.ReadAllLines(pathMissedFiles).ToList();

            foreach (var item in fileLinesMissed) {
                InputFile file = new InputFile(item);
                fileNamesMissed.Add(file.GetFileNameFormPath());
            }

            fileLinesProvided = File.ReadAllLines(pathProvidedFiles).ToList();

            foreach (var item in fileLinesProvided) {
                InputFile file = new InputFile(item);
                fileNamesProvided.Add(file.GetFileNameFormPath());
            }

            Dictionary<string, string> result = new Dictionary<string, string>();

            int Id = 0;

            for (int i = 0; i < fileNamesMissed.Count; i++) {
                int longestSeq = 0;
                string missedFile = "";
                string providedFile = "";

                for (int ii = 0; ii < fileLinesProvided.Count; ii++) {
                    int currentSeq = InputFile.LCS(fileNamesMissed[i].ToCharArray(), fileLinesProvided[ii].ToCharArray());
                    if (currentSeq > longestSeq) {
                        longestSeq = currentSeq;
                        missedFile = fileNamesMissed[i];
                        providedFile = fileLinesProvided[ii];
                    }
                    else if (currentSeq == longestSeq) {
                        missedFile = fileNamesMissed[i];
                        providedFile = providedFile + "; " + fileLinesProvided[ii];
                    }
                }
                result.Add(++Id + "." + missedFile, providedFile);
            }

            using (StreamWriter file = new StreamWriter(pathResult)) {
                foreach (var entry in result) {
                    file.WriteLine("{0}\t{1}", entry.Key, entry.Value);
                }
            }

            Console.WriteLine("Task complited.");

            /*
            string path = @"U:\UA_PC\Python_lab\CNP_pivot_2018_Prodfi_RC_FD.txt";
            InputFile file = new InputFile(path);
            string pathToFolder = file.GetPathWithoutFileName();
            string fileName = file.GetFileNameFormPath();
            bool isFolderExists = Directory.Exists(pathToFolder);
            Console.WriteLine(pathToFolder);
            Console.WriteLine(fileName);
            if (isFolderExists) {
                Console.WriteLine("File path is OK.");
            } else {
                Console.WriteLine("Dirictory doesn't exist or you haven't access to it.");
            }
            */
        }
    }
}
