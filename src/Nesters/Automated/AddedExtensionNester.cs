using System.IO;
using EnvDTE;

namespace MadsKristensen.FileNesting
{
    internal class AddedExtensionNester : IFileNester
    {
        public NestingResult Nest(string fileName)
        {
            string trimmed = Path.GetFileNameWithoutExtension(fileName);
            ProjectItem item = FileNestingPackage.DTE.Solution.FindProjectItem(trimmed);

            if (item != null)
            {
                item.ProjectItems.AddFromFile(fileName);
                return NestingResult.StopProcessing;
            }

            return NestingResult.Continue;
        }


        public bool IsEnabled()
        {
            return FileNestingPackage.Options.EnableExtensionRule;
        }
    }
}
