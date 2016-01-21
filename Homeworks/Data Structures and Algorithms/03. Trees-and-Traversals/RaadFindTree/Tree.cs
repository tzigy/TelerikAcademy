namespace ReadAndFindInTree
{
	public class Tree<T>
	{
		private TreeNode<T> root;
		

		public Tree(T value)
		{
			this.root = new TreeNode<T>(value);
		}

		public Tree(T value, params Tree<T>[] children)
			: this(value)
		{
			foreach (var child in children)
			{
				child.root.HasParent = true;
				this.root.AddChild(child.root);
			}
		}

		public TreeNode<T> Root { get { return this.root; } }


	}
}
