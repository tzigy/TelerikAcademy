namespace ReadAndFindInTree
{
	using System;
	using System.Collections.Generic;

	public class Program
	{
		public static void Main()
		{
			TreeNode<int> node = new TreeNode<int>(2);
			TreeNode<int> node1 = new TreeNode<int>(4);
			node1.HasParent = true;
			node.AddChild(node1);
			Tree<int> tr = new Tree<int>(2);

		}
	}
}
