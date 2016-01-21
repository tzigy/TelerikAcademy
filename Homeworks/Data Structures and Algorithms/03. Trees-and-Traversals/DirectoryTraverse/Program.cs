namespace DirectoryTraverser
{
	using System;
	using System.IO;

	public class Program
	{
		public static void Main()
		{
			FindAllExeFiles("C:\\Windows");
		}

		private static void TraverseDirectoryDFS(string path, string spaces)
		{
			spaces = spaces + "  ";
			try
			{
				PrintExeFilesFromDirectory(new DirectoryInfo(path), spaces);
				string[] directories = Directory.GetDirectories(path);

				foreach (var dir in directories)
				{
					TraverseDirectoryDFS(dir, spaces);
				}
			}
			catch (UnauthorizedAccessException)
			{

			}
		}

		private static void FindAllExeFiles(string directoryPath)
		{
			TraverseDirectoryDFS(directoryPath, string.Empty);
		}

		private static void PrintExeFilesFromDirectory(DirectoryInfo directory, string spaces)
		{
			FileInfo[] exeFiles = directory.GetFiles("*.exe");

			if (exeFiles.Length != 0)
			{
				Console.WriteLine(spaces + directory.FullName);
			}

			foreach (var file in exeFiles)
			{
				Console.WriteLine(spaces + "  " + file);
			}
		}

		//private static void PrintExeFilesFromDirectory(string path, string spaces)
		//{
		//	string[] exeFiles = Directory.GetFiles(path);

		//	//if (exeFiles.Length != 0)
		//	//{
		//	//	Console.WriteLine(spaces + path);
		//	//}

		//	foreach (var file in exeFiles)
		//	{
		//		if (file.EndsWith(".exe"))
		//		{
		//			Console.WriteLine(spaces + "  " + file);
		//		}

		//	}
		//}
	}
}
