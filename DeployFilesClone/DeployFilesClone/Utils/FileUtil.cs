using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployFilesClone.Utils
{
    public class FileUtil
    {
        public static void CopyDirectory(string sourceDirPath, string destDirPath)
        {
            if (!Directory.Exists(destDirPath))
            {
                Directory.CreateDirectory(destDirPath);

                File.SetAttributes(destDirPath,
                    File.GetAttributes(sourceDirPath));
            }

            string[] sourceFiles = Directory.GetFiles(sourceDirPath);
            foreach (string sourceFilePath in sourceFiles)
            {
                File.Copy(sourceFilePath, Path.Combine(destDirPath, Path.GetFileName(sourceFilePath)), true);
            }

            //sourceDirPathにあるディレクトリに対して、再帰的に実行
            string[] sourceDirs = Directory.GetDirectories(sourceDirPath);
            foreach (string sourceDir in sourceDirs)
            {
                CopyDirectory(sourceDir, Path.Combine(destDirPath, Path.GetFileName(sourceDir)));
            }
        }


        public static string[] ReadLineList(string filePath) => File.ReadAllLines(filePath);

        public static void ReplaceBatchId(string filePath, string[] lines, string replaceBatchIdStr, string batchId)
        {
            using (var sw = new StreamWriter(filePath))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    sw.WriteLine(line);
                    if (line.Contains(replaceBatchIdStr))
                    {
                        if (lines[i + 1].Contains("<value>"))
                        {
                            string value = lines[i + 1].Trim().Replace("<value>", "").Split('<')[0];
                            string replaceLine = lines[i + 1].Replace($"<value>{value}</value>", $"<value>{batchId}</value>");
                            sw.WriteLine(replaceLine);
                            i++;
                        }
                    }
                }
            }
        }
    }
}
