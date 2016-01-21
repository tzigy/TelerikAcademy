namespace FilesAndFolder
{
	using System;
	using System.IO;

	public class Program
	{
		public static void Main()
		{
			string folderPath = @"C:\Windows";
			var root = new Folder(GetFolderName(folderPath));

			BuildTreeDFS(folderPath, root);

			long size = root.GetFolderSize();			

			Console.WriteLine("Size of all files in {0} is {1}", root.Name, size);
		}

		private static string GetFolderName(string path)
		{
			return new DirectoryInfo(path).Name;
		}

		private static void BuildTreeDFS(string folderPath, Folder root)
		{
			string[] files = Directory.GetFiles(folderPath);
			foreach (var file in files)
			{
				FileInfo currentFile = new FileInfo(file);				
                root.AddFile(new File(currentFile.Name, currentFile.Length));
			}

			try
			{
				string[] directories = Directory.GetDirectories(folderPath);
				foreach (var directory in directories)
				{
					DirectoryInfo currentDirectory = new DirectoryInfo(directory);
					var newDir = new Folder(currentDirectory.Name);

					BuildTreeDFS(directory, newDir);

					root.AddFolder(newDir);
				}
			}
			catch (UnauthorizedAccessException)
			{				
			}
		}		
	}
}
