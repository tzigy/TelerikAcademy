namespace FilesAndFolder
{
	using System.Collections.Generic;
	using System.Linq;

	public class Folder
	{
		private string name;
		private List<File> files;
		private List<Folder> childFolders;

		public Folder(string name)
		{
			this.Name = name;
			this.files = new List<File>();
			this.childFolders = new List<Folder>();
		}

		public string Name { get; set; }

		public List<File> Files { get; set; }

		public List<Folder> Folders { get; set; }

		public void AddFile(File file)
		{
			this.files.Add(file);
		}

		public void AddFolder(Folder folder)
		{
			this.childFolders.Add(folder);
		}

		public long GetFolderSize()
		{
			long sum = 0;

			sum = this.files.Sum(file => file.Size) + this.childFolders.Sum(folder => folder.GetFolderSize()); 

			return sum;
		}
		


	}
}
