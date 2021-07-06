using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeployFilesClone.Utils;

namespace DeployFilesClone.Sequences
{
    public class AnyBatchDeploySequence
    {
        public static void Sequence()
        {
            //1.Directory 内のファイルをコピーする
            string[] batchIdArray = Properties.Settings.Default.BatchIdArray.Split(',');
            foreach (string batchId in batchIdArray)
            {
                string distinationBatchDirPath = $"{Properties.Settings.Default.BatchDirPath}{batchId}";
                if (Directory.Exists(distinationBatchDirPath))
                {
                    Directory.Delete(distinationBatchDirPath, true);
                }
                FileUtil.CopyDirectory(Properties.Settings.Default.BatchDirPath, distinationBatchDirPath);

                //2.ファイル名をRenameする
                string[] batchRenameFileExtensionNameArray = Properties.Settings.Default.BatchRenameFileExtensionName.Split(',');
                string tmpExeFileName = string.Empty;
                foreach (string searchFileExtensionName in batchRenameFileExtensionNameArray)
                {
                    string tmpSearchFileExtensionName = string.Empty;
                    //コピー元のディレクトリにある検索したファイルをRename
                    if (searchFileExtensionName.Contains(".pdb"))
                    {
                        tmpSearchFileExtensionName = $"{tmpExeFileName}.pdb";
                    }
                    else
                    {
                        tmpSearchFileExtensionName = searchFileExtensionName;
                    }

                    string[] targetFiles = Directory.GetFiles(distinationBatchDirPath, tmpSearchFileExtensionName);
                    foreach (string targetFile in targetFiles)
                    {
                        string targetFileName = Path.GetFileNameWithoutExtension(targetFile);
                        string renamedFileName = $"{targetFileName.Split('.')[0]}{batchId}{searchFileExtensionName.Replace("*", "")}";
                        tmpExeFileName = targetFileName.Split('.')[0];
                        string renamedFilePath = Path.Combine(distinationBatchDirPath, renamedFileName);
                        File.Move(targetFile, renamedFilePath);
                    }
                }

                //3.ファイル内の所定の箇所を置換する
                string[] replaceTargetFiles = Directory.GetFiles(distinationBatchDirPath, "*.exe.config");
                foreach (string replaceTargetFile in replaceTargetFiles)
                {
                    string[] fileLines = FileUtil.ReadLineList(replaceTargetFile);
                    FileUtil.ReplaceBatchId(replaceTargetFile, fileLines, Properties.Settings.Default.ReplaceBeforeBatchIdString, batchId);
                }

            }
        }
    }
}
